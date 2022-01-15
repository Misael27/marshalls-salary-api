using System;
using System.Collections.Generic;
using System.Text;

namespace MarshallsSalary.Core.Models
{

    public class SalaryDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public OfficeDTO Office { get; set; }
        public float BaseSalary { get; set; }
        public float ProductionBonus { get; set; }
        public float CompensatioBonus { get; set; }
        public float Commission { get; set; }
        public float Contributions { get; set; }
    }

    public class OfficeDTO
    {
        public int OfficeId { get; set; }
        public string Name { get; set; }
    }

}
