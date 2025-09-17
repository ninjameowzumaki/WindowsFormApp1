using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private string fullName;

        public Login()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ----- Admin login -----
            if (username == "admin" && password == "admin")
            {
                Admin a = new Admin();
                a.Show();
                this.Hide();
                return;
            }

            string connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // ----- User login -----
                    string userQuery = @"
                SELECT UserID, FullName, Status 
                FROM Users 
                WHERE LTRIM(RTRIM(Username)) = LTRIM(RTRIM(@Username)) 
                  AND LTRIM(RTRIM(Password)) = LTRIM(RTRIM(@Password))";

                    using (SqlCommand cmd = new SqlCommand(userQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status = reader["Status"].ToString();
                                if (status.Equals("Blocked", StringComparison.OrdinalIgnoreCase))
                                {
                                    MessageBox.Show("Your account is blocked.", "Login Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                int userId = Convert.ToInt32(reader["UserID"]);
                                string fullName = reader["FullName"].ToString();

                                customerDashboard dashboard = new customerDashboard(userId, fullName);
                                dashboard.Show();
                                this.Hide();
                                return;
                            }
                        }
                    }

                    // ----- Vendor login -----
                    string vendorQuery = @"
                SELECT VendorID, FullName, Status 
                FROM Vendors 
                WHERE LTRIM(RTRIM(Username)) = LTRIM(RTRIM(@Username)) 
                  AND LTRIM(RTRIM(Password)) = LTRIM(RTRIM(@Password))";

                    using (SqlCommand cmd = new SqlCommand(vendorQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status = reader["Status"].ToString();
                                if (status.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                                {
                                    int vendorId = Convert.ToInt32(reader["VendorID"]);
                                    string vFullName = reader["FullName"].ToString();

                                    VendorDashboard dashboard = new VendorDashboard(vendorId, vFullName);
                                    dashboard.Show();
                                    this.Hide();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Your vendor account is not approved yet.", "Access Denied",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }

                    // If neither user nor vendor found
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            role a = new role();
            a.Show();
            this.Hide();
        }
    }
}
