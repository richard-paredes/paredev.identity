using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Paredev.SharedKernel.Domain;
using Paredev.SharedKernel.Interfaces;

namespace Paredev.Identity.Core.Models;


public class User : IdentityUser<Guid>, IAggregateRoot, IEventEntity
{
    public ICollection<UserRole> Roles { get; set; }
    public List<BaseDomainEvent> Events { get; } = new List<BaseDomainEvent>();
}