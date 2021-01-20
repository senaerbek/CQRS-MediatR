using Microsoft.EntityFrameworkCore;
using Domain;
namespace Persistence
{

    public class DataContext : DbContext
    {
            public DataContext(DbContextOptions options) :base(options)
            {
                
            }

            public DbSet<Value> Values { get; set; }
            public DbSet<Post> Posts { get; set; }

            protected override void OnModelCreating(ModelBuilder builder){
                builder.Entity<Value>()
                .HasData(
                    new Value {Id =1 , Name = "V1"},
                    new Value {Id =2 , Name = "V2"}
                );
            }
    }

}