using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace ServiceStation
{
    public partial class login : Form
    {
        int p = 0;

        public login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            SQLiteConnection conn = new SQLiteConnection();

            conn.ConnectionString = @"Data Source = " + Data.baseName;

            try
            {
                conn.Open();
            }
            catch (SQLiteException se)
            {
                MessageBox.Show("Error: {0}", se.Message);
                return;
            }
            
            SQLiteCommand login = new SQLiteCommand("Select login, pass From Users", conn);

            using (SQLiteDataReader dr = login.ExecuteReader(CommandBehavior.CloseConnection))
            {
                string user = "";
                string password = "";

                while (dr.Read())
                {
                    user = dr.GetValue(0).ToString().Trim();
                    password = dr.GetValue(1).ToString().Trim();

                    if (p == 0)
                    {
                        if (textBox1.Text.ToString().Equals(user) && textBox2.Text.ToString().Equals(password))
                        {
                            main main = new main();
                            main.Show();
                            this.Hide();
                            p++;
                        }
                    }
                }

                if (p == 0)
                {
                    MessageBox.Show("Wrong login or password");
                }
            }

            conn.Close();
            conn.Dispose();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    button1_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    button1_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
