using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MarshallsSalary.Core.Entities
{
    public class EmployeeSalary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int OfficeId { get; set; }
        [JsonIgnore]
        public virtual Office Office { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int DivisionId { get; set; }
        [JsonIgnore]
        public virtual Division Division { get; set; }
        public int PositionId { get; set; }
        [JsonIgnore]
        public virtual Position Position { get; set; }
        public int Grade { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime Birthday { get; set; }
        public string IdentificationNumber { get; set; }
        public float BaseSalary { get; set; }
        public float ProductionBonus { get; set; }
        public float CompensatioBonus { get; set; }
        public float Commission { get; set; }
        public float Contributions { get; set; }
    }
}
