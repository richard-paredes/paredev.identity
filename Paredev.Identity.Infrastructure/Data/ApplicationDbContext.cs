using System.Reflection;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paredev.Identity.Core.Models;
using Paredev.SharedKernel.Domain;
using UserClaim = Paredev.Identity.Core.Models.UserClaim;

namespace Paredev.Identity.Infrastructure.Data;

public class ApplicationDbContext :
    IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>,
    IPersistedGrantDbContext,
    IConfigurationDbContext
{
    private readonly IMediator? _mediator;

    public DbSet<PersistedGrant> PersistedGrants { get; set; } = null!;
    public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; } = null!;
    public DbSet<IdentityResource> IdentityResources { get; set;} = null!;
    public DbSet<ApiResource> ApiResources { get; set; } = null!;
    public DbSet<ApiScope> ApiScopes { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator? mediator = null) : base(options) => _mediator = mediator;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        await PublishEntityEvents().ConfigureAwait(false);

        return result;
    }

    private async Task PublishEntityEvents()
    {
        // ignore events if no dispatcher provided
        if (_mediator == null) return;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<IEventEntity>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator!.Publish(domainEvent).ConfigureAwait(false);
            }
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await SaveChangesAsync();
    }
}