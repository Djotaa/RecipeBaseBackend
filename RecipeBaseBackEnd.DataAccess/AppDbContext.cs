using Microsoft.EntityFrameworkCore;
using RecipeBase_Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBase_Backend.DataAccess
{
    public class AppDbContext : DbContext
    {
        public IAppUser AppUser { get; }

        public AppDbContext(DbContextOptions options, IAppUser appUser)
            : base(options)
        {

            this.AppUser = appUser;
        }

        //public AppDbContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=RecipeBase;Integrated Security=True").UseLazyLoadingProxies();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<Favorite>().HasKey(x => new { x.RecipeId, x.UserId });
            modelBuilder.Entity<UseCase>().HasKey(x => new { x.UseCaseId, x.UserId });
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            e.UpdatedBy = AppUser?.Username;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            e.IsActive = false;
                            e.DeletedAt = DateTime.UtcNow;
                            e.DeletedBy = AppUser?.Username;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<UseCase> UseCases{ get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
    }
}
