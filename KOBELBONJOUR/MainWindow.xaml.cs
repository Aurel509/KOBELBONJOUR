using System;
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
        private readonly List<Sounds> sounds = new List<Sounds>();
        //All sounds

        private void InitSounds()
        {
            string path = System.Environment.CurrentDirectory;
            Sounds oof_sound = new Sounds("MINECRAFT OOF", path + "\\sounds\\oof.mp3");
            Sounds kourauh_sound = new Sounds("KOURAUH QUI GUEULE", path + "\\sounds\\kourauh.mp3");
            AddSound(oof_sound);
            AddSound(kourauh_sound);
        }
        private void AddSound(Sounds sound)
        {
            sounds.Add(sound);
            Button btn = new Button();
            btn.Content = sound.GetName();
            btn.Click += new RoutedEventHandler(TriggerButton); 
            
            list_buttons.Children.Add(btn);

        }

        //FONCTIONS DE SONS EN CARTON
        void TriggerButton(object sender, RoutedEventArgs e)
        {
            var btn = e.OriginalSource as Button;
            Sounds sound = sounds.Find(x => x.GetName().Contains(btn.Content.ToString()));
            sound.PlaySound();
        }
    }
}
