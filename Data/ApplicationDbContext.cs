using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dsd03Razor2020Assessment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<dsd03Razor2020Assessment.Models.Movie> Movie { get; set; }
        public DbSet<dsd03Razor2020Assessment.Models.Cast> Cast { get; set; }
    }
}