using MarshallsSalary.Core.Entities;
using MarshallsSalary.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Infrastructure.Repositories
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        public DivisionRepository(DataContext context) : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }

    }
}
