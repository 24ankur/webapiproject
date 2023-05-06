using dbfirstapproch.IServices;
using dbfirstapproch.Models;
using System.Collections;
using System.Collections.Generic;
using dbfirstapproch.DTOs;
using System.Threading.Tasks;
using dbfirstapproch.IRepositories;

namespace dbfirstapproch.Services
{
    public class EmployeeServ:IEmployeeServ
    {
        private readonly IEmployeeRepo _employeeRepo;   
        public EmployeeServ(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;   
        }
        public Task<IList<EmployeeDto>> GetEmployeeDetails(int employee_id)
        {
            return _employeeRepo.GetEmployeeDetails(employee_id);
        }

        public void SaveEmployeeData(IList<EmployeeDto> employeeDto)
        {
            _employeeRepo.SaveEmployeeData(employeeDto);    
        }
        public void DeleteEmployeesData(int employee_id)
        {
            _employeeRepo.DeleteEmployeesData(employee_id);
        }
        public IList<decimal> GetTopNemployeesSalaries(int n)
        {
            return _employeeRepo.GetTopNemployeeSalary(n);
        }

        public string GetRegionName(int employee_id)
        {
            return _employeeRepo.GetRegionName(employee_id);
        }
    }
}
