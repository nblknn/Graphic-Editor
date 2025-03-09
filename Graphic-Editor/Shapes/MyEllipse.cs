using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graphic_Editor {
    internal class MyEllipse : MyShape {
        public int height { get; set; }
        public int width { get; set; }
        public int xcenter { get; set; }
        public int ycenter { get; set; }

        public MyEllipse(int height, int width, int xcenter, int ycenter, Color color) {
            this.height = height;
            this.width = width;
            this.xcenter = xcenter;
            this.ycenter = ycenter;
            this.color = color;
        }

        public override void Draw(Canvas canvas) {
            Ellipse ellipse = new Ellipse();
            ellipse.Height = height;
            ellipse.Width = width;
            ellipse.Stroke = new SolidColorBrush(color);
            ellipse.Fill = new SolidColorBrush(color);
            canvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, xcenter - width / 2);
            Canvas.SetTop(ellipse, ycenter - height / 2);
        }
    }
}
