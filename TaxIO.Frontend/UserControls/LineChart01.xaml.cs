using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using TaxIO.Core;

namespace TaxIO.Frontend.UserControls
{
    public partial class LineChart01 : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public LineChart01()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void LoadData(Dictionary<DateTime, double> data)
        {
            var values = data.Values.ToArray();
            var labels = data.Keys.ToList();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "",
                    Values = new ChartValues<double>(values),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                }
            };

            List<string> labelsstr = [];

            foreach (var label in labels)
            {
                labelsstr.Add(label.ToString("dd.MM.yyyy"));
            }

            Labels = labelsstr;
            YFormatter = value => $"{value} {Settings.BaseCurrency}";

            // Refresh binding
            DataContext = null;
            DataContext = this;
        }
    }
}