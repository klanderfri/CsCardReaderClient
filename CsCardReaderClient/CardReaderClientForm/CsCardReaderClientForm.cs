using CsCardReaderClient.Connectivity;
using CsCardReaderClient.Helpers;
using System;
using System.Windows.Forms;

namespace CsCardReaderClient.CardReaderClientForm
{
    public partial class CsCardReaderClientForm : Form
    {
        private CsCardReaderClientController controller;
        private Card currentlyDisplayedCard;

        private Card CurrentlyDisplayedCard
        {
            get { return currentlyDisplayedCard; }
            set
            {
                if (value != null)
                {
                    currentlyDisplayedCard = value;
                }
            }
        }

        public CsCardReaderClientForm()
        {
            InitializeComponent();
            controller = new CsCardReaderClientController();
        }

        private void CsCardReaderClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.Dispose();
        }

        private void btn_fetchCard_Click(object sender, EventArgs e)
        {
            CurrentlyDisplayedCard = controller.FetchCardByID(tbx_multiverseID.Text, lbl_cardImage, pbx_cardImage);
        }

        private void btn_openImageFolder_Click(object sender, EventArgs e)
        {
            controller.OpenImageFolder(CurrentlyDisplayedCard?.ImagePath);
        }

        private void btn_openGathererWebpage_Click(object sender, EventArgs e)
        {
            Utilities.OpenGathererPage(CurrentlyDisplayedCard.MultiverseID);
        }

        private void btn_readMagicCard_Click(object sender, EventArgs e)
        {
            tbx_diskResults.Text = controller.ReadCard(pbx_extractedCardImage);
        }
        
        private void btn_testCardReading_Click(object sender, EventArgs e)
        {
            controller.ShowCardReadTest();
        }

        private void btn_openExePath_Click(object sender, EventArgs e)
        {
            Utilities.OpenExeFolder();
        }

        private void pbx_extractedCardImage_Click(object sender, EventArgs e)
        {
            controller.OpenImageFolder(pbx_extractedCardImage.ImageLocation);
        }

        private void btn_fetchGathererResult_Click(object sender, EventArgs e)
        {
            CurrentlyDisplayedCard = controller.UpdateGathererTab(tabControl1, lbl_cardImage, pbx_cardImage, tbx_multiverseID);
        }
    }
}
