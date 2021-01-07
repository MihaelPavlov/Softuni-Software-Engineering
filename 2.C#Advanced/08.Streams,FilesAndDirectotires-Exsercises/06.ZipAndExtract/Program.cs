using System;
using System.IO;
using System.Linq;
using System.IO.Compression;
namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\USER\Desktop\CopyMe", @"D:\Downloads\myArchive.zip");
            ZipFile.ExtractToDirectory(@"D:\Downloads\myArchive.zip", @"D:\Downloads");
        }
    }
}
