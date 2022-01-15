using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Core.Models
{
    public class EmployeeSalaryDTO
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeFullName { get; set; }
        public string Division { get; set; }
        public string Position { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime Birthday { get; set; }
        public string IdentificationNumber { get; set; }
        public double TotalSalary { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
