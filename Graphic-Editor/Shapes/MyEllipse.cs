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
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        private Ellipse drawnEllipse;

        public MyEllipse(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            point1 = startPoint;
            point2 = startPoint;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnEllipse = new Ellipse();
        }

        public MyEllipse(Point point1, Point point2, Color outlineColor, Color fillColor, double outlineThickness) {
            this.point1 = point1;
            this.point2 = point2;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnEllipse = new Ellipse();
        }

        public override void Draw(Canvas canvas) {
            drawnEllipse.Height = Math.Abs(point2.Y - point1.Y);
            drawnEllipse.Width = Math.Abs(point2.X - point1.X);
            drawnEllipse.Stroke = new SolidColorBrush(outlineColor);
            drawnEllipse.Fill = new SolidColorBrush(fillColor);
            drawnEllipse.StrokeThickness = outlineThickness;
            canvas.Children.Add(drawnEllipse);
            Canvas.SetLeft(drawnEllipse, Math.Min(point1.X, point2.X));
            Canvas.SetTop(drawnEllipse, Math.Min(point1.Y, point2.Y));
        }

        public override void Redraw(Point nextPoint) {
            point2 = nextPoint;
            drawnEllipse.Height = Math.Abs(point2.Y - point1.Y);
            drawnEllipse.Width = Math.Abs(point2.X - point1.X);
            Canvas.SetLeft(drawnEllipse, Math.Min(point1.X, point2.X));
            Canvas.SetTop(drawnEllipse, Math.Min(point1.Y, point2.Y));
        }
    }
}
