using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BinbowsExplorer
{
    class FileLogics
    {
        // Zwraca listę dysków w komputerze
        public List<FileModel> loadDrives()
        {
            var drives = Directory.GetLogicalDrives();
            var items = new List<FileModel>();

            foreach (var drive in drives)
            {
                DriveInfo driveInfo = new DriveInfo(drive);
                items.Add(new FileModel
                {
                    Name = drive,
                    Type = "Drive",
                    Size = 0,
                    FilePath = drive
                });
            }
            return items;
        }

        // Zwraca listę folderów z podanej ścieżki
        public List<FileModel> getDirectories(string directoryPath)
        {
            List<FileModel> items = new List<FileModel>();
            if (Directory.Exists(directoryPath))
            {
                var directories = Directory.GetDirectories(directoryPath);
                foreach (var dir in directories)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);
                    items.Add(new FileModel
                    {
                        Name = dirInfo.Name,
                        Type = "Folder",
                        Size = 0,
                        FilePath = dirInfo.FullName
                    });
                }
                return items;
            }
            else
            {
                MessageBox.Show("Directory not found!");
                return null;
            }
        }

        // Zwraca listę plików z podanej ścieżki
        public List<FileModel> getFiles(string directoryPath)
        {
            List<FileModel> items = new List<FileModel>();
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    items.Add(new FileModel
                    {
                        Name = fileInfo.Name,
                        Type = fileInfo.Extension,
                        Size = fileInfo.Length,
                        FilePath = fileInfo.FullName
                    });
                }
                return items;
            }
            else
            {
                MessageBox.Show("Directory not found!");
                return null;
            }
        }

        // Funkcja zwracająca listę plików oraz folderów z podanej ścieżki, wykorzystuje funkcję getDirectories oraz getFiles
        public List<FileModel> loadFilesAndDirectories(string directoryPath)
        {
            List<FileModel> items = new List<FileModel>();
            items.AddRange(getDirectories(directoryPath));
            items.AddRange(getFiles(directoryPath));
            return items;
        }
    }
}
