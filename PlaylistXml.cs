using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Bragi {
    class PlaylistXml {

        private string listPath = "C:\\Users\\Christian\\Dropbox\\Projects\\Bragi\\Bragi\\bin\\playlist.xml";

        public Stack<string> createPlaylistStack() {

            Stack<string> listStack = new Stack<string>();
            string xml = File.ReadAllText(listPath);
            
            XDocument document = XDocument.Load(listPath);
            var query = from t in document.Root.Elements("track")
                        select new Track()
                        {
                            title = t.Element("title").Value,
                            location = t.Element("location").Value
                        };

            query.ToList();

            return listStack;

        }

    }
}
