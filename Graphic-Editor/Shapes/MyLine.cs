using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using Newtonsoft.Json;

namespace Graphic_Editor.Shapes {
    internal class MyLine : MyShape {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        private Line drawnLine {  get; set; }

        public MyLine(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.point1 = startPoint;
            this.point2 = startPoint;
            this.outlineColor = outlineColor;
            this.outlineThickness = outlineThickness;
            drawnLine = new Line();
        }

        [JsonConstructor]
        public MyLine(Point point1, Point point2, Color color, double outlineThickness) {
            this.point1 = point1;
            this.point2 = point2;
            this.outlineColor = color;
            this.outlineThickness = outlineThickness;
            drawnLine = new Line();
        }

        public override void Draw(Canvas canvas) {
            drawnLine.X1 = point1.X;
            drawnLine.Y1 = point1.Y;
            drawnLine.X2 = point2.X;
            drawnLine.Y2 = point2.Y;
            drawnLine.Stroke = new SolidColorBrush(outlineColor);
            drawnLine.StrokeThickness = outlineThickness;
            canvas.Children.Add(drawnLine);
        }

        public override void Redraw(Point nextPoint) {
            point2 = nextPoint;
            drawnLine.X2 = point2.X;
            drawnLine.Y2 = point2.Y;
        }

        public override string ToString() {
            return "Прямая";
        }
    }
}
