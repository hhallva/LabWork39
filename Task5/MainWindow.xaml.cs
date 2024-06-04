using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace Task5
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
            var result = directories.GroupJoin(files,
            directory => directory.Name,
            file => Directory.GetParent(file.FullName).Name,
            (directory, fileGroup) => new { DirectoryName = directory.Name, FilesCount = fileGroup.Count() });

            resultDataGrid.ItemsSource = result;
        }
    }
}
