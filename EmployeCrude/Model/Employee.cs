using System.Data;

namespace EmployeCrude.Entities
{
    public class Employee
    {
       
        public int Id { get; set;}
        public int EmployeeId { get; set;}
        public string? EmployeeName { get; set; }
        public string? Employeestate { get; set; }
        public string? EmployeeAddress { get; set; }
    }
}
