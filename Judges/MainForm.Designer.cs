using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class MainForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new MaterialLabel();
            labelName = new MaterialLabel();
            textBoxName = new MaterialTextBox();
            labelAddress = new MaterialLabel();
            textBoxAddress = new MaterialTextBox();
            labelType = new MaterialLabel();
            textBoxType = new MaterialTextBox();
            buttonAddCourt = new MaterialButton();
            dataGridViewCourts = new DataGridView();
            labelJudges = new MaterialLabel();
            dataGridViewJudges = new DataGridView();
            buttonAddJudge = new MaterialButton();
            buttonOpenCases = new MaterialButton();
            progressBarLoading = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewJudges).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(13, 86);
            label1.MouseState = MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(187, 19);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать, User!";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Depth = 0;
            labelName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelName.Location = new Point(13, 115);
            labelName.Margin = new Padding(2, 0, 2, 0);
            labelName.MouseState = MouseState.HOVER;
            labelName.Name = "labelName";
            labelName.Size = new Size(73, 19);
            labelName.TabIndex = 1;
            labelName.Text = "Название";
            // 
            // textBoxName
            // 
            textBoxName.AnimateReadOnly = false;
            textBoxName.BorderStyle = BorderStyle.None;
            textBoxName.Depth = 0;
            textBoxName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxName.LeadingIcon = null;
            textBoxName.Location = new Point(13, 143);
            textBoxName.Margin = new Padding(2);
            textBoxName.MaxLength = 50;
            textBoxName.MouseState = MouseState.OUT;
            textBoxName.Multiline = false;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(165, 50);
            textBoxName.TabIndex = 2;
            textBoxName.Text = "";
            textBoxName.TrailingIcon = null;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Depth = 0;
            labelAddress.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelAddress.Location = new Point(189, 115);
            labelAddress.Margin = new Padding(2, 0, 2, 0);
            labelAddress.MouseState = MouseState.HOVER;
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(46, 19);
            labelAddress.TabIndex = 3;
            labelAddress.Text = "Адрес";
            // 
            // textBoxAddress
            // 
            textBoxAddress.AnimateReadOnly = false;
            textBoxAddress.BorderStyle = BorderStyle.None;
            textBoxAddress.Depth = 0;
            textBoxAddress.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxAddress.LeadingIcon = null;
            textBoxAddress.Location = new Point(189, 143);
            textBoxAddress.Margin = new Padding(2);
            textBoxAddress.MaxLength = 50;
            textBoxAddress.MouseState = MouseState.OUT;
            textBoxAddress.Multiline = false;
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(215, 50);
            textBoxAddress.TabIndex = 4;
            textBoxAddress.Text = "";
            textBoxAddress.TrailingIcon = null;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Depth = 0;
            labelType.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelType.Location = new Point(416, 115);
            labelType.Margin = new Padding(2, 0, 2, 0);
            labelType.MouseState = MouseState.HOVER;
            labelType.Name = "labelType";
            labelType.Size = new Size(68, 19);
            labelType.TabIndex = 5;
            labelType.Text = "Тип суда";
            // 
            // textBoxType
            // 
            textBoxType.AnimateReadOnly = false;
            textBoxType.BorderStyle = BorderStyle.None;
            textBoxType.Depth = 0;
            textBoxType.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxType.LeadingIcon = null;
            textBoxType.Location = new Point(416, 143);
            textBoxType.Margin = new Padding(2);
            textBoxType.MaxLength = 50;
            textBoxType.MouseState = MouseState.OUT;
            textBoxType.Multiline = false;
            textBoxType.Name = "textBoxType";
            textBoxType.Size = new Size(150, 50);
            textBoxType.TabIndex = 6;
            textBoxType.Text = "";
            textBoxType.TrailingIcon = null;
            // 
            // buttonAddCourt
            // 
            buttonAddCourt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAddCourt.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonAddCourt.Depth = 0;
            buttonAddCourt.HighEmphasis = true;
            buttonAddCourt.Icon = null;
            buttonAddCourt.Location = new Point(592, 115);
            buttonAddCourt.Margin = new Padding(2, 3, 2, 3);
            buttonAddCourt.MouseState = MouseState.HOVER;
            buttonAddCourt.Name = "buttonAddCourt";
            buttonAddCourt.NoAccentTextColor = Color.Empty;
            buttonAddCourt.Size = new Size(133, 36);
            buttonAddCourt.TabIndex = 7;
            buttonAddCourt.Text = "Добавить суд";
            buttonAddCourt.Type = MaterialButton.MaterialButtonType.Contained;
            buttonAddCourt.UseAccentColor = false;
            buttonAddCourt.UseVisualStyleBackColor = true;
            buttonAddCourt.Click += buttonAddCourt_Click;
            // 
            // dataGridViewCourts
            // 
            dataGridViewCourts.AllowUserToAddRows = false;
            dataGridViewCourts.AllowUserToDeleteRows = false;
            dataGridViewCourts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCourts.BackgroundColor = Color.DimGray;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewCourts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCourts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.DimGray;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridViewCourts.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCourts.Location = new Point(13, 216);
            dataGridViewCourts.Margin = new Padding(2);
            dataGridViewCourts.Name = "dataGridViewCourts";
            dataGridViewCourts.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.DimGray;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridViewCourts.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCourts.RowHeadersWidth = 62;
            dataGridViewCourts.Size = new Size(765, 142);
            dataGridViewCourts.TabIndex = 8;
            dataGridViewCourts.CellClick += dataGridViewCourts_CellClick;
            dataGridViewCourts.CellDoubleClick += dataGridViewCourts_CellDoubleClick;
            // 
            // labelJudges
            // 
            labelJudges.AutoSize = true;
            labelJudges.Depth = 0;
            labelJudges.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelJudges.Location = new Point(13, 373);
            labelJudges.Margin = new Padding(2, 0, 2, 0);
            labelJudges.MouseState = MouseState.HOVER;
            labelJudges.Name = "labelJudges";
            labelJudges.Size = new Size(181, 19);
            labelJudges.TabIndex = 9;
            labelJudges.Text = "Судьи выбранного суда";
            // 
            // dataGridViewJudges
            // 
            dataGridViewJudges.AllowUserToAddRows = false;
            dataGridViewJudges.AllowUserToDeleteRows = false;
            dataGridViewJudges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewJudges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewJudges.Location = new Point(13, 394);
            dataGridViewJudges.Margin = new Padding(2);
            dataGridViewJudges.Name = "dataGridViewJudges";
            dataGridViewJudges.ReadOnly = true;
            dataGridViewJudges.RowHeadersWidth = 62;
            dataGridViewJudges.Size = new Size(575, 110);
            dataGridViewJudges.TabIndex = 10;
            // 
            // buttonAddJudge
            // 
            buttonAddJudge.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAddJudge.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonAddJudge.Depth = 0;
            buttonAddJudge.Enabled = false;
            buttonAddJudge.HighEmphasis = true;
            buttonAddJudge.Icon = null;
            buttonAddJudge.Location = new Point(592, 468);
            buttonAddJudge.Margin = new Padding(2, 3, 2, 3);
            buttonAddJudge.MouseState = MouseState.HOVER;
            buttonAddJudge.Name = "buttonAddJudge";
            buttonAddJudge.NoAccentTextColor = Color.Empty;
            buttonAddJudge.Size = new Size(197, 36);
            buttonAddJudge.TabIndex = 11;
            buttonAddJudge.Text = "Внести нового судью";
            buttonAddJudge.Type = MaterialButton.MaterialButtonType.Contained;
            buttonAddJudge.UseAccentColor = false;
            buttonAddJudge.UseVisualStyleBackColor = true;
            buttonAddJudge.Click += buttonAddJudge_Click;
            // 
            // buttonOpenCases
            // 
            buttonOpenCases.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonOpenCases.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonOpenCases.Depth = 0;
            buttonOpenCases.Enabled = false;
            buttonOpenCases.HighEmphasis = true;
            buttonOpenCases.Icon = null;
            buttonOpenCases.Location = new Point(592, 157);
            buttonOpenCases.Margin = new Padding(2, 3, 2, 3);
            buttonOpenCases.MouseState = MouseState.HOVER;
            buttonOpenCases.Name = "buttonOpenCases";
            buttonOpenCases.NoAccentTextColor = Color.Empty;
            buttonOpenCases.Size = new Size(177, 36);
            buttonOpenCases.TabIndex = 14;
            buttonOpenCases.Text = "Открыть дела суда";
            buttonOpenCases.Type = MaterialButton.MaterialButtonType.Contained;
            buttonOpenCases.UseAccentColor = false;
            buttonOpenCases.UseVisualStyleBackColor = true;
            buttonOpenCases.Click += buttonOpenCases_Click;
            // 
            // progressBarLoading
            // 
            progressBarLoading.Location = new Point(592, 81);
            progressBarLoading.Margin = new Padding(2);
            progressBarLoading.MarqueeAnimationSpeed = 40;
            progressBarLoading.Name = "progressBarLoading";
            progressBarLoading.Size = new Size(144, 24);
            progressBarLoading.Style = ProgressBarStyle.Marquee;
            progressBarLoading.TabIndex = 15;
            progressBarLoading.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(806, 532);
            Controls.Add(dataGridViewCourts);
            Controls.Add(buttonAddJudge);
            Controls.Add(buttonOpenCases);
            Controls.Add(dataGridViewJudges);
            Controls.Add(labelJudges);
            Controls.Add(buttonAddCourt);
            Controls.Add(textBoxType);
            Controls.Add(labelType);
            Controls.Add(textBoxAddress);
            Controls.Add(labelAddress);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(progressBarLoading);
            Controls.Add(label1);
            Name = "MainForm";
            Padding = new Padding(2, 32, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Судебные дела";
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewCourts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewJudges).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialLabel label1;
        private MaterialLabel labelName;
        private MaterialTextBox textBoxName;
        private MaterialLabel labelAddress;
        private MaterialTextBox textBoxAddress;
        private MaterialLabel labelType;
        private MaterialTextBox textBoxType;
        private MaterialButton buttonAddCourt;
        private DataGridView dataGridViewCourts;
        private MaterialLabel labelJudges;
        private DataGridView dataGridViewJudges;
        private MaterialButton buttonAddJudge;
        private MaterialButton buttonOpenCases;
        private ProgressBar progressBarLoading;
    }
}