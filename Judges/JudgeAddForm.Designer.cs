using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class JudgeAddForm
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
            labelFullName = new MaterialLabel();
            textBoxFullName = new MaterialTextBox();
            labelBadgeNumber = new MaterialLabel();
            textBoxBadgeNumber = new MaterialTextBox();
            buttonSave = new MaterialButton();
            buttonCancel = new MaterialButton();
            SuspendLayout();
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Depth = 0;
            labelFullName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelFullName.Location = new Point(15, 73);
            labelFullName.MouseState = MouseState.HOVER;
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(35, 19);
            labelFullName.TabIndex = 0;
            labelFullName.Text = "ФИО";
            // 
            // textBoxFullName
            // 
            textBoxFullName.AnimateReadOnly = false;
            textBoxFullName.BorderStyle = BorderStyle.None;
            textBoxFullName.Depth = 0;
            textBoxFullName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxFullName.LeadingIcon = null;
            textBoxFullName.Location = new Point(15, 95);
            textBoxFullName.MaxLength = 50;
            textBoxFullName.MouseState = MouseState.OUT;
            textBoxFullName.Multiline = false;
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(350, 50);
            textBoxFullName.TabIndex = 1;
            textBoxFullName.Text = "";
            textBoxFullName.TrailingIcon = null;
            // 
            // labelBadgeNumber
            // 
            labelBadgeNumber.AutoSize = true;
            labelBadgeNumber.Depth = 0;
            labelBadgeNumber.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelBadgeNumber.Location = new Point(15, 148);
            labelBadgeNumber.MouseState = MouseState.HOVER;
            labelBadgeNumber.Name = "labelBadgeNumber";
            labelBadgeNumber.Size = new Size(136, 19);
            labelBadgeNumber.TabIndex = 2;
            labelBadgeNumber.Text = "Табельный номер";
            // 
            // textBoxBadgeNumber
            // 
            textBoxBadgeNumber.AnimateReadOnly = false;
            textBoxBadgeNumber.BorderStyle = BorderStyle.None;
            textBoxBadgeNumber.Depth = 0;
            textBoxBadgeNumber.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxBadgeNumber.LeadingIcon = null;
            textBoxBadgeNumber.Location = new Point(15, 170);
            textBoxBadgeNumber.MaxLength = 50;
            textBoxBadgeNumber.MouseState = MouseState.OUT;
            textBoxBadgeNumber.Multiline = false;
            textBoxBadgeNumber.Name = "textBoxBadgeNumber";
            textBoxBadgeNumber.Size = new Size(350, 50);
            textBoxBadgeNumber.TabIndex = 3;
            textBoxBadgeNumber.Text = "";
            textBoxBadgeNumber.TrailingIcon = null;
            // 
            // buttonSave
            // 
            buttonSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonSave.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonSave.Depth = 0;
            buttonSave.HighEmphasis = true;
            buttonSave.Icon = null;
            buttonSave.Location = new Point(15, 229);
            buttonSave.Margin = new Padding(4, 6, 4, 6);
            buttonSave.MouseState = MouseState.HOVER;
            buttonSave.Name = "buttonSave";
            buttonSave.NoAccentTextColor = Color.Empty;
            buttonSave.Size = new Size(109, 36);
            buttonSave.TabIndex = 4;
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
            buttonCancel.Location = new Point(132, 229);
            buttonCancel.Margin = new Padding(4, 6, 4, 6);
            buttonCancel.MouseState = MouseState.HOVER;
            buttonCancel.Name = "buttonCancel";
            buttonCancel.NoAccentTextColor = Color.Empty;
            buttonCancel.Size = new Size(82, 36);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.Type = MaterialButton.MaterialButtonType.Contained;
            buttonCancel.UseAccentColor = false;
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // JudgeAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(385, 293);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxBadgeNumber);
            Controls.Add(labelBadgeNumber);
            Controls.Add(textBoxFullName);
            Controls.Add(labelFullName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "JudgeAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление судьи";
            ResumeLayout(false);
            PerformLayout();
        }

        private MaterialLabel labelFullName;
        private MaterialTextBox textBoxFullName;
        private MaterialLabel labelBadgeNumber;
        private MaterialTextBox textBoxBadgeNumber;
        private MaterialButton buttonSave;
        private MaterialButton buttonCancel;
    }
}
