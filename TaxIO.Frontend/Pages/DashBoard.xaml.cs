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

namespace TaxIO.Frontend.Pages
{
    /// <summary>
    /// Interakční logika pro DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Page
    {
        public DashBoard()
        {
            InitializeComponent();

            PieChart01.SetData(new Dictionary<string, double>
            {
                { "Item 1", 30 },
                { "Item 2", 20 },
                { "Item 3", 50 }
            });
        }
    }
}
