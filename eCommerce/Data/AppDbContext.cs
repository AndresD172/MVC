using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Agregamos los modelos correspondientes a cada tabla de la base de datos
        DbSet<Category> category { get; set; }
    }
}
