using System;
using System.Windows.Forms;

namespace ServiceStation
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Data.ClientID = textBox1.Text.Trim();
                
                clientsAll clients = new clientsAll();
                clients.MdiParent = main.ActiveForm;                
                clients.Show();

                clients.clientsSearchId(Data.ClientID);

            }
            else if (textBox2.Text != "")
            {
                Data.ClientLastName = textBox2.Text.Trim();

                clientsAll clients = new clientsAll();
                clients.MdiParent = main.ActiveForm;
                clients.Show();

                clients.clientsSearchLastName(Data.ClientLastName);
            }
            else
            {
                MessageBox.Show("You need to enter Client's Id or Client's Last Name");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                Data.CarID = textBox3.Text.Trim();

                carsAll cars = new carsAll();
                cars.MdiParent = main.ActiveForm;
                cars.Show();

                cars.carsSearchId(Data.CarID);
            }
            else if (textBox4.Text != "")
            {
                Data.CarVIN = textBox4.Text.Trim();

                carsAll cars = new carsAll();
                cars.MdiParent = main.ActiveForm;
                cars.Show();

                cars.carsSearchVIN(Data.CarVIN);
            }
            else
            {
                MessageBox.Show("You need to enter Car's Id or Car's Last VIN");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                Data.OrderID = textBox5.Text.Trim();

                ordersAll orders = new ordersAll();
                orders.MdiParent = main.ActiveForm;
                orders.Show();

                orders.ordersSearchId(Data.OrderID);
            }
            else if (comboBox1.Text != "")
            {
                switch (comboBox1.Text)
                {
                    case "in progress":
                        {
                            Data.OrderStatus = comboBox1.Text; break;
                        }
                    case "completed":
                        {
                            Data.OrderStatus = comboBox1.Text; break;
                        }
                    case "cancelled":
                        {
                            Data.OrderStatus = comboBox1.Text; break;
                        }
                    default:
                        {
                            Data.OrderStatus = ""; break;
                        }
                }

                ordersAll orders = new ordersAll();
                orders.MdiParent = main.ActiveForm;
                orders.Show();

                orders.ordersSearchStatus(Data.OrderStatus);
            }
            else
            {
                MessageBox.Show("You need to enter Order's Id or choose Order's Status");
                return;
            }
        }

        private void search_Activated(object sender, EventArgs e)
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

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (textBox1.Text != "")
                    {
                        Data.ClientID = textBox1.Text.Trim();

                        clientsAll clients = new clientsAll();
                        clients.MdiParent = main.ActiveForm;
                        clients.Show();

                        clients.clientsSearchId(Data.ClientID);

                    }
                    else
                    {
                        MessageBox.Show("You need to enter Client's Id");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (textBox2.Text != "")
                    {
                        Data.ClientLastName = textBox2.Text.Trim();

                        clientsAll clients = new clientsAll();
                        clients.MdiParent = main.ActiveForm;
                        clients.Show();

                        clients.clientsSearchLastName(Data.ClientLastName);
                    }
                    else
                    {
                        MessageBox.Show("You need to enter Client's Last Name");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (textBox3.Text != "")
                    {
                        Data.CarID = textBox3.Text.Trim();

                        carsAll cars = new carsAll();
                        cars.MdiParent = main.ActiveForm;
                        cars.Show();

                        cars.carsSearchId(Data.CarID);
                    }
                    else
                    {
                        MessageBox.Show("You need to enter Car's Id");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (textBox4.Text != "")
                    {
                        Data.CarVIN = textBox4.Text.Trim();

                        carsAll cars = new carsAll();
                        cars.MdiParent = main.ActiveForm;
                        cars.Show();

                        cars.carsSearchVIN(Data.CarVIN);
                    }
                    else
                    {
                        MessageBox.Show("You need to enter Car's VIN");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (textBox5.Text != "")
                    {
                        Data.OrderID = textBox5.Text.Trim();

                        ordersAll orders = new ordersAll();
                        orders.MdiParent = main.ActiveForm;
                        orders.Show();

                        orders.ordersSearchId(Data.OrderID);
                    }
                    else
                    {
                        MessageBox.Show("You need to enter Order's Id");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    if (comboBox1.Text != "")
                    {
                        switch (comboBox1.Text)
                        {
                            case "in progress":
                                {
                                    Data.OrderStatus = comboBox1.Text; break;
                                }
                            case "completed":
                                {
                                    Data.OrderStatus = comboBox1.Text; break;
                                }
                            case "cancelled":
                                {
                                    Data.OrderStatus = comboBox1.Text; break;
                                }
                            default:
                                {
                                    Data.OrderStatus = ""; break;
                                }
                        }

                        ordersAll orders = new ordersAll();
                        orders.MdiParent = main.ActiveForm;
                        orders.Show();

                        orders.ordersSearchStatus(Data.OrderStatus);
                    }
                    else
                    {
                        MessageBox.Show("You need to enter Order's Id or choose Order's Status");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
