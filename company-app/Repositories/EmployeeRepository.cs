using company_app.Data;
using company_app.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace company_app.Repositories
{
   // layer repository untuk employee
   public class EmployeeRepository
   {
      // global variable
      private readonly CompanyContext _db;

      // create constructor
      public EmployeeRepository(CompanyContext db)
      {
         this._db = db;
      }

      // method untuk get all data employees
      public async Task<List<Employee>?> GetAllEmployeesAsync()
      {
         try
         {
            List<Employee>? employees = await _db.Employees.ToListAsync();

            // jika data tidak ditemukan (masih kosong)
            if (employees == null || employees.Count == 0)
            {
               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage("record not found").Build());
            }

            // success get all employees
            return employees;
         }
         catch (Exception err)
         {
            // send error message
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method to get data employee by id
      public async Task<Employee?> GetEmployeeByIdAsync(int? id)
      {
         try
         {
            Employee? employee = await _db.Employees.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

            // jika data tidak ditemukan
            if (employee == null)
            {
               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage("record not found").Build());
            }

            // success get data employee by ID
            return employee;
         }
         catch (Exception err)
         {
            // send error message
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method untuk add new data employee
      public async Task<Employee?> AddEmployeeAsync(Employee? newEmployee)
      {
         try
         {
            await _db.Employees.AddAsync(newEmployee);

            int? result = await _db.SaveChangesAsync();
            
            // jika gagal insert data
            if (result < 1)
            {
               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage("failed to add new data").Build());
            }

            // success add new data
            return newEmployee;
         }
         catch(Exception err)
         {
            // send error message
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method untuk update employee by ID
      public async Task<Employee?> UpdateEmployeeByIdAsync(Employee? newEmployee)
      {
         try
         {
            // get data employee by id
            Employee? employee = await _db.Employees.AsQueryable().FirstOrDefaultAsync(x => x.Id == newEmployee.Id);

            // jika data tidak ditemukan
            if (employee == null)
            {
               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage("record not found").Build());
            }

            // update database
            _db.Employees.Entry(employee).CurrentValues.SetValues(newEmployee);
            await _db.SaveChangesAsync();

            // success update data
            return newEmployee;
         }
         catch(Exception err)
         {
            // send error message
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }

      // method untuk delete data employee by ID
      public async Task<Employee?> DeleteEmployeeByIdAsync(int? id)
      {
         try
         {
            // get data yang akan didelete
            Employee? employee = await _db.Employees.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

            // jika data yang akan dihapus tidak ditemukan
            if (employee == null)
            {
               // send error message
               throw new GraphQLException(new ErrorBuilder().SetMessage("record not found").Build());
            }

            // delete data
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            // success delete employee by id
            return employee;
         }
         catch(Exception err)
         {
            // send error message
            throw new GraphQLException(new ErrorBuilder().SetMessage(err.Message).Build());
         }
      }
   }
}
