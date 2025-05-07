using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Graphic_Editor.ShapeFactories;
using Graphic_Editor.Shapes;
using Microsoft.Win32;

namespace Graphic_Editor {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        CanvasManager canvasManager;

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
            RadioButton[] buttons = new RadioButton[canvasManager.shapeFactories.Count];
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i] = CreateShapeButton(canvasManager.shapeFactories[i]);
            }
            buttons[0].IsChecked = true;
        }

        private RadioButton CreateShapeButton(MyShapeFactory shapeFactory) {
            Canvas canvas = new Canvas() { Height = 30, Width = 30, Margin = new Thickness(1) };
            MyShape testShape = shapeFactory.Create(new Point(0, 2), Colors.Black, Colors.Transparent, 1);
            testShape.Draw(canvas);
            if (testShape is MyComplexShape complexShape) {
                complexShape.Redraw(new Point(15, 0));
                complexShape.AddPoint(new Point(0, 30));
                complexShape.AddPoint(new Point(30, 20));
            }
            else {
                testShape.Redraw(new Point(30, 28));
            }
            Label label = new Label() {
                MinWidth = 90,
                VerticalAlignment = VerticalAlignment.Center,
                Content = testShape.ToString(),
            };
            StackPanel stackPanel = new StackPanel() {
                Orientation = Orientation.Horizontal,
                Children = { label, canvas },
            };
            RadioButton button = new RadioButton() {
                Content = stackPanel,
                Tag = shapeFactory,
            };
            button.Checked += RadioButton_Checked;
            shapePanel.Children.Add(button);
            return button;
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

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            canvasManager.Undo();
        }

        private void RedoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            canvasManager.Redo();
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog() {
                Filter = "Shapes files (*.shp)|*.shp",
            };
            if (openFileDialog.ShowDialog() == false) return;
            canvasManager.Deserialize(File.ReadAllText(openFileDialog.FileName));
        }

        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog() {
                Filter = "Shapes files (*.shp)|*.shp",
            };
            if (saveFileDialog.ShowDialog() == false) return;
            File.WriteAllText(saveFileDialog.FileName, canvasManager.Serialize());
        }

        private void LoadPlugins_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog() {
                Filter = "Libraries (*.dll)|*.dll",
            };
            if (openFileDialog.ShowDialog() == false) return;
            List<MyShapeFactory>? factories = canvasManager.LoadPlugin(openFileDialog.FileName);
            if (factories != null)
                foreach (MyShapeFactory factory in factories)
                    CreateShapeButton(factory);
        }
    }
}