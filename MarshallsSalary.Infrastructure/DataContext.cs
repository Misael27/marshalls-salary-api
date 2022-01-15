using MarshallsSalary.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarshallsSalary.Infrastructure
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region DbSets
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Position> Position { get; set; }
        #endregion
    }
}
