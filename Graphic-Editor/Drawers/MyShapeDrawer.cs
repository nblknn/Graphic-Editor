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
            isDrawing = false;
        }

        private void MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            StartDrawing(e);
        }

        private void MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            StopDrawing();
        }

        private void MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed && isDrawing)
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

        public override void StartDrawing(MouseButtonEventArgs e) {
            shape = canvasManager.selectedFactory.Create(e.GetPosition(canvasManager.canvas),
                canvasManager.outlineColor, canvasManager.fillColor, canvasManager.outlineThickness);
            shape.Draw(canvasManager.canvas);
            isDrawing = true;
        }

        public override void StopDrawing() {
            if (!isDrawing) return;
            canvasManager.AddShape(shape);
            isDrawing = false;
        }
    }
}
