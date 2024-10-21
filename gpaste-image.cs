using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        string defaultFilename = $"clipboard_image_{DateTime.Now:yyyyMMdd_HHmmss}.png";
        string filename = args.Length > 0 ? args[0] : defaultFilename;

        if (Clipboard.ContainsImage())
        {
            Image clipboardImage = Clipboard.GetImage();
            clipboardImage.Save(filename, ImageFormat.Png);
            string fullPath = System.IO.Path.GetFullPath(filename);
            Environment.ExitCode = 0;
            Console.WriteLine(fullPath);
        }
        else
        {
            Console.WriteLine("No image found in the clipboard.");
            Environment.ExitCode = 1;
        }
    }
}
