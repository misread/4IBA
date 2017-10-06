using System;
using System.Windows.Forms;

namespace ServiceStation
{
    public partial class ordersAll : Form
    {
        public ordersAll()
        {
            InitializeComponent();
        }

        private void ordersAll_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ssSQLite.Orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.ssSQLite.Orders);
        }
        internal void ordersSearchId(object s)
        {
            label1.Text = "Search for Order by Id";

            ordersTableAdapter.FillById(ssSQLite.Orders, int.Parse(s.ToString()));
        }

        internal void ordersSearchStatus(object s)
        {
            label1.Text = "Search for Order by Status";

            ordersTableAdapter.FillByStatus(ssSQLite.Orders, s.ToString());
        }

        private void ordersAll_Activated(object sender, EventArgs e)
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

        private void ordersAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return)
            {
                this.Close();
            }
        }
    }
}
