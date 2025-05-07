using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Graphic_Editor.Shapes {
    internal class MyPolygon : MyComplexShape {
        private Polygon drawnPolygon;

        public MyPolygon(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            points = new PointCollection() { startPoint };
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnPolygon = new Polygon();
        }

        [JsonConstructor]
        public MyPolygon(PointCollection points, Color outlineColor, Color fillColor, double outlineThickness) {
            this.points = points;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnPolygon = new Polygon();
        }

        public override void Draw(Canvas canvas) {
            drawnPolygon.Points = points;
            drawnPolygon.Stroke = new SolidColorBrush(outlineColor);
            drawnPolygon.Fill = new SolidColorBrush(fillColor);
            drawnPolygon.StrokeThickness = outlineThickness;
            canvas.Children.Add(drawnPolygon);
        }

        public override void AddPoint(Point point) {
            points.Add(point);
            drawnPolygon.Points.Add(point);
        }

        public override void Redraw(Point nextPoint) {
            points[points.Count - 1] = nextPoint;
            drawnPolygon.Points[points.Count - 1] = nextPoint;
        }

        public override string ToString() {
            return "Многоугольник";
        }
    }
}
