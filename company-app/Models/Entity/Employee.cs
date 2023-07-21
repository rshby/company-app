using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace company_app.Models.Entity
{
   // representasi tabel employee
   
   [Table("employees")]
   public class Employee
   {
      [Key]
      [Required]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Column("id", Order = 1)]
      public int? Id { get; set; }

      [Required]
      [Column("identity_number", Order = 2)]
      [MaxLength(16), MinLength(16)]
      public string? IdentityNumber { get; set; }

      [Required]
      [Column("name", Order = 3)]
      [MaxLength(255)]
      public string? Name { get; set; }

      [Required]
      [Column("gender", Order = 4)]
      [MaxLength(1), MinLength(1)]
      public string? Gender { get; set; }

      [Required]
      [Column("birth_date", Order = 5)]
      public DateTime? BirthDate { get; set; }

      [Column("address", Order = 6)]
      [MaxLength(500)]
      public string? Address { get; set; }
   }
}
