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
    internal class MyPolyline : MyShape {
        private PointCollection points { get; set; }

        public MyPolyline(PointCollection points, Color color) {
            this.points = points;
            this.color = color;
        }

        public override void Draw(Canvas canvas) {
            Polyline polyline = new Polyline();
            polyline.Points = points;
            polyline.Stroke = new SolidColorBrush(color);
            canvas.Children.Add(polyline);
        }
    }
}
