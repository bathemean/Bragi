using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;
using System.Threading;

namespace Bragi {
    class Program {
        static void Main(string[] args) {

            System.IO.File.Delete("C:\\Users\\Christian\\Dropbox\\Projects\\Bragi\\Bragi\\bin\\playlist.txt");

            RequestListener listener = new RequestListener("http://localhost:8080/");

            // Create listener thread
            Thread listenerThread = new Thread(new ThreadStart( listener.listen ));
            listenerThread.Start();

            //while (!listenerThread.IsAlive) ;

            //Thread.Sleep(1);

            Playlist list = Playlist.getInstance();
            //list.addToList("C:\\Users\\Christian\\Dropbox\\Projects\\Bragi\\Bragi\\bin\\tnt.mp3");
            //list.addToList("C:\\Users\\Christian\\Dropbox\\Projects\\Bragi\\Bragi\\bin\\monalisa.mp3");

            PlaylistXml pxml = new PlaylistXml();
            pxml.createPlaylistStack();

            Player player = new Player();

            player.loadFile(list.getNext());
            //player.play();

            /*Thread.Sleep(10000);
            player.loadFile(list.getNext());
            player.play();*/

            /*Console.WriteLine("Press a key to terminate.");
            Console.ReadKey();
            Environment.Exit(1);*/

            while(true) {

            }

        }
    }
}
