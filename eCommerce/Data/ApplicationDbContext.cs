using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    /*
     * DbContext representa una sesión con la base de datos, que puede ser utilizada 
     * para obtener y guardar instancias de algunas entidades.
     */
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /*
         * La clase EntityFrameworkCore.DbSet<TEntity> nos permite almacenar instancias
         * de TEntity y ejecutar queries de LINQ contra estas. Su comportamiento básico
         * es similar al de un IEnumerable.
         */
        public DbSet<Category> Category { get; set; }
        public DbSet<TipoAplicacion> TipoAplicacion { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
