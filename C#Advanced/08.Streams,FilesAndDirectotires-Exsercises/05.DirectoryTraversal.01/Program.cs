using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _05.DirectoryTraversal._01
{
    class Program
    {
        static void Main(string[] args)
        {


            var filesExtension = new Dictionary<string, Dictionary<string, long>>();


            //  var files = directory.GetFiles();//back file array
            var files = GetAllFilesFromDirectory(Environment.CurrentDirectory);

            foreach (var file in files)
            {
                var extension = file.Extension;

                if (!filesExtension.ContainsKey(extension))
                {
                    filesExtension.Add(extension, new Dictionary<string, long>());
                }
                filesExtension[extension].Add(file.Name, file.Length);
            }

            var sortedFilesByExtension = filesExtension
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            using (var streamWriter = new StreamWriter("../../../report.txt"))
            {
                foreach (var extension in sortedFilesByExtension)
                {
                    streamWriter.WriteLine(extension.Key);
                    var currentFiles = extension.Value
                        .OrderBy(x => x.Value)
                        .ToDictionary(x => x.Key, x => x.Value);

                    foreach (var file in currentFiles)
                    {
                        streamWriter.WriteLine($"--{file.Key} - {(file.Value / 1000.0):f3}KB");
                    }

                }
            }

        }

        private static List<FileInfo> GetAllFilesFromDirectory(string path)
        {
            var rootDirectory = new DirectoryInfo(path);

            var allFiles = new List<FileInfo>();
            var files = rootDirectory.GetFiles();

            allFiles.AddRange(files);

            var subDirectories = rootDirectory.GetDirectories();

            foreach (var directory in subDirectories)
            {

                var subFiles = GetAllFilesFromDirectory(directory.FullName);
                allFiles.AddRange(subFiles);

            }

            return allFiles;
        }
    }
}
