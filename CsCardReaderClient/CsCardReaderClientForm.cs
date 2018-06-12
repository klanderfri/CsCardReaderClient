using CsCardReaderClient.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsCardReaderClient
{
    public partial class CsCardReaderClientForm : Form
    {
        private string PathOfCurrentlyDisplayedImage = null;
        private Dictionary<int, Card> Cards = new Dictionary<int, Card>();

        public CsCardReaderClientForm()
        {
            InitializeComponent();
        }

        private void btn_fetchCard_Click(object sender, EventArgs e)
        {
            int cardID;
            if (!tryGetCardID(out cardID)) { return; }

            var card = getCard(cardID);
            lbl_cardImage.Text = card.Name;
            showImage(pbx_cardImage, card);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var card in Cards)
            {
                Directory.Delete(card.Value.ImageFolderPath, true);
            }
        }

        private void btn_openImageFolder_Click(object sender, EventArgs e)
        {
            if (PathOfCurrentlyDisplayedImage == null)
            {
                MessageBox.Show("No image has been shown yet!", "No displayed image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            openFolder(PathOfCurrentlyDisplayedImage);
        }

        private void openFolder(string pathToOpen)
        {
            var folderPath = isFolder(pathToOpen)? pathToOpen: new FileInfo(pathToOpen).Directory.FullName;
            Process.Start(folderPath);
        }

        private bool isFolder(string path)
        {
            //Implemented as suggested at:
            //https://stackoverflow.com/a/1395226/1997617

            var attr = File.GetAttributes(path);
            var isFolderPath = attr.HasFlag(FileAttributes.Directory);

            return isFolderPath;
        }

        private bool tryGetCardID(out int cardID)
        {
            cardID = 0;

            string strCardID = tbx_multiverseID.Text;
            if (String.IsNullOrWhiteSpace(strCardID))
            {
                MessageBox.Show("You have to enter a value!", "Empty value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Int32.TryParse(strCardID, out cardID))
            {
                MessageBox.Show("The value you entered was not a number!", "Not a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void showImage(PictureBox box, Card card)
        {
            card.LoadImage();
            showImage(box, card.ImagePath);
            PathOfCurrentlyDisplayedImage = card.ImagePath;
        }

        private void showImage(PictureBox box, string fullImagePath)
        {
            box.SizeMode = PictureBoxSizeMode.StretchImage;
            box.ImageLocation = fullImagePath;
        }
        
        private Card getCard(int intCardID)
        {
            if (!Cards.ContainsKey(intCardID))
            {
                var newCard = new Card(intCardID);
                newCard.LoadData();
                Cards.Add(intCardID, newCard);
            }

            var card = Cards[intCardID];
            return card;
        }
        
        private void btn_readMagicCard_Click(object sender, EventArgs e)
        {
            var decoder = new CardDecoder();
            tbx_diskResults.Text = decoder.Decode();
            showImage(pbx_extractedCardImage, decoder.PathsToExtractedImages.FirstOrDefault());
        }

        private List<CardTitle> extractCardTitles()
        {
            var myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var filename = Path.Combine(myPictures, "MtG-cards", "Image Data", "CardTitles.txt");

            var cardTitles = new List<CardTitle>();

            bool hasHandledFileHeader = false;
            using (var reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!hasHandledFileHeader)
                    {
                        hasHandledFileHeader = true;
                        continue;
                    }

                    char deliminator = '\t';
                    int size = line.Count(f => f == deliminator);
                    var values = new List<string>(size);

                    int index;
                    do
                    {
                        index = line.IndexOf(deliminator);
                        int length = (index < 0) ? line.Length : index;

                        var value = line.Substring(0, length);
                        values.Add(value);

                        line = line.Substring(index + 1);

                    } while (index >= 0);


                    CardTitle title = new CardTitle()
                    {
                        ImageFileName = values[0],
                        ImageFilePath = values[1],
                        CardName = values[2],
                        CardType = Convert.ToInt32(values[3]),
                        Confidence = Convert.ToInt32(values[4]),
                        Success = Convert.ToBoolean(Convert.ToUInt32(values[5]))
                    };
                    cardTitles.Add(title);
                }
            }

            return cardTitles;
        }

        private void btn_testCardReading_Click(object sender, EventArgs e)
        {
            int sum = MtgLibrary.GetMaxCardAmount();
            
            int maxLength = 300;
            byte[] result = new byte[maxLength];
            MtgLibrary.GetResultExample(result, maxLength);
            string str = Encoding.Default.GetString(result);

            MessageBox.Show(str, "Card Read Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_openExePath_Click(object sender, EventArgs e)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            MessageBox.Show(path, "Exe File Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
            openFolder(path);
        }
    }
}
