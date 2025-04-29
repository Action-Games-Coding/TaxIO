using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxIO.Core
{
    public static class Settings
    {
        public static string AppName { get; set; } = "TaxIO";
        public static string AppVersion { get; set; } = "1.0.0";
        public static string AppDescription { get; set; } = "TaxIO is a personal finance management application.";
        public static string AppAuthor { get; set; } = "KikiZC & KarlBox";

        // Application settings
        public static string BaseCurrency { get; set; } = "USD";
    }
}
