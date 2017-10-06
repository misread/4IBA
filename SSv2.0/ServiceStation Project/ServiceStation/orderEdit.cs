using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace ServiceStation
{
    public partial class orderEdit : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        private String SQLUpdate = "UPDATE Orders SET date=@date, amount=@amount, status=@status WHERE Id=" + Data.OrderID + "";
        public orderEdit()
        {
            InitializeComponent();

            label1.Text += " of " + Data.ClientName + "'s car " + Data.Car;

            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Order Amount");
                return;
            }
            else
            {
                int amount = Int32.Parse(textBox2.Text.ToString().Trim());

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = SQLUpdate;

                command.Parameters.AddWithValue("@date", textBox1.Text.ToString().Trim());
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@status", comboBox1.Text.ToString().Trim());

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("The Order Edited");
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();

            this.Close();
        }

        private void orderEdit_Activated(object sender, EventArgs e)
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

        private void orderEdit_KeyDown(object sender, KeyEventArgs e)
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
