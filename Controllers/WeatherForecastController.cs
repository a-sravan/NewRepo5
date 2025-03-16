using EmployeeApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using EmployeeApi.Controllers.Models.Entities;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        public readonly ApplicationDBContext _applicationDBContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDBContext applicationDBContext)
        {
            _logger = logger;
            _applicationDBContext = applicationDBContext;
        }

        //[HttpGet(Name = "Test call")]
        //public string Test()
        //{
        //    return "true";
        //}

        [HttpGet("GetEmployeesFromDB")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeDetailsFromDB()
        {
            try
            {
                var employees = await _applicationDBContext.Employees.ToListAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{ex.Message},failed to fetch employee data");
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet("StudentData")]
        //public async Task<ActionResult<List<Student>>> GetStudentDetails()
        //{
        //    List<string> studentList = new List<string>();
        //    try
        //    {
        //        var studentsData = await _applicationDBContext.Students.ToListAsync();
        //        return Ok(studentsData);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException($"{ex.Message},failed to fetch student data");
        //    }
        //}
    }
}