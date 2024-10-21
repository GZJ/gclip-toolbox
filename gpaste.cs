using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        try
        {
            List<string> result = new List<string>();
            StringCollection fileDropList = Clipboard.GetFileDropList();

            if (fileDropList != null && fileDropList.Count > 0)
            {
                foreach (
                    string destinationFolderPath in args.Length > 0
                        ? args
                        : new[] { Directory.GetCurrentDirectory() }
                )
                {
                    foreach (string sourceFilePath in fileDropList)
                    {
                        string destinationFilePath = Path.Combine(
                            destinationFolderPath,
                            Path.GetFileName(sourceFilePath)
                        );
                        destinationFilePath = Path.GetFullPath(destinationFilePath);
                        if (!IsValidPath(destinationFolderPath) || !IsValidPath(sourceFilePath))
                        {
                            continue;
                        }

                        File.Copy(sourceFilePath, destinationFilePath, true);
                        result.Add($"\"{sourceFilePath}\",\"{destinationFilePath}\"");
                    }
                }

                Console.WriteLine("src,dst");
                Console.WriteLine(string.Join("\n", result));
                Environment.ExitCode = 0;
            }
            else
            {
                Console.WriteLine("Clipboard does not contain a list of files.");
                Environment.ExitCode = 1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occurred: " + ex.Message);
            Environment.ExitCode = 1;
        }
    }

    static bool IsValidPath(string path)
    {
        return Directory.Exists(path) || File.Exists(path);
    }
}
