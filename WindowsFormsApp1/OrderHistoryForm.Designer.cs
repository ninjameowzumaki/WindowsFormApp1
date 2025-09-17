namespace WindowsFormsApp1
{
    partial class OrderHistoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2GradientPanel topPanel;
        private Guna.UI2.WinForms.Guna2Panel contentPanel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnMaximize;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2DragControl dragControl;

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lblOrderCount;
        private Guna.UI2.WinForms.Guna2Button btnViewDetails;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnCloseForm;

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
            this.components = new System.ComponentModel.Container();
            this.topPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();

            this.contentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.btnViewDetails = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseForm = new Guna.UI2.WinForms.Guna2Button();
            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);

            this.SuspendLayout();

            // ===== Form Settings =====
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order History";
            this.MinimumSize = new System.Drawing.Size(800, 500);

            // ===== Top Panel =====
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.FillColor = System.Drawing.Color.White;
            this.topPanel.FillColor2 = System.Drawing.Color.White;
            this.topPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.topPanel.Size = new System.Drawing.Size(1000, 60);
            this.topPanel.ShadowDecoration.Enabled = true;
            this.topPanel.ShadowDecoration.Color = System.Drawing.Color.FromArgb(0, 0, 0, 10);

            // ===== Title Label =====
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "📋 Order History";

            // ===== Control Boxes =====
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.IconColor = System.Drawing.Color.Black;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 230, 230);

            this.btnMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.FillColor = System.Drawing.Color.Transparent;
            this.btnMaximize.IconColor = System.Drawing.Color.Black;
            this.btnMaximize.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 230, 230);

            this.btnClose.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.CloseBox;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnClose.IconColor = System.Drawing.Color.Black;

            // Add controls to topPanel
            this.topPanel.Controls.Add(this.btnClose);
            this.topPanel.Controls.Add(this.btnMaximize);
            this.topPanel.Controls.Add(this.btnMinimize);
            this.topPanel.Controls.Add(this.lblTitle);

            // ===== Content Panel =====
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.FillColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.contentPanel.ShadowDecoration.Enabled = false;
            this.contentPanel.Padding = new System.Windows.Forms.Padding(20);

            // ===== Order Count Label =====
            this.lblOrderCount.AutoSize = true;
            this.lblOrderCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblOrderCount.ForeColor = System.Drawing.Color.Black;
            this.lblOrderCount.Location = new System.Drawing.Point(20, 20);
            this.lblOrderCount.Text = "Total Orders: 0";

            // ===== Data Grid View =====
            this.dgvOrders.Location = new System.Drawing.Point(20, 60);
            this.dgvOrders.Size = new System.Drawing.Size(940, 500);
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                        | System.Windows.Forms.AnchorStyles.Left) 
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOrders.ColumnHeadersHeight = 40;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(222, 226, 230);
            this.dgvOrders.RowTemplate.Height = 40;
            this.dgvOrders.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.dgvOrders.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvOrders.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);

            // ===== Buttons =====
            this.btnViewDetails.BorderRadius = 8;
            this.btnViewDetails.Text = "👁️ View Details";
            this.btnViewDetails.Size = new System.Drawing.Size(140, 40);
            this.btnViewDetails.Location = new System.Drawing.Point(20, 580);
            this.btnViewDetails.FillColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);

            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.Location = new System.Drawing.Point(180, 580);
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnCloseForm.BorderRadius = 8;
            this.btnCloseForm.Text = "❌ Close";
            this.btnCloseForm.Size = new System.Drawing.Size(100, 40);
            this.btnCloseForm.Location = new System.Drawing.Point(320, 580);
            this.btnCloseForm.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnCloseForm.ForeColor = System.Drawing.Color.White;
            this.btnCloseForm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseForm.Click += new System.EventHandler(this.btnClose_Click);

            // Add controls to content panel
            this.contentPanel.Controls.Add(this.lblOrderCount);
            this.contentPanel.Controls.Add(this.dgvOrders);
            this.contentPanel.Controls.Add(this.btnViewDetails);
            this.contentPanel.Controls.Add(this.btnRefresh);
            this.contentPanel.Controls.Add(this.btnCloseForm);

            // ===== Drag Control =====
            this.dragControl.TargetControl = this.topPanel;
            this.dragControl.DockIndicatorTransparencyValue = 0.6D;
            this.dragControl.UseTransparentDrag = true;

            // ===== Add panels to form =====
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.topPanel);

            this.ResumeLayout(false);
        }
    }
}
