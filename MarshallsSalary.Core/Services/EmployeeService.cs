using MarshallsSalary.Core.DTO;
using MarshallsSalary.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MarshallsSalary.Core.Entities;
using MarshallsSalary.Core.Mappers;
using System.Linq.Expressions;

namespace MarshallsSalary.Core.Services
{
    public interface IEmployeeService
    {
        void PostCreateDataDummy();
        EmployeeDTO GetEmployeeByName(FilterNameDTO filterDTO);
        EmployeeDTO PostEmployeeSalary(EmployeeDTO employeeDTO);
        List<EmployeeSalaryDTO> GetEmployeeList(FilterOptionDTO filterDTO);
        EmployeeDTO getSalaryAverage(FilterCodeDTO filterCodeDTO);
    }

    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region services
        public void PostCreateDataDummy()
        {
            string[] names = new string[] { "MIKE", "KALI", "JANE", "ANN", "JACK", "EDWARD", "TOM", "JASON", "JENNIFER", "ALISON" };
            string[] surnames = new string[] { "JAMES", "PRASAD", "DOE", "WHITAKER", "SMITH", "WILLIAMS", "BROWN", "MILLER", "JENNIFER", "ANDERSON" };
            int[] positions = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] divisions = { 1, 2, 3, 4 };
            int[] offices = { 1, 2, 3, 4 };

