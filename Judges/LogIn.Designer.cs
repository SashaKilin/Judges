using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class LogIn
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
            label1 = new MaterialLabel();
            textBox1 = new MaterialTextBox();
            textBox2 = new MaterialTextBox();
            label2 = new MaterialLabel();
            button1 = new MaterialButton();
            button2 = new MaterialButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Depth = 0;
            label1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label1.Location = new Point(20, 22);
            label1.MouseState = MouseState.HOVER;
            label1.Name = "label1";
            label1.Size = new Size(50, 19);
            label1.TabIndex = 0;
            label1.Text = "Логин:";
            // 
            // textBox1
            // 
            textBox1.AnimateReadOnly = false;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Depth = 0;
            textBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox1.LeadingIcon = null;
            textBox1.Location = new Point(20, 44);
            textBox1.MaxLength = 50;
            textBox1.MouseState = MouseState.OUT;
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(260, 50);
            textBox1.TabIndex = 1;
            textBox1.Text = "";
            textBox1.TrailingIcon = null;
            // 
            // textBox2
            // 
            textBox2.AnimateReadOnly = false;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Depth = 0;
            textBox2.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBox2.LeadingIcon = null;
            textBox2.Location = new Point(20, 126);
            textBox2.MaxLength = 50;
            textBox2.MouseState = MouseState.OUT;
            textBox2.Multiline = false;
            textBox2.Name = "textBox2";
            textBox2.Password = true;
            textBox2.Size = new Size(260, 50);
            textBox2.TabIndex = 3;
            textBox2.Text = "";
            textBox2.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Depth = 0;
            label2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            label2.Location = new Point(20, 104);
            label2.MouseState = MouseState.HOVER;
            label2.Name = "label2";
            label2.Size = new Size(61, 19);
            label2.TabIndex = 2;
            label2.Text = "Пароль:";
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Density = MaterialButton.MaterialButtonDensity.Default;
            button1.Depth = 0;
            button1.HighEmphasis = true;
            button1.Icon = null;
            button1.Location = new Point(42, 185);
            button1.Margin = new Padding(4, 6, 4, 6);
            button1.MouseState = MouseState.HOVER;
            button1.Name = "button1";
            button1.NoAccentTextColor = Color.Empty;
            button1.Size = new Size(64, 36);
            button1.TabIndex = 4;
            button1.Text = "Вход";
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
            button2.Location = new Point(184, 185);
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
            // LogIn
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(307, 256);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "LogIn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialLabel label1;
        private MaterialTextBox textBox1;
        private MaterialTextBox textBox2;
        private MaterialLabel label2;
        private MaterialButton button1;
        private MaterialButton button2;
    }
}