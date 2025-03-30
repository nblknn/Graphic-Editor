using Graphic_Editor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Graphic_Editor.Drawers {
    internal class MyComplexShapeDrawer : MyDrawer {
        private MyComplexShape shape;

        public MyComplexShapeDrawer(CanvasManager canvasManager) {
            this.canvasManager = canvasManager;
            isFinishedDrawing = true;
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if (isFinishedDrawing) {
                shape = (MyComplexShape)canvasManager.selectedFactory.Create(e.GetPosition(canvasManager.canvas), canvasManager.outlineColor,
                    canvasManager.fillColor, canvasManager.outlineThickness);
                shape.Draw(canvasManager.canvas);
                isFinishedDrawing = false;
            }
            shape.AddPoint(e.GetPosition(canvasManager.canvas));
        }

        private void MouseMove(object sender, MouseEventArgs e) {
            if (!isFinishedDrawing)
                shape.Redraw(e.GetPosition(canvasManager.canvas));
        }

        private void MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            isFinishedDrawing = true;
            canvasManager.AddShape(shape);
        }

        public override void SetHandlers() {
            canvasManager.canvas.MouseLeftButtonDown += MouseLeftButtonDown;
            canvasManager.canvas.MouseMove += MouseMove;
            canvasManager.canvas.MouseRightButtonDown += MouseRightButtonDown;
        }

        public override void RemoveHandlers() {
            canvasManager.canvas.MouseLeftButtonDown -= MouseLeftButtonDown;
            canvasManager.canvas.MouseMove -= MouseMove;
            canvasManager.canvas.MouseRightButtonDown -= MouseRightButtonDown;
        }
    }
}
