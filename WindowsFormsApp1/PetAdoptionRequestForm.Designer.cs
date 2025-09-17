namespace WindowsFormsApp1
{
    public partial class PetAdoptionRequestForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbPets;
        private System.Windows.Forms.Label lblPet;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnSubmit;
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbPets = new System.Windows.Forms.ComboBox();
            this.lblPet = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PetAdoptionRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 320);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pet Adoption";

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Request Pet for Adoption";

            // lblPet
            this.lblPet.AutoSize = true;
            this.lblPet.Location = new System.Drawing.Point(22, 70);
            this.lblPet.Text = "Select Pet";

            // cmbPets
            this.cmbPets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPets.Location = new System.Drawing.Point(110, 66);
            this.cmbPets.Size = new System.Drawing.Size(370, 24);

            // lblNotes
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(22, 110);
            this.lblNotes.Text = "Notes";

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(110, 106);
            this.txtNotes.Multiline = true;
            this.txtNotes.Size = new System.Drawing.Size(370, 120);

            // btnSubmit
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(290, 250);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(390, 250);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPet);
            this.Controls.Add(this.cmbPets);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


