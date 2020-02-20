using Microsoft.EntityFrameworkCore;
using PeopleWebApi.Models;
using System;

namespace PeopleWebApi.Db
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> contextOptions)
            : base(contextOptions) { }

        public DbSet<Person> People { get; set; }

        #region Overrides of DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Person>()
                .HasData(
                    new Person { Id = Guid.NewGuid(), Fullname = "Person-1-Fullname"}, 
                    new Person { Id = Guid.NewGuid(), Fullname = "Person-2-Fullname"}, 
                    new Person { Id = Guid.NewGuid(), Fullname = "Person-3-Fullname"});
        }

        #endregion
    }
}
