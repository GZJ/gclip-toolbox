using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Text;
using System.Runtime.Serialization.Json;

class Program {
    [STAThread]
    static void Main(string[] args) {
        try {
            List < string > result = new List < string > ();

            StringCollection fileDropList = Clipboard.GetFileDropList();

            if (fileDropList != null && fileDropList.Count > 0) {

                bool resultAdded = false;
                foreach(string destinationFolderPath in args.Length > 0 ? args : new [] {
                    Directory.GetCurrentDirectory()
                }) {
                    foreach(string sourceFilePath in fileDropList) {
                        string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));
                        if (!IsValidPath(destinationFolderPath) || !IsValidPath(sourceFilePath)) {
                            continue;
                        }

                        File.Copy(sourceFilePath, destinationFilePath, true);
                        if (!resultAdded) {
                            result.Add(sourceFilePath);
                        }
                    }
                    resultAdded = true;
                }
            } else {
                Console.WriteLine("Clipboard does not contain a list of files.");
            }

            Console.WriteLine(string.Join("\n", result));
        } catch (Exception ex) {
            Console.WriteLine("An exception occurred: " + ex.Message);
        }
    }

    static bool IsValidPath(string path) {
        return Directory.Exists(path) || File.Exists(path);
    }
}
