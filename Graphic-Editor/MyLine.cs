using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphic_Editor {
    internal class MyLine : MyShape {
        private int x1 { get; set; }
        private int y1 { get; set; }
        private int x2 { get; set; }
        private int y2 { get; set; }

        public MyLine(int x1, int y1, int x2, int y2, Color color) {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.color = color;
        }

        public override void Draw(Canvas canvas) {
            Line line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(color);
            canvas.Children.Add(line);
        }
    }
}
