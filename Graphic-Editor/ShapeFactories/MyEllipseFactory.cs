﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Graphic_Editor.Shapes;

namespace Graphic_Editor.ShapeFactories {
    internal class MyEllipseFactory : MyShapeFactory {
        public override MyShape Create(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            return new MyEllipse(startPoint, outlineColor, fillColor, outlineThickness);
        }
    }
}
