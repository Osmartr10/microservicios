using EstudianteDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EstudianteInfrastructure
{
    public class EstudiantebdContext : DbContext
    {
        public EstudiantebdContext(DbContextOptions<EstudiantebdContext> options) : base(options)
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
        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}
