using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaxIO.Frontend.UserControls
{
    /// <summary>
    /// Interakční logika pro PieChart01.xaml
    /// </summary>
    public partial class PieChart01 : UserControl
    {
        public PieChart01()
        {
            InitializeComponent();
            _data = [];
        }

        public void SetData(Dictionary<string, double> data)
        {
            ChartCanvas.Children.Clear();
            _data = data;

            double total = 0;
            foreach (var item in data)
                total += item.Value;

            double angle = 0;
            Random random = new();

            foreach (var item in data)
            {
                double sweep = item.Value / total * 360;

                Path path = CreatePieSlice(angle, sweep, 0,  0, 175);
                path.Fill = new SolidColorBrush(Color.FromRgb(
                    (byte)random.Next(100, 256),
                    (byte)random.Next(100, 256),
                    (byte)random.Next(100, 256)));

                path.Tag = item.Key;  // uložíme název položky do Tagu pro pozdější použití
                path.MouseEnter += PieSlice_MouseEnter; // přidáme event pro najetí myši
                path.MouseLeave += PieSlice_MouseLeave; // event pro opuštění myši

                ChartCanvas.Children.Add(path);
                angle += sweep;
            }

            LegendTextLine1.Text = _data.Values.Sum().ToString();
            LegendTextLine1.Visibility = Visibility.Visible;  // zobrazíme první řádek legendy
            LegendTextLine2.Visibility = Visibility.Collapsed;  // skryjeme druhý řádek legendy
        }

        private void PieSlice_MouseEnter(object sender, MouseEventArgs e)
        {
            var path = sender as Path;
            if (path != null)
            {
                string itemName = path.Tag.ToString();
                string itemValue = _data[itemName].ToString();

                LegendTextLine1.Text = itemName;  // zobrazíme název položky
                LegendTextLine2.Text = itemValue;  // zobrazíme hodnotu položky
                LegendTextLine2.Visibility = Visibility.Visible;  // zobrazíme druhý řádek legendy
                LegendTextLine1.Visibility = Visibility.Visible;  // zajistíme, že první řádek je také viditelný
            }
        }

        private void PieSlice_MouseLeave(object sender, MouseEventArgs e)
        {
            LegendTextLine1.Text = _data.Values.Sum().ToString();  // resetujeme text v legendě
            LegendTextLine1.Visibility = Visibility.Visible;  // zajistíme, že první řádek je viditelný
            LegendTextLine2.Visibility = Visibility.Collapsed;  // skryjeme druhý řádek legendy
        }

        private void ChartCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            LegendTextLine1.Text = _data.Values.Sum().ToString();  // pokud myš opustí celý graf, resetujeme text
            LegendTextLine1.Visibility = Visibility.Visible;  // zajistíme, že první řádek je viditelný
            LegendTextLine2.Visibility = Visibility.Collapsed;  // skryjeme druhý řádek legendy
        }

        private Path CreatePieSlice(double startAngle, double sweepAngle, double centerX, double centerY, double radius)
        {
            double startRadians = (Math.PI / 180.0) * (startAngle - 90);
            double endRadians = (Math.PI / 180.0) * (startAngle + sweepAngle - 90);

            Point startPoint = new Point(
                centerX + radius * Math.Cos(startRadians),
                centerY + radius * Math.Sin(startRadians));

            Point endPoint = new Point(
                centerX + radius * Math.Cos(endRadians),
                centerY + radius * Math.Sin(endRadians));

            bool isLargeArc = sweepAngle > 180;

            PathFigure figure = new PathFigure
            {
                StartPoint = new Point(centerX, centerY)
            };
            figure.Segments.Add(new LineSegment(startPoint, true));
            figure.Segments.Add(new ArcSegment(
                endPoint,
                new Size(radius, radius),
                0,
                isLargeArc,
                SweepDirection.Clockwise,
                true));
            figure.Segments.Add(new LineSegment(new Point(centerX, centerY), true));

            PathGeometry geometry = new PathGeometry();
            geometry.Figures.Add(figure);

            return new Path
            {
                Data = geometry,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
        }

        private Dictionary<string, double> _data;
    }
}

