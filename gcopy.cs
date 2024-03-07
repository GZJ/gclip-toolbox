using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;

class Program {
    [STAThread]
    static void Main(string[] args) {
        try {
            if (args.Length > 0) {
                StringCollection filePaths = new StringCollection();

                foreach(string arg in args) {
                    if (File.Exists(arg)) {
                        string fullPath = Path.GetFullPath(arg);
                        filePaths.Add(fullPath);
                        Console.WriteLine("File added: " + fullPath);
                    } else {
                        Console.WriteLine("File does not exist: " + arg);
                    }
                }

                Clipboard.SetFileDropList(filePaths);
            }

        } catch (Exception ex) {
            Console.WriteLine("An exception occurred: " + ex.Message);
        }
    }
}
