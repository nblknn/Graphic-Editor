using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Graphic_Editor.Shapes;
using Newtonsoft.Json;

namespace TestPlugin {
    internal class Curve : MyComplexShape {
        private Path drawnCurve;
        private PolyBezierSegment bezierSegment;
        private PathFigure pathFigure;

        public Curve(Point startPoint, Color outlineColor, Color fillColor, double outlineThickness) :
            this (new PointCollection() { startPoint }, outlineColor, fillColor, outlineThickness) {
        }

        [JsonConstructor]
        public Curve(PointCollection points, Color outlineColor, Color fillColor, double outlineThickness) {
            this.points = points;
            this.outlineColor = outlineColor;
            this.fillColor = fillColor;
            this.outlineThickness = outlineThickness;
            bezierSegment = new PolyBezierSegment();
            pathFigure = new PathFigure() {
                StartPoint = points[0],
                Segments = new PathSegmentCollection() { bezierSegment },
            };
            drawnCurve = new Path() {
                Data = new PathGeometry() {
                    Figures = new PathFigureCollection() {
                        pathFigure
                    }
                },
                Stroke = new SolidColorBrush(outlineColor),
                StrokeThickness = outlineThickness,
            };
        }

        private void CalcBezierSegment() {
            if (points.Count < 2) return;
            int a = 2;
            List<Vector> pointDerivatives = new();
            pointDerivatives.Add((points[1] - points[0]) / a);
            for (int i = 1; i < points.Count - 1; i++) {
                pointDerivatives.Add((points[i + 1] - points[i - 1]) / a);
            }
            pointDerivatives.Add((points[points.Count - 1] - points[points.Count - 2]) / a);
            bezierSegment.Points.Clear();
            for (int i = 0; i < points.Count - 1; i++) {
                bezierSegment.Points.Add(points[i] + pointDerivatives[i] / 3);
                bezierSegment.Points.Add(points[i + 1] - pointDerivatives[i + 1] / 3);
                bezierSegment.Points.Add(points[i + 1]);
            }
        }

        public override void Draw(Canvas canvas) {
            CalcBezierSegment();
            canvas.Children.Add(drawnCurve);
        }

        public override void AddPoint(Point point) {
            points.Add(point);
            CalcBezierSegment();
        }

        public override void Redraw(Point nextPoint) {
            points[points.Count - 1] = nextPoint;
            if (points.Count == 1) pathFigure.StartPoint = nextPoint;
            CalcBezierSegment();
        }

        public override string ToString() {
            return "Кривая";
        }
    }
}