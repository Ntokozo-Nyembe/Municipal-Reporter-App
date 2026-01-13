using System.Collections.Generic;
using MunicipalReporterApp.Models;

namespace MunicipalReporterApp
{
   
    public static class DataStore
    {
        // In‑memory list of all submitted issue reports
        public static readonly List<IssueReport> Reports = new List<IssueReport>();


        // Initial categories (users can add their own – co‑creation)
        public static readonly List<string> Categories = new List<string>
        {
            "Sanitation",
            "Roads",
            "Utilities",
            "Public Safety",
            "Parks & Recreation",
            "Other (add new…)"
        };
    }
}
