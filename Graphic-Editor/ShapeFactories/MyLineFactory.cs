using Graphic_Editor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Graphic_Editor.ShapeFactories {
    internal class MyLineFactory : MyShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new MyLine(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}
