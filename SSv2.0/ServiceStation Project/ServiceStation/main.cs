using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Excel;

namespace ServiceStation
{
    public partial class main : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]

        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            clients clients = new clients();
            clients.MdiParent = this;
            clients.Show();

            clients.firstnameToolStripTextBox.Focus();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientsAll clients = new clientsAll();
            clients.MdiParent = this;
            clients.Show();
        }

        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carsAll cars = new carsAll();
            cars.MdiParent = this;
            cars.Show();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ordersAll orders = new ordersAll();
            orders.MdiParent = this;
            orders.Show();
        }

        private void aboutServiceStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.MdiParent = this;
            about.Show();
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
                
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            clientAdd newClient = new clientAdd();
            newClient.MdiParent = ActiveForm;
            newClient.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            clients tempChild = (clients)ActiveMdiChild;
            tempChild.editToolStripMenuItem_Click(tempChild, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            clients tempChild = (clients)ActiveMdiChild;

            Data.ClientID = tempChild.dataGridView1[0, tempChild.dataGridView1.CurrentRow.Index].Value.ToString();

            cars cars = new cars();
            cars.MdiParent = ActiveForm;
            cars.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            carAdd newCar = new carAdd();
            newCar.MdiParent = ActiveForm;
            newCar.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            cars tempChild = (cars)ActiveMdiChild;
            tempChild.deleteTheCarToolStripMenuItem_Click(tempChild,e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            cars tempChild = (cars)ActiveMdiChild;

            Data.CarID = tempChild.dataGridView1[0, tempChild.dataGridView1.CurrentRow.Index].Value.ToString();
            Data.Car = tempChild.dataGridView1[1, tempChild.dataGridView1.CurrentRow.Index].Value.ToString() + " " + tempChild.dataGridView1[2, tempChild.dataGridView1.CurrentRow.Index].Value.ToString() + " year " + tempChild.dataGridView1[3, tempChild.dataGridView1.CurrentRow.Index].Value.ToString();

            orders orders = new orders();
            orders.MdiParent = ActiveForm;
            orders.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            orderAdd newOrder = new orderAdd();
            newOrder.MdiParent = ActiveForm;
            newOrder.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search search = new search();
            search.MdiParent = ActiveForm;
            search.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            orders tempChild = (orders)ActiveMdiChild;
            tempChild.editOrderToolStripMenuItem_Click(tempChild, e);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            clients clients = new clients();
            clients.MdiParent = this;
            clients.Show();

            clients.firstnameToolStripTextBox.Focus();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                 printForm(this, e);
            }
        }

        private void captureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        private void printForm(object sender, EventArgs e)
        {
            captureScreen();
            printDocument1.Print();
        }
    }
}
