using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebAPIRevisãoOng.Models
{
    public class PetModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [Key]
        public string Chip { get; set; }
        public string Raca { get; set; }
        public string Familia { get; set; }
        public string Sexo { get; set; }
        public string Situacao { get; set; }
        public string Name { get; set; }
    }
}
