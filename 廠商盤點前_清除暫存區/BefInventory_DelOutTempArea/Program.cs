using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BefInventory_DelOutTempArea
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("新細明體", 9);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
