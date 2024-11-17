using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BinbowsExplorer
{
    class UserInteractions : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private static string _currentPath = @"C:\Users\dalone\Desktop";
        public ObservableCollection<FileModel> Files { get; set; } = new ObservableCollection<FileModel>(new FileLogics().loadFilesAndDirectories(_currentPath));

        public string CurrentPath
        {
            get => _currentPath;
            set
            {
                _currentPath = value;
                OnPropertyChanged("DirectoryPath");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void updateView()
        {
            if (Directory.Exists(new FileModel().FilePath))
            {
                //UserInteractions uI = new UserInteractions();
                //FileLogics fl = new FileLogics();
                //uI.setDirectoryPath(directoryPath);
                //MainWindow.DirectoryTreeView.ItemsSource = fl.getDirectories(uI.getDirectoryPath());
                //FileListView.ItemsSource = fl.loadFilesAndDirectories(uI.getDirectoryPath());
            }
            else
            {
                MessageBox.Show("Directory not found!");
            }
        }
    }
}
