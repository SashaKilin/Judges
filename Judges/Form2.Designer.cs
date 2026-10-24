using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class Form2
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
            textBox1 = new MaterialTextBox();
            label1 = new MaterialLabel();
            label2 = new MaterialLabel();
            textBox2 = new MaterialTextBox();
            button1 = new MaterialButton();
            button2 = new MaterialButton();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AnimateReadOnly = false;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Depth = 0;
            textBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox1.LeadingIcon = null;
            textBox1.Location = new Point(22, 98);
            textBox1.MaxLength = 50;
            textBox1.MouseState = MouseState.OUT;
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 50);
            textBox1.TabIndex = 0;
            textBox1.Text = "";
            textBox1.TrailingIcon = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(27, 76);
            label1.MouseState = MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(46, 19);
            label1.TabIndex = 1;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.Location = new Point(22, 151);
            label2.MouseState = MouseState.HOVER;
            label2.Name = "label2";
            label2.Size = new Size(57, 19);
            label2.TabIndex = 3;
            label2.Text = "Пароль";
            // 
            // textBox2
            // 
            textBox2.AnimateReadOnly = false;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Depth = 0;
            textBox2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox2.LeadingIcon = null;
            textBox2.Location = new Point(22, 173);
            textBox2.MaxLength = 50;
            textBox2.MouseState = MouseState.OUT;
            textBox2.Multiline = false;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(332, 50);
            textBox2.TabIndex = 2;
            textBox2.Text = "";
            textBox2.TrailingIcon = null;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Density = MaterialButton.MaterialButtonDensity.Default;
            button1.Depth = 0;
            button1.HighEmphasis = true;
            button1.Icon = null;
            button1.Location = new Point(28, 243);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.MouseState = MouseState.HOVER;
            button1.Name = "button1";
            button1.NoAccentTextColor = Color.Empty;
            button1.Size = new Size(191, 36);
            button1.TabIndex = 4;
            button1.Text = "Зарегистрироваться";
            button1.Type = MaterialButton.MaterialButtonType.Contained;
            button1.UseAccentColor = false;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.Density = MaterialButton.MaterialButtonDensity.Default;
            button2.Depth = 0;
            button2.HighEmphasis = true;
            button2.Icon = null;
            button2.Location = new Point(272, 243);
            button2.Margin = new Padding(4, 6, 4, 6);
            button2.MouseState = MouseState.HOVER;
            button2.Name = "button2";
            button2.NoAccentTextColor = Color.Empty;
            button2.Size = new Size(71, 36);
            button2.TabIndex = 5;
            button2.Text = "Назад";
            button2.Type = MaterialButton.MaterialButtonType.Contained;
            button2.UseAccentColor = false;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(380, 315);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Margin = new Padding(2, 1, 2, 1);
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Регистрация";
            FormClosed += Form2_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialTextBox textBox1;
        private MaterialLabel label1;
        private MaterialLabel label2;
        private MaterialTextBox textBox2;
        private MaterialButton button1;
        private MaterialButton button2;
    }
}