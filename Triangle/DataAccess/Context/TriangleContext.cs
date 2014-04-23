using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class TriangleContext : DbContext
    {
        public TriangleContext()
            : base("ConnectionString")
        {
            Database.SetInitializer<TriangleContext>(null);
            //Database.SetInitializer<DatabaseContext>(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }
        public DbSet<Triangle> Triangles { get; set; }
    }
}
