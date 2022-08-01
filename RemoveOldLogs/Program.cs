using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveOldLogs
{
    class Program
    {
        private const string ZipLocation = @"C:\Users\blaec\Downloads\zip_test\";
        private static readonly string OldZipLocation = $"{ZipLocation}old_zips{Path.DirectorySeparatorChar}";

        /// <summary>
        /// Move old zip files to directory another directory for further review and removing
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Directory.CreateDirectory(OldZipLocation);
            string[] zipFiles = Directory.GetFiles(ZipLocation, "*.zip", SearchOption.AllDirectories);
            foreach (var zipFile in zipFiles)
            {
                string logFile = zipFile.Replace(".zip", ".log");
                if (File.Exists(logFile))
                {
                    File.Move(zipFile, $"{OldZipLocation}{Path.GetFileName(zipFile)}");
                }
            }
        }
    }
}