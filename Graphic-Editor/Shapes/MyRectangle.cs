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
    internal class MyRectangle : MyShape {
        public Point point1 { get; set; }
        public Point point2 { get; set; }

        public MyRectangle(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.point1 = startPoint;
            this.point2 = startPoint;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
        }

        public MyRectangle(Point point1, Point point2, Color outlineColor, Color fillColor, double outlineThickness) {
            this.point1 = point1;
            this.point2 = point2;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
        }

        public override void Draw(Canvas canvas) {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = Math.Abs(point2.Y - point1.Y);
            rectangle.Width = Math.Abs(point2.X - point1.X);
            rectangle.Stroke = new SolidColorBrush(outlineColor);
            rectangle.Fill = new SolidColorBrush(fillColor);
            rectangle.StrokeThickness = outlineThickness;
            canvas.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, Math.Min(point1.X, point2.X));
            Canvas.SetTop(rectangle, Math.Min(point1.Y, point2.Y));
        }
    }
}
