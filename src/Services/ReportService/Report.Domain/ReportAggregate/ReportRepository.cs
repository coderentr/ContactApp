using Report.Infrastructure.mongodb;
using Report.Infrastructure.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Domain.ReportAggregate
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
