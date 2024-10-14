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
        public List<FileModel> loadDrives()
        {
            var drives = Directory.GetLogicalDrives();
            var items = new List<FileModel>();

            foreach (var drive in drives)
            {
                //DriveInfo driveInfo = new DriveInfo(drive);
                items.Add(new FileModel
                {
                    Name = drive,//driveInfo.Name,
                    Type = "Drive",
                    Size = 0,//driveInfo.TotalSize,
                    Path = drive//driveInfo.Name
                });
            }
            return items;
        }

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
                        Path = dirInfo.FullName
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
                        Type = fileInfo.Name[fileInfo.Name.IndexOf(".")..fileInfo.Name.Length],
                        // może być to -> "fileInfo.Extension", ale ja chcę to /\
                        Size = fileInfo.Length,
                        Path = fileInfo.FullName
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
    }
}
