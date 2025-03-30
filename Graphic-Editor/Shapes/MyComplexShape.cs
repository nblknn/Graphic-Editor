﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graphic_Editor.Shapes {
    internal abstract class MyComplexShape : MyShape {
        public PointCollection points { get; set; }
        public abstract void AddPoint(Point point);
    }
}
