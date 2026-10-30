using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mutex.DataLayer.Models;

public class Admin
{
    [Key]
    public int AdminId { get; set; }

    public string UserName { get; set; }
    public string Password { get; set; }
}
