using Microsoft.EntityFrameworkCore;
using WebApiSummeryHW.Models;

namespace WebApiSummeryHW.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public virtual DbSet<Flower> Flowers { get; set; }  
    }
}
