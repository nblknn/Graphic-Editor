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
        private List<MyShape> shapeList;
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
            shapeList = new List<MyShape>();
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

        public void AddShape(MyShape shape) {
            redoStack.Clear();
            shapeList.Add(shape);
        }

        public void DrawAllShapes() {
            foreach (MyShape shape in shapeList) {
                shape.Draw(canvas);
            }
        }

        public void Undo() {
            if (selectedDrawer.isDrawing) {
                selectedDrawer.StopDrawing();
            }
            if (shapeList.Count > 0) {
                canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
                redoStack.Push(shapeList[shapeList.Count - 1]);
                shapeList.RemoveAt(shapeList.Count - 1);
            }
        }
        public void Redo() {
            if (selectedDrawer.isDrawing) {
                selectedDrawer.StopDrawing();
            }
            if (redoStack.Count > 0) {
                MyShape shape = redoStack.Pop();
                shape.Draw(canvas);
                shapeList.Add(shape);
            }
        }
    }
}
