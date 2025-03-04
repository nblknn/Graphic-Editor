using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphic_Editor {
    internal class MyPolygon : MyShape {
        private PointCollection points { get; set; }

        public MyPolygon(PointCollection points, Color color) {
            this.points = points;
            this.color = color;
        }

        public override void Draw(Canvas canvas) {
            Polygon polygon = new Polygon();
            polygon.Points = points;
            polygon.Stroke = new SolidColorBrush(color);
            polygon.Fill = new SolidColorBrush(color);
            canvas.Children.Add(polygon);
        }
    }
}
