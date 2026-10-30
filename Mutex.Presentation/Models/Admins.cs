using System.ComponentModel.DataAnnotations;

namespace Mutex.Presentation.Models;

public class Admins
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
