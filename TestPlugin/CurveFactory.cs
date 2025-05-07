using System.Windows;
using System.Windows.Media;
using Graphic_Editor.ShapeFactories;
using Graphic_Editor.Shapes;

namespace TestPlugin {
    public class CurveFactory : MyComplexShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new Curve(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}