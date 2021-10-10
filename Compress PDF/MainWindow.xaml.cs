using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WinForms = System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;

namespace Compress_PDF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string DST = "C:\\Program Files\\gs\\";
        public static string SRC = @".\gs\";
        public static string command;
        public static string saveFile;

        private void Button_Click(object sender, RoutedEventArgs e)
        {                  
            DirectoryInfo srcDirectory = new DirectoryInfo(SRC);
            DirectoryInfo dstDirectory = new DirectoryInfo(DST);

            if (!dstDirectory.Exists)
            {
                dstDirectory.Create();
            }
            if(dstDirectory.Exists)
            {
               MessageBox.Show("Программа уже устпновлена!");
               return;
            }

            Install install = new Install();          
            install.CopyDir(srcDirectory.ToString(), dstDirectory.ToString());

            Thread thread = new Thread(install.SetVariable);
            thread.Start();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Uninstall.uninstall();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFilePDF = new OpenFileDialog();
            openFilePDF.Filter = "Формат pdf(*.pdf)|*.pdf";
            openFilePDF.Title = "Выберете файл";
            openFilePDF.Multiselect = true;

            if (openFilePDF.ShowDialog() != null)
            {
                string[] arrFiles = openFilePDF.FileNames;
               
                foreach (var file in arrFiles)
                {

                    command = @"ps2pdf -dPDFSETTINGS#/screen " + "\"" + file + "\"";// + " " + saveFile + "\"" + s;
                    startCompres();
                }
            }
        }
       
      
        public void startCompres()
        {          
            var proc = new ProcessStartInfo();
            {
                proc.UseShellExecute = true;
                proc.WorkingDirectory = @"C:\Windows\System32";
                proc.FileName = @"C:\Windows\System32\cmd.exe";
                proc.Arguments = "/C " + command;
                proc.WindowStyle = ProcessWindowStyle.Hidden;
            };

            Process.Start(proc);

            Thread.Sleep(1000);

         
        }
    } 
}
