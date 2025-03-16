using EmployeeApi.Controllers.Models.Entities;
using EmployeeApi.Data;
using EmployeeApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationDBContext _dbContext;
        public EmployeeService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesData()
        {
            try
            {
                var empData = await _dbContext.Employees.ToListAsync();
                return empData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Employee>> GetEmployeesDataWithId(int id)
        {
            try
            {
                var matachingEmpData = await _dbContext.Employees.Where(emp => emp.EmpId == id).ToListAsync();
                return matachingEmpData;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Employee>> UpdateEmployeeData(int id, Employee data)
        {
            try
            {
                _dbContext.Update(data);
                await _dbContext.SaveChangesAsync();
                return await GetEmployeesData();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> InsertEmployeeData(Employee emp)
        {
            try
            {
                _dbContext.Employees.Add(emp);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployeeRowData(int id)
        {
            var matchData = await _dbContext.Employees.FindAsync(id);
            if(matchData == null)
            {
                return false;  //data not found in table
            }
            _dbContext.Employees.Remove(matchData);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
