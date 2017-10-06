using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace ServiceStation
{
    public partial class orderAdd : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        private String SQLInsert = "INSERT INTO Orders (date, amount, status, carid) VALUES (@date, @amount, @status, @carid)";

        public orderAdd()
        {
            InitializeComponent();

            label1.Text += " of " + Data.ClientName + "'s car " + Data.Car;
            textBox1.Text = DateTime.Today.ToShortDateString();

            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLInsert;

            command.Parameters.AddWithValue("@date", textBox1.Text.ToString().Trim());
            command.Parameters.AddWithValue("@amount", textBox2.Text.ToString().Trim());
            command.Parameters.AddWithValue("@status", comboBox1.Text.ToString().Trim());
            command.Parameters.AddWithValue("@carid", Data.CarID);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The Order Added");
                connection.Close();
                this.Close();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("there was an issue: " + ex.Message);
            }
            catch (InvalidOperationException ex) // This will catch SqlConnection Exception
            {
                MessageBox.Show("Connection Exception issue: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();

            this.Close();
        }

        private void orderAdd_Activated(object sender, EventArgs e)
        {
            main Main = (main)this.MdiParent;
            Main.toolStripButton2.Enabled = false;
            Main.toolStripButton3.Enabled = false;
            Main.toolStripButton4.Enabled = false;
            Main.toolStripButton5.Enabled = false;
            Main.toolStripButton7.Enabled = false;
            Main.toolStripButton6.Enabled = false;
            Main.toolStripButton9.Enabled = false;
        }

        private void orderAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                this.Close();
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
