using System.IO;
using System.Linq;
using System.Windows;

namespace Task3
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
            var result = files.GroupBy(file => new { file.CreationTime.Year, file.CreationTime.Month })
                              .Select(group => new
                              {
                                  Year = group.Key.Year,
                                  Month = group.Key.Month,
                                  FileCount = group.Count()
                              });

            resultDataGrid.ItemsSource = result;
        }
    }
}
