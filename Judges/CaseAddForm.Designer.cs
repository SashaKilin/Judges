using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class CaseAddForm
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
            labelCaseNumber = new MaterialLabel();
            textBoxCaseNumber = new MaterialTextBox();
            labelJudge = new MaterialLabel();
            comboBoxJudge = new MaterialComboBox();
            labelDefendant = new MaterialLabel();
            comboBoxDefendant = new MaterialComboBox();
            labelTitle = new MaterialLabel();
            textBoxTitle = new MaterialTextBox();
            labelCategory = new MaterialLabel();
            textBoxCategory = new MaterialTextBox();
            labelStatus = new MaterialLabel();
            textBoxStatus = new MaterialTextBox();
            labelFillingDate = new MaterialLabel();
            dateTimePickerFillingDate = new DateTimePicker();
            buttonSave = new MaterialButton();
            buttonCancel = new MaterialButton();
            labelNoJudges = new MaterialLabel();
            SuspendLayout();
            // 
            // labelCaseNumber
            // 
            labelCaseNumber.AutoSize = true;
            labelCaseNumber.Depth = 0;
            labelCaseNumber.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelCaseNumber.Location = new Point(32, 77);
            labelCaseNumber.MouseState = MouseState.HOVER;
            labelCaseNumber.Name = "labelCaseNumber";
            labelCaseNumber.Size = new Size(90, 19);
            labelCaseNumber.TabIndex = 0;
            labelCaseNumber.Text = "Номер дела";
            // 
            // textBoxCaseNumber
            // 
            textBoxCaseNumber.AnimateReadOnly = false;
            textBoxCaseNumber.BorderStyle = BorderStyle.None;
            textBoxCaseNumber.Depth = 0;
            textBoxCaseNumber.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCaseNumber.LeadingIcon = null;
            textBoxCaseNumber.Location = new Point(32, 99);
            textBoxCaseNumber.MaxLength = 50;
            textBoxCaseNumber.MouseState = MouseState.OUT;
            textBoxCaseNumber.Multiline = false;
            textBoxCaseNumber.Name = "textBoxCaseNumber";
            textBoxCaseNumber.Size = new Size(350, 50);
            textBoxCaseNumber.TabIndex = 1;
            textBoxCaseNumber.Text = "";
            textBoxCaseNumber.TrailingIcon = null;
            // 
            // labelJudge
            // 
            labelJudge.AutoSize = true;
            labelJudge.Depth = 0;
            labelJudge.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelJudge.Location = new Point(32, 152);
            labelJudge.MouseState = MouseState.HOVER;
            labelJudge.Name = "labelJudge";
            labelJudge.Size = new Size(47, 19);
            labelJudge.TabIndex = 2;
            labelJudge.Text = "Судья";
            // 
            // comboBoxJudge
            // 
            comboBoxJudge.AutoResize = false;
            comboBoxJudge.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxJudge.Depth = 0;
            comboBoxJudge.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxJudge.DropDownHeight = 174;
            comboBoxJudge.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJudge.DropDownWidth = 121;
            comboBoxJudge.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxJudge.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxJudge.FormattingEnabled = true;
            comboBoxJudge.IntegralHeight = false;
            comboBoxJudge.ItemHeight = 43;
            comboBoxJudge.Location = new Point(33, 174);
            comboBoxJudge.MaxDropDownItems = 4;
            comboBoxJudge.MouseState = MouseState.OUT;
            comboBoxJudge.Name = "comboBoxJudge";
            comboBoxJudge.Size = new Size(350, 49);
            comboBoxJudge.StartIndex = 0;
            comboBoxJudge.TabIndex = 3;
            // 
            // labelDefendant
            // 
            labelDefendant.AutoSize = true;
            labelDefendant.Depth = 0;
            labelDefendant.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelDefendant.Location = new Point(32, 237);
            labelDefendant.MouseState = MouseState.HOVER;
            labelDefendant.Name = "labelDefendant";
            labelDefendant.Size = new Size(99, 19);
            labelDefendant.TabIndex = 4;
            labelDefendant.Text = "Подсудимый";
            // 
            // comboBoxDefendant
            // 
            comboBoxDefendant.AutoResize = false;
            comboBoxDefendant.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxDefendant.Depth = 0;
            comboBoxDefendant.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxDefendant.DropDownHeight = 174;
            comboBoxDefendant.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDefendant.DropDownWidth = 121;
            comboBoxDefendant.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxDefendant.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxDefendant.FormattingEnabled = true;
            comboBoxDefendant.IntegralHeight = false;
            comboBoxDefendant.ItemHeight = 43;
            comboBoxDefendant.Location = new Point(33, 259);
            comboBoxDefendant.MaxDropDownItems = 4;
            comboBoxDefendant.MouseState = MouseState.OUT;
            comboBoxDefendant.Name = "comboBoxDefendant";
            comboBoxDefendant.Size = new Size(350, 49);
            comboBoxDefendant.StartIndex = 0;
            comboBoxDefendant.TabIndex = 5;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Depth = 0;
            labelTitle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelTitle.Location = new Point(33, 311);
            labelTitle.MouseState = MouseState.HOVER;
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(73, 19);
            labelTitle.TabIndex = 6;
            labelTitle.Text = "Название";
            // 
            // textBoxTitle
            // 
            textBoxTitle.AnimateReadOnly = false;
            textBoxTitle.BorderStyle = BorderStyle.None;
            textBoxTitle.Depth = 0;
            textBoxTitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxTitle.LeadingIcon = null;
            textBoxTitle.Location = new Point(33, 333);
            textBoxTitle.MaxLength = 50;
            textBoxTitle.MouseState = MouseState.OUT;
            textBoxTitle.Multiline = false;
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(350, 50);
            textBoxTitle.TabIndex = 7;
            textBoxTitle.Text = "";
            textBoxTitle.TrailingIcon = null;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Depth = 0;
            labelCategory.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelCategory.Location = new Point(33, 386);
            labelCategory.MouseState = MouseState.HOVER;
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(79, 19);
            labelCategory.TabIndex = 8;
            labelCategory.Text = "Категория";
            // 
            // textBoxCategory
            // 
            textBoxCategory.AnimateReadOnly = false;
            textBoxCategory.BorderStyle = BorderStyle.None;
            textBoxCategory.Depth = 0;
            textBoxCategory.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCategory.LeadingIcon = null;
            textBoxCategory.Location = new Point(33, 408);
            textBoxCategory.MaxLength = 50;
            textBoxCategory.MouseState = MouseState.OUT;
            textBoxCategory.Multiline = false;
            textBoxCategory.Name = "textBoxCategory";
            textBoxCategory.Size = new Size(350, 50);
            textBoxCategory.TabIndex = 9;
            textBoxCategory.Text = "";
            textBoxCategory.TrailingIcon = null;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Depth = 0;
            labelStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelStatus.Location = new Point(33, 461);
            labelStatus.MouseState = MouseState.HOVER;
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(52, 19);
            labelStatus.TabIndex = 10;
            labelStatus.Text = "Статус";
            // 
            // textBoxStatus
            // 
            textBoxStatus.AnimateReadOnly = false;
            textBoxStatus.BorderStyle = BorderStyle.None;
            textBoxStatus.Depth = 0;
            textBoxStatus.Font = new Font("Microsoft Sans Serif", 12F);
            textBoxStatus.LeadingIcon = null;
            textBoxStatus.Location = new Point(33, 483);
            textBoxStatus.MaxLength = 50;
            textBoxStatus.MouseState = MouseState.OUT;
            textBoxStatus.Multiline = false;
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(350, 50);
            textBoxStatus.TabIndex = 11;
            textBoxStatus.Text = "Новое";
            textBoxStatus.TrailingIcon = null;
            // 
            // labelFillingDate
            // 
            labelFillingDate.AutoSize = true;
            labelFillingDate.Depth = 0;
            labelFillingDate.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelFillingDate.Location = new Point(33, 536);
            labelFillingDate.MouseState = MouseState.HOVER;
            labelFillingDate.Name = "labelFillingDate";
            labelFillingDate.Size = new Size(98, 19);
            labelFillingDate.TabIndex = 12;
            labelFillingDate.Text = "Дата подачи";
            // 
            // dateTimePickerFillingDate
            // 
            dateTimePickerFillingDate.Format = DateTimePickerFormat.Short;
            dateTimePickerFillingDate.Location = new Point(33, 558);
            dateTimePickerFillingDate.Name = "dateTimePickerFillingDate";
            dateTimePickerFillingDate.Size = new Size(350, 23);
            dateTimePickerFillingDate.TabIndex = 13;
            // 
            // buttonSave
            // 
            buttonSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonSave.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonSave.Depth = 0;
            buttonSave.HighEmphasis = true;
            buttonSave.Icon = null;
            buttonSave.Location = new Point(69, 619);
            buttonSave.Margin = new Padding(4, 6, 4, 6);
            buttonSave.MouseState = MouseState.HOVER;
            buttonSave.Name = "buttonSave";
            buttonSave.NoAccentTextColor = Color.Empty;
            buttonSave.Size = new Size(109, 36);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Сохранить";
            buttonSave.Type = MaterialButton.MaterialButtonType.Contained;
            buttonSave.UseAccentColor = false;
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancel.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonCancel.Depth = 0;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.HighEmphasis = true;
            buttonCancel.Icon = null;
            buttonCancel.Location = new Point(258, 619);
            buttonCancel.Margin = new Padding(4, 6, 4, 6);
            buttonCancel.MouseState = MouseState.HOVER;
            buttonCancel.Name = "buttonCancel";
            buttonCancel.NoAccentTextColor = Color.Empty;
            buttonCancel.Size = new Size(82, 36);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отмена";
            buttonCancel.Type = MaterialButton.MaterialButtonType.Contained;
            buttonCancel.UseAccentColor = false;
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelNoJudges
            // 
            labelNoJudges.AutoSize = true;
            labelNoJudges.Depth = 0;
            labelNoJudges.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelNoJudges.ForeColor = Color.Firebrick;
            labelNoJudges.Location = new Point(45, 594);
            labelNoJudges.MouseState = MouseState.HOVER;
            labelNoJudges.Name = "labelNoJudges";
            labelNoJudges.Size = new Size(326, 19);
            labelNoJudges.TabIndex = 16;
            labelNoJudges.Text = "Сначала добавьте судью в выбранный суд";
            labelNoJudges.Visible = false;
            // 
            // CaseAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(409, 689);
            Controls.Add(labelNoJudges);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(dateTimePickerFillingDate);
            Controls.Add(labelFillingDate);
            Controls.Add(textBoxStatus);
            Controls.Add(labelStatus);
            Controls.Add(textBoxCategory);
            Controls.Add(labelCategory);
            Controls.Add(textBoxTitle);
            Controls.Add(labelTitle);
            Controls.Add(comboBoxDefendant);
            Controls.Add(labelDefendant);
            Controls.Add(comboBoxJudge);
            Controls.Add(labelJudge);
            Controls.Add(textBoxCaseNumber);
            Controls.Add(labelCaseNumber);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CaseAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новое дело";
            Load += CaseAddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private MaterialLabel labelCaseNumber;
        private MaterialTextBox textBoxCaseNumber;
        private MaterialLabel labelJudge;
        private MaterialComboBox comboBoxJudge;
        private MaterialLabel labelDefendant;
        private MaterialComboBox comboBoxDefendant;
        private MaterialLabel labelTitle;
        private MaterialTextBox textBoxTitle;
        private MaterialLabel labelCategory;
        private MaterialTextBox textBoxCategory;
        private MaterialLabel labelStatus;
        private MaterialTextBox textBoxStatus;
        private MaterialLabel labelFillingDate;
        private DateTimePicker dateTimePickerFillingDate;
        private MaterialButton buttonSave;
        private MaterialButton buttonCancel;
        private MaterialLabel labelNoJudges;
    }
}
