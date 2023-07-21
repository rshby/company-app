using company_app.Exceptions;
using company_app.Models.DTO;
using company_app.Services;
using System.ComponentModel.DataAnnotations;

namespace company_app.GrapghQL
{
   public class EmployeeMutation
   {
      // handler to add new data employee
      [GraphQLName("add")]
      [UseMutationConvention]
      public async Task<EmployeeResponse?> AddEmployeeAsync([Service] IEmployeeService empService, [Required] InsertEmployeeRequest? request)
      {
         return await empService.AddEmployeeAsync(request);
      }

      // handler to delete data employee by ID
      [GraphQLName("delete")]
      [UseMutationConvention]
      [Error(typeof(InvalidIdException))]
      public async Task<EmployeeResponse?> DeleteEmployeeByIdAsync([Service] IEmployeeService empService, [Required] int? id)
      {
         return await empService.DeleteEmployeeByIdAsync(id);
      }

      // handler to update data employee
      [GraphQLName("update")]
      public async Task<EmployeeResponse?> UpdateEmployeeAsync([Service] IEmployeeService empService, [Required] UpdateEmployeeRequest? request)
      {
         return await empService.UpdateEmployeeAsync(request);
      }
   }
}
