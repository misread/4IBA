using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace ServiceStation
{
    public partial class orders : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        public orders()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
        }

        private void orders_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text += " of " + Data.ClientName + "'s car " + Data.Car;
                carsOrders();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void carsOrders()
        {
            if (this.ordersTableAdapter.CarOrders(this.ssSQLite.Orders, Convert.ToInt32(Data.CarID)) == 0)
            {
                string message = "Would you like to create new order?";
                string caption = "No orders for the car";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    orderAdd newOrder = new orderAdd();
                    newOrder.MdiParent = main.ActiveForm;
                    newOrder.Show();
                }
            }
            else
            {
                main Main = (main)MdiParent;
                Main.toolStripButton6.Enabled = true;
                Main.toolStripButton9.Enabled = true;
                Main.toolStripButton3.Enabled = false;
                Main.toolStripButton4.Enabled = false;
                Main.toolStripButton7.Enabled = false;
                Main.toolStripButton5.Enabled = false;
                Main.toolStripButton2.Enabled = false;
            }
        }

        private void carOrdersToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                ordersTableAdapter.CarOrders(ssSQLite.Orders, Convert.ToInt32(Data.CarID));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addAnOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderAdd newOrder = new orderAdd();
            newOrder.MdiParent = ActiveForm;
            newOrder.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                carsOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void inProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateStatus("in progress");
        }

        private void completedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateStatus("completed");
        }

        private void cancelledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateStatus("cancelled");
        }
        
        private void updateStatus(string status)
        {
            String SQLUpdate = "Update Orders SET status = @status Where (Id=" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + ")";

            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = SQLUpdate;

            command.Parameters.AddWithValue("@status", status);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Status updated");
                connection.Close();
                carsOrders();
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

        private void orders_Activated(object sender, EventArgs e)
        {
            try
            {
                carsOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        internal void editOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.OrderID = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            orderEdit order = new orderEdit();
            order.MdiParent = ActiveForm;

            order.textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            order.textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            order.comboBox1.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();

            order.Show();
        }

        private void orders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
