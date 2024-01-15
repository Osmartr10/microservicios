using LibroDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
namespace LibroInfrastructure
{
    public class LibrobdContext : DbContext
    {
        public LibrobdContext(DbContextOptions options) : base(options)
        {
            try
            {
                var basedatos = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (basedatos != null)
                {
                    if (!basedatos.CanConnect())
                    {
                        basedatos.Create();
                    }
                    if (!basedatos.HasTables())
                    {
                        basedatos.CreateTables();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<AutorLibro> AutorLibros { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
