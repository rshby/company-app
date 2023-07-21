using System.ComponentModel.DataAnnotations;

namespace company_app.Models.DTO
{
   [GraphQLName("update_employee")]
   public class UpdateEmployeeRequest
   {
      [Required]
      [GraphQLName("id")]
      [GraphQLNonNullType]
      public int? Id { get; set; }

      [Required]
      [GraphQLName("identity_number")]
      [GraphQLNonNullType]
      [StringLength(16, MinimumLength = 16)]
      public string? IdentityNumber { get; set; }

      [Required]
      [GraphQLName("name")]
      [GraphQLNonNullType]
      [StringLength(255)]
      public string? Name { get; set; }

      [Required]
      [GraphQLName("gender")]
      [GraphQLNonNullType]
      [StringLength(1, MinimumLength = 1)]
      public string? Gender { get; set; }

      [Required]
      [GraphQLName("birth_date")]
      [GraphQLNonNullType]
      public string? BirthDate { get; set; }

      [GraphQLName("address")]
      public string? Address { get; set; }
   }
}
