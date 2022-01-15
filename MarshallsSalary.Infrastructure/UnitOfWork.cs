using MarshallsSalary.Core;
using MarshallsSalary.Core.IRepositories;
using MarshallsSalary.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IEmployeeSalaryRepository EmployeeSalaries { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            EmployeeSalaries = new EmployeeSalaryRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
