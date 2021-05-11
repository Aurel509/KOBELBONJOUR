using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KOBELBONJOUR
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitSounds();
        }

        private readonly List<Sound> sounds = new List<Sound>();

        //All sounds
        private void InitSounds()
        {
            string path = System.Environment.CurrentDirectory + "\\sounds\\";
            System.IO.Directory.CreateDirectory("path");
            List<string> files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            foreach (string file in files)
            {
                string caca = Util.ReverseString(file).Split('\\')[0];
                Sound sound = new Sound(file.Substring(file.Length - caca.Length, caca.Length - 4), file.ToString());
                AddSound(sound);
            }

            foreach (Sound sound in sounds)
            {
                Console.WriteLine(sound.GetName() + " : " + sound.GetPath());
            }
        }
        private void AddSound(Sound sound)
        {
            sounds.Add(sound);
            Button btn = new Button();
            btn.Content = sound.GetName();
            btn.Click += new RoutedEventHandler(TriggerButton);
            btn.Width = 100;
            btn.Height = 100;
            btn.Margin = new Thickness(15, 15, 15, 15);

            list_buttons.Children.Add(btn);
        }

        //FONCTIONS DE SONS EN CARTON
        void TriggerButton(object sender, RoutedEventArgs e)
        {
            var btn = e.OriginalSource as Button;
            Sound sound = sounds.Find(x => x.GetName().Contains(btn.Content.ToString()));
            sound.Play();
        }
    }
}
