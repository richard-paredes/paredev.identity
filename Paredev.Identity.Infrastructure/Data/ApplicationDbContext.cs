using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Paredev.Identity.Core.Models;

namespace Paredev.Identity.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User> 
{
    
}