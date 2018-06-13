using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsCardReaderClient.Helpers
{
    public class CardDecoder : IDisposable
    {
        public List<string> PathsToExtractedImages { get; private set; }

        public CardDecoder()
        {
            PathsToExtractedImages = new List<string>();
        }

        public void Dispose() { }

        public string Decode()
        {
            var myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var openFile = new OpenFileDialog()
            {
                Multiselect = false,
                Filter = "JPEG Files (*.jpg;*.jpeg)|*.JPG;*.JPEG",
                InitialDirectory = myPictures
            };

            var input = new StringBuilder();
            var outputFolder = Path.Combine(myPictures, "MtG Read Client");
            input.AppendFormat("0;1;1;0;{0};", outputFolder);
            
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFile.FileNames)
                {
                    input.AppendFormat("{0};", file);
                }
            }

            var inBytes = Encoding.ASCII.GetBytes(input.ToString());
            int maxLength = 3000;
            byte[] result = new byte[maxLength];
            MtgLibrary.ReadCardTitles(inBytes, result, maxLength);
            string str = Encoding.Default.GetString(result);

            var values = str.Split(';').Reverse().Skip(1).Reverse().ToList();
            var display = new StringBuilder();
            PathsToExtractedImages = new List<string>(values.Count / 5);
            for (int i = 0; i < values.Count; i += 5)
            {
                var extractedImagePath = Path.Combine(outputFolder, "Extracted Cards", Path.GetFileName(values[i]));
                PathsToExtractedImages.Add(extractedImagePath);

                display.AppendLine(String.Format("Card name: {0}", values[i + 1]));
                display.AppendLine(String.Format("Card type: {0}", getCardType(Convert.ToInt32(values[i + 2]))));
                display.AppendLine(String.Format("OCR confidence: {0}", Convert.ToInt32(values[i + 3])));
                display.AppendLine(String.Format("Success: {0}", Convert.ToBoolean(Convert.ToInt32(values[i + 4])) ? "True" : "False"));
                display.AppendLine();
            }

            return display.ToString();
        }

        private string getCardType(int titleType)
        {
            switch (titleType)
            {
                case 1:
                    return "NormalTitle";
                case 2:
                    return "SplitCardTitle";
                case 3:
                    return "AkhSplitCardTitle";
                case 4:
                    return "TransformedTitle";
                case 5:
                    return "FutureSightTitle";
                case 6:
                    return "AmonkhetInvocationsTitle";
                case 7:
                    return "Emblem";
                case 8:
                    return "Token";
                case 9:
                    return "Backside";
                case 10:
                    return "Commercial";
                default:
                    return "Unknown card type!";
            }
        }
    }
}
