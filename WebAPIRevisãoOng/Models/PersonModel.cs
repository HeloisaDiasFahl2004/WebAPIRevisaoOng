using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace WebAPIRevisãoOng.Models
{
    public class PersonModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public PetModel Pet{ get; set; }
        public AddressModel Address{ get; set; }
    }
}
