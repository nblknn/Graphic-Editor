using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Graphic_Editor.Shapes {
    internal class MyEllipse : MyShape {
        public int height { get; set; }
        public int width { get; set; }
        public Point center { get; set; }

        public MyEllipse(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.height = 0;
            this.width = 0;
            this.center = startPoint;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
        }

        public MyEllipse(int height, int width, Point center, Color outlineColor, Color fillColor, double outlineThickness) {
            this.height = height;
            this.width = width;
            this.center = center;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
        }

        public override void Draw(Canvas canvas) {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Stroke = new SolidColorBrush(outlineColor);
            ellipse.Fill = new SolidColorBrush(fillColor);
            ellipse.StrokeThickness = outlineThickness;
            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, center.X - width / 2);
            Canvas.SetTop(ellipse, center.Y - height / 2);
        }
    }
}
