using Microsoft.EntityFrameworkCore;
using Dima.Core.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
namespace Dima.Api.Data
    
{
    public class AppDbContext(DbContextOptions<AppDbContext> opts) : IdentityDbContext<User, IdentityRole<long>,long,
        IdentityUserClaim<long>,IdentityUserRole<long>,IdentityUserLogin<long>,
        IdentityRoleClaim<long>,IdentityUserToken<long>>(opts)
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
