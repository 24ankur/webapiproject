using dbfirstapproch.DTOs;
using dbfirstapproch.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dbfirstapproch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServ _employeeServ;
        public EmployeeController(IEmployeeServ employeeServ)
        {
            _employeeServ = employeeServ;   
        }
        [Route("GetEmployeeDetails")]
        [HttpGet]
        public Task<IList<EmployeeDto>> getEmployeeDetails(int employee_id)
        {
            return _employeeServ.GetEmployeeDetails(employee_id);
        }
        [Route("SaveEmployeeDetails")]
        [HttpPost]
        public IActionResult saveEmployeeData(IList<EmployeeDto> employeeDto)
        {
             _employeeServ.SaveEmployeeData(employeeDto);
            return Ok("Succsessfully updated....");
        }
        [Route("DeleteEmployeeData")]
        [HttpDelete]
        public IActionResult deleteEmployeeData(int employee_id)
        {
            try
            {
                _employeeServ.DeleteEmployeesData(employee_id);
                return Ok("Delete successfully...");
            }
            catch (Exception)
            {

                return Ok("Not deleted ...");
            } 
        }
        [Route("GetTopNemployeeSalaries")]
        [HttpGet]
        public IList<decimal> getTopNemployeeSalaries(int n)
        {
            return _employeeServ.GetTopNemployeesSalaries(n);
        }

        [Route("GetRegionName")]
        [HttpGet]
        public string getRegionOfEmployee(int employee_id)
        {
            return _employeeServ.GetRegionName(employee_id);
        }

    }
}
