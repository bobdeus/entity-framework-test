using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkTest.Models;

[Table("tdc_sys_user")]
public class User
{
    [Required] [Key] [Column("user_id")] public string UserId { get; set; }

    [Column("last_nm")] public string LastName { get; set; }

    [Column("first_nm")] public string FirstName { get; set; }
}