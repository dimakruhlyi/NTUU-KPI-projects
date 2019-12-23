using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace FtpClient
{
    public partial class MainWindow : Window
    {
        string prevAdress = "ftp://";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_connect_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем объект подключения по FTP
                Client client = new Client(txt_adres.Text, txt_login.Text, txt_password.Password);

                // Регулярное выражение, которое ищет информацию о папках и файлах 
                // в строке ответа от сервера
                Regex regex = new Regex(@"^([d-])([rwxt-]{3}){3}\s+\d{1,}\s+.*?(\d{1,})\s+(\w+\s+\d{1,2}\s+(?:\d{4})?)(\d{1,2}:\d{2})?\s+(.+?)\s?$",
                    RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                // Получаем список корневых файлов и папок
                // Используется LINQ to Objects и регулярные выражения
                List<FileDirectoryInfo> list = client.ListDirectoryDetails()
                                                     .Select(s =>
                                                     {
                                                         Match match = regex.Match(s);
                                                         if (match.Length > 5)
                                                         {
                                                             // Устанавливаем тип, чтобы отличить файл от папки (используется также для установки рисунка)
                                                             string type = match.Groups[1].Value == "d" ? "DIR.png" : "FILE.png";

                                                             // Размер задаем только для файлов, т.к. для папок возвращается
                                                             // размер ярлыка 4кб, а не самой папки
                                                             string size = "";
                                                             if (type == "FILE.png")
                                                                 size = (Int32.Parse(match.Groups[3].Value.Trim()) / 1024).ToString() + " кБ";

                                                             return new FileDirectoryInfo(size, type, match.Groups[6].Value, match.Groups[4].Value, txt_adres.Text);
                                                         }
                                                         else return new FileDirectoryInfo();
                                                     }).ToList();

                // Добавить поле, которое будет возвращать пользователя на директорию выше
                list.Add(new FileDirectoryInfo("","DEFAULT.png","...","",txt_adres.Text));
                list.Reverse();

                // Отобразить список в ListView
                lbx_files.DataContext = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + ": \n" + ex.Message);
            }
        }

        private void folder_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                FileDirectoryInfo fdi = (FileDirectoryInfo)(sender as StackPanel).DataContext;
                if (fdi.Type == "DIR.png")
                {
                    prevAdress = fdi.adress;
                    txt_adres.Text = fdi.adress + fdi.Name + "/";
                    btn_connect_Click_1(null, null);
                }
            }
        }
    }
}
