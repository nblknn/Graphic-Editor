using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Graphic_Editor.Shapes {
    internal class MyPolyline : MyComplexShape {
        private Polyline drawnPolyline;

        public MyPolyline(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.points = new PointCollection() { startPoint };
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnPolyline = new Polyline();
        }

        [JsonConstructor]
        public MyPolyline(PointCollection points, Color outlineColor, double outlineThickness) {
            this.points = points;
            this.outlineColor = outlineColor;
            this.outlineThickness = outlineThickness;
            drawnPolyline = new Polyline();
        }

        public override void Draw(Canvas canvas) {
            drawnPolyline.Points = points;
            drawnPolyline.Stroke = new SolidColorBrush(outlineColor);
            drawnPolyline.StrokeThickness = outlineThickness;
            canvas.Children.Add(drawnPolyline);
        }

        public override void AddPoint(Point point) {
            points.Add(point);
            drawnPolyline.Points.Add(point);
        }

        public override void Redraw(Point nextPoint) {
            points[points.Count - 1] = nextPoint;
            drawnPolyline.Points[points.Count - 1] = nextPoint;
        }
    }
}
