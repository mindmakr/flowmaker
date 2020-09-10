using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flowmaker.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
/*
    using (var context = serviceProvider.GetService<BloggingContext>())
    {
      // do stuff
    }
    var options = serviceProvider.GetService<DbContextOptions<BloggingContext>>();
 */
namespace Flowmaker.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Flow> Flows { get; set; }
        public DbSet<FlowInstance> FlowInstances { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<ViewPage> ContentPages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workspace>(eb =>
            {
                eb.Property(b => b.Name).HasMaxLength(32).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(64).HasDefaultValue("Untitled Workspace");
                eb.Property(b => b.DisplayOrder).HasDefaultValue(100);
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<Slot>(eb =>
            {
                eb.Property(b => b.Name).HasMaxLength(32).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(64).HasDefaultValue("Untitled Slot");
                eb.Property(b => b.Hostname).HasMaxLength(128);
                eb.Property(b => b.DisplayOrder).HasDefaultValue(100);
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.IsEditable).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<Workspace>().HasData(
                new Workspace { Id = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Title = "HCA Website", Name = "hca", DisplayOrder = 50 },
                new Workspace { Id = Guid.Parse("1a485ecf-ccb4-4921-b323-ad4e61d7b224"), Title = "Skilled Guru", Name = "skilled-guru" }
                );

            modelBuilder.Entity<Slot>().HasData(
             new Slot { IsEditable = false, WorkspaceId = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Id = Guid.Parse("127febed-3f95-4d43-9d91-ea1e15452a13"), Hostname = "hca.local", Title = "Production", Name = "prod", DisplayOrder = 50 },
             new Slot { IsEditable = true, WorkspaceId = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Id = Guid.Parse("f7c2b760-c763-4a9d-a5e0-5e72c5e22d6b"), Hostname = "dev.hca.local", Title = "Development", Name = "dev" }
             );


            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is DomainObject && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (!(entityEntry.Entity is DomainObject entity)) break;

                entity.UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    if (entity.CreatedAt == default) entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
