using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Graphic_Editor.Shapes;

namespace Graphic_Editor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            /*MyShape[] shapes = {
                new MyEllipse(100, 200, new Point(240, 250), Colors.Beige, Colors.Aqua, 1),
                new MyPolygon(new PointCollection() { new Point(50, 300), new Point(200, 100), new Point(150, 100)}, Colors.DarkOliveGreen, Colors.DeepPink, 3),
                new MyRectangle(new Point(500, 100), new Point(700, 400), Colors.Green, Colors.MediumSlateBlue, 2),
                new MyLine(new Point(10, 10), new Point(300, 300), Colors.Chocolate, 1),
                new MyPolyline(new PointCollection() { new Point(400, 50), new Point(300, 130), new Point(550, 90), new Point(200, 300)}, Colors.Plum, 4),
            };
            for (int i = 0; i < shapes.Length; i++)
                shapes[i].Draw(MainCanvas);*/
        }

    }
}