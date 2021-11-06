using System;
using Microsoft.AspNetCore.Identity;
using Paredev.SharedKernel.Interfaces;

namespace Paredev.Identity.Core.Models;

public class Role : IdentityRole<Guid>, IAggregateRoot
{
}