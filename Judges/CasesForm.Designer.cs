using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class CasesForm
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
            dataGridViewCases = new DataGridView();
            buttonAddCase = new MaterialButton();
            dataGridViewHearings = new DataGridView();
            buttonAddHearing = new MaterialButton();
            buttonEditHearing = new MaterialButton();
            buttonDeleteHearing = new MaterialButton();
            labelTitle = new MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHearings).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCases
            // 
            dataGridViewCases.AllowUserToAddRows = false;
            dataGridViewCases.AllowUserToDeleteRows = false;
            dataGridViewCases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCases.Location = new Point(19, 100);
            dataGridViewCases.Name = "dataGridViewCases";
            dataGridViewCases.ReadOnly = true;
            dataGridViewCases.RowHeadersWidth = 62;
            dataGridViewCases.Size = new Size(1050, 430);
            dataGridViewCases.TabIndex = 1;
            dataGridViewCases.CellClick += dataGridViewCases_CellClick;
            // 
            // buttonAddCase
            // 
            buttonAddCase.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAddCase.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonAddCase.Depth = 0;
            buttonAddCase.HighEmphasis = true;
            buttonAddCase.Icon = null;
            buttonAddCase.Location = new Point(19, 548);
            buttonAddCase.Margin = new Padding(4, 6, 4, 6);
            buttonAddCase.MouseState = MouseState.HOVER;
            buttonAddCase.Name = "buttonAddCase";
            buttonAddCase.NoAccentTextColor = Color.Empty;
            buttonAddCase.Size = new Size(196, 36);
            buttonAddCase.TabIndex = 2;
            buttonAddCase.Text = "Добавить новое дело";
            buttonAddCase.Type = MaterialButton.MaterialButtonType.Contained;
            buttonAddCase.UseAccentColor = false;
            buttonAddCase.UseVisualStyleBackColor = true;
            buttonAddCase.Click += buttonAddCase_Click;
            // 
            // dataGridViewHearings
            // 
            dataGridViewHearings.AllowUserToAddRows = false;
            dataGridViewHearings.AllowUserToDeleteRows = false;
            dataGridViewHearings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHearings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHearings.Location = new Point(19, 593);
            dataGridViewHearings.Name = "dataGridViewHearings";
            dataGridViewHearings.ReadOnly = true;
            dataGridViewHearings.Size = new Size(1050, 180);
            dataGridViewHearings.TabIndex = 3;
            dataGridViewHearings.CellClick += dataGridViewHearings_CellClick;
            // 
            // buttonAddHearing
            // 
            buttonAddHearing.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAddHearing.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonAddHearing.Depth = 0;
            buttonAddHearing.HighEmphasis = true;
            buttonAddHearing.Icon = null;
            buttonAddHearing.Location = new Point(260, 548);
            buttonAddHearing.Margin = new Padding(4, 6, 4, 6);
            buttonAddHearing.MouseState = MouseState.HOVER;
            buttonAddHearing.Name = "buttonAddHearing";
            buttonAddHearing.NoAccentTextColor = Color.Empty;
            buttonAddHearing.Size = new Size(186, 36);
            buttonAddHearing.TabIndex = 4;
            buttonAddHearing.Text = "Добавить слушание";
            buttonAddHearing.Type = MaterialButton.MaterialButtonType.Contained;
            buttonAddHearing.UseAccentColor = false;
            buttonAddHearing.UseVisualStyleBackColor = true;
            buttonAddHearing.Click += buttonAddHearing_Click;
            // 
            // buttonEditHearing
            // 
            buttonEditHearing.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEditHearing.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonEditHearing.Depth = 0;
            buttonEditHearing.HighEmphasis = true;
            buttonEditHearing.Icon = null;
            buttonEditHearing.Location = new Point(492, 548);
            buttonEditHearing.Margin = new Padding(4, 6, 4, 6);
            buttonEditHearing.MouseState = MouseState.HOVER;
            buttonEditHearing.Name = "buttonEditHearing";
            buttonEditHearing.NoAccentTextColor = Color.Empty;
            buttonEditHearing.Size = new Size(188, 36);
            buttonEditHearing.TabIndex = 5;
            buttonEditHearing.Text = "Изменить слушание";
            buttonEditHearing.Type = MaterialButton.MaterialButtonType.Contained;
            buttonEditHearing.UseAccentColor = false;
            buttonEditHearing.UseVisualStyleBackColor = true;
            buttonEditHearing.Click += buttonEditHearing_Click;
            // 
            // buttonDeleteHearing
            // 
            buttonDeleteHearing.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonDeleteHearing.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonDeleteHearing.Depth = 0;
            buttonDeleteHearing.HighEmphasis = true;
            buttonDeleteHearing.Icon = null;
            buttonDeleteHearing.Location = new Point(720, 548);
            buttonDeleteHearing.Margin = new Padding(4, 6, 4, 6);
            buttonDeleteHearing.MouseState = MouseState.HOVER;
            buttonDeleteHearing.Name = "buttonDeleteHearing";
            buttonDeleteHearing.NoAccentTextColor = Color.Empty;
            buttonDeleteHearing.Size = new Size(177, 36);
            buttonDeleteHearing.TabIndex = 6;
            buttonDeleteHearing.Text = "Удалить слушание";
            buttonDeleteHearing.Type = MaterialButton.MaterialButtonType.Contained;
            buttonDeleteHearing.UseAccentColor = false;
            buttonDeleteHearing.UseVisualStyleBackColor = true;
            buttonDeleteHearing.Click += buttonDeleteHearing_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Depth = 0;
            labelTitle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTitle.Location = new Point(19, 78);
            labelTitle.MouseState = MouseState.HOVER;
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(78, 19);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Дела суда";
            // 
            // CasesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 790);
            Controls.Add(buttonAddHearing);
            Controls.Add(buttonEditHearing);
            Controls.Add(buttonDeleteHearing);
            Controls.Add(dataGridViewHearings);
            Controls.Add(buttonAddCase);
            Controls.Add(dataGridViewCases);
            Controls.Add(labelTitle);
            Name = "CasesForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Дела суда";
            Load += CasesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHearings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridView dataGridViewCases;
        private MaterialButton buttonAddCase;
        private DataGridView dataGridViewHearings;
        private MaterialButton buttonAddHearing;
        private MaterialButton buttonEditHearing;
        private MaterialButton buttonDeleteHearing;
        private MaterialLabel labelTitle;
    }
}
