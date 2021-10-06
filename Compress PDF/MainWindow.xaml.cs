using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;
using Microsoft.Win32;

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
                label1.Content = "Папка с установленной программой в C:\\Program Files уже существует! ";
                return;
            }

            Install install = new Install();
            install.CopyDir(srcDirectory.ToString(), dstDirectory.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFilePDF = new OpenFileDialog();
            openFilePDF.Filter = "Формат pdf(*.pdf)|*.pdf";
            openFilePDF.Title = "Выберете файл";

            if (openFilePDF.ShowDialog() == true)
            {
                filePDF = openFilePDF.FileName;
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

           

        }
    } 
}
