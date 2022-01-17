using MarshallsSalary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Core.Services
{
    public interface IPositionService
    {
        List<Position> GetAll();
    }
    public class PositionService : IPositionService
    {
        private IUnitOfWork _unitOfWork;
        public PositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Position> GetAll()
        {
            return (List<Position>)_unitOfWork.Positions.GetAll();
        }
    }
}
