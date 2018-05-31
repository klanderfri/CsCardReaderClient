using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace CsCardReaderClient.Connectivity
{
    public class Connection
    {
        public static string MakePostRequest(string uri, string parameters)
        {
            //Implemented as suggested at
            //https://stackoverflow.com/a/21051864/1997617

            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                return wc.UploadString(uri, parameters);
            }
        }

        public static string MakeGetRequest(string uri)
        {
            var brandURI = new Uri(uri);
            var request = (HttpWebRequest)WebRequest.Create(brandURI);
            var response = request.GetResponse() as HttpWebResponse;

            using (var stream = response.GetResponseStream())
            {
                var reader = new StreamReader(stream, Encoding.UTF8);
                var responseString = reader.ReadToEnd();

                return responseString;
            }
        }

        public static bool DownloadImage(string targetURL, string destinationFilepath, ImageFormat destinationImageType)
        {
            //Implemented as suggested at:
            //https://stackoverflow.com/a/24797679/1997617

            bool success = false;
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(targetURL);
            Bitmap bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(destinationFilepath, destinationImageType);
                success = true;
            }

            stream.Flush();
            stream.Close();
            client.Dispose();

            return success;
        }
    }
}
