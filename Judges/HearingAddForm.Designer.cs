using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class HearingAddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelDate = new MaterialLabel();
            dateTimePickerHearingDate = new DateTimePicker();
            labelRoom = new MaterialLabel();
            textBoxRoom = new MaterialTextBox();
            labelResult = new MaterialLabel();
            textBoxResult = new MaterialTextBox();
            labelParticipants = new MaterialLabel();
            listBoxParticipants = new ListBox();
            buttonSave = new MaterialButton();
            buttonCancel = new MaterialButton();
            SuspendLayout();
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Depth = 0;
            labelDate.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelDate.Location = new Point(12, 79);
            labelDate.MouseState = MouseState.HOVER;
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(103, 19);
            labelDate.TabIndex = 9;
            labelDate.Text = "Дата и время";
            // 
            // dateTimePickerHearingDate
            // 
            dateTimePickerHearingDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimePickerHearingDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerHearingDate.Location = new Point(12, 101);
            dateTimePickerHearingDate.Name = "dateTimePickerHearingDate";
            dateTimePickerHearingDate.Size = new Size(260, 23);
            dateTimePickerHearingDate.TabIndex = 8;
            // 
            // labelRoom
            // 
            labelRoom.AutoSize = true;
            labelRoom.Depth = 0;
            labelRoom.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelRoom.Location = new Point(12, 127);
            labelRoom.MouseState = MouseState.HOVER;
            labelRoom.Name = "labelRoom";
            labelRoom.Size = new Size(89, 19);
            labelRoom.TabIndex = 7;
            labelRoom.Text = "Номер зала";
            // 
            // textBoxRoom
            // 
            textBoxRoom.AnimateReadOnly = false;
            textBoxRoom.BorderStyle = BorderStyle.None;
            textBoxRoom.Depth = 0;
            textBoxRoom.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxRoom.LeadingIcon = null;
            textBoxRoom.Location = new Point(12, 149);
            textBoxRoom.MaxLength = 50;
            textBoxRoom.MouseState = MouseState.OUT;
            textBoxRoom.Multiline = false;
            textBoxRoom.Name = "textBoxRoom";
            textBoxRoom.Size = new Size(260, 50);
            textBoxRoom.TabIndex = 6;
            textBoxRoom.Text = "";
            textBoxRoom.TrailingIcon = null;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Depth = 0;
            labelResult.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelResult.Location = new Point(12, 202);
            labelResult.MouseState = MouseState.HOVER;
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(114, 19);
            labelResult.TabIndex = 5;
            labelResult.Text = "Итог слушания";
            // 
            // textBoxResult
            // 
            textBoxResult.AnimateReadOnly = false;
            textBoxResult.BorderStyle = BorderStyle.None;
            textBoxResult.Depth = 0;
            textBoxResult.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxResult.LeadingIcon = null;
            textBoxResult.Location = new Point(12, 224);
            textBoxResult.MaxLength = 50;
            textBoxResult.MouseState = MouseState.OUT;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(260, 50);
            textBoxResult.TabIndex = 4;
            textBoxResult.Text = "";
            textBoxResult.TrailingIcon = null;
            // 
            // labelParticipants
            // 
            labelParticipants.AutoSize = true;
            labelParticipants.Depth = 0;
            labelParticipants.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelParticipants.Location = new Point(294, 79);
            labelParticipants.MouseState = MouseState.HOVER;
            labelParticipants.Name = "labelParticipants";
            labelParticipants.Size = new Size(324, 19);
            labelParticipants.TabIndex = 3;
            labelParticipants.Text = "Подсудимые (можно выбрать нескольких)";
            // 
            // listBoxParticipants
            // 
            listBoxParticipants.FormattingEnabled = true;
            listBoxParticipants.Location = new Point(294, 101);
            listBoxParticipants.Name = "listBoxParticipants";
            listBoxParticipants.SelectionMode = SelectionMode.MultiExtended;
            listBoxParticipants.Size = new Size(330, 184);
            listBoxParticipants.TabIndex = 2;
            // 
            // buttonSave
            // 
            buttonSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonSave.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonSave.Depth = 0;
            buttonSave.HighEmphasis = true;
            buttonSave.Icon = null;
            buttonSave.Location = new Point(13, 283);
            buttonSave.Margin = new Padding(4, 6, 4, 6);
            buttonSave.MouseState = MouseState.HOVER;
            buttonSave.Name = "buttonSave";
            buttonSave.NoAccentTextColor = Color.Empty;
            buttonSave.Size = new Size(109, 36);
            buttonSave.TabIndex = 1;
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
            buttonCancel.Location = new Point(130, 283);
            buttonCancel.Margin = new Padding(4, 6, 4, 6);
            buttonCancel.MouseState = MouseState.HOVER;
            buttonCancel.Name = "buttonCancel";
            buttonCancel.NoAccentTextColor = Color.Empty;
            buttonCancel.Size = new Size(82, 36);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Отмена";
            buttonCancel.Type = MaterialButton.MaterialButtonType.Contained;
            buttonCancel.UseAccentColor = false;
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // HearingAddForm
            // 
            AcceptButton = buttonSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(657, 352);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(listBoxParticipants);
            Controls.Add(labelParticipants);
            Controls.Add(textBoxResult);
            Controls.Add(labelResult);
            Controls.Add(textBoxRoom);
            Controls.Add(labelRoom);
            Controls.Add(dateTimePickerHearingDate);
            Controls.Add(labelDate);
            Name = "HearingAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Новое слушание";
            Load += HearingAddForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private MaterialLabel labelDate;
        private DateTimePicker dateTimePickerHearingDate;
        private MaterialLabel labelRoom;
        private MaterialTextBox textBoxRoom;
        private MaterialLabel labelResult;
        private MaterialTextBox textBoxResult;
        private MaterialLabel labelParticipants;
        private ListBox listBoxParticipants;
        private MaterialButton buttonSave;
        private MaterialButton buttonCancel;
    }
}
