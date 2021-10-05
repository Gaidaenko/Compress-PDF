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
            
             string variableBin = "Path";
             string valueBin = ";C:\\Program Files\\gs\\bin;C:\\Program Files\\gs\\lib";

             string pach = Environment.GetEnvironmentVariable("Path");
             string addPach = pach + valueBin;

             Environment.SetEnvironmentVariable(variableBin, addPach, EnvironmentVariableTarget.Machine);


        }
    }
}
