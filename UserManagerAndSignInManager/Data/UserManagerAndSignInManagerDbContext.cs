using UserManagerAndSignInManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace UserManagerAndSignInManager.Data
{
    // << IdentityDbContext NOT "DbContext" 
    // << This Links "Identity" Framework with the database
    // NOW GO TO DEPENDENCY INJECTION IN THE PROGRAM FILE
    public class UserManagerAndSignInManagerDBContext : IdentityDbContext  

    {
        
        public UserManagerAndSignInManagerDBContext()
        {
        }

        public UserManagerAndSignInManagerDBContext(DbContextOptions<UserManagerAndSignInManagerDBContext> options) : base(options)
        {
        }

        // DbSets For Purpose of Migration
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MigrationTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }
    }
}

