using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace ServiceStation
{
    public partial class carAdd : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        private String SQLInsert = "INSERT INTO Cars (make, model, year, VIN, clientid) VALUES (@make, @model, @year, @VIN, @clientid)";

        public carAdd()
        {
            InitializeComponent();

            label1.Text += " of " + Data.ClientName;

            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);

            main Main = (main)this.MdiParent;
            Main.toolStripButton2.Enabled = false;
            Main.toolStripButton3.Enabled = false;
            Main.toolStripButton4.Enabled = false;
            Main.toolStripButton5.Enabled = false;
            Main.toolStripButton7.Enabled = false;
            Main.toolStripButton6.Enabled = false;
            Main.toolStripButton9.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year = Int32.Parse(textBox3.Text.ToString().Trim());

            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLInsert;

            command.Parameters.AddWithValue("@make", textBox1.Text.ToString().Trim());
            command.Parameters.AddWithValue("@model", textBox2.Text.ToString().Trim());
            command.Parameters.AddWithValue("@year", year);
            command.Parameters.AddWithValue("@VIN", textBox4.Text.ToString().Trim());
            command.Parameters.AddWithValue("@clientid", Data.ClientID);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The Car Added");
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

        private void carAdd_KeyDown(object sender, KeyEventArgs e)
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
