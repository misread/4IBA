using System;
using System.Windows.Forms;

namespace ServiceStation
{
    public partial class carsAll : Form
    {
        public carsAll()
        {
            InitializeComponent();
        }

        private void carsAll_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ssSQLite.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.ssSQLite.Cars);
        }
        internal void carsSearchId(object s)
        {
            label1.Text = "Search for Car by Id";

            carsTableAdapter.FillById(ssSQLite.Cars, int.Parse(s.ToString()));
        }

        internal void carsSearchVIN(object s)
        {
            label1.Text = "Search for Car by VIN";

            carsTableAdapter.FillByVIN(ssSQLite.Cars, s.ToString());
        }

        private void carsAll_Activated(object sender, EventArgs e)
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

        private void carsAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return)
            {
                this.Close();
            }
        }
    }
}
