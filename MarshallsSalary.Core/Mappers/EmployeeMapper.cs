using MarshallsSalary.Core.DTO;
using MarshallsSalary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MarshallsSalary.Core.Models;

namespace MarshallsSalary.Core.Mappers
{
    class EmployeeMapper
    {
        internal static List<EmployeeSalary> FromDto(EmployeeDTO employeeDTO)
        {
            var result = new List<EmployeeSalary>();
            foreach (var salaryDTO in employeeDTO.Salaries)
            {
                var userSalary = new EmployeeSalary()
                {
                    EmployeeName = employeeDTO.EmployeeName,
                    EmployeeSurname = employeeDTO.EmployeeSurname,
                    IdentificationNumber = employeeDTO.IdentificationNumber,
                    EmployeeCode = employeeDTO.EmployeeCode,
                    BeginDate = employeeDTO.BeginDate,
                    Birthday = employeeDTO.Birthday,
                    DivisionId = employeeDTO.Division.DivisionId,
                    PositionId = employeeDTO.Position.PositionId,
                    Grade = employeeDTO.Grade,
                    BaseSalary = salaryDTO.BaseSalary,
                    Commission = salaryDTO.Commission,
                    CompensatioBonus = salaryDTO.CompensatioBonus,
                    Contributions = salaryDTO.Contributions,
                    ProductionBonus = salaryDTO.ProductionBonus,
                    Year = salaryDTO.Year,
                    Month = salaryDTO.Month,
                    OfficeId = salaryDTO.Office.OfficeId,
                };
                result.Add(userSalary);
            }
            return result;
        }

        internal static List<EmployeeDTO> ToDto(List<EmployeeSalary> employeeSalaries)
        {
            var employees = employeeSalaries.Select(x => 
                new EmployeeDTO () 
                { 
                    EmployeeName = x.EmployeeName,
                    EmployeeSurname =  x.EmployeeSurname,
                    IdentificationNumber = x.IdentificationNumber, 
                    EmployeeCode = x.EmployeeCode, 
                    BeginDate = x.BeginDate, 
                    Birthday = x.Birthday,
                    Grade = x.Grade,
                    Division = new DivisionDTO() 
                    {
                        DivisionId = x.Division.DivisionId,
                        Name = x.Division.Name
                    }, 
                    Position = new PositionDTO()
                    {
                        PositionId = x.Position.PositionId,
                        Name = x.Position.Name
                    }, 
                }).Distinct().ToList();
            foreach (var employee in employees)
            {
                employee.Salaries = new List<SalaryDTO>();
                employee.Salaries = employeeSalaries
                                    .Where(x => x.EmployeeName == employee.EmployeeName && x.EmployeeSurname == employee.EmployeeSurname)
                                    .Select(x => new SalaryDTO()
                                    {
                                        Id = x.Id,
                                        BaseSalary = x.BaseSalary,
                                        Commission = x.Commission,
                                        CompensatioBonus = x.CompensatioBonus,
                                        Contributions = x.Contributions,
                                        ProductionBonus = x.ProductionBonus,
                                        Year = x.Year,
                                        Month = x.Month,
                                        Office = new OfficeDTO() 
                                        {
                                            OfficeId = x.Office.OfficeId,
                                            Name = x.Office.Name
                                        }
                                    }).ToList();
            }
            return employees;
        }
    }
}
