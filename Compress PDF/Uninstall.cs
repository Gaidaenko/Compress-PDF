using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Compress_PDF
{
    public static class Uninstall
    {
        public static void uninstall()
        {
            DirectoryInfo dstDirectory = new DirectoryInfo(MainWindow.DST);

            try
            {
                if (dstDirectory.Exists)
                {
                    Directory.Delete(MainWindow.DST, true);

                    MessageBox.Show("Программа удалена!");
                    return;
                }
                if (!dstDirectory.Exists)
                {
                    MessageBox.Show("Программа отсутствует или нельзя удалить!");
                }
            }
            catch (Exception d)
            {
                MessageBox.Show("Программа отсутствует или нельзя удалить!");
            }
        }    
    }
}
