using System;
using System.Windows.Forms;

namespace ServiceStation
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void about_Activated(object sender, EventArgs e)
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

        private void about_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return)
            {
                this.Close();
            }
        }
    }
}
