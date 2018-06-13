using CsCardReaderClient.Containers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace CsCardReaderClient.Connectivity
{
    public class IntelligentCard : Card
    {
        private const string SPLIT_CARD_SEPARATOR = " // ";
        private const string API_BASE_URI = "https://api.magicthegathering.io/v1/cards";

        public IntelligentCard(int multiverseID = 0)
        {
            MultiverseID = multiverseID;
        }

        public bool LoadData(string name = null)
        {
            return (name == null) ? loadData(MultiverseID) : loadData(name);
        }

        private bool loadData(int multiverseID)
        {
            var uri = String.Format("{0}/{1}", API_BASE_URI, multiverseID);
            return loadDataURI(uri, false);
        }

        private bool loadData(string name)
        {
            var fullName = name;
            if (name.Contains(SPLIT_CARD_SEPARATOR))
            {
                var names = name.Split(new[] { SPLIT_CARD_SEPARATOR }, StringSplitOptions.None);
                name = names[0];
            }

            var uri = String.Format("{0}?name={1}", API_BASE_URI, name);
            return loadDataURI(uri, true, fullName);
        }

        private bool loadDataURI(string uri, bool multipleCards, string cardname = null)
        {
            try
            {
                string htm_Result = Connection.MakeGetRequest(uri);
                var jsn_Result = JObject.Parse(htm_Result);

                if (multipleCards)
                {
                    var cards = jsn_Result["cards"];
                    foreach (var card in cards)
                    {
                        extractCardData(card);

                        if (hasFoundCorrectCard(cardname)) { break; }
                    }
                }
                else
                {
                    extractCardData(jsn_Result["card"]);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Error when loading card", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool hasFoundCorrectCard(string cardname)
        {
            if (cardname == null) { return true; }

            string foundCardName = null;
            var isSplitCard = cardname.Contains(SPLIT_CARD_SEPARATOR);
            if (isSplitCard)
            {
                if (!SplitNames.Any()) { return false; }
                foundCardName = String.Join(SPLIT_CARD_SEPARATOR, SplitNames).ToLowerInvariant();
            }
            else
            {
                foundCardName = Name.ToLowerInvariant();
            }
            if (foundCardName == cardname.ToLowerInvariant()) { return true; }

            return false;
        }

        private void extractCardData(JToken json)
        {
            Json = json;
            Name = (string)json["name"];
            SplitNames = Json["names"]?.ToObject<List<string>>() ?? new List<string>();
            MultiverseID = Convert.ToInt32(json["multiverseid"]);
        }

        public bool LoadImage()
        {
            //Do not reload images.
            if (ImagePath != null) { return true; }

            var imageUrl = (string)Json["imageUrl"];
            var imageFilename = String.Format("{0}.png", MultiverseID);
            ImagePath = getTempPath(imageFilename);
            var success = Connection.DownloadImage(imageUrl, ImagePath, ImageFormat.Png);

            return success;
        }

        private string getTempPath(string filename)
        {
            string parentTempFolder = Path.GetTempPath();
            string childTempFolder = Path.GetRandomFileName();

            if (ImageFolderPath == null)
            {
                do
                {
                    ImageFolderPath = Path.Combine(parentTempFolder, childTempFolder);

                } while (Directory.Exists(ImageFolderPath));

                Directory.CreateDirectory(ImageFolderPath);
            }

            return Path.Combine(ImageFolderPath, filename);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
