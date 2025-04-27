using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxIO.Core
{
    public static class Getters
    {
        public static Dictionary<string, double> GetCategoryValuesData()
        {
            Dictionary<string, double> data = new()
            {
                { "Caregory 1", 30 },
                { "Caregory 2", 20 },
                { "Caregory 3", 50 },
                { "Ultra long category name 01", 100 },
            };

            return data;
        }

        public static Dictionary<DateTime, double> GetDateFullWorth()
        {
            // Simulovaná data pro graf
            Dictionary<DateTime, double> data = new(){
                { new DateTime(2023, 1, 1), 100 },
                { new DateTime(2023, 2, 1), 200 },
                { new DateTime(2023, 3, 1), 500 },
                { new DateTime(2023, 4, 1), 400 },
                { new DateTime(2023, 5, 1), 100 },
                { new DateTime(2023, 6, 1), 500 },
                { new DateTime(2023, 7, 1), 700 },
            };

            return data;
        }
    }
}
