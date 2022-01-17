using MarshallsSalary.Core.DTO;
using MarshallsSalary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Core.Services
{
    public interface IOfficeService
    {
        List<Office> GetAll();
    }
    public class OfficeService : IOfficeService
    {
        private IUnitOfWork _unitOfWork;
        public OfficeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Office> GetAll()
        {
            return (List<Office>)_unitOfWork.Offices.GetAll();
        }
    }
}
