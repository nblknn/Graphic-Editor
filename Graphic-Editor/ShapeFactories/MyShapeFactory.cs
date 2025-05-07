using System.Windows.Media;
using System.Windows;
using Graphic_Editor.Shapes;

namespace Graphic_Editor.ShapeFactories {
    public abstract class MyShapeFactory {
        public abstract MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness);
    }
}
