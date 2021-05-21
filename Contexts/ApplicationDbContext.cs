using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApiWallet.Entities;
using WebApiWallet.Models;

namespace WebApiWallet.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Cartera> Carteras { get; set; }
        public DbSet<Costes_fin> Costes_fins { get; set; }
        public DbSet<Costes_ini> Costes_inis { get; set; }
        public DbSet<Costos_gastos> Costos_Gastos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Letra> Letras { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<Tasa> Tasas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}