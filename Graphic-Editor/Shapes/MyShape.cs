using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace Graphic_Editor.Shapes {
    internal abstract class MyShape {
        public Color fillColor { get; set; }
        public Color outlineColor { get; set; }
        public double outlineThickness { get; set; }

        public abstract void Draw(Canvas canvas);
        public abstract void Redraw(Point nextPoint);
    }
}
