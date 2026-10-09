using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Judges
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        long userEx;

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "Host=localhost;Username=postgres;Password=pass;Database=postgres";

            using (var connection = new NpgsqlConnection(connStr))
            {
                connection.Open();

                string sql = "SELECT COUNT(1) FROM users WHERE username = @user AND password = @pass";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("user", textBox1.Text);
                    command.Parameters.AddWithValue("pass", textBox2.Text);

                    userEx = (long)command.ExecuteScalar();
                }


                if (userEx > 0)
                {
                    MessageBox.Show("Успешный вход!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Учетная запись не найдена!");
                }
            }
        }

        private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
