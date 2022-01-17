using MarshallsSalary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Core.Services
{
    public interface IDivisionService
    {
        List<Division> GetAll();
    }
    public class DivisionService : IDivisionService
    {
        private IUnitOfWork _unitOfWork;
        public DivisionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Division> GetAll()
        {
            return (List<Division>)_unitOfWork.Divisions.GetAll();
        }
    }
}
