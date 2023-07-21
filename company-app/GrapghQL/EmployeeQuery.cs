using company_app.Exceptions;
using company_app.Models.DTO;
using company_app.Services;
using System.ComponentModel.DataAnnotations;

namespace company_app.GrapghQL
{
   public class EmployeeQuery
   {
      // handler get all data employees
      [GraphQLName("employees")]
      public async Task<List<EmployeeResponse>?> GetAllEmployeesAsync([Service] IEmployeeService empService)
      {
         return await empService.GetAllEmployeesAsync();
      }

      // handler get data employee by ID
      [GraphQLName("employee")]
      public async Task<EmployeeResponse?> GetEmployeeByIdAsync([Service] IEmployeeService empService, [Required] int? id)
      {
         return await empService.GetEmployeeByIdAsync(id);
      }
   }
}
