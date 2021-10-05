using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Path = System.IO.Path;

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

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {       
            string DST = "C:\\Program Files\\gs\\";
            string SRC = "C:\\Users\\Yura\\source\\repos\\Compress PDF\\Compress PDF\\bin\\Release\\gs\\";

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
    }
}
