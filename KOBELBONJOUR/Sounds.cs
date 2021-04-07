using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KOBELBONJOUR
{
    public class Sounds
    {

        private readonly string name;
        private readonly string path;
        private MediaPlayer player = new MediaPlayer();


        public Sounds(String name,String path)
        {
            this.name = name;
            this.path = path;
        }

        public void PlaySound()
        {
            Uri link = new Uri(path, UriKind.Relative);
            Debug.WriteLine(link);
            player.Open(link);
            player.Play();

        }

        public String GetName() { return name; }
        public Sounds GetSound() { return this; }
    }
}
