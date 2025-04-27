using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TaxIO.Frontend.UserControls
{
    /// <summary>
    /// Interakční logika pro LineChart01.xaml
    /// </summary>
    public partial class LineChart01 : UserControl
    {
        public LineChart01()
        {
            InitializeComponent();
            DataContext = this; // Nastavení DataContext pro binding
        }

        // Property pro data
        public Dictionary<DateTime, double> Data { get; set; }

        // Property pro vykreslení grafu
        public PlotModel LinePlotModel { get; private set; }

        public void LoadData(Dictionary<DateTime, double> data)
        {
            Data = data;

            var plotModel = new PlotModel { Title = "Vývoj hodnoty" };
            var lineSeries = new LineSeries
            {
                Title = "Data",
                MarkerType = MarkerType.Circle,
                MarkerSize = 4
            };

            foreach (var entry in data)
            {
                lineSeries.Points.Add(new DataPoint(DateTimeAxis.ToDouble(entry.Key), entry.Value));
            }

            plotModel.Series.Add(lineSeries);
            LinePlotModel = plotModel;
            plotView.Model = LinePlotModel;
        }
    }
}