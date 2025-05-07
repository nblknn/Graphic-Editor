using System.Windows.Media;
using System.Windows.Controls;
using Graphic_Editor.Shapes;
using Graphic_Editor.ShapeFactories;
using Graphic_Editor.Drawers;
using System.Windows;
using Graphic_Editor.Serializers;

namespace Graphic_Editor {
    internal class CanvasManager {
        public Canvas canvas { get; private set; }
        private List<MyShape> shapeList;
        private Stack<MyShape> undoStack;
        private Stack<MyShape> redoStack;
        public List<MyShapeFactory> shapeFactories { get; private set; }
        public MyShapeFactory selectedFactory { get; private set; }
        public List<MyDrawer> drawers {  get; private set; }
        public MyDrawer selectedDrawer { get; private set; }
        public ShapeSerializer serializer { get; private set; }
        public PluginLoader pluginLoader { get; private set; }
        public Color fillColor { get; set; }
        public Color outlineColor { get; set; }
        public double outlineThickness { get; set; }

        public CanvasManager(Canvas canvas) {
            this.canvas = canvas;
            shapeList = new List<MyShape>();
            undoStack = new Stack<MyShape>();
            redoStack = new Stack<MyShape>();
            shapeFactories = new List<MyShapeFactory>() { new MyLineFactory(), new MyPolylineFactory(),
                new MyRectangleFactory(), new MyPolygonFactory(), new MyEllipseFactory() };
            drawers = new List<MyDrawer>() { new MyShapeDrawer(this), new MyComplexShapeDrawer(this) };
            serializer = new JSONShapeSerializer();
            pluginLoader = new PluginLoader();
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
            undoStack.Push(shape);
        }

        public void DrawAllShapes() {
            foreach (MyShape shape in shapeList) {
                shape.Draw(canvas);
            }
        }

        public void ClearCanvas() {
            canvas.Children.Clear();
        }

        public void Undo() {
            if (undoStack.Count > 0) {
                selectedDrawer.StopDrawing();
                canvas.Children.Remove(canvas.Children[canvas.Children.Count - 1]);
                redoStack.Push(undoStack.Pop());
                shapeList.RemoveAt(shapeList.Count - 1);
            }
        }

        public void Redo() {
            if (redoStack.Count > 0) {
                selectedDrawer.StopDrawing();
                MyShape shape = redoStack.Pop();
                shape.Draw(canvas);
                shapeList.Add(shape);
                undoStack.Push(shape);
            }
        }

        public string Serialize() {
            return serializer.Serialize(shapeList);
        }

        public void Deserialize(string jsonString) {
            try {
                List<MyShape>? tempList = serializer.Deserialize(jsonString);
                if (tempList == null)
                    shapeList = new List<MyShape>();
                else {
                    shapeList = tempList; 
                }
                redoStack.Clear();
                undoStack.Clear();
                selectedDrawer.StopDrawing();
                ClearCanvas();
                DrawAllShapes();
            }
            catch (Newtonsoft.Json.JsonException) {
                MessageBox.Show("Ошибка при чтении файла", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<MyShapeFactory>? LoadPlugin(string path) {
            List<MyShapeFactory>? factories = null;
            try {
                factories = pluginLoader.LoadPlugin(path);
                foreach (MyShapeFactory factory in factories)
                    shapeFactories.Add(factory);
            }
            catch {
                MessageBox.Show("Ошибка при загрузке плагина", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return factories;
        }
    }
}
