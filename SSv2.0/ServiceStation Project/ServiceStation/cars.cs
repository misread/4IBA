using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace ServiceStation
{
    public partial class cars : Form
    {
        private String connectionString;
        private SQLiteConnection connection;

        public cars()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            connection = new SQLiteConnection(connectionString);
        }

        private void addNewCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carAdd newCar = new carAdd();
            newCar.MdiParent = main.ActiveForm;
            newCar.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clientCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        internal void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.CarID = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            Data.Car = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString() + " year " + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();

            orders orders = new orders();
            orders.MdiParent = main.ActiveForm;
            orders.Show();
        }

        internal void deleteTheCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.CarID = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            Data.Car = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() + " " + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString() + " year " + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();

            string message = "Are you sure you want to delete " + Data.ClientName + "'s car " + Data.Car + "?";
            string caption = "Delete the Car";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                deleteCar(sender, e);
            }
        }

        private void cars_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text += " of " + Data.ClientName;
                clientCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clientCars()
        {
            if (this.carsTableAdapter.ClientCars(this.ssSQLite.Cars, Convert.ToInt32(Data.ClientID)) == 0)
            {
                string message = "Would you like to add a car?";
                string caption = "No cars of " + Data.ClientName;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    carAdd newCar = new carAdd();
                    newCar.MdiParent = main.ActiveForm;
                    newCar.Show();
                }
            }
            else
            {
                main Main = (main)this.MdiParent;
                Main.toolStripButton4.Enabled = true;
                Main.toolStripButton7.Enabled = true;
                Main.toolStripButton5.Enabled = true;
                Main.toolStripButton2.Enabled = false;
                Main.toolStripButton6.Enabled = false;
                Main.toolStripButton3.Enabled = false;
                Main.toolStripButton9.Enabled = false;
            }
        }

        private void clientCarsToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.carsTableAdapter.ClientCars(this.ssSQLite.Cars, Convert.ToInt32(Data.ClientID));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteCar(object sender, EventArgs e)
        {
            String SQLDelete = "Delete FROM Cars Where (Id='" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "')";
            String SQLSelect = "Select Count(Id) From Orders Where (carid='" + Data.CarID + "' And status='in progress')";
            String SQLUpdate = "Update Orders SET carid = 0 Where carid='" + Data.CarID + "'";

            if (connection.State != ConnectionState.Open)
                connection.Open();

            SQLiteCommand delete = connection.CreateCommand();
            delete.CommandText = SQLDelete;
            SQLiteCommand select = connection.CreateCommand();
            select.CommandText = SQLSelect;
            SQLiteCommand update = connection.CreateCommand();
            update.CommandText = SQLUpdate;

            Int32 count = Convert.ToInt32(select.ExecuteScalar());

            if (count == 0)
            {
                try
                {
                    update.ExecuteNonQuery();
                    delete.ExecuteNonQuery();
                    MessageBox.Show("The Car Deleted");
                    clientCars();
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
            else
            {
                if (count > 1)
                    MessageBox.Show("The car can not be deleted. There are " + count + " orders in progress.");
                else
                    MessageBox.Show("The car can not be deleted. There is one order in progress.");

                count = 0;
            }

            connection.Close();
        }

        private void cars_Activated(object sender, EventArgs e)
        {
            try
            {
                clientCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }

        private void cars_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
