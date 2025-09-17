using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PetEditForm : Form
    {
        private readonly int? _petId;
        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public PetEditForm(int? petId)
        {
            InitializeComponent();
            _petId = petId;
            if (_petId.HasValue) LoadPet();
        }

        private void LoadPet()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM Pet_list WHERE PetID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _petId.Value);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                txtName.Text = Convert.ToString(r["Name"] ?? r["PetName"]);
                                txtBreed.Text = Convert.ToString(r["Breed"]);
                                numAge.Value = SafeInt(r["Age"]);
                                numQty.Value = SafeInt(r["Quantity"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pet: " + ex.Message);
            }
        }

        private int SafeInt(object o)
        {
            int v; return int.TryParse(Convert.ToString(o), out v) ? v : 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    if (_petId.HasValue)
                    {
                        using (var cmd = new SqlCommand("UPDATE Pet_list SET Name=@n, Breed=@b, Age=@a, Quantity=@q WHERE PetID=@id", conn))
                        {
                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
                            cmd.Parameters.AddWithValue("@id", _petId.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var cmd = new SqlCommand("INSERT INTO Pet_list(Name, Breed, Age, Quantity) VALUES(@n,@b,@a,@q)", conn))
                        {
                            cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@b", txtBreed.Text.Trim());
                            cmd.Parameters.AddWithValue("@a", (int)numAge.Value);
                            cmd.Parameters.AddWithValue("@q", (int)numQty.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}


