using System.Windows;
using System.Windows.Media;
using Graphic_Editor.ShapeFactories;
using Graphic_Editor.Shapes;

namespace TestPlugin {
    public class TrapezoidFactory : MyShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new Trapezoid(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}
