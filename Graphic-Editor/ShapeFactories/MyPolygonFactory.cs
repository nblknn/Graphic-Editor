using System.Windows;
using System.Windows.Media;
using Graphic_Editor.Shapes;

namespace Graphic_Editor.ShapeFactories {
    internal class MyPolygonFactory : MyComplexShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new MyPolygon(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}
