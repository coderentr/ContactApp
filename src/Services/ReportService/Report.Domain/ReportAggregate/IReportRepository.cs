﻿using Contact.Infrastructure.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Domain.ReportAggregate
{
    public interface IReportRepository : IBaseRepository<Report>
    {
    }
}
