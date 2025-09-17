namespace WindowsFormsApp1
{
    partial class PetEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.TextBox txtBreed;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBreed = new System.Windows.Forms.Label();
            this.txtBreed = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.lblQty = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.SuspendLayout();

            this.Text = "Pet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ClientSize = new System.Drawing.Size(360, 240);

            // Name
            this.lblName.Text = "Name";
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.txtName.Location = new System.Drawing.Point(120, 18);
            this.txtName.Size = new System.Drawing.Size(200, 22);

            // Breed
            this.lblBreed.Text = "Breed";
            this.lblBreed.Location = new System.Drawing.Point(20, 56);
            this.txtBreed.Location = new System.Drawing.Point(120, 54);
            this.txtBreed.Size = new System.Drawing.Size(200, 22);

            // Age
            this.lblAge.Text = "Age";
            this.lblAge.Location = new System.Drawing.Point(20, 92);
            this.numAge.Location = new System.Drawing.Point(120, 90);
            this.numAge.Maximum = 1000;

            // Quantity
            this.lblQty.Text = "Quantity";
            this.lblQty.Location = new System.Drawing.Point(20, 128);
            this.numQty.Location = new System.Drawing.Point(120, 126);
            this.numQty.Maximum = 1000000;

            // Buttons
            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(160, 170);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(245, 170);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblBreed);
            this.Controls.Add(this.txtBreed);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.ResumeLayout(false);
        }
    }
}


