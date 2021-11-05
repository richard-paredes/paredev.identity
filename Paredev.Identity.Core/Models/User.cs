using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace Paredev.Identity.Core.Models;


public class User : IdentityUser<Guid>
{
    public ICollection<UserRole> Roles { get; set; }
}