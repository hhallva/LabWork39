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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            var result = files.Select(file => new { file.Name, file.CreationTime })
                              .Union(directories.Select(directory => new { directory.Name, directory.CreationTime }))
                              .ToList();

            resultDataGrid.ItemsSource = result;
        }
    }
}
