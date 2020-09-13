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
        const int MAX_NAME_SIZE = 64;
        const int MAX_HOSTNAME_SIZE = 64;
        const int MAX_TITLE_SIZE = 132;
        const int MAX_SLUG_SIZE = 1024;

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
                eb.Property(b => b.Name).HasMaxLength(MAX_NAME_SIZE).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(MAX_TITLE_SIZE).HasDefaultValue("Untitled Project");
                eb.Property(b => b.DisplayOrder).HasDefaultValue(100);
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<Environment>(eb =>
            {
                eb.Property(b => b.Name).HasMaxLength(MAX_NAME_SIZE).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(MAX_TITLE_SIZE).HasDefaultValue("Untitled Environment");
                eb.Property(b => b.Hostname).HasMaxLength(MAX_HOSTNAME_SIZE);
                eb.Property(b => b.DisplayOrder).HasDefaultValue(100);
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<Flow>().Ignore(c => c.Route);
            modelBuilder.Entity<Flow>(eb =>
            {
                eb.Property(b => b.Name).HasMaxLength(MAX_NAME_SIZE).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(MAX_TITLE_SIZE).HasDefaultValue("Untitled Flow");
                eb.Property(b => b.Slug).HasMaxLength(MAX_SLUG_SIZE).IsRequired();
                eb.Property(b => b.ParentSlug).HasMaxLength(MAX_SLUG_SIZE).IsRequired();
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<ViewPage>(eb =>
            {
                eb.Property(b => b.Name).HasMaxLength(MAX_NAME_SIZE).IsRequired();
                eb.Property(b => b.Title).HasMaxLength(MAX_TITLE_SIZE).HasDefaultValue("Untitled View");
                eb.Property(b => b.Disabled).HasDefaultValue(false);
                eb.Property(b => b.CreatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAdd();
                eb.Property(b => b.UpdatedAt).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate().IsRowVersion();
            });

            modelBuilder.Entity<Project>().HasData(
            new Project { Id = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Title = "HCA Website", Name = "hca", DisplayOrder = 50, EditableHostname = "dev.hca.local" },
            new Project { Id = Guid.Parse("1a485ecf-ccb4-4921-b323-ad4e61d7b224"), Title = "Skilled Guru", Name = "skilled.guru", EditableHostname = "dev.skilledguru.local" }
            );

            modelBuilder.Entity<Environment>().HasData(
             new Environment { ProjectId = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Id = Guid.Parse("127febed-3f95-4d43-9d91-ea1e15452a13"), Hostname = "hca.local", Title = "Production", Name = "prod", DisplayOrder = 50 },
             new Environment { ProjectId = Guid.Parse("57594ca7-a447-4e3b-b894-c971f3e6821b"), Id = Guid.Parse("f7c2b760-c763-4a9d-a5e0-5e72c5e22d6b"), Hostname = "dev.hca.local", Title = "Development", Name = "dev" }
             );

            modelBuilder.Entity<Flow>().HasData(
                new Flow { EnvironmentId = Guid.Parse("f7c2b760-c763-4a9d-a5e0-5e72c5e22d6b"), Id = Guid.Parse("38881cc4-dac1-414a-b18a-7db338c0809e"), Slug = "/", ParentSlug = "", Name = "flow-homeage", Title = "Flow homepage", DisplayOrder = 50 },
                new Flow { EnvironmentId = Guid.Parse("f7c2b760-c763-4a9d-a5e0-5e72c5e22d6b"), Id = Guid.Parse("c71972e7-9a31-496f-a348-e1208a9186d3"), Slug = "/development", ParentSlug = "/", Name = "homeppage-all-development", Title = "Development", DisplayOrder = 100 }
                );

            modelBuilder.Entity<ViewPage>().HasData(
                new ViewPage { FlowId = Guid.Parse("38881cc4-dac1-414a-b18a-7db338c0809e"), Id = Guid.Parse("6e1c7243-df64-49a1-b489-b2cded451450"), Content = "<h1>Homepage from Db</h1>", Name = "page1", Title = "First Page", DisplayOrder = 50 },
                new ViewPage { FlowId = Guid.Parse("c71972e7-9a31-496f-a348-e1208a9186d3"), Id = Guid.Parse("aba759fe-c97f-434d-bf62-3d7774af9d56"), Content = "<h2>Development from Db</h2>", Name = "page2", Title = "Second Page", DisplayOrder = 100 }
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

                entity.UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    if (entity.CreatedAt == default) entity.CreatedAt = DateTime.UtcNow;
                }
                if(string.IsNullOrEmpty(entity.Name))  entity.Name = entity.Name.Replace(" ","_").ToLower();
            }
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
