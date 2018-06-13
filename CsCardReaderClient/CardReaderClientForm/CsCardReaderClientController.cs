using CsCardReaderClient.Connectivity;
using CsCardReaderClient.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsCardReaderClient.CardReaderClientForm
{
    public class CsCardReaderClientController : IDisposable
    {
        private Dictionary<int, Card> Cards = new Dictionary<int, Card>();
        private Dictionary<string, int> NameToID = new Dictionary<string, int>();
        public string NameOfExtractedCard { get; private set; }

        public void Dispose()
        {
            foreach (var card in Cards)
            {
                Directory.Delete(card.Value.ImageFolderPath, true);
            }
        }

        public Card FetchCardByID(string strMultiverseID, Label cardNameLabel, PictureBox cardImageBox)
        {
            var card = getCardByID(strMultiverseID);
            showCard(cardNameLabel, cardImageBox, card);

            return card;
        }

        public Card FetchCardByName(string cardName, Label cardNameLabel, PictureBox cardImageBox)
        {
            if (String.IsNullOrWhiteSpace(cardName))
            {
                var message = "The card name cannot be null or whitespace!";
                var parameter = "cardName";

                throw (cardName == null) ?
                    new ArgumentNullException(parameter, message) :
                    new ArgumentException(message, parameter);
            }

            var card = getCardByName(cardName);
            showCard(cardNameLabel, cardImageBox, card);

            return card;
        }

        private void showCard(Label cardNameLabel, PictureBox cardImageBox, Card card)
        {
            if (card != null)
            {
                cardNameLabel.Text = card.Name;
                Utilities.ShowImage(cardImageBox, card);
            }
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

        public Card UpdateGathererTab(TabControl parentTabControl, Label cardNameLabel, PictureBox cardImageBox, TextBox MultiverseIdBox)
        {
            if (String.IsNullOrWhiteSpace(NameOfExtractedCard))
            {
                MessageBox.Show("No card has been extracted!", "No card extracted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var card = FetchCardByName(NameOfExtractedCard, cardNameLabel, cardImageBox);
            MultiverseIdBox.Text = Convert.ToString(card.MultiverseID);
            parentTabControl.SelectedIndex = 1;

            return card;
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
                var cardData = decoder.Decode();
                var cardToUse = decoder.PathsToExtractedImages.FirstOrDefault();
                Utilities.ShowImage(box, cardToUse.Value);
                NameOfExtractedCard = cardToUse.Key;

                return cardData;
            }
        }

        private Card getCardByID(string strCardID)
        {
            int intCardID;
            if (!tryGetCardID(out intCardID, strCardID)) { return null; }

            return getCard(intCardID);
        }

        private Card getCardByName(string cardName)
        {
            var name = cardName.ToLowerInvariant();
            if (NameToID.ContainsKey(name))
            {
                int multiverseID = NameToID[name];
                return Cards[multiverseID];
            }

            var newCard = new Card();
            var gotCard = newCard.LoadData(name);

            if (!gotCard) { return null; }

            Cards.Add(newCard.MultiverseID, newCard);
            NameToID.Add(name, newCard.MultiverseID);

            return newCard;
        }

        private Card getCard(int multiverseID)
        {
            if (!Cards.ContainsKey(multiverseID))
            {
                var newCard = new Card(multiverseID);
                var gotCard = newCard.LoadData();

                if (!gotCard) { return null; }

                Cards.Add(multiverseID, newCard);
                NameToID.Add(newCard.Name.ToLowerInvariant(), multiverseID);
            }

            var card = Cards[multiverseID];
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
