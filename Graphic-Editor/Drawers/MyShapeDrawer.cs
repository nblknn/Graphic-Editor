using Graphic_Editor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Graphic_Editor.Drawers {
    internal class MyShapeDrawer : MyDrawer {
        private MyShape shape;

        public MyShapeDrawer(CanvasManager canvasManager) {
            this.canvasManager = canvasManager;
            isFinishedDrawing = true;
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            shape = canvasManager.selectedFactory.Create(e.GetPosition(canvasManager.canvas),
                canvasManager.outlineColor, canvasManager.fillColor, canvasManager.outlineThickness);
            shape.Draw(canvasManager.canvas);
            isFinishedDrawing = false;
        }

        private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            canvasManager.AddShape(shape);
            isFinishedDrawing = true;
        }

        private void MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed && !isFinishedDrawing)
                shape.Redraw(e.GetPosition(canvasManager.canvas));
        }

        public override void SetHandlers() {
            canvasManager.canvas.MouseLeftButtonDown += MouseLeftButtonDown;
            canvasManager.canvas.MouseLeftButtonUp += MouseLeftButtonUp;
            canvasManager.canvas.MouseMove += MouseMove;
        }

        public override void RemoveHandlers() {
            canvasManager.canvas.MouseLeftButtonDown -= MouseLeftButtonDown;
            canvasManager.canvas.MouseLeftButtonUp -= MouseLeftButtonUp;
            canvasManager.canvas.MouseMove -= MouseMove;
        }
    }
}
