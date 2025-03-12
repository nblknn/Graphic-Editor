using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphic_Editor.Shapes {
    internal class MyPolygon : MyShape {
        public PointCollection points { get; set; }

        public MyPolygon(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.points = new PointCollection() { startPoint };
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
        }

        public MyPolygon(PointCollection points, Color outlineColor, Color fillColor, double outlineThickness) {
            this.points = points;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
        }

        public override void Draw(Canvas canvas) {
            Polygon polygon = new Polygon();
            polygon.Points = points;
            polygon.Stroke = new SolidColorBrush(outlineColor);
            polygon.Fill = new SolidColorBrush(fillColor);
            polygon.StrokeThickness = outlineThickness;
            canvas.Children.Add(polygon);
        }
    }
}
