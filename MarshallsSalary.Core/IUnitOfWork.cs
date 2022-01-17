using MarshallsSalary.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeSalaryRepository EmployeeSalaries { get; }
        IOfficeRepository Offices { get; }
        IDivisionRepository Divisions { get; }
        IPositionRepository Positions { get; }
        void Complete();
    }
}
