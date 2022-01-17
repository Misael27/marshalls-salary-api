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

        public IOfficeRepository Offices { get; private set; }

        public IDivisionRepository Divisions { get; private set; }

        public IPositionRepository Positions { get; private set; }


        public UnitOfWork(DataContext context)
        {
            _context = context;
            EmployeeSalaries = new EmployeeSalaryRepository(_context);
            Offices = new OfficeRepository(_context);
            Divisions = new DivisionRepository(_context);
            Positions = new PositionRepository(_context);
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
