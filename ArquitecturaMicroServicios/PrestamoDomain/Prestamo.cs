using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PrestamoDomain
{
    [Serializable, BsonIgnoreExtraElements]
    public class Prestamo
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Idprestamo { get; set; }

        [BsonElement("idestudiante"), BsonRepresentation(BsonType.Int32)]
        public int Idestudiante { get; set; }

        [BsonElement("fechaprestamo"), BsonRepresentation(BsonType.DateTime)]
        public DateTime FechaPrestamo { get; set; }

        [BsonElement("fechadevolucion"), BsonRepresentation(BsonType.DateTime)]
        public DateTime FechaDevolucion { get; set; }

        [BsonElement("estado"), BsonRepresentation(BsonType.String)]
        public string Estado { get; set; } = null!;

        [BsonElement("detalle")]
        public List<Detalle>? PrestamoDetalle { get; set; }
    }
}
