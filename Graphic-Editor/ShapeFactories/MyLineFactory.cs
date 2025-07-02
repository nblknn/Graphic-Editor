using Graphic_Editor.Shapes;
using System.Windows;
using System.Windows.Media;

namespace Graphic_Editor.ShapeFactories {
    internal class MyLineFactory : MyShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new MyLine(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}
