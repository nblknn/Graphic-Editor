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
