namespace EmployeeApi.Controllers.Models.Entities
{
    public class Employee
    {
        public int? EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? EmpDept { get; set; }
        public string? EmpPhone { get; set; }
        public decimal? EmpSalary { get; set; }
        //public Address? Adress { get; set; }
    }

}
