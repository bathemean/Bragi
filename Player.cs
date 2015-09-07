using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bragi {
    class Player {

        private WMPLib.WindowsMediaPlayer player;

        public Player() {
            this.player = new WMPLib.WindowsMediaPlayer();
        }

        public void loadFile(string URL) {
            this.player.URL = URL;
        }

        public void play() {
            this.player.controls.play();
        }


    }
}
