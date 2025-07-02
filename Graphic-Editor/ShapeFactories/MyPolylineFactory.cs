using System.Windows;
using System.Windows.Media;
using Graphic_Editor.Shapes;

namespace Graphic_Editor.ShapeFactories {
    internal class MyPolylineFactory : MyComplexShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new MyPolyline(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}
