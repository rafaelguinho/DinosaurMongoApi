using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DinosaurApi.Models
{
    public class Dinossaur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Diet { get; set; }

        public decimal Length { get; set; }

        public decimal? Weight { get; set; }

        public string WhenItLived { get; set; }

        public List<string> FoundIn { get; set; }

        public string Type { get; set; }
    }
}