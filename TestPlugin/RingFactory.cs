using Graphic_Editor.ShapeFactories;
using Graphic_Editor.Shapes;
using System.Windows;
using System.Windows.Media;

namespace TestPlugin {
    public class RingFactory : MyShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new Ring(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}
