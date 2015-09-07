using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bragi {
    class Playlist {

        private static Playlist instance;

        private Stack<string> list = new Stack<string>();
        private string listPath = "playlist.xml";

        public Playlist() {

        }

        public static Playlist getInstance() {
            if (instance == null)
                instance = new Playlist();

            return instance;
        }

        public void addToList(string URL) {
            list.Push(URL);
        }

        public string getNext() {

            return "C:\\Users\\Christian\\Dropbox\\Projects\\Bragi\\Bragi\\bin\\monalisa.mp3";
        }

        private void writeTxt() {

            if(!File.Exists(this.listPath)) {
                using (StreamWriter sw = File.AppendText(listPath));
            } else {
                File.Delete(this.listPath);
            }

            using (StreamWriter sw = File.AppendText(this.listPath)) {
                foreach(string s in this.list) {
                    Console.WriteLine(s);
                    sw.WriteLine(s);
                }
            }

        }

        public string getListXml() {

            if (!File.Exists(this.listPath))
                throw new FileNotFoundException();

            return File.ReadAllText(this.listPath);

        }

    }
}
