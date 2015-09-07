using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Bragi {
    class RequestListener {

        private HttpListener listener = new HttpListener();
        private string prefixes;

        public RequestListener(string prefixes) {
            this.prefixes = prefixes;
            this.listener.Start();
            Console.WriteLine("Listener has started.");
        }

        public void listen() {

            if (this.prefixes == null || this.prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            listener.Prefixes.Add(prefixes);

            Console.WriteLine("Listening has started");
            HttpListenerContext context = this.listener.GetContext();
            

            this.processRequest(context);
            
        }

        private void processRequest(HttpListenerContext context) {

            HttpListenerRequest request = context.Request;

            string method = request.HttpMethod;
            Uri URL = request.Url;
            string argument = URL.GetComponents(UriComponents.Path, UriFormat.SafeUnescaped);


            if(method == "GET") {
                
                switch (argument) {
                    case "library.xml":
                        this.sendLibrary(context);
                        break;
                    case "playlist.xml":
                        //this.sendPlaylist(context);
                        break;
                }

            } else if(method == "POST") {

            }

        }

        private void respond(HttpListenerContext context, string responseString) {
            //Console.WriteLine(context.Request.HttpMethod + " " + context.Request.Headers);
            
            HttpListenerResponse response = context.Response;

            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();

        }

        private void sendLibrary(HttpListenerContext context) {

        }

        private void sendPlaylist(HttpListenerContext context) {

            Playlist list = Playlist.getInstance();
            string responseString = list.getListXml();
            Console.Write(responseString);
            this.respond(context, responseString);

        }


        public void stopListener() {
            this.listener.Stop();
        }

    }
}
