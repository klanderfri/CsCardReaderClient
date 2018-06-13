using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CsCardReaderClient.Containers
{
    public class Card
    {
        public int MultiverseID { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<string> SplitNames { get; protected set; }
        public string ImageFolderPath { get; protected set; }
        public string ImagePath { get; protected set; }
        public JToken Json { get; protected set; }
    }
}
