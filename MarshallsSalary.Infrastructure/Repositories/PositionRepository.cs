using MarshallsSalary.Core.Entities;
using MarshallsSalary.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Infrastructure.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(DataContext context) : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }

    }
}
