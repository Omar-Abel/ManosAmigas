using ManosAmigas_Back.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManosAmigas_Back.Data
{
    public class DbContextMAN : IdentityDbContext<Users>
    {
        public DbContextMAN(DbContextOptions<DbContextMAN> options) : base(options)
        {

        }
    }
}
