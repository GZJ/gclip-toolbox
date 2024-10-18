using System;
using System.Collections.Generic;
using System.Windows.Forms;

class ClipboardTypeDetector
{
    [STAThread]
    static void Main()
    {
        var formatMap = new Dictionary<string, string>
        {
            { DataFormats.Bitmap, "CF_BITMAP" },
            { DataFormats.Dib, "CF_DIB" },
            { DataFormats.EnhancedMetafile, "CF_ENHMETAFILE" },
            { DataFormats.FileDrop, "CF_FILEDROP" },
            { DataFormats.Html, "CF_HTML" },
            { DataFormats.Rtf, "CF_RTF" },
            { DataFormats.StringFormat, "CF_STRING" },
            { DataFormats.Text, "CF_TEXT" },
            { DataFormats.UnicodeText, "CF_UNICODETEXT" },
        };

        var foundFormats = new List<string>();

        foreach (var format in formatMap)
        {
            if (Clipboard.ContainsData(format.Key))
            {
                foundFormats.Add(format.Value);
            }
        }

        if (foundFormats.Count > 0)
        {
            Console.Write($"{string.Join(",", foundFormats)}");
        }
        else
        {
            Console.Write("");
        }
    }
}
