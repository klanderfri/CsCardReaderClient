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
        private int IdOfCurrentlyDisplayedImage = 0;
        private Dictionary<int, Card> Cards = new Dictionary<int, Card>();

        public CsCardReaderClientForm()
        {
            InitializeComponent();
        }

        private void btn_fetchCard_Click(object sender, EventArgs e)
        {
            if (!tryGetCardID(out IdOfCurrentlyDisplayedImage)) { return; }

            var card = getCard(IdOfCurrentlyDisplayedImage);
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

        private void btn_openGathererWebpage_Click(object sender, EventArgs e)
        {
            var url = String.Format("http://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid={0}", IdOfCurrentlyDisplayedImage);
            Process.Start(url);
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

            var image = Image.FromFile(card.ImagePath);
            box.Size = new Size(image.Width, image.Height);

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
