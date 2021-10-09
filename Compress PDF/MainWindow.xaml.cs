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

        public static string filePDF;
        public static string saveFile;

        private void Button_Click(object sender, RoutedEventArgs e)
        {       
            string DST = "C:\\Program Files\\gs\\";
            string SRC = @".\gs\";

            DirectoryInfo srcDirectory = new DirectoryInfo(SRC);
            DirectoryInfo dstDirectory = new DirectoryInfo(DST);

            if (!dstDirectory.Exists)
            {
                dstDirectory.Create();
            }
            if(dstDirectory.Exists)
            {
                label1.Content = "Программа уже устпновлена! ";
                return;
            }

            Install install = new Install();          
            
            Thread thread = new Thread(install.SetVariable);
            thread.Start();
            
            install.CopyDir(srcDirectory.ToString(), dstDirectory.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFilePDF = new OpenFileDialog();
            openFilePDF.Filter = "Формат pdf(*.pdf)|*.pdf";
            openFilePDF.Title = "Выберете файл";

            if (openFilePDF.ShowDialog() != null)
            {
                filePDF = openFilePDF.FileName;
            }           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {          
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "pdf files (*.pdf)|*.pdf";

            if (saveFileDialog.ShowDialog() != null)
            {               
                saveFile = saveFileDialog.FileName;
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            string command = @"ps2pdf -dPDFSETTINGS#/screen " + "\"" + filePDF + "\"" + " " + saveFile;

            var proc = new ProcessStartInfo();
            {
                proc.UseShellExecute = true;
                proc.WorkingDirectory = @"C:\Windows\System32";
                proc.FileName = @"C:\Windows\System32\cmd.exe";
                proc.Arguments = "/C " + command;
                proc.WindowStyle = ProcessWindowStyle.Hidden;
            };

            Process.Start(proc);
            
            Thread.Sleep(500);

            if (File.Exists(saveFile))
            {
                label1.Content = "Файл записан";
            }
            else
            {
                label1.Content = "Файл не записан";
            }

            filePDF = null;
            saveFile = null;
        }
    } 
}
