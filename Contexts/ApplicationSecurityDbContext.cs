using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApiWallet.Entities;
using WebApiWallet.Models;

namespace WebApiWallet.Contexts
{
    public class ApplicationSecurityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationSecurityDbContext(DbContextOptions options) : base(options)
        {

        }
        
    }
}