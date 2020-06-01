using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Klausurvorbereitung_SS20
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        List<Dreieck> Dreiecke = new List<Dreieck>();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(17);
            timer.Tick += Animiere;
        }

        private void Animiere(object sender, EventArgs e)
        {
            Zeichenflaeche.Children.Clear();
            foreach (Dreieck item in Dreiecke)
            {
                item.Zeichne(Zeichenflaeche);
                item.Bewegen(timer.Interval, Zeichenflaeche);
            }
        }

        private void BTN_Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            BTN_Start.IsEnabled = false;
            for (int i = 0; i < 20; i++)
            {
                double x, y;
                x = Zeichenflaeche.ActualWidth / 20 * i;
                y = Zeichenflaeche.ActualHeight / 20 * i;
                Dreiecke.Add(new Dreieck(Zeichenflaeche, x, y));
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer.IsEnabled)
            {
                switch (e.Key)
                {
                    case Key.Left:
                        Dreiecke.ForEach(x => x.RichtungAendern(0));
                        break;
                    case Key.Right:
                        Dreiecke.ForEach(x => x.RichtungAendern(1));
                        break;
                    case Key.Up:
                        Dreiecke.ForEach(x => x.RichtungAendern(2));
                        break;
                    case Key.Down:
                        Dreiecke.ForEach(x => x.RichtungAendern(3));
                        break;
                }
            }
        }
    }
}
