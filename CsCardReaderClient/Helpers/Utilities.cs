using CsCardReaderClient.Connectivity;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CsCardReaderClient.Helpers
{
    public class Utilities
    {
        public static void ShowImage(PictureBox box, IntelligentCard card)
        {
            card.LoadImage();

            using (var image = Image.FromFile(card.ImagePath))
            {
                box.Size = new Size(image.Width, image.Height);
            }

            ShowImage(box, card.ImagePath);
        }

        public static void ShowImage(PictureBox box, string fullImagePath)
        {
            box.SizeMode = PictureBoxSizeMode.StretchImage;
            box.ImageLocation = fullImagePath;
        }

        public static bool IsFolder(string path)
        {
            //Implemented as suggested at:
            //https://stackoverflow.com/a/1395226/1997617

            var attr = File.GetAttributes(path);
            var isFolderPath = attr.HasFlag(FileAttributes.Directory);

            return isFolderPath;
        }

        public static void OpenFolder(string pathToOpen)
        {
            var folderPath = IsFolder(pathToOpen) ? pathToOpen : new FileInfo(pathToOpen).Directory.FullName;
            Process.Start(folderPath);
        }

        public static void OpenExeFolder()
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            MessageBox.Show(path, "Exe File Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFolder(path);
        }

        public static void OpenGathererPage(int cardID)
        {
            var url = String.Format("http://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid={0}", cardID);
            Process.Start(url);
        }
    }
}
