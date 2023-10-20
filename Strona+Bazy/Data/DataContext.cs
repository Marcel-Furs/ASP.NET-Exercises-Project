using Microsoft.EntityFrameworkCore;
using Strona_Bazy.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Strona_Bazy.Data
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<Charakter> Charakter { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}
