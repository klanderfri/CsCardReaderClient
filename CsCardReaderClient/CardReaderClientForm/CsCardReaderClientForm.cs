using CsCardReaderClient.Connectivity;
using CsCardReaderClient.Helpers;
using System;
using System.Windows.Forms;

namespace CsCardReaderClient.CardReaderClientForm
{
    public partial class CsCardReaderClientForm : Form
    {
        private CsCardReaderClientController Controller { get; set; }

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
        private Card currentlyDisplayedCard;

        public CsCardReaderClientForm()
        {
            InitializeComponent();
            Controller = new CsCardReaderClientController();
        }

        private void CsCardReaderClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Controller.Dispose();
        }

        private void btn_fetchCard_Click(object sender, EventArgs e)
        {
            CurrentlyDisplayedCard = Controller.FetchCardByID(tbx_multiverseID.Text, lbl_cardImage, pbx_cardImage);
        }

        private void btn_openImageFolder_Click(object sender, EventArgs e)
        {
            Controller.OpenImageFolder(CurrentlyDisplayedCard?.ImagePath);
        }

        private void btn_openGathererWebpage_Click(object sender, EventArgs e)
        {
            Utilities.OpenGathererPage(CurrentlyDisplayedCard.MultiverseID);
        }

        private void btn_readMagicCard_Click(object sender, EventArgs e)
        {
            tbx_diskResults.Text = Controller.ReadCard(pbx_extractedCardImage);
        }
        
        private void btn_testCardReading_Click(object sender, EventArgs e)
        {
            Controller.ShowCardReadTest();
        }

        private void btn_openExePath_Click(object sender, EventArgs e)
        {
            Utilities.OpenExeFolder();
        }

        private void pbx_extractedCardImage_Click(object sender, EventArgs e)
        {
            Controller.OpenImageFolder(pbx_extractedCardImage.ImageLocation);
        }

        private void btn_fetchGathererResult_Click(object sender, EventArgs e)
        {
            CurrentlyDisplayedCard = Controller.UpdateGathererTab(tabControl1, lbl_cardImage, pbx_cardImage, tbx_multiverseID);
        }
    }
}
