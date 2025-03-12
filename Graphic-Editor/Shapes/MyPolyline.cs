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
    internal class MyPolyline : MyShape {
        public PointCollection points { get; set; }

        public MyPolyline(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.points = new PointCollection() { startPoint };
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
        }

        public MyPolyline(PointCollection points, Color outlineColor, double outlineThickness) {
            this.points = points;
            this.outlineColor = outlineColor;
            this.outlineThickness = outlineThickness;
        }

        public override void Draw(Canvas canvas) {
            Polyline polyline = new Polyline();
            polyline.Points = points;
            polyline.Stroke = new SolidColorBrush(outlineColor);
            polyline.StrokeThickness = outlineThickness;
            canvas.Children.Add(polyline);
        }
    }
}
