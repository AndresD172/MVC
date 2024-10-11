using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    /*
     * DbContext representa una sesión con la base de datos, que puede ser utilizada 
     * para obtener y guardar instancias de algunas entidades.
     */
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /*
         * La clase EntityFrameworkCore.DbSet<TEntity> nos permite almacenar instancias
         * de TEntity y ejecutar queries de LINQ contra estas. Su comportamiento básico
         * es similar al de un IEnumerable.
         */
        public DbSet<Category> Category { get; set; }
        public DbSet<AppType> AppType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}
