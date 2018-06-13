using CsCardReaderClient.Connectivity;
using System;
using System.Windows.Forms;

namespace CsCardReaderClient
{
    public partial class CsCardReaderClientForm : Form
    {
        private CsCardReaderClientController controller;
        private Card CurrentlyDisplayedCard;

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
            CurrentlyDisplayedCard = controller.FetchCard(tbx_multiverseID.Text, lbl_cardImage, pbx_cardImage);
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
    }
}
