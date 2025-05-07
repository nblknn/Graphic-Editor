using System.Windows;
using System.Windows.Media;

namespace Graphic_Editor.Shapes {
    public abstract class MyComplexShape : MyShape {
        public PointCollection points { get; set; }
        public abstract void AddPoint(Point point);
    }
}
