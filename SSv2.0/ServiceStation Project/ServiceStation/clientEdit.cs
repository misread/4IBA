using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace ServiceStation
{
    public partial class clientEdit : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        private String SQLUpdate = "UPDATE Clients SET firstname=@firstname, lastname=@lastname, phone=@phone, email=@email, country=@country, city=@city, street=@street, house=@house, flat=@flat WHERE Id=" + Data.ClientID + "";

        public clientEdit()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int phone = Int32.Parse(textBox3.Text.ToString().Trim());
            int house = Int32.Parse(textBox9.Text.ToString().Trim());
            int? flat = null;

            if (textBox10.Text != "")
                flat = Int32.Parse(textBox10.Text.ToString().Trim());

            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLUpdate;

            command.Parameters.AddWithValue("@firstname", textBox1.Text.ToString().Trim());
            command.Parameters.AddWithValue("@lastname", textBox2.Text.ToString().Trim());
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@email", textBox4.Text.ToString().Trim());
            command.Parameters.AddWithValue("@country", textBox6.Text.ToString().Trim());
            command.Parameters.AddWithValue("@city", textBox7.Text.ToString().Trim());
            command.Parameters.AddWithValue("@street", textBox8.Text.ToString().Trim());
            command.Parameters.AddWithValue("@house", house);
            command.Parameters.AddWithValue("@flat", flat);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The Client Edited");
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

        private void clientEdit_Activated(object sender, EventArgs e)
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

        private void clientEdit_KeyDown(object sender, KeyEventArgs e)
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
