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
    internal class MyLine : MyShape {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public MyLine(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            this.point1 = startPoint;
            this.point2 = startPoint;
            this.outlineColor = outlineColor;
            this.outlineThickness = outlineThickness;
        }

        public MyLine(Point point1, Point point2, Color color, double outlineThickness) {
            this.point1 = point1;
            this.point2 = point2;
            this.outlineColor = color;
            this.outlineThickness = outlineThickness;
        }

        public override void Draw(Canvas canvas) {
            Line line = new Line();
            line.X1 = point1.X;
            line.Y1 = point1.Y;
            line.X2 = point2.X;
            line.Y2 = point2.Y;
            line.Stroke = new SolidColorBrush(outlineColor);
            line.StrokeThickness = outlineThickness;
            canvas.Children.Add(line);
        }
    }
}
