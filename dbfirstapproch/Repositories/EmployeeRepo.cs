using dbfirstapproch.DTOs;
using dbfirstapproch.IRepositories;
using dbfirstapproch.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System;
using Microsoft.Extensions.Logging;

namespace dbfirstapproch.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly HumanResourceContext _humanResourceContext;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeRepo> _logger; 
        public EmployeeRepo(HumanResourceContext humanResourceContext, IMapper mapper, ILogger<EmployeeRepo> logger)
        {
            _humanResourceContext = humanResourceContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IList<EmployeeDto>> GetEmployeeDetails(int employee_id)
        {
            
            
                var ret = await _humanResourceContext.Employees.Include(x=>x.Job).Where(x => x.EmployeeId == employee_id).ToListAsync();
                if (ret.Count == 0)
                {
                    return new List<EmployeeDto>();
                }
                else
                {
                    return _mapper.Map<IList<EmployeeDto>>(ret);
                }
            
        }

        public void SaveEmployeeData(IList<EmployeeDto> employeeDto)
        {
            foreach (var item in employeeDto)
            {
                //Employee employee = new Employee()
                //{
                //    //EmployeeId = item.EmployeeId,
                //    FirstName = item.FirstName,
                //    LastName = item.LastName,
                //    Email = item.Email,
                //    HireDate = item.HireDate,
                //    PhoneNumber = item.PhoneNumber,
                //    DepartmentId = item.DepartmentId,
                //    ManagerId = item.ManagerId,
                //    JobId = item.JobId,
                //    Salary = item.Salary
                //};

                var employee = _mapper.Map<Employee>(item);
                // Save the employee to the database
                _humanResourceContext.Employees.Add(employee);
                _humanResourceContext.SaveChanges();

                // Map the saved employee back to a DTO
                // var savedEmployeeDto = _mapper.Map<EmployeeDto>(employee);
            }
        }

        public void DeleteEmployeesData(int employee_id)
        {
          
                _logger.LogInformation("Deleting the Employees Details.......");
                var ret = _humanResourceContext.Employees.Find(employee_id);
                _humanResourceContext.Employees.Remove(ret);
                _humanResourceContext.SaveChanges();
                _logger.LogInformation("Successfully delete employee details.......");
        
        }
        public IList<decimal> GetTopNemployeeSalary(int n)
        {
            return _humanResourceContext.Employees.OrderByDescending(x => x.Salary).Take(n).Select(x => x.Salary).Distinct().ToList();
        }

        public string GetRegionName(int employee_id)
        {
            var ret= _humanResourceContext.Employees.Include(x => x.Department).
                ThenInclude(x => x.Location).
                ThenInclude(x => x.Country).ThenInclude(x => x.Region).Where(x => x.EmployeeId==employee_id)
                .Select(x => x.Department.Location.Country.Region.RegionName).FirstOrDefault();
            return ret;
        }
    }
}


