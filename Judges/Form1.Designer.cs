using MaterialSkin.Controls;
using MaterialSkin;

namespace Judges
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new MaterialButton();
            button2 = new MaterialButton();
            materialLabel1 = new MaterialLabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Density = MaterialButton.MaterialButtonDensity.Default;
            button1.Depth = 0;
            button1.HighEmphasis = true;
            button1.Icon = null;
            button1.Location = new Point(118, 132);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.MouseState = MouseState.HOVER;
            button1.Name = "button1";
            button1.NoAccentTextColor = Color.Empty;
            button1.Size = new Size(71, 36);
            button1.TabIndex = 1;
            button1.Text = "Войти";
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
            button2.Location = new Point(93, 179);
            button2.Margin = new Padding(2, 1, 2, 1);
            button2.MouseState = MouseState.HOVER;
            button2.Name = "button2";
            button2.NoAccentTextColor = Color.Empty;
            button2.Size = new Size(126, 36);
            button2.TabIndex = 2;
            button2.Text = "Регистрация";
            button2.Type = MaterialButton.MaterialButtonType.Outlined;
            button2.UseAccentColor = false;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(82, 92);
            materialLabel1.MouseState = MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(149, 19);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Добро пожаловать!";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(313, 264);
            Controls.Add(materialLabel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(2, 1, 2, 1);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Судебные дела";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialButton button1;
        private MaterialButton button2;
        private MaterialLabel materialLabel1;
    }
}
