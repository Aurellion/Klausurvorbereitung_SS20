using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace Klausurvorbereitung_SS20
{
    class Dreieck
    {
        double x, y, vx, vy;
        Polygon umriss;
        public Dreieck(Canvas Zeichenflaeche, double x, double y)
        {
            this.x = x;
            this.y = y;
            vy = 0;
            vx = 50;
            umriss = new Polygon();
            umriss.Points.Add(new Point(0,20));
            umriss.Points.Add(new Point(5,7));
            umriss.Points.Add(new Point(-5,7));
            umriss.Fill = Brushes.Gray;
        }

        public void Zeichne(Canvas Zeichenflaeche)
        {
            double winkelInGrad = Math.Atan2(vy, vx) * 180 / Math.PI -90;
            umriss.RenderTransform = new RotateTransform(winkelInGrad);
            Canvas.SetTop(umriss, y);
            Canvas.SetLeft(umriss, x);
            Zeichenflaeche.Children.Add(umriss);
        }

        public void Bewegen(TimeSpan intervall, Canvas Zeichenflaeche)
        {
            x += intervall.TotalSeconds * vx;
            y += intervall.TotalSeconds * vy;

            if (x < 0) x = Zeichenflaeche.ActualWidth;
            if (x > Zeichenflaeche.ActualWidth) x = 0;
            if (y < 0) y = Zeichenflaeche.ActualHeight;
            if (y > Zeichenflaeche.ActualHeight) y = 0;
        }

        public void RichtungAendern(int Richtung)
        {
            switch (Richtung)
            {
                case 0:
                    vx = -50;
                    vy = 0;
                    break;
                case 1:
                    vx = 50;
                    vy = 0;
                    break;
                case 2:
                    vx = 0;
                    vy = -50;
                    break;
                case 3:
                    vx = 0;
                    vy = 50;
                    break;
            }
        }
    }
}
