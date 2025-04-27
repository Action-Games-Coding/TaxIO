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

    }
}
