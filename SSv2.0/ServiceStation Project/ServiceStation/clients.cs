using System;
using System.Globalization;
using System.Windows.Forms;

namespace ServiceStation
{
    public partial class clients : Form
    {
        public clients()
        {
            InitializeComponent();
        }

        private void clientSearchToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Data.ClientName = firstnameToolStripTextBox.Text.Trim() + " " + lastnameToolStripTextBox.Text.Trim();
                clientSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.ClientID = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            cars cars = new cars();
            cars.MdiParent = ActiveForm;
            cars.Show();
        }

        internal void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.ClientID = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            clientEdit client = new clientEdit();
            client.MdiParent = ActiveForm;

            client.textBox1.Text = dataGridView1[1, 0].Value.ToString();
            client.textBox2.Text = dataGridView1[2, 0].Value.ToString();
            client.textBox3.Text = dataGridView1[3, 0].Value.ToString();
            client.textBox4.Text = dataGridView1[4, 0].Value.ToString();
            client.textBox6.Text = dataGridView1[5, 0].Value.ToString();
            client.textBox7.Text = dataGridView1[6, 0].Value.ToString();
            client.textBox8.Text = dataGridView1[7, 0].Value.ToString();
            client.textBox9.Text = dataGridView1[8, 0].Value.ToString();
            client.textBox10.Text = dataGridView1[9, 0].Value.ToString();

            client.Show();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clientSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
        }
        private void clientSearch()
        {
            if (this.clientsTableAdapter.ClientSearch(this.ssSQLite.Clients, CultureInfo.CurrentCulture.TextInfo.ToTitleCase
                (firstnameToolStripTextBox.Text.Trim()), CultureInfo.CurrentCulture.TextInfo.ToTitleCase
                (lastnameToolStripTextBox.Text.Trim())) == 0)
            {
                string message = "Would you like to add new client?";
                string caption = "No such client registered";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    clientAdd newClient = new clientAdd();
                    newClient.MdiParent = ActiveForm;
                    newClient.Show();
                }
            }
            else
            {
                main Main = (main)this.MdiParent;
                Main.toolStripButton2.Enabled = true;
                Main.toolStripButton3.Enabled = true;
                Main.toolStripButton4.Enabled = false;
                Main.toolStripButton5.Enabled = false;
                Main.toolStripButton7.Enabled = false;
                Main.toolStripButton6.Enabled = false;
                Main.toolStripButton9.Enabled = false;
            }
        }
        
        private void clients_Load(object sender, EventArgs e)
        {
            
        }

        private void clients_Activated(object sender, EventArgs e)
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
        
        private void lastnameToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    clientSearchToolStripButton_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void clients_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Return)
            {
                try
                {
                    clientSearchToolStripButton_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        } 
               
    }
}
