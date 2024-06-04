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
using static System.Net.WebRequestMethods;

namespace Task4
{
    public partial class MainWindow : Window
    {
        public FileInfo[] files;
        public DirectoryInfo[] directories;

        public MainWindow()
        {
            InitializeComponent();
            GetFiles();
            OutputFiles();
        }

        private void GetFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(DirectoryTextBox.Text);
            files = directory.GetFiles("*", SearchOption.AllDirectories);
            directories = directory.GetDirectories("*", SearchOption.AllDirectories);
        }

        public void OutputFiles()
        {
            DateTime today = DateTime.Today.Date;
            var todayDirectories = directories.Where(directory => directory.CreationTime.Date ==today).ToList();

            var result = files.Join(todayDirectories,
                                    file => Directory.GetParent(file.FullName).Name,
                                    directory => directory.Name,
                                    (file, directory) => new { file.Name, directory.CreationTime });

            resultDataGrid.ItemsSource = result;
        }
    }
}
