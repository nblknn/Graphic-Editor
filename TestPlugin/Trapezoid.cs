using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Graphic_Editor.Shapes;
using Newtonsoft.Json;

namespace TestPlugin {
    public class Trapezoid : MyShape {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        private Polygon drawnTrapezoid;

        public Trapezoid(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            point1 = startPoint;
            point2 = startPoint;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnTrapezoid = new Polygon() {
                Stroke = new SolidColorBrush(outlineColor),
                Fill = new SolidColorBrush(fillColor),
                StrokeThickness = outlineThickness
            };
        }

        [JsonConstructor]
        public Trapezoid(Point point1, Point point2, Color outlineColor, Color fillColor, double outlineThickness) : this(point1, outlineColor, fillColor, outlineThickness) {
            this.point2 = point2;
        }

        private PointCollection CalcPoints() {
            PointCollection points = new PointCollection() {
                new Point(Math.Min(point1.X, point2.X), point1.Y),
                new Point(Math.Max(point1.X, point2.X), point1.Y),
                new Point(Math.Abs(point2.X - point1.X) / 3 * 2 + Math.Min(point1.X, point2.X), point2.Y),
                new Point(Math.Abs(point2.X - point1.X) / 3 + Math.Min(point1.X, point2.X), point2.Y),
            };
            return points;
        }

        public override void Draw(Canvas canvas) {
            drawnTrapezoid.Points = CalcPoints();
            canvas.Children.Add(drawnTrapezoid);
        }

        public override void Redraw(Point nextPoint) {
            point2 = nextPoint;
            drawnTrapezoid.Points = CalcPoints();
        }

        public override string ToString() {
            return "Трапеция";
        }
    }
}
