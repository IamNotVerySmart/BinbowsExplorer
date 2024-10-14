using System.IO;
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

namespace BinbowsExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FileLogics fl = new FileLogics();
            DirectoryTreeView.ItemsSource = fl.loadDrives();
            FileListView.ItemsSource = fl.getFiles(@"C:\Users\dalone\Desktop");
            //DirectoryTreeView.ItemsSource = fl.getDirectories(@"C:\Users\dalone\Desktop");
        }
    }
}