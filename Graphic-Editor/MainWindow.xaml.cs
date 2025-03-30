using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Graphic_Editor.ShapeFactories;

namespace Graphic_Editor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        CanvasManager canvasManager;
        RadioButton[] buttons;

        public MainWindow() {
            InitializeComponent();
            canvasManager = new CanvasManager(mainCanvas) {
                outlineColor = colorDisplay.SelectedColor,
                fillColor = colorDisplay.SecondaryColor,
            };
            CreateShapeButtons();
            sliderOutlineThickness.Value = 1;
        }

        private void CreateShapeButtons() {
            String[] shapeNames = new String[] { "Прямая", "Ломаная", "Прямоугольник", "Многоугольник", "Эллипс" };
            String[] shapeImages = new String[] { "./Images/line.png", "./Images/polyline.png",
                "./Images/rectangle.png", "./Images/polygon.png", "./Images/ellipse.png" };
            buttons = new RadioButton[canvasManager.shapeFactories.Count];
            for (int i = 0; i < buttons.Length; i++) {
                Label label = new Label() {
                    MinWidth = 90,
                    VerticalAlignment = VerticalAlignment.Center,
                    Content = shapeNames[i],
                };
                Image image = new Image() {
                    MaxWidth = 30,
                    Source = new BitmapImage(new Uri(shapeImages[i], UriKind.Relative)),
                };
                StackPanel stackPanel = new StackPanel() {
                    Orientation = Orientation.Horizontal,
                    Children = { label, image },
                };
                buttons[i] = new RadioButton() {
                    Content = stackPanel,
                    Tag = canvasManager.shapeFactories[i],
                };
                buttons[i].Checked += RadioButton_Checked;
                shapePanel.Children.Add(buttons[i]);
            }
            buttons[0].IsChecked = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e) {
            if (sender is RadioButton radioButton && radioButton.Tag is MyShapeFactory factory) {
                canvasManager.SetFactory(factory);
            }
        }

        private void sliderOutlineThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            canvasManager.outlineThickness = sliderOutlineThickness.Value;
        }

        private void colorPicker_ColorChanged(object sender, RoutedEventArgs e) {
            canvasManager.outlineColor = colorPicker.SelectedColor;
        }

        private void colorDisplay_MouseLeave(object sender, MouseEventArgs e) {
            canvasManager.outlineColor = colorDisplay.SelectedColor;
            canvasManager.fillColor = colorDisplay.SecondaryColor;
        }
    }
}