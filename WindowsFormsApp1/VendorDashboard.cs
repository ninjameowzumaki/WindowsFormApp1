using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VendorDashboard : Form
    {
        private string _username;

        public VendorDashboard(int vendorId, string username)
        {
            InitializeComponent();
            Theme.Apply(this);
            _username = username ?? string.Empty;
            lblWelcome.Text = $"Welcome, {_username}";
        }

        // Navigation button handlers (wired in Designer)
        private void btnProducts_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Products";
            contentPanel.Controls.Clear();
            ProductsManagement productsManagement = new ProductsManagement(_username);
            productsManagement.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(productsManagement);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Orders";
            contentPanel.Controls.Clear();
            var control = new VendorOrdersControl(_username);
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void btnManagePets_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Manage Pets";
            contentPanel.Controls.Clear();
            var control = new VendorPetsControl(_username);
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Profile - {_username}";
            using (var form = new VendorProfileForm(_username))
            {
                form.ShowDialog(this);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new Login().Show();
            Hide();
        }

        private void btnAdoptionRequests_Click(object sender, EventArgs e)
        {
            lblWelcome.Text = "Adoption Requests";
            contentPanel.Controls.Clear();
            var control = new VendorAdoptionRequestsControl(_username);
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
        }
    }
}


