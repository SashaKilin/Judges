using MaterialSkin;
using MaterialSkin.Controls;

namespace Judges
{
    partial class CaseArchiveForm
    {
        private System.ComponentModel.IContainer components = null;

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
            dataGridViewArchive = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArchive).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewArchive
            // 
            dataGridViewArchive.AllowUserToAddRows = false;
            dataGridViewArchive.AllowUserToDeleteRows = false;
            dataGridViewArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArchive.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArchive.Location = new Point(6, 67);
            dataGridViewArchive.Name = "dataGridViewArchive";
            dataGridViewArchive.ReadOnly = true;
            dataGridViewArchive.RowHeadersWidth = 62;
            dataGridViewArchive.Size = new Size(1126, 537);
            dataGridViewArchive.TabIndex = 0;
            // 
            // CaseArchiveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 610);
            Controls.Add(dataGridViewArchive);
            Name = "CaseArchiveForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Архив дел";
            Load += CaseArchiveForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewArchive).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridViewArchive;
    }
}
