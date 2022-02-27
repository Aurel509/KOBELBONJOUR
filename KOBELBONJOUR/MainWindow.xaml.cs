using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
        private Sound CurrentSound;

        //All sounds
        private void InitSounds()
        {
            string path = Environment.CurrentDirectory + "\\sounds\\";
            Directory.CreateDirectory("sounds");
            List<string> files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            foreach (string file in files)
            {
                string fileReversed = Util.ReverseString(file).Split('\\')[0];
                Sound sound = new Sound(file.Substring(file.Length - fileReversed.Length, fileReversed.Length - 4), file.ToString());
                AddSound(sound);
            }

            //test message//foreach (Sound sound in sounds) Console.WriteLine(sound.GetName() + " : " + sound.GetPath());
        }
        private void AddSound(Sound sound)
        {
            sounds.Add(sound);
            Button btn = new Button
            {
                Content = sound.GetName(),
                Width = 85,
                Height = 75,
                Margin = new Thickness(15, 15, 15, 15)
            };

            btn.Click += new RoutedEventHandler(TriggerButton);

            list_buttons.Children.Add(btn);
        }

        //FONCTIONS DE SONS EN CARTON
        void TriggerButton(object sender, RoutedEventArgs e)
        {
            if(CurrentSound != null && cancer_mode.IsChecked == false) CurrentSound.Stop();

            var btn = e.OriginalSource as Button;
            Sound sound = sounds.Find(x => x.GetName().Contains(btn.Content.ToString()));
            sound.Play();

            CurrentSound = sound;
        }

        private void StopAllSounds(object sender, RoutedEventArgs e)
        {
            foreach(Sound snd in sounds)
                snd.Stop();
        }

        private void AddNewSound(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("test ajout son");
        }
    }
}
