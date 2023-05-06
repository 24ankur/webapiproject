using dbfirstapproch.Models;
using System.Collections;
using System.Collections.Generic;
using dbfirstapproch.DTOs;
using System.Threading.Tasks;

namespace dbfirstapproch.IRepositories
{
    public interface IEmployeeRepo
    {
        public void DeleteEmployeesData(int employee_id);
        public Task<IList<EmployeeDto>> GetEmployeeDetails(int employee_id);
        public void SaveEmployeeData(IList<EmployeeDto> employeeDto);
        public IList<decimal> GetTopNemployeeSalary(int n);
        public string GetRegionName(int employee_id);

    }
}
