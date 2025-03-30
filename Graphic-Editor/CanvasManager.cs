using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using Graphic_Editor.Shapes;
using Graphic_Editor.ShapeFactories;
using Graphic_Editor.Drawers;

namespace Graphic_Editor {
    internal class CanvasManager {
        public Canvas canvas { get; private set; }
        private Stack<MyShape> undoStack;
        private Stack<MyShape> redoStack;
        public List<MyShapeFactory> shapeFactories { get; private set; }
        public MyShapeFactory selectedFactory { get; private set; }
        public List<MyDrawer> drawers {  get; private set; }
        public MyDrawer selectedDrawer { get; private set; }
        public Color fillColor { get; set; }
        public Color outlineColor { get; set; }
        public double outlineThickness {  get; set; }

        public CanvasManager(Canvas canvas) {
            this.canvas = canvas;
            undoStack = new Stack<MyShape>();
            redoStack = new Stack<MyShape>();
            shapeFactories = new List<MyShapeFactory>() { new MyLineFactory(), new MyPolylineFactory(),
                new MyRectangleFactory(), new MyPolygonFactory(), new MyEllipseFactory() };
            drawers = new List<MyDrawer>() { new MyShapeDrawer(this), new MyComplexShapeDrawer(this) };
            SetFactory(shapeFactories[0]);
        }
        public void SetFactory(MyShapeFactory factory) {
            selectedFactory = factory;
            if (factory is MyComplexShapeFactory)
                SetDrawer(drawers[1]);
            else
                SetDrawer(drawers[0]);
        }
        public void SetDrawer(MyDrawer drawer) {
            if (selectedDrawer != null)
                selectedDrawer.RemoveHandlers();
            selectedDrawer = drawer;
            selectedDrawer.SetHandlers();
        }

        public void AddShape(MyShape shape) { }
        public void Undo() { }
        public void Redo() { }
    }
}
