using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Path = System.IO.Path;
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace Compress_PDF
{
    public class Install
    {
       public void CopyDir(string copyFromDir, string copyToDir)
       {
            try
            {
                Directory.CreateDirectory(copyToDir);
                foreach (string s1 in Directory.GetFiles(copyFromDir))
                {
                    string s2 = copyToDir + "\\" + Path.GetFileName(s1);
                    File.Copy(s1, s2);
                }
                foreach (string s in Directory.GetDirectories(copyFromDir))
                {
                    CopyDir(s, copyToDir + "\\" + Path.GetFileName(s));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удается скопировать файлы в папку с установкой программы!");
            }
       }

        public void SetVariable()
        {
            try
            {
                string variableBin = "Path";
                string valueBin = ";C:\\Program Files\\gs\\bin;C:\\Program Files\\gs\\lib";

                string pach = Environment.GetEnvironmentVariable("Path");
                string addPach = pach + valueBin;

                Environment.SetEnvironmentVariable(variableBin, addPach, EnvironmentVariableTarget.Machine);

            }
            catch (Exception e)
            {
                MessageBox.Show("Не удается установить глобальные переменные");
            }
    
        }
        void CheckInstall()
        {

            if (File.Exists(@"C:\\Program Files\\gs\\"));
            {
                MessageBox.Show("Программа установлена. Перезагрузите компьютер!");
                return;
            }
            if (!File.Exists(@"C:\\Program Files\\gs\\"));
            {
                MessageBox.Show("Не удалось установить программу!");
            }
        }
    }
}
