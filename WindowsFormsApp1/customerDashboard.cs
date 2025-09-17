using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class customerDashboard : Form
    {
        private int _userId;
        private string _fullName;
        private List<ProductView> _allProducts = new List<ProductView>();
        private ShoppingCartManager _cartManager;
        private string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        // Constructor receives user info
        public customerDashboard(int userId, string fullName)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
            _cartManager = new ShoppingCartManager();
            Theme.Apply(this);

            this.Load += CustomerDashboard_Load;
        }

        // Form Load event → set welcome label and dashboard values
        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_fullName}";
            LoadProductsFromDatabase();
            LoadCategories();
            BindGrid();
            UpdateCartDisplay();
        }

        // Logout button click
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            // Optionally: navigate back to login form
            // new Login().Show();
        }

        // Side menu navigation (future)
        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadProductsFromDatabase();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                // Open Order History Form
                OrderHistoryForm orderHistoryForm = new OrderHistoryForm(_userId);
                orderHistoryForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening order history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var profile = new CustomerProfileForm(_userId))
                {
                    profile.ShowDialog(this);
                    // Refresh any data that might be displayed on dashboard (e.g., cart summary)
                    UpdateCartDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new PetAdoptionRequestForm(_userId))
                {
                    form.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening adoption: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            if (cbCategory == null || dgvItems == null) return;
            string category = (cbCategory.SelectedItem as string) ?? "All";
            string query = (txtSearch?.Text ?? string.Empty).Trim().ToLowerInvariant();

            var filtered = _allProducts;
            if (category != "All")
            {
                filtered = filtered.FindAll(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(query))
            {
                filtered = filtered.FindAll(p => p.ProductName.ToLowerInvariant().Contains(query) || 
                                               p.Description.ToLowerInvariant().Contains(query) ||
                                               p.VendorName.ToLowerInvariant().Contains(query));
            }

            dgvItems.DataSource = null;
            dgvItems.DataSource = filtered;
        }

        private void LoadProductsFromDatabase()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.ProductID,
                            p.ProductName,
                            p.Description,
                            p.Price,
                            p.StockQuantity,
                            p.DiscountPercentage,
                            p.Category,
                            v.Username AS VendorName,
                            CASE 
                                WHEN p.DiscountPercentage > 0 
                                THEN p.Price - (p.Price * p.DiscountPercentage / 100)
                                ELSE p.Price 
                            END AS DiscountedPrice
                        FROM Products p
                        INNER JOIN Vendors v ON p.VendorID = v.VendorID
                        WHERE p.IsActive = 1 AND p.StockQuantity > 0
                        ORDER BY p.ProductName";
                    //If a discount exists (p.DiscountPercentage > 0), it calculates the discounted price.
                    //Formula → Price - (Price * DiscountPercentage / 100)

                    //If no discount, it just returns the original Price.

                    //The result is given an alias: DiscountedPrice.


                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            _allProducts.Clear();
                            while (reader.Read())
                            {
                                _allProducts.Add(new ProductView
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductName = reader["ProductName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                                    DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"]),
                                    Category = reader["Category"].ToString(),
                                    VendorName = reader["VendorName"].ToString(),
                                    DiscountedPrice = Convert.ToDecimal(reader["DiscountedPrice"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = new List<string> { "All" };
                categories.AddRange(_allProducts.Select(p => p.Category).Distinct().OrderBy(c => c));
                
                cbCategory.Items.Clear();
                cbCategory.Items.AddRange(categories.ToArray());
                cbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartDisplay()
        {
            try
            {
                var (itemCount, totalAmount) = _cartManager.GetCartTotal(_userId);
                lblCartInfo.Text = $"Cart: {itemCount} items - ${totalAmount:F2}";
            }
            catch (Exception ex)
            {
                lblCartInfo.Text = "Cart: Error loading";
            }
        }

        private void ShowCartAndCheckout()
        {
            try
            {
                var cartItems = _cartManager.GetCartItems(_userId);
                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Your cart is empty. Add some products first!", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var totalAmount = cartItems.Sum(item => item.TotalPrice);
                var checkoutForm = new CheckoutForm(_userId, cartItems, totalAmount);
                
                if (checkoutForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateCartDisplay();
                    MessageBox.Show("Order placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing cart: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToCart(int productId)
        {
            try
            {
                // Find the product to get its name for better feedback
                var product = _allProducts.FirstOrDefault(p => p.ProductID == productId);
                string productName = product?.ProductName ?? "Product";

                bool success = _cartManager.AddToCart(_userId, productId, 1);
                if (success)
                {
                    UpdateCartDisplay();
                    
                    // Show a more attractive success message
                    var result = MessageBox.Show(
                        $"✅ {productName} has been added to your cart!\n\nWould you like to view your cart now?", 
                        "Added to Cart", 
                        MessageBoxButtons.YesNo, 
                        MessageBoxIcon.Information
                    );
                    
                    if (result == DialogResult.Yes)
                    {
                        ShowCartAndCheckout();
                    }
                }
                else
                {
                    MessageBox.Show($"❌ Failed to add {productName} to cart.\n\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error adding to cart:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var product = dgvItems.Rows[e.RowIndex].DataBoundItem as ProductView;
                if (product != null)
                {
                    AddToCart(product.ProductID);
                }
            }
        }

        private void btnViewCart_Click(object sender, EventArgs e)
        {
            ShowCartAndCheckout();
        }


        public class ProductView
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
            public decimal DiscountPercentage { get; set; }
            public string Category { get; set; }
            public string VendorName { get; set; }
            public decimal DiscountedPrice { get; set; }
        }
    }
}
