﻿using CsCardReaderClient.Connectivity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
            showImage(card);
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

            var folderPath = new FileInfo(PathOfCurrentlyDisplayedImage).Directory.FullName;
            Process.Start(folderPath);
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

        private void showImage(Card card)
        {
            card.LoadImage();
            pbx_cardImage.ImageLocation = card.ImagePath;
            PathOfCurrentlyDisplayedImage = card.ImagePath;
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

        //Image file name	Image file path	Card name	Card type	OCR confidence	Success


        private void btn_fetchResults_Click(object sender, EventArgs e)
        {
            var cards = extractCardTitles();

            int totalConfidence = cards.Sum(c => c.Confidence);
            int lowestConfidence = cards.Min(c => c.Confidence);
            double averageConfidens = totalConfidence / (double)cards.Count;
            bool wasSuccessful = (cards.FindIndex(c => !c.Success) < 0);

            var message = new StringBuilder();
            message.AppendLine(String.Format("Total confidence: {0}", totalConfidence));
            message.AppendLine(String.Format("Lowest confidence: {0}", lowestConfidence));
            message.AppendLine(String.Format("Average confidence: {0}", averageConfidens));
            message.AppendLine(String.Format("Read was successful: {0}", wasSuccessful ? "Yes" : "No"));

            tbx_diskResults.Text = message.ToString();
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
            //long maxAmount = MtgLibrary.GetMaxCardAmount();

            //string testResult = "";
            //MtgLibrary.GetResultExample(testResult, 1000);

            int sum = MtgLibrary.GetMaxCardAmount();

            //int maxLength = 300;
            //string result = "";
            //IntPtr strPtr = Marshal.StringToHGlobalUni(result);
            //string nullStrPtr = Marshal.PtrToStringAuto(strPtr);
            //IntPtr str = MtgLibrary.GetString(strPtr, maxLength);
            //string str1 = Marshal.PtrToStringAuto(strPtr);
            //string str2 = Marshal.PtrToStringAuto(str);

            int maxLength = 300;
            byte[] result = new byte[maxLength];
            MtgLibrary.GetResultExample(result, maxLength);
            string str = Encoding.Default.GetString(result);
        }
    }
}