            foreach (var name in names)
            {
                foreach (var surname in surnames)
                {
                    if (_unitOfWork.EmployeeSalaries.GetAll().Any(x => x.EmployeeName.ToLower() == name.ToLower() && x.EmployeeSurname.ToLower() == surname.ToLower())) continue;
                    string IdentificationNumber = RandomStringNumber(8);
                    string EmployeeCode = RandomString(8);
                    DateTime BeginDate = RandomDay();
                    DateTime Birthday = RandomDay();
                    int rdn = int.Parse(RandomStringNumber(1));
                    int DivisionId = divisions[int.Parse(RandomStringNumber(1)) % 4];
                    int PositionId = positions[int.Parse(RandomStringNumber(1)) % 8]; 
                    int OfficeId = offices[int.Parse(RandomStringNumber(1)) % 4];
                    int grade = int.Parse(RandomStringNumber(1));
                    for (var i = 1; i <= 6; i++) 
                    {
                        EmployeeSalary employeeSalary = new EmployeeSalary()
                        {
                            EmployeeName = name,
                            EmployeeSurname = surname,
                            IdentificationNumber = IdentificationNumber,
                            EmployeeCode = EmployeeCode,
                            BeginDate = BeginDate,
                            Birthday = Birthday,
                            DivisionId = DivisionId,
                            PositionId = PositionId,
                            Grade = grade,
                            BaseSalary = RandomFloat(),
                            Commission = RandomFloat(),
                            CompensatioBonus = RandomFloat(),
                            Contributions = RandomFloat(),
                            ProductionBonus = RandomFloat(),
                            Year = DateTime.Now.AddMonths(-1*i).Year,
                            Month = DateTime.Now.AddMonths(-1 * i).Month,
                            OfficeId = OfficeId
                        };
                        _unitOfWork.EmployeeSalaries.Add(employeeSalary);
                    }
                }
            }
            _unitOfWork.Complete();
        }

        public EmployeeDTO GetEmployeeByName(FilterNameDTO filterDTO)
        {
            List<EmployeeSalary> employeeSalaries = _unitOfWork.EmployeeSalaries
                                                    .Find(x => 
                                                        x.EmployeeName.ToLower() == filterDTO.EmployeeName.ToLower() &&
                                                        x.EmployeeSurname.ToLower() == filterDTO.EmployeeSurname.ToLower())
                                                    .ToList();
            var result = EmployeeMapper.ToDto(employeeSalaries);
            return result.FirstOrDefault();
        }

        public EmployeeDTO PostEmployeeSalary(EmployeeDTO employeeDTO)
        {
            foreach (var salaryDTO in employeeDTO.Salaries)
            {
                EmployeeSalary employeeSalary = _unitOfWork.EmployeeSalaries
                                                .Find(x => 
                                                    x.EmployeeName.ToLower() == employeeDTO.EmployeeName.ToLower() && 
                                                    x.EmployeeSurname.ToLower() == employeeDTO.EmployeeSurname.ToLower() && 
                                                    x.Year == salaryDTO.Year &&
                                                    x.Month == salaryDTO.Month)
                                                .FirstOrDefault();
                if (employeeSalary != null) //EDIT mode
                {
                    //employee data
                    employeeSalary.IdentificationNumber = employeeDTO.IdentificationNumber;
                    employeeSalary.EmployeeCode = employeeDTO.EmployeeCode;
                    employeeSalary.BeginDate = employeeDTO.BeginDate;
                    employeeSalary.Birthday = employeeDTO.Birthday;
                    employeeSalary.DivisionId = employeeDTO.Division.DivisionId;
                    //salary data
                    employeeSalary.BaseSalary = salaryDTO.BaseSalary;
                    employeeSalary.Commission = salaryDTO.Commission;
                    employeeSalary.CompensatioBonus = salaryDTO.CompensatioBonus;
                    employeeSalary.Contributions = salaryDTO.Contributions;
                    employeeSalary.ProductionBonus = salaryDTO.ProductionBonus;
                    employeeSalary.OfficeId = employeeDTO.Office.OfficeId;
                    _unitOfWork.EmployeeSalaries.Set(employeeSalary);
                }
                else //CREATE mode
                {
                    employeeSalary = new EmployeeSalary()
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
                        OfficeId = employeeDTO.Office.OfficeId,
                    };
                    _unitOfWork.EmployeeSalaries.Add(employeeSalary);
                }
            }
            //save database
            _unitOfWork.Complete();
            return employeeDTO;
        }

        public List<EmployeeSalaryDTO> GetEmployeeList(FilterOptionDTO filterDTO)
        {
            //get filter predicate
            var filterPredicate = getFilterPredicate(filterDTO);
            //get all salaries
            List<EmployeeSalaryDTO> employees = _unitOfWork.EmployeeSalaries
                            .Find(filterPredicate)
                            .ToList()
                            .Select(x => new EmployeeSalaryDTO() 
                            {
                                Id = x.Id,
                                EmployeeCode = x.EmployeeCode,
                                EmployeeFullName = x.EmployeeName + " " + x.EmployeeSurname,
                                Division = x.Division.Name,
                                Position = x.Position.Name,
                                BeginDate = x.BeginDate,
                                Birthday = x.Birthday,
                                IdentificationNumber = x.IdentificationNumber,
                                Year = x.Year,
                                Month = x.Month,
                                TotalSalary = getTotalSalary(x.BaseSalary, x.ProductionBonus, x.CompensatioBonus, x.Commission, x.Contributions)
                            })
                            .OrderBy(x => x.EmployeeFullName)
                            .ThenByDescending(x => x.Year)
                            .ThenByDescending(x => x.Month)
                            .ToList();
            //variables for return
            var result = new List<EmployeeSalaryDTO>();
            var employeeNames = new string[employees.Count];
            var index = 0;
            //remove repeted items and take last salary
            foreach(var employee in employees)
            {
                if (!employeeNames.Contains(employee.EmployeeFullName)) {
                    employeeNames[index++] = employee.EmployeeFullName;
                    result.Add(employee);
                }
            }
            //result
            return result;
        }

        public EmployeeDTO getSalaryAverage(FilterCodeDTO filterCodeDTO) 
        {
            //get last 3 salaries
            List<EmployeeSalary> employeeSalaries = _unitOfWork.EmployeeSalaries
                                            .Find(x => x.EmployeeCode == filterCodeDTO.EmployeeCode)
                                            .OrderByDescending(x => x.Year)
                                            .ThenByDescending(x => x.Month)
                                            .Take(3)
                                            .ToList();
            //variables for average
            int lastMont = 0;
            int lastYear = 0;
            double sum = 0;
            int count = 0;
            double average = 0.0;
            //calculate average
            foreach (var salary in employeeSalaries)
            {
                if (lastMont == 0
                    || lastMont - 1 == salary.Month && lastYear == salary.Year
                    || lastMont == 1 && salary.Month == 12 && lastYear - 1 == salary.Year) 
                {
                    lastMont = salary.Month;
                    lastYear = salary.Year;
                    sum = getTotalSalary(salary.BaseSalary, salary.ProductionBonus, salary.CompensatioBonus, salary.Commission, salary.Contributions);
                    count++;
                }
            }
            if (count > 0) 
            {
                average = sum / count;
            }
            var result = EmployeeMapper.ToDto(employeeSalaries).FirstOrDefault();
            result.Bonus = average;
            return result;
        }
        #endregion services

        #region privateFunctions
        private Expression<Func<EmployeeSalary, bool>> getFilterPredicate(FilterOptionDTO filterDTO)
        {
            //validate if exist filter options
            if (filterDTO.FilterOption < 1 || filterDTO.FilterOption > 4 || filterDTO.Id == 0) return x => x.EmployeeName != null;
            //check if exist employee to filter
            EmployeeSalary filterEmployee = _unitOfWork.EmployeeSalaries.Find(x => x.Id == filterDTO.Id).FirstOrDefault();
            if (filterEmployee == null) return x => x.EmployeeName != null;
            //create predicate
            if (filterDTO.FilterOption == 1) //same Office and Grade
                return x => x.Id != filterDTO.Id && x.OfficeId == filterEmployee.OfficeId && x.Grade == filterEmployee.Grade;
            if (filterDTO.FilterOption == 2) //same Grade
                return x => x.Id != filterDTO.Id && x.Grade == filterEmployee.Grade;
            if (filterDTO.FilterOption == 3) //same Position and Grade
                return x => x.Id != filterDTO.Id && x.PositionId == filterEmployee.PositionId && x.Grade == filterEmployee.Grade;
            if (filterDTO.FilterOption == 4) //same Grade
                return x => x.Id != filterDTO.Id && x.Grade == filterEmployee.Grade;
            else
                return x => x.EmployeeName != null;
        }

        private double getTotalSalary(double BaseSalary, double ProductionBonus, double CompensatioBonus, double Commission, double Contributions)
        {
            return BaseSalary + ProductionBonus + (CompensatioBonus * 0.75) + ((BaseSalary + Commission) * 0.008 + Commission) - Contributions;
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static string RandomStringNumber(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private float RandomFloat()
        {
            double min = 1;
            double max = 10;
            double range = max - min;
            double sample = random.NextDouble();
            double scaled = (sample * range) + min;
            return (float)scaled;
        }
        
    #endregion privateFunctions

}
}
