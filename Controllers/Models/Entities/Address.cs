namespace EmployeeApi.Controllers.Models.Entities
{
    public class  Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }   
        public string? State { get; set; }
        public int PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
