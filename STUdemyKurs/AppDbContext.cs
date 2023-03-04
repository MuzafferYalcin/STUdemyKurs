using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STUdemyKurs.Models;

namespace STUdemyKurs
{
    public class AppDbContext : IdentityDbContext<User,Role,int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
