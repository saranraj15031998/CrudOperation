using EmployeCrude.Entities;
using EmployeCrude.Respiratories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeCrude.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
        {
            private readonly IEmployeeService EmployeeService;

            public EmployeeController(IEmployeeService EmployeeService)
            {
                this.EmployeeService = EmployeeService;
            }

        [HttpPost("addEmployee")]
        public async Task<IActionResult> AddEmployeeAsync(Employee Employee)
        {
            if (Employee == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await EmployeeService.AddEmployeeAsync(Employee);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }


        [HttpPut("updateEmploye")]
        public async Task<IActionResult> UpdateProductAsync(Employee Employee)
        {
            if (Employee == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await EmployeeService.UpdateEmployeeAsync(Employee);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }


        [HttpDelete("deleteEmployee")]
        public async Task<int> DeleteProductAsync(int Id)
        {
            try
            {
                var response = await EmployeeService.DeleteEmployeeAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }

            }

        [HttpGet("GetEmployeeById")]
        public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int Id)
        {
            try
            {
                var response = await EmployeeService.GetEmployeeByIdAsync(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }



    }
}
