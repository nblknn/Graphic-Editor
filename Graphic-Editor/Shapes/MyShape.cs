using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Graphic_Editor.Shapes {
    public abstract class MyShape {
        public Color fillColor { get; set; }
        public Color outlineColor { get; set; }
        public double outlineThickness { get; set; }

        public abstract void Draw(Canvas canvas);
        public abstract void Redraw(Point nextPoint);
    }
}
