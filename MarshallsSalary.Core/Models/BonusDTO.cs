using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Core.Models
{
    public class BonusDTO
    {
        public double Bonus { get; set; }
        public List<EmployeeSalaryDTO> Salaries { get; set; }
    }
}
