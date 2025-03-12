using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using Graphic_Editor.Shapes;

namespace Graphic_Editor.ShapeFactories {
    internal abstract class MyShapeFactory {
        public abstract MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness);
    }
}
