namespace CsCardReaderClient.CardReaderClientForm
{
    partial class CsCardReaderClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_fetchCard = new System.Windows.Forms.Button();
            this.tbx_multiverseID = new System.Windows.Forms.TextBox();
            this.lbl_multiverseID = new System.Windows.Forms.Label();
            this.pbx_cardImage = new System.Windows.Forms.PictureBox();
            this.lbl_cardImage = new System.Windows.Forms.Label();
            this.btn_openImageFolder = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg_cardReader = new System.Windows.Forms.TabPage();
            this.btn_fetchGathererResult = new System.Windows.Forms.Button();
            this.pbx_extractedCardImage = new System.Windows.Forms.PictureBox();
            this.tbx_diskResults = new System.Windows.Forms.TextBox();
            this.btn_readMagicCard = new System.Windows.Forms.Button();
            this.tpg_gatherFetcher = new System.Windows.Forms.TabPage();
            this.btn_openGathererWebpage = new System.Windows.Forms.Button();
            this.btn_openExePath = new System.Windows.Forms.Button();
            this.btn_testCardReading = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_cardImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpg_cardReader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_extractedCardImage)).BeginInit();
            this.tpg_gatherFetcher.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_fetchCard
            // 
            this.btn_fetchCard.Location = new System.Drawing.Point(11, 49);
            this.btn_fetchCard.Name = "btn_fetchCard";
            this.btn_fetchCard.Size = new System.Drawing.Size(175, 23);
            this.btn_fetchCard.TabIndex = 0;
            this.btn_fetchCard.Text = "Fetch Card";
            this.btn_fetchCard.UseVisualStyleBackColor = true;
            this.btn_fetchCard.Click += new System.EventHandler(this.btn_fetchCard_Click);
            // 
            // tbx_multiverseID
            // 
            this.tbx_multiverseID.Location = new System.Drawing.Point(86, 23);
            this.tbx_multiverseID.Name = "tbx_multiverseID";
            this.tbx_multiverseID.Size = new System.Drawing.Size(100, 20);
            this.tbx_multiverseID.TabIndex = 1;
            this.tbx_multiverseID.Text = "386616";
            // 
            // lbl_multiverseID
            // 
            this.lbl_multiverseID.AutoSize = true;
            this.lbl_multiverseID.Location = new System.Drawing.Point(8, 26);
            this.lbl_multiverseID.Name = "lbl_multiverseID";
            this.lbl_multiverseID.Size = new System.Drawing.Size(72, 13);
            this.lbl_multiverseID.TabIndex = 2;
            this.lbl_multiverseID.Text = "Multiverse ID:";
            // 
            // pbx_cardImage
            // 
            this.pbx_cardImage.Location = new System.Drawing.Point(266, 42);
            this.pbx_cardImage.Name = "pbx_cardImage";
            this.pbx_cardImage.Size = new System.Drawing.Size(223, 311);
            this.pbx_cardImage.TabIndex = 3;
            this.pbx_cardImage.TabStop = false;
            // 
            // lbl_cardImage
            // 
            this.lbl_cardImage.AutoSize = true;
            this.lbl_cardImage.Location = new System.Drawing.Point(263, 26);
            this.lbl_cardImage.Name = "lbl_cardImage";
            this.lbl_cardImage.Size = new System.Drawing.Size(64, 13);
            this.lbl_cardImage.TabIndex = 4;
            this.lbl_cardImage.Text = "Card Image:";
            // 
            // btn_openImageFolder
            // 
            this.btn_openImageFolder.Location = new System.Drawing.Point(11, 78);
            this.btn_openImageFolder.Name = "btn_openImageFolder";
            this.btn_openImageFolder.Size = new System.Drawing.Size(175, 23);
            this.btn_openImageFolder.TabIndex = 5;
            this.btn_openImageFolder.Text = "Open Image Folder";
            this.btn_openImageFolder.UseVisualStyleBackColor = true;
            this.btn_openImageFolder.Click += new System.EventHandler(this.btn_openImageFolder_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg_cardReader);
            this.tabControl1.Controls.Add(this.tpg_gatherFetcher);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 426);
            this.tabControl1.TabIndex = 6;
            // 
            // tpg_cardReader
            // 
            this.tpg_cardReader.Controls.Add(this.btn_fetchGathererResult);
            this.tpg_cardReader.Controls.Add(this.pbx_extractedCardImage);
            this.tpg_cardReader.Controls.Add(this.tbx_diskResults);
            this.tpg_cardReader.Controls.Add(this.btn_readMagicCard);
            this.tpg_cardReader.Location = new System.Drawing.Point(4, 22);
            this.tpg_cardReader.Name = "tpg_cardReader";
            this.tpg_cardReader.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_cardReader.Size = new System.Drawing.Size(589, 400);
            this.tpg_cardReader.TabIndex = 1;
            this.tpg_cardReader.Text = "Card Reader";
            this.tpg_cardReader.UseVisualStyleBackColor = true;
            // 
            // btn_fetchGathererResult
            // 
            this.btn_fetchGathererResult.Location = new System.Drawing.Point(167, 31);
            this.btn_fetchGathererResult.Name = "btn_fetchGathererResult";
            this.btn_fetchGathererResult.Size = new System.Drawing.Size(129, 55);
            this.btn_fetchGathererResult.TabIndex = 3;
            this.btn_fetchGathererResult.Text = "Fetch Gatherer Data";
            this.btn_fetchGathererResult.UseVisualStyleBackColor = true;
            this.btn_fetchGathererResult.Click += new System.EventHandler(this.btn_fetchGathererResult_Click);
            // 
            // pbx_extractedCardImage
            // 
            this.pbx_extractedCardImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbx_extractedCardImage.Location = new System.Drawing.Point(369, 117);
            this.pbx_extractedCardImage.Name = "pbx_extractedCardImage";
            this.pbx_extractedCardImage.Size = new System.Drawing.Size(212, 277);
            this.pbx_extractedCardImage.TabIndex = 2;
            this.pbx_extractedCardImage.TabStop = false;
            this.pbx_extractedCardImage.Click += new System.EventHandler(this.pbx_extractedCardImage_Click);
            // 
            // tbx_diskResults
            // 
            this.tbx_diskResults.Location = new System.Drawing.Point(8, 117);
            this.tbx_diskResults.Multiline = true;
            this.tbx_diskResults.Name = "tbx_diskResults";
            this.tbx_diskResults.Size = new System.Drawing.Size(355, 277);
            this.tbx_diskResults.TabIndex = 1;
            // 
            // btn_readMagicCard
            // 
            this.btn_readMagicCard.Location = new System.Drawing.Point(8, 31);
            this.btn_readMagicCard.Name = "btn_readMagicCard";
            this.btn_readMagicCard.Size = new System.Drawing.Size(129, 55);
            this.btn_readMagicCard.TabIndex = 0;
            this.btn_readMagicCard.Text = "Read Magic Card";
            this.btn_readMagicCard.UseVisualStyleBackColor = true;
            this.btn_readMagicCard.Click += new System.EventHandler(this.btn_readMagicCard_Click);
            // 
            // tpg_gatherFetcher
            // 
            this.tpg_gatherFetcher.Controls.Add(this.btn_openGathererWebpage);
            this.tpg_gatherFetcher.Controls.Add(this.btn_openExePath);
            this.tpg_gatherFetcher.Controls.Add(this.btn_testCardReading);
            this.tpg_gatherFetcher.Controls.Add(this.pbx_cardImage);
            this.tpg_gatherFetcher.Controls.Add(this.btn_openImageFolder);
            this.tpg_gatherFetcher.Controls.Add(this.lbl_cardImage);
            this.tpg_gatherFetcher.Controls.Add(this.btn_fetchCard);
            this.tpg_gatherFetcher.Controls.Add(this.lbl_multiverseID);
            this.tpg_gatherFetcher.Controls.Add(this.tbx_multiverseID);
            this.tpg_gatherFetcher.Location = new System.Drawing.Point(4, 22);
            this.tpg_gatherFetcher.Name = "tpg_gatherFetcher";
            this.tpg_gatherFetcher.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_gatherFetcher.Size = new System.Drawing.Size(589, 400);
            this.tpg_gatherFetcher.TabIndex = 0;
            this.tpg_gatherFetcher.Text = "The Gatherer";
            this.tpg_gatherFetcher.UseVisualStyleBackColor = true;
            // 
            // btn_openGathererWebpage
            // 
            this.btn_openGathererWebpage.Location = new System.Drawing.Point(11, 107);
            this.btn_openGathererWebpage.Name = "btn_openGathererWebpage";
            this.btn_openGathererWebpage.Size = new System.Drawing.Size(175, 23);
            this.btn_openGathererWebpage.TabIndex = 8;
            this.btn_openGathererWebpage.Text = "Open Gatherer Webpage";
            this.btn_openGathererWebpage.UseVisualStyleBackColor = true;
            this.btn_openGathererWebpage.Click += new System.EventHandler(this.btn_openGathererWebpage_Click);
            // 
            // btn_openExePath
            // 
            this.btn_openExePath.Location = new System.Drawing.Point(11, 210);
            this.btn_openExePath.Name = "btn_openExePath";
            this.btn_openExePath.Size = new System.Drawing.Size(175, 23);
            this.btn_openExePath.TabIndex = 7;
            this.btn_openExePath.Text = "Open exe Path";
            this.btn_openExePath.UseVisualStyleBackColor = true;
            this.btn_openExePath.Click += new System.EventHandler(this.btn_openExePath_Click);
            // 
            // btn_testCardReading
            // 
            this.btn_testCardReading.Location = new System.Drawing.Point(11, 181);
            this.btn_testCardReading.Name = "btn_testCardReading";
            this.btn_testCardReading.Size = new System.Drawing.Size(175, 23);
            this.btn_testCardReading.TabIndex = 6;
            this.btn_testCardReading.Text = "Test Card Reading";
            this.btn_testCardReading.UseVisualStyleBackColor = true;
            this.btn_testCardReading.Click += new System.EventHandler(this.btn_testCardReading_Click);
            // 
            // CsCardReaderClientForm
            // 
            this.AcceptButton = this.btn_fetchCard;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 426);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CsCardReaderClientForm";
            this.Text = "Magic: the Gathering - Information Fetcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CsCardReaderClientForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_cardImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpg_cardReader.ResumeLayout(false);
            this.tpg_cardReader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_extractedCardImage)).EndInit();
            this.tpg_gatherFetcher.ResumeLayout(false);
            this.tpg_gatherFetcher.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_fetchCard;
        private System.Windows.Forms.TextBox tbx_multiverseID;
        private System.Windows.Forms.Label lbl_multiverseID;
        private System.Windows.Forms.PictureBox pbx_cardImage;
        private System.Windows.Forms.Label lbl_cardImage;
        private System.Windows.Forms.Button btn_openImageFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg_gatherFetcher;
        private System.Windows.Forms.TabPage tpg_cardReader;
        private System.Windows.Forms.TextBox tbx_diskResults;
        private System.Windows.Forms.Button btn_readMagicCard;
        private System.Windows.Forms.Button btn_testCardReading;
        private System.Windows.Forms.PictureBox pbx_extractedCardImage;
        private System.Windows.Forms.Button btn_openExePath;
        private System.Windows.Forms.Button btn_fetchGathererResult;
        private System.Windows.Forms.Button btn_openGathererWebpage;
    }
}

