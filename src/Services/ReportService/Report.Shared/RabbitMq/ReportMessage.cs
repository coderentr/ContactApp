using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Shared.RabbitMq
{
    public class ReportMessage
    {
        public string ReportId { get; set; }
        public string Location { get; set; }
    }
}
