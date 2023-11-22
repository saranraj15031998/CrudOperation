using EmployeCrude.Data;
using EmployeCrude.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeCrude.Respiratories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DbContextClass _dbContext;
        public EmployeeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> AddEmployeeAsync(Employee Employee)
        {
            var parameter = new List<SqlParameter>();

            
            parameter.Add(new SqlParameter("@Id", Employee.Id));
            
            parameter.Add(new SqlParameter("@EmployeeId", Employee.EmployeeId));

            parameter.Add(new SqlParameter("@EmployeeName", Employee.EmployeeName));

            parameter.Add(new SqlParameter("@EmployeeState", Employee.Employeestate));

            parameter.Add(new SqlParameter("@Employeeaddress", Employee.EmployeeAddress));

           // var result = await Task.Run(() => _dbContext.Database
           //.ExecuteSqlRawAsync(@"exec AddNewEmployee EmployeeId ,@EmployeeName, @EmployeeState, @EmployeeAddress", parameter.ToArray()));
           
            
            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC AddNewEmployee @id,@Employeeid,@EmployeeName, @EmployeeState, @EmployeeAddress", parameter.ToArray());


            return result;

        }

        public async Task<int> DeleteEmployeeAsync(int EmployeeId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteEmployee {EmployeeId}"));
        }


     public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int EmployeeId)
{
    var param = new SqlParameter("@EmployeeId", EmployeeId);

    var employeeDetails = await Task.Run(() => _dbContext.Employee
                    .FromSqlRaw(@"exec GetEmployeeById @EmployeeId", param).ToListAsync());

    return employeeDetails;
}


        public Task<List<Employee>> GetEmployeeListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateEmployeeAsync(Employee Employee)
        {
            var parameter = new List<SqlParameter>();


            parameter.Add(new SqlParameter("@Id", Employee.Id));

            parameter.Add(new SqlParameter("@EmployeeId", Employee.EmployeeId));

            parameter.Add(new SqlParameter("@EmployeeName", Employee.EmployeeName));

            parameter.Add(new SqlParameter("@EmployeeState", Employee.Employeestate));

            parameter.Add(new SqlParameter("@Employeeaddress", Employee.EmployeeAddress));

            // var result = await Task.Run(() => _dbContext.Database
            //.ExecuteSqlRawAsync(@"exec AddNewEmployee EmployeeId ,@EmployeeName, @EmployeeState, @EmployeeAddress", parameter.ToArray()));


            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC AddNewEmployee @id,@Employeeid,@EmployeeName, @EmployeeState, @EmployeeAddress", parameter.ToArray());


            return result;

        }

       

    }
}

