using EmployeeApi.Controllers.Models.Entities;
using EmployeeApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmpData")]
        public async Task<IEnumerable<Employee>> GetEmp()
        {
            return await _employeeService.GetEmployeesData();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("GetEmpDataWithId{id}")]
        public async Task<List<Employee>> GetEmpById(int id)
        {
            var response = await _employeeService.GetEmployeesDataWithId(id);
            return response;
        }

        // POST api/<EmployeeController>
        [HttpPut("PutUpdateEmpDataWithId{id}")]
        public async Task<List<Employee>> PostUpdateEmp(int id, [FromBody] Employee data)
        {
            var res = await _employeeService.UpdateEmployeeData(id, data);
            return res;
        }

        // PUT api/<EmployeeController>/5
        [HttpPost("PostInsertEmpData")]
        public async Task<string> PostInsertEmp([FromBody] Employee emp)
        {
            var res = await _employeeService.InsertEmployeeData(emp);
            return "new data inserted successfully";
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("DeleteEmpDataWithId{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _employeeService.DeleteEmployeeRowData(id);
            return res;
        }
    }
}
