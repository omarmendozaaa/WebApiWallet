using Microsoft.EntityFrameworkCore;
using WebApiWallet.Entities;

namespace WebApiWallet
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}