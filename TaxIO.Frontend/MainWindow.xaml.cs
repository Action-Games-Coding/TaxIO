using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using TaxIO.Frontend.Pages;

namespace TaxIO.Frontend
{
    public partial class MainWindow : Window
    {
        private BindingGroup MainGroup = new();

        public MainWindow()
        {
            Core.OnStart.Start();

            InitializeComponent();

            MainPage.Content = new DashBoard();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton? toggleButton = sender as ToggleButton;
            if (toggleButton == null) return;

            string? tag = (string)toggleButton.Tag;

            if (tag == null) return;

            MainPage.Content = tag switch
            {
                "Dashboard" => new DashBoard(),
                "Income" => new IncomePG(),
                "Expense" => new ExpensePG(),
                "Inventory" => new InventoryPG(),
                "Charts" => new ChartPG(),
                "Check" => new CheckPG(),
                "Settings" => new SettingsPG(),
                _ => new DashBoard(),
            };


        }
    }
}