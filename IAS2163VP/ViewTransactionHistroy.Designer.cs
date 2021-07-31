
namespace IAS2163VP
{
    partial class ViewTransactionHistroy
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
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.lblTitleNewAccForm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Location = new System.Drawing.Point(12, 93);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.Size = new System.Drawing.Size(1023, 345);
            this.dataGridViewHistory.TabIndex = 33;
            // 
            // lblTitleNewAccForm
            // 
            this.lblTitleNewAccForm.AutoSize = true;
            this.lblTitleNewAccForm.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleNewAccForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleNewAccForm.ForeColor = System.Drawing.Color.Teal;
            this.lblTitleNewAccForm.Location = new System.Drawing.Point(313, 18);
            this.lblTitleNewAccForm.Name = "lblTitleNewAccForm";
            this.lblTitleNewAccForm.Size = new System.Drawing.Size(269, 31);
            this.lblTitleNewAccForm.TabIndex = 34;
            this.lblTitleNewAccForm.Text = "Transaction History";
            // 
            // ViewTransactionHistroy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 450);
            this.Controls.Add(this.lblTitleNewAccForm);
            this.Controls.Add(this.dataGridViewHistory);
            this.Name = "ViewTransactionHistroy";
            this.Text = "ViewTransactionHistroy";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Label lblTitleNewAccForm;
    }
}