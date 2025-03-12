using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Graphic_Editor.Shapes;
using Graphic_Editor.ShapeFactories;

namespace Graphic_Editor {
    internal class CanvasManager {
        private Canvas canvas;
        private Stack<MyShape> undoStack;
        private Stack<MyShape> redoStack;
        public List<MyShapeFactory> shapeFactories;
        public void AddShape(MyShape shape) { }
        public void Undo() { }
        public void Redo() { }
    }
}
