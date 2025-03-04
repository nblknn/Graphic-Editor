using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graphic_Editor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MyShape[] shapes = {
                new MyEllipse(100, 200, 240, 250, Colors.Aqua),
                new MyPolygon(new PointCollection() { new Point(50, 300), new Point(200, 100), new Point(150, 100)}, Colors.DeepPink),
                new MyRectangle(500, 100, 700, 400, Colors.MediumSlateBlue),
                new MyLine(10, 10, 300, 300, Colors.Chocolate),
                new MyPolyline(new PointCollection() { new Point(400, 50), new Point(300, 130), new Point(550, 90), new Point(200, 300)}, Colors.Plum),
            };
            for (int i = 0; i < shapes.Length; i++)
                shapes[i].Draw(MainCanvas);
        }
    }
}