using CsCardReaderClient.Connectivity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CsCardReaderClient
{
    public class Utilities
    {
        public static void ShowImage(PictureBox box, Card card)
        {
            card.LoadImage();

            var image = Image.FromFile(card.ImagePath);
            box.Size = new Size(image.Width, image.Height);

            ShowImage(box, card.ImagePath);
        }

        public static void ShowImage(PictureBox box, string fullImagePath)
        {
            box.SizeMode = PictureBoxSizeMode.StretchImage;
            box.ImageLocation = fullImagePath;
        }

        public static void OpenFolder(string pathToOpen)
        {
            var folderPath = IsFolder(pathToOpen) ? pathToOpen : new FileInfo(pathToOpen).Directory.FullName;
            Process.Start(folderPath);
        }

        public static bool IsFolder(string path)
        {
            //Implemented as suggested at:
            //https://stackoverflow.com/a/1395226/1997617

            var attr = File.GetAttributes(path);
            var isFolderPath = attr.HasFlag(FileAttributes.Directory);

            return isFolderPath;
        }
    }
}
