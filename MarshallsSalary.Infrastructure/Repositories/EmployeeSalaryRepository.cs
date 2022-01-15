using MarshallsSalary.Core.Entities;
using MarshallsSalary.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Infrastructure.Repositories
{
    public class EmployeeSalaryRepository : Repository<EmployeeSalary>, IEmployeeSalaryRepository
    {
        public EmployeeSalaryRepository(DataContext context) : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }

    }
}
