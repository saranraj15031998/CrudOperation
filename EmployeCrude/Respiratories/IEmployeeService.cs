using EmployeCrude.Entities;

namespace EmployeCrude.Respiratories
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployeeListAsync();
        public Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int Id);
        public Task<int> AddEmployeeAsync(Employee Employee);
        public Task<int> UpdateEmployeeAsync(Employee Employee);
        public Task<int> DeleteEmployeeAsync(int Id);

    }
}
