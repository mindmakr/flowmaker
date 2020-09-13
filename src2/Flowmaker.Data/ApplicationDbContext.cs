using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flowmaker.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Environment = Flowmaker.Entities.Environment;
/*
using (var context = serviceProvider.GetService<BloggingContext>())
{
// do stuff
}
var options = serviceProvider.GetService<DbContextOptions<BloggingContext>>();
*/
namespace Flowmaker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Environment> Environments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ViewPage> ContentPages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(eb =>
            {
                eb.Property(b => b.Name).HasMaxLength(32).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(64).HasDefaultValue("Untitled Project");
                eb.Property(b => b.DisplayOrder).HasDefaultValue(100);
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<Entities.Environment>(eb =>
            {
                eb.Property(b => b.Name).HasMaxLength(32).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(64).HasDefaultValue("Untitled Slot");
                eb.Property(b => b.Hostname).HasMaxLength(128);
                eb.Property(b => b.DisplayOrder).HasDefaultValue(100);
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Title = "HCA Website", Name = "hca", DisplayOrder = 50, EditableHostname="dev.hca.local" },
                new Project { Id = Guid.Parse("1a485ecf-ccb4-4921-b323-ad4e61d7b224"), Title = "Skilled Guru", Name = "skilled.guru", EditableHostname = "dev.skilledguru.local" }
                );

            modelBuilder.Entity<Environment>().HasData(
             new Environment {ProjectId = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Id = Guid.Parse("127febed-3f95-4d43-9d91-ea1e15452a13"), Hostname = "hca.local", Title = "Production", Name = "prod", DisplayOrder = 50 },
             new Environment {ProjectId = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Id = Guid.Parse("f7c2b760-c763-4a9d-a5e0-5e72c5e22d6b"), Hostname = "dev.hca.local", Title = "Development", Name = "dev" }
             );
            modelBuilder.Entity<Flow>().HasData(
                new Flow { EnvironmentId=Guid.Parse("f7c2b760-c763-4a9d-a5e0-5e72c5e22d6b"), Id = Guid.Parse("38881cc4-dac1-414a-b18a-7db338c0809e"), Slug = "/", ParentSlug = "", Name = "flow-homeage", Title = "Flow homepage" },
                new Flow { EnvironmentId = Guid.Parse("f7c2b760-c763-4a9d-a5e0-5e72c5e22d6b"), Id = Guid.Parse("c71972e7-9a31-496f-a348-e1208a9186d3"), Slug = "/development", ParentSlug = "/", Name = "homeppage-all-development", Title = "Development" }
                );

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityObject && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (!(entityEntry.Entity is EntityObject entity)) break;

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
