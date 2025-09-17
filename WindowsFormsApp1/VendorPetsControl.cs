using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class VendorPetsControl : UserControl
    {
        private readonly string _username;
        private readonly string _connectionString = @"Data Source=.;Initial Catalog=Pet_Shop;Integrated Security=True";

        public VendorPetsControl(string username)
        {
            InitializeComponent();
            _username = username ?? string.Empty;
            LoadAllPets();
        }

        private void LoadAllPets()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("SELECT * FROM Pet_list", conn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        grid.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pets: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadAllPets();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PetEditForm(null))
            {
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadAllPets();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) { MessageBox.Show("Select a pet first."); return; }
            int petId = Convert.ToInt32((grid.CurrentRow.DataBoundItem as DataRowView)["PetID"]);
            using (var form = new PetEditForm(petId))
            {
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadAllPets();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) { MessageBox.Show("Select a pet first."); return; }
            int petId = Convert.ToInt32((grid.CurrentRow.DataBoundItem as DataRowView)["PetID"]);
            if (MessageBox.Show("Delete this pet?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("DELETE FROM Pet_list WHERE PetID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", petId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadAllPets();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting pet: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


