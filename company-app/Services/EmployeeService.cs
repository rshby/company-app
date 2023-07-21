using company_app.Models.DTO;
using company_app.Models.Entity;
using company_app.Repositories;
using System.Transactions;

namespace company_app.Services
{
   public class EmployeeService : IEmployeeService
   {
      // global variable
      private readonly EmployeeRepository _employeeRepo;

      // create consttuctor
      public EmployeeService(EmployeeRepository empRepo)
      {
         this._employeeRepo = empRepo;
      }

      // method untuk insert new data employee to database
      public async Task<EmployeeResponse?> AddEmployeeAsync(InsertEmployeeRequest? request)
      {
         using (var tr = new TransactionScope(asyncFlowOption: TransactionScopeAsyncFlowOption.Enabled))
         {
            try
            {
               // create entity
               Employee? newEmployee = new Employee()
               {
                  IdentityNumber = request?.IdentityNumber,
                  Name = request?.Name,
                  Gender = request?.Gender,
                  BirthDate = DateTime.ParseExact($"{request.BirthDate} 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                  Address = request?.Address,
               };

               // call procedure insert in repository
               Employee? resultInsert = await _employeeRepo.AddEmployeeAsync(newEmployee);

               // mapping to DTO
               EmployeeResponse? response = new EmployeeResponse()
               {
                  Id = resultInsert?.Id,
                  IdentityNumber = resultInsert?.IdentityNumber,
                  Name = resultInsert?.Name,
                  Gender = resultInsert?.Gender,
                  BirthDate = ((DateTime)resultInsert?.BirthDate).ToString("yyyy-MM-dd"),
                  Address = resultInsert?.Address,
               };

               // success insert
               tr.Complete();
               return response;
            }
            catch (Exception err)
            {
               tr.Dispose();

               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }

      public async Task<EmployeeResponse?> DeleteEmployeeByIdAsync(int? id)
      {
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            try
            {
               // call procedure in repository
               Employee? employee = await _employeeRepo.DeleteEmployeeByIdAsync(id);

               // mapping to DTO
               EmployeeResponse? responses = new EmployeeResponse()
               {
                  Id = employee?.Id,
                  IdentityNumber = employee?.IdentityNumber,
                  Name = employee?.Name,
                  Gender = employee.Gender,
                  BirthDate = ((DateTime)employee?.BirthDate).ToString("yyyy-MM-dd"),
                  Address = employee?.Address
               };

               // success delete data
               tr.Complete();
               return responses;
            }
            catch (Exception err)
            {
               tr.Dispose();

               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }

      public async Task<List<EmployeeResponse>?> GetAllEmployeesAsync()
      {
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            try
            {
               // call procedure in repository
               List<Employee>? employees = await _employeeRepo.GetAllEmployeesAsync();

               // mapping to DTO
               List<EmployeeResponse>? responses = employees.Select(x => new EmployeeResponse()
               {
                  Id = x?.Id,
                  IdentityNumber = x?.IdentityNumber,
                  Name = x?.Name,
                  Gender = x?.Gender,
                  BirthDate = ((DateTime)x?.BirthDate).ToString("yyyy-MM-dd"),
                  Address = x?.Address
               }).ToList();

               // success get all data
               tr.Complete();
               return responses;
            }
            catch (Exception err)
            {
               tr.Dispose();

               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }

      public async Task<EmployeeResponse?> GetEmployeeByIdAsync(int? id)
      {
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            try
            {
               // call procedure in repository
               Employee? employee = await _employeeRepo.GetEmployeeByIdAsync(id);

               // mapping to DTO
               EmployeeResponse? response = new EmployeeResponse()
               {
                  Id = employee?.Id,
                  IdentityNumber = employee?.IdentityNumber,
                  Name = employee?.Name,
                  Gender = employee?.Gender,
                  BirthDate = ((DateTime)employee?.BirthDate).ToString("yyyy-MM-dd"),
                  Address = employee?.Address
               };

               // success get data employee by ID
               tr.Complete();
               return response;
            }
            catch (Exception err)
            {
               tr.Dispose();

               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }

      public async Task<EmployeeResponse?> UpdateEmployeeAsync(UpdateEmployeeRequest? request)
      {
         using (var tr = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            try
            {
               // create entity
               Employee? newEmployee = new Employee()
               {
                  Id = request?.Id,
                  IdentityNumber = request?.IdentityNumber,
                  Name = request?.Name,
                  Gender = request?.Gender,
                  BirthDate = DateTime.ParseExact($"{request?.BirthDate} 00:00:00", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                  Address = request?.Address
               };

               // call procedure update
               Employee? resultUpdate = await _employeeRepo.UpdateEmployeeByIdAsync(newEmployee);

               // mapping to DTO
               EmployeeResponse? response = new EmployeeResponse()
               {
                  Id = resultUpdate?.Id,
                  IdentityNumber = resultUpdate?.IdentityNumber,
                  Name = resultUpdate?.Name,
                  Gender = resultUpdate?.Gender,
                  BirthDate = ((DateTime)resultUpdate?.BirthDate).ToString("yyyy-MM-dd"),
                  Address = resultUpdate?.Address
               };

               // success update
               tr.Complete();
               return response;
            }
            catch (Exception err)
            {
               tr.Dispose();

               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
            }
         }
      }
   }
}
