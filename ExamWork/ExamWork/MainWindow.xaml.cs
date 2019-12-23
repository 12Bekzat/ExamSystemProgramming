using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ExamWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            StringNumber stringNumber = new StringNumber();

            for(int i = 0; i < 1000; i++)
            {
                ThreadPool.QueueUserWorkItem(stringNumber.AddNum, i);
            }

            var strIndex = new Indexer
            {
                Text = stringNumber.Text,
            };

            Task.Run(() => WriteFile(stringNumber.Text));
            //Task.Run(() => WriteDb(strIndex));

            MessageBox.Show(stringNumber.Text);
        }

        private async void WriteFile(string file)
        {
            using(var stream = new StreamWriter("i.txt"))
            {
                await stream.WriteLineAsync(file);
            }
        }

        private async void WriteDb(Indexer file)
        {
            using(var context = new Context())
            {
                context.Indexs.Add(file);
                await context.SaveChangesAsync();
            }
        }
    }
}
