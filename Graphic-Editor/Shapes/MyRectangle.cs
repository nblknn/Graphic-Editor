using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphic_Editor {
    internal class MyRectangle : MyShape {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public MyRectangle(int x1, int y1, int x2, int y2, Color color) {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.color = color;
        }

        public override void Draw(Canvas canvas) {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = Math.Abs(y2 - y1);
            rectangle.Width = Math.Abs(x2 - x1);
            rectangle.Stroke = new SolidColorBrush(color);
            rectangle.Fill = new SolidColorBrush(color);
            canvas.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, Math.Min(x1, x2));
            Canvas.SetTop(rectangle, Math.Min(y1, y2));
        }
    }
}
