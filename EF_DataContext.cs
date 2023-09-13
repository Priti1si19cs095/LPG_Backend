
using Lpg_Backend.EF_Core;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;


namespace WebApplication1.EF_Core
{
    public class EF_DataContext : DbContext
    {


        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }  
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
