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
            //Binding binding = new Binding();
            //binding.Source = new UserInteractions();

            //binding.Path = new PropertyPath("DirectoryPath");
            //binding.Mode = BindingMode.TwoWay;
            //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //directoryPath.SetBinding(TextBox.TextProperty, binding);

            //UserInteractions.DirectoryPath = @"C:\Users\dalone\Desktop\";
            //directoryPath.Text = Directory.GetLogicalDrives()[0];
            //updateView();
        }

        private void directoryPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //updateView();
                Keyboard.ClearFocus();
            }
        }
    }
}