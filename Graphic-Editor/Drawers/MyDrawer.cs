using ColorPicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Graphic_Editor.Drawers {
    internal abstract class MyDrawer {
        protected CanvasManager canvasManager;
        protected bool isFinishedDrawing;
        public abstract void SetHandlers();
        public abstract void RemoveHandlers();
    }
}
