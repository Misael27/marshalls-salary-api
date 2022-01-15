using MarshallsSalary.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarshallsSalary.Core.DTO
{

    public class EmployeeDTO
    {
        [Required]
        public string EmployeeCode { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeSurname { get; set; }
        [Required]
        public DivisionDTO Division { get; set; }
        [Required]
        public PositionDTO Position { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public DateTime BeginDate { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public string IdentificationNumber { get; set; }
        public double Bonus { get; set; }
        [Required]
        public List<SalaryDTO> Salaries { get; set; }
    }

    public class DivisionDTO
    {
        public int DivisionId { get; set; }
        public string Name { get; set; }
    }

    public class PositionDTO
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
    }

}
