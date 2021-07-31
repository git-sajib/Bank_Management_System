
namespace IAS2163VP
{
    partial class ViewAccountHistory
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
            this.lblTitleNewAccForm = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblUserBalance = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.TxtAccountNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.lblUserAccountNumber = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitleNewAccForm
            // 
            this.lblTitleNewAccForm.AutoSize = true;
            this.lblTitleNewAccForm.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleNewAccForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleNewAccForm.ForeColor = System.Drawing.Color.Teal;
            this.lblTitleNewAccForm.Location = new System.Drawing.Point(381, 9);
            this.lblTitleNewAccForm.Name = "lblTitleNewAccForm";
            this.lblTitleNewAccForm.Size = new System.Drawing.Size(312, 31);
            this.lblTitleNewAccForm.TabIndex = 30;
            this.lblTitleNewAccForm.Text = "Account History Check";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblUserAccountNumber);
            this.panel4.Controls.Add(this.lblUserBalance);
            this.panel4.Controls.Add(this.lblUserName);
            this.panel4.Controls.Add(this.CheckBtn);
            this.panel4.Controls.Add(this.lblAccountNumber);
            this.panel4.Controls.Add(this.TxtAccountNumber);
            this.panel4.Location = new System.Drawing.Point(2, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1088, 100);
            this.panel4.TabIndex = 31;
            // 
            // lblUserBalance
            // 
            this.lblUserBalance.AutoSize = true;
            this.lblUserBalance.BackColor = System.Drawing.Color.Transparent;
            this.lblUserBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserBalance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUserBalance.Location = new System.Drawing.Point(498, 67);
            this.lblUserBalance.Name = "lblUserBalance";
            this.lblUserBalance.Size = new System.Drawing.Size(74, 20);
            this.lblUserBalance.TabIndex = 25;
            this.lblUserBalance.Text = "Balance";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUserName.Location = new System.Drawing.Point(517, 11);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 20);
            this.lblUserName.TabIndex = 25;
            this.lblUserName.Text = "Name";
            // 
            // CheckBtn
            // 
            this.CheckBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CheckBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CheckBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CheckBtn.FlatAppearance.BorderSize = 5;
            this.CheckBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.CheckBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Cyan;
            this.CheckBtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.CheckBtn.Location = new System.Drawing.Point(268, 43);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(96, 31);
            this.CheckBtn.TabIndex = 24;
            this.CheckBtn.Text = "Check";
            this.CheckBtn.UseVisualStyleBackColor = false;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblAccountNumber.Location = new System.Drawing.Point(40, 27);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(121, 16);
            this.lblAccountNumber.TabIndex = 14;
            this.lblAccountNumber.Text = "Account Number";
            // 
            // TxtAccountNumber
            // 
            this.TxtAccountNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAccountNumber.Location = new System.Drawing.Point(43, 46);
            this.TxtAccountNumber.Name = "TxtAccountNumber";
            this.TxtAccountNumber.Size = new System.Drawing.Size(197, 26);
            this.TxtAccountNumber.TabIndex = 19;
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Location = new System.Drawing.Point(2, 172);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.Size = new System.Drawing.Size(1088, 274);
            this.dataGridViewHistory.TabIndex = 32;
            // 
            // lblUserAccountNumber
            // 
            this.lblUserAccountNumber.AutoSize = true;
            this.lblUserAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblUserAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAccountNumber.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUserAccountNumber.Location = new System.Drawing.Point(517, 43);
            this.lblUserAccountNumber.Name = "lblUserAccountNumber";
            this.lblUserAccountNumber.Size = new System.Drawing.Size(55, 20);
            this.lblUserAccountNumber.TabIndex = 26;
            this.lblUserAccountNumber.Text = "Name";
            // 
            // ViewAccountHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 450);
            this.Controls.Add(this.dataGridViewHistory);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblTitleNewAccForm);
            this.Name = "ViewAccountHistory";
            this.Text = "ViewAccountHistory";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleNewAccForm;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblUserBalance;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.TextBox TxtAccountNumber;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Label lblUserAccountNumber;
    }
}