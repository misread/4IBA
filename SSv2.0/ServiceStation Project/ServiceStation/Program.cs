using System;
using System.Windows.Forms;

namespace ServiceStation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login());
        }
    }

    static class Data
    {
        public static string ClientName { get; set; }
        public static string ClientID { get; set; }
        public static string CarID { get; set; }
        public static string Car { get; set; }

        public static string baseName = "ss.sqlite";

        public static int i = 0;
        public static string ClientLastName { get; set; }
        public static string CarVIN { get; set; }
        public static string OrderID { get; set; }
        public static string OrderStatus { get; set; }

    }
}
