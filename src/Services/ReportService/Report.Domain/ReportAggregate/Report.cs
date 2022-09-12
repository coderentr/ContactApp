using Report.Domain.Core;
using Report.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Domain.ReportAggregate
{
    public class Report:Entity
    {
        public DateTime Date { get; set; }
        public ReportStatus Status { get; set; }
        public string FilePath { get; set; }
        public int PersonCount { get; set; }
        public string Location { get; set; }
    }
    
}
