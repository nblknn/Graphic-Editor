using Graphic_Editor.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace TestPlugin {
    public class Ring : MyShape {
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        private Path drawnRing;

        public Ring(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) {
            point1 = startPoint;
            point2 = startPoint;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            drawnRing = new Path() {
                Data = new CombinedGeometry(GeometryCombineMode.Exclude, new EllipseGeometry(), new EllipseGeometry()),
                Stroke = new SolidColorBrush(outlineColor),
                Fill = new SolidColorBrush(fillColor),
                StrokeThickness = outlineThickness
            };
        }

        [JsonConstructor]
        public Ring(Point point1, Point point2, Color outlineColor, Color fillColor, double outlineThickness) : this(point1, outlineColor, fillColor, outlineThickness) {
            this.point2 = point2;
        }

        private void SetDrawnCoordinates() {
            CombinedGeometry geometry = drawnRing.Data as CombinedGeometry;
            EllipseGeometry[] ellipses = [
                geometry.Geometry1 as EllipseGeometry,
                geometry.Geometry2 as EllipseGeometry
            ];
            ellipses[0].RadiusX = Math.Abs(point2.X - point1.X) / 2;
            ellipses[0].RadiusY = Math.Abs(point2.Y - point1.Y) / 2;
            ellipses[1].RadiusX = 2 * ellipses[0].RadiusX / 3;
            ellipses[1].RadiusY = 2 * ellipses[0].RadiusY / 3;
            ellipses[0].Center = new Point((point2.X + point1.X) / 2, (point2.Y + point1.Y) / 2);
            ellipses[1].Center = new Point((point2.X + point1.X) / 2, (point2.Y + point1.Y) / 2);
        }

        public override void Draw(Canvas canvas) {
            SetDrawnCoordinates();
            canvas.Children.Add(drawnRing);
        }

        public override void Redraw(Point nextPoint) {
            point2 = nextPoint;
            SetDrawnCoordinates();
        }

        public override string ToString() {
            return "Кольцо";
        }
    }

}
