﻿using System;
using System.Collections.Generic;
using Raunstrup.Domain;

namespace Raunstrup.Data.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {
        IList<Report> FindByProject(Project project);
        IList<Report> FindByDurationAndEmployee(DateTime start, DateTime end, Employee employee);
    }
}
