namespace company_app.Models.DTO
{
   // object response 
   [GraphQLName("employee")]
   public class EmployeeResponse
   {
      [GraphQLName("id")]
      public int? Id { get; set; }

      [GraphQLName("identity_number")]
      public string? IdentityNumber { get; set; }

      [GraphQLName("name")]
      public string? Name { get; set; }

      [GraphQLName("gender")]
      public string? Gender { get; set; }

      [GraphQLName("birth_date")]
      public string? BirthDate { get; set; }

      [GraphQLName("address")]
      public string? Address { get; set; }

   }
}
