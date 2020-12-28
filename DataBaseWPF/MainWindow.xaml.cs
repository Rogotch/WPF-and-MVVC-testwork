using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using DataBaseWPF.Models;
using Microsoft.Win32;

namespace DataBaseWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
            {
                Brigade.Text = "Бригада 1";
            }
            else
            {
                Brigade.Text = "Бригада 2";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = $"\"City\":\"{City.Text}\"" +
                       $"\n\"Shop\":\"{Shop.Text}\"" +
                       $"\n\"Worker\":\"{Worker.Text}\"" +
                       $"\n\"Brigade\":\"{Brigade.Text}\"" +
                       $"\n\"Shift\":\"{Shift.Text}\"";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, text);
            }

        }
    }
}
