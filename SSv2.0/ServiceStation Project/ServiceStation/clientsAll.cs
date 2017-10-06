using System;
using System.Windows.Forms;

namespace ServiceStation
{
    public partial class clientsAll : Form
    {
        public clientsAll()
        {
            InitializeComponent();
        }

        private void clientsAll_Load(object sender, EventArgs e)
        {
            clientsTableAdapter.Fill(ssSQLite.Clients);
        }

        internal void clientsSearchId(object s)
        {
            label1.Text = "Search for Client by Id";

            clientsTableAdapter.FillById(ssSQLite.Clients, int.Parse(s.ToString()));
        }

        internal void clientsSearchLastName(object s)
        {
            label1.Text = "Search for Client by Last Name";

            clientsTableAdapter.FillByLastName(ssSQLite.Clients, s.ToString());
        }

        private void clientsAll_Activated(object sender, EventArgs e)
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

        private void clientsAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return)
            {
                this.Close();
            }
        }
    }
}
