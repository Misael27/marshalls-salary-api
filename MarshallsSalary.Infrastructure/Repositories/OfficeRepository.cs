using MarshallsSalary.Core.Entities;
using MarshallsSalary.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Infrastructure.Repositories
{
    public class OfficeRepository : Repository<Office>, IOfficeRepository
    {
        public OfficeRepository(DataContext context) : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }

    }
}
