using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarshallsSalary.Core.Models
{
    public class FilterCodeDTO
    {
        public string EmployeeCode { get; set; }
    }

    public class FilterNameDTO
    {
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeSurname { get; set; }
    }

    public class FilterOptionDTO
    {
        public int Id { get; set; }
        public int FilterOption { get; set; }
    }

}
