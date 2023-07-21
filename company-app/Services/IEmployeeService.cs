using company_app.Models.DTO;

namespace company_app.Services
{
   public interface IEmployeeService
   {
      // method untuk get all data employee
      public Task<List<EmployeeResponse>?> GetAllEmployeesAsync();

      // method untuk get data employee by ID
      public Task<EmployeeResponse?> GetEmployeeByIdAsync(int? id);

      // method untuk add new employees data
      public Task<EmployeeResponse?> AddEmployeeAsync(InsertEmployeeRequest? request);

      // method untuk update data employee
      public Task<EmployeeResponse?> UpdateEmployeeAsync(UpdateEmployeeRequest? request);

      // method untuk delete data employees by id
      public Task<EmployeeResponse?> DeleteEmployeeByIdAsync(int? id);
   }
}
