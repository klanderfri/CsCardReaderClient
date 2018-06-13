using CsCardReaderClient.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsCardReaderClient
{
    public class CsCardReaderClientController : IDisposable
    {
        private Dictionary<int, Card> Cards = new Dictionary<int, Card>();

        public void Dispose()
        {
            foreach (var card in Cards)
            {
                Directory.Delete(card.Value.ImageFolderPath, true);
            }
        }

        public Card FetchCard(string strMultiverseID, Label cardName, PictureBox cardImage)
        {
            var card = getCard(strMultiverseID);

            if (card != null)
            {
                cardName.Text = card.Name;
                Utilities.ShowImage(cardImage, card);
            }

            return card;
        }

        public void OpenImageFolder(string imagePath)
        {
            if (imagePath == null)
            {
                MessageBox.Show("No image has been shown yet!", "No displayed image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Utilities.OpenFolder(imagePath);
        }

        public void ShowCardReadTest()
        {
            int sum = MtgLibrary.GetMaxCardAmount();

            int maxLength = 300;
            byte[] result = new byte[maxLength];
            MtgLibrary.GetResultExample(result, maxLength);
            string str = Encoding.Default.GetString(result);

            MessageBox.Show(str, "Card Read Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string ReadCard(PictureBox box)
        {
            using (var decoder = new CardDecoder())
            {
                var cardName = decoder.Decode();
                Utilities.ShowImage(box, decoder.PathsToExtractedImages.FirstOrDefault());

                return cardName;
            }
        }

        private Card getCard(string strCardID)
        {
            int intCardID;
            if (!tryGetCardID(out intCardID, strCardID)) { return null; }

            return getCard(intCardID);
        }

        private Card getCard(int intCardID)
        {
            if (!Cards.ContainsKey(intCardID))
            {
                var newCard = new Card(intCardID);
                var gotCard = newCard.LoadData();

                if (!gotCard) { return null; }

                Cards.Add(intCardID, newCard);
            }

            var card = Cards[intCardID];
            return card;
        }

        private bool tryGetCardID(out int cardID, string strCardID)
        {
            cardID = 0;

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
    }
}
