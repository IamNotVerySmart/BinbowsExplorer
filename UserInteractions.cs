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
using System.Windows.Threading;

namespace BinbowsExplorer
{
    class UserInteractions : INotifyPropertyChanged
    {
        private DispatcherTimer _debounceTimer;
        UserInteractions()
        {
            _debounceTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000) // Czas oczekiwania na zakończenie wpisywania przez użytkownika przed aktualizacją widoku
            };
            _debounceTimer.Tick += DebounceTimer_Tick;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private static string _currentPath = @"C:\"; // Domyślna ścieżka
        public static ObservableCollection<FileModel> Files { get; set; } = new ObservableCollection<FileModel>(new FileLogics().loadFilesAndDirectories(_currentPath));

        public string CurrentPath
        {
            get => _currentPath;
            set
            {
                _currentPath = value;
                OnPropertyChanged(nameof(CurrentPath)); // OnPropertyChanged, odświeżanie widoku

                _debounceTimer.Stop();
                _debounceTimer.Start();
            }
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            _debounceTimer.Stop(); // Zatrzymawanie timera
            updateFilesView(); // Odświeżenie widoku
        }

        private void updateFilesView()
        {
            if (Directory.Exists(_currentPath))
            {
                var files = new FileLogics().loadFilesAndDirectories(_currentPath);
                Files.Clear();
                foreach(var file in files)
                    Files.Add(file);
            }
            else
            {
                Files.Clear();
                Files.Add(new FileModel
                {
                    Name = "Directory not found!",
                    Type = "Error",
                    Size = 0,
                    FilePath = _currentPath
                });
            }
        }
    }
}
