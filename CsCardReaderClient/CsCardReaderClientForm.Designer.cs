﻿namespace CsCardReaderClient
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
            this.tpg_gatherFetcher = new System.Windows.Forms.TabPage();
            this.tpg_readMagicCard = new System.Windows.Forms.TabPage();
            this.tbx_diskResults = new System.Windows.Forms.TextBox();
            this.btn_fetchResults = new System.Windows.Forms.Button();
            this.btn_testCardReading = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_cardImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tpg_gatherFetcher.SuspendLayout();
            this.tpg_readMagicCard.SuspendLayout();
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
            this.pbx_cardImage.Size = new System.Drawing.Size(159, 207);
            this.pbx_cardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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
            this.tabControl1.Controls.Add(this.tpg_gatherFetcher);
            this.tabControl1.Controls.Add(this.tpg_readMagicCard);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 426);
            this.tabControl1.TabIndex = 6;
            // 
            // tpg_gatherFetcher
            // 
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
            // tpg_readMagicCard
            // 
            this.tpg_readMagicCard.Controls.Add(this.tbx_diskResults);
            this.tpg_readMagicCard.Controls.Add(this.btn_fetchResults);
            this.tpg_readMagicCard.Location = new System.Drawing.Point(4, 22);
            this.tpg_readMagicCard.Name = "tpg_readMagicCard";
            this.tpg_readMagicCard.Padding = new System.Windows.Forms.Padding(3);
            this.tpg_readMagicCard.Size = new System.Drawing.Size(589, 400);
            this.tpg_readMagicCard.TabIndex = 1;
            this.tpg_readMagicCard.Text = "Card Reader Result";
            this.tpg_readMagicCard.UseVisualStyleBackColor = true;
            // 
            // tbx_diskResults
            // 
            this.tbx_diskResults.Location = new System.Drawing.Point(8, 117);
            this.tbx_diskResults.Multiline = true;
            this.tbx_diskResults.Name = "tbx_diskResults";
            this.tbx_diskResults.Size = new System.Drawing.Size(573, 277);
            this.tbx_diskResults.TabIndex = 1;
            // 
            // btn_fetchResults
            // 
            this.btn_fetchResults.Location = new System.Drawing.Point(234, 29);
            this.btn_fetchResults.Name = "btn_fetchResults";
            this.btn_fetchResults.Size = new System.Drawing.Size(129, 55);
            this.btn_fetchResults.TabIndex = 0;
            this.btn_fetchResults.Text = "Fetch Results from Disk";
            this.btn_fetchResults.UseVisualStyleBackColor = true;
            this.btn_fetchResults.Click += new System.EventHandler(this.btn_fetchResults_Click);
            // 
            // btn_testCardReading
            // 
            this.btn_testCardReading.Location = new System.Drawing.Point(32, 180);
            this.btn_testCardReading.Name = "btn_testCardReading";
            this.btn_testCardReading.Size = new System.Drawing.Size(175, 23);
            this.btn_testCardReading.TabIndex = 6;
            this.btn_testCardReading.Text = "Test Card Reading";
            this.btn_testCardReading.UseVisualStyleBackColor = true;
            this.btn_testCardReading.Click += new System.EventHandler(this.btn_testCardReading_Click);
            // 
            // InfoFetcherForm
            // 
            this.AcceptButton = this.btn_fetchCard;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 426);
            this.Controls.Add(this.tabControl1);
            this.Name = "InfoFetcherForm";
            this.Text = "Magic: the Gathering - Information Fetcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_cardImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tpg_gatherFetcher.ResumeLayout(false);
            this.tpg_gatherFetcher.PerformLayout();
            this.tpg_readMagicCard.ResumeLayout(false);
            this.tpg_readMagicCard.PerformLayout();
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
        private System.Windows.Forms.TabPage tpg_readMagicCard;
        private System.Windows.Forms.TextBox tbx_diskResults;
        private System.Windows.Forms.Button btn_fetchResults;
        private System.Windows.Forms.Button btn_testCardReading;
    }
}

