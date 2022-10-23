using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebAPIRevisãoOng.Models
{
    public class AddressModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [Key]
        public string IdAddress { get; set; }
        public string Cep { get; set; }
        public string Number { get; set; }
    }
}
