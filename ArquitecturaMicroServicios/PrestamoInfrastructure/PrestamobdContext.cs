using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PrestamoDomain;

namespace PrestamoInfrastructure
{
    public class PrestamobdContext
    {
        private readonly IMongoDatabase _basedatos;

        public PrestamobdContext(IOptions<BDConfiguracion> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _basedatos = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<Prestamo> Prestamos
        {
            get
            {
                return _basedatos.GetCollection<Prestamo>("prestamo");
            }
        }
    }
}
