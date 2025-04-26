using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxIO.Database;

namespace TaxIO.Core
{
    public class OnStart
    {
        public static void InitializeDatabase()
        {
            TaxIODbContext db = new TaxIODbContext();
            db.Database.EnsureCreated();
        }
    }
}
