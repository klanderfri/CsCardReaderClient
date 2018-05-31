using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsCardReaderClient.Connectivity
{
    public class Card
    {
        public int MultiverseID { get; private set; }
        public string Name { get; private set; }
        public string ImageFolderPath { get; private set; }
        public string ImagePath { get; private set; }
        public JToken Json { get; private set; }
        
        public Card(int multiverseID)
        {
            MultiverseID = multiverseID;
        }

        public bool LoadData()
        {
            string uri = String.Format("https://api.magicthegathering.io/v1/cards/{0}", MultiverseID);
            string htm_Result = Connection.MakeGetRequest(uri);
            var jsn_Result = JObject.Parse(htm_Result);

            Json = jsn_Result["card"];
            Name = (string)Json["name"];

            return true;
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
    }
}
