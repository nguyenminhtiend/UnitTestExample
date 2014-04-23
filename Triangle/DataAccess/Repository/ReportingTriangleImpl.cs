using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ReportingTriangleImpl : IReportingTriangle
    {
        private DbContext dbContext;
        public ReportingTriangleImpl(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<TriangleReport> GetAllTriangle()
        {
            return dbContext.Database.SqlQuery<TriangleReport>("spTriangleCallReport").ToList();
        }
    }
}
