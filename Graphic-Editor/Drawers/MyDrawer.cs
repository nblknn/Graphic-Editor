﻿using ColorPicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Graphic_Editor.Drawers {
    internal abstract class MyDrawer {
        protected CanvasManager canvasManager;
        public bool isDrawing { get; protected set; }
        public abstract void SetHandlers();
        public abstract void RemoveHandlers();
        public abstract void StartDrawing(MouseButtonEventArgs e);
        public abstract void StopDrawing();
    }
}
