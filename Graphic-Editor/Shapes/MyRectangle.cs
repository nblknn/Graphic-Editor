using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using Newtonsoft.Json;

namespace Graphic_Editor.Shapes {
    internal class MyRectangle : MyShape {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        private Rectangle drawnRectangle;

        public MyRectangle(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.point1 = startPoint;
            this.point2 = startPoint;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnRectangle = new Rectangle();
        }

        [JsonConstructor]
        public MyRectangle(Point point1, Point point2, Color outlineColor, Color fillColor, double outlineThickness) {
            this.point1 = point1;
            this.point2 = point2;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnRectangle = new Rectangle();
        }

        public override void Draw(Canvas canvas) {
            drawnRectangle.Height = Math.Abs(point2.Y - point1.Y);
            drawnRectangle.Width = Math.Abs(point2.X - point1.X);
            drawnRectangle.Stroke = new SolidColorBrush(outlineColor);
            drawnRectangle.Fill = new SolidColorBrush(fillColor);
            drawnRectangle.StrokeThickness = outlineThickness;
            canvas.Children.Add(drawnRectangle);
            Canvas.SetLeft(drawnRectangle, Math.Min(point1.X, point2.X));
            Canvas.SetTop(drawnRectangle, Math.Min(point1.Y, point2.Y));
        }

        public override void Redraw(Point nextPoint) {
            point2 = nextPoint;
            drawnRectangle.Height = Math.Abs(point2.Y - point1.Y);
            drawnRectangle.Width = Math.Abs(point2.X - point1.X);
            Canvas.SetLeft(drawnRectangle, Math.Min(point1.X, point2.X));
            Canvas.SetTop(drawnRectangle, Math.Min(point1.Y, point2.Y));
        }

        public override string ToString() {
            return "Прямоугольник";
        }
    }
}
