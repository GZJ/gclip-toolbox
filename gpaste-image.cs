using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Specialized;

class Program {

    [STAThread]
    static void Main(string[] args) {
        string defaultFilename = "clipboard_image.png";
        string filename = args.Length > 0 ? args[0] : defaultFilename;

        if (Clipboard.ContainsImage()) {
            Image clipboardImage = Clipboard.GetImage();
            clipboardImage.Save(filename, ImageFormat.Png);
            Console.WriteLine("Image saved successfully.");
        } else {
            Console.WriteLine("No image found in the clipboard.");
        }
    }
}
