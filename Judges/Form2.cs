using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace Judges
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connStr = "Host=localhost;Username=postgres;Password=pass;Database=postgres";

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Одно из полей пустое!");
            }
            else
            {
                using(var connection = new NpgsqlConnection(connStr))
                {
                    connection.Open();

                    string sql = "INSERT INTO users (username, password) VALUES (@user, @pass);";

                    using(var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("user", textBox1.Text);
                        command.Parameters.AddWithValue("pass", textBox2.Text);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Регистрация прошла успешно!");
                    }
                }
            }
        }
    }
}
