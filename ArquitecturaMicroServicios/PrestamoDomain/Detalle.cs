using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace PrestamoDomain
{
    [Serializable, BsonIgnoreExtraElements]
    public class Detalle
    {
        [BsonElement("idlibro"), BsonRepresentation(BsonType.Int32)]
        public int Idlibro { get; set; }
    }
}
