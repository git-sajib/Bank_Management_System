
namespace IAS2163VP
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CreateNewAccountBtn = new System.Windows.Forms.Button();
            this.TransactionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 402);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CreateNewAccountBtn
            // 
            this.CreateNewAccountBtn.Location = new System.Drawing.Point(198, 35);
            this.CreateNewAccountBtn.Name = "CreateNewAccountBtn";
            this.CreateNewAccountBtn.Size = new System.Drawing.Size(270, 54);
            this.CreateNewAccountBtn.TabIndex = 1;
            this.CreateNewAccountBtn.Text = "Open A banck Account";
            this.CreateNewAccountBtn.UseVisualStyleBackColor = true;
            this.CreateNewAccountBtn.Click += new System.EventHandler(this.CreateNewAccountBtn_Click);
            // 
            // TransactionBtn
            // 
            this.TransactionBtn.Location = new System.Drawing.Point(198, 135);
            this.TransactionBtn.Name = "TransactionBtn";
            this.TransactionBtn.Size = new System.Drawing.Size(270, 54);
            this.TransactionBtn.TabIndex = 2;
            this.TransactionBtn.Text = "Transaction";
            this.TransactionBtn.UseVisualStyleBackColor = true;
            this.TransactionBtn.Click += new System.EventHandler(this.TransactionBtn_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(572, 402);
            this.Controls.Add(this.TransactionBtn);
            this.Controls.Add(this.CreateNewAccountBtn);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Page";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateNewAccountBtn;
        private System.Windows.Forms.Button TransactionBtn;
    }
}