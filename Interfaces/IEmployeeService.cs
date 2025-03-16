using EmployeeApi.Controllers.Models.Entities;
using EmployeeApi.Services;

namespace EmployeeApi.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> DeleteEmployeeRowData(int id);
        public Task<List<Employee>> GetEmployeesData();
        Task<List<Employee>> GetEmployeesDataWithId(int id);
        public Task<bool> InsertEmployeeData(Employee emp);
        public Task<List<Employee>> UpdateEmployeeData(int id, Employee emp);
    }
}
