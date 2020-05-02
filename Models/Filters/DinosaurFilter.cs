using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DinosaurApi.Models.Filters
{
    public class DinossaurFilter
    {
        public string Name { get; set; }

        public string Diet { get; set; }

        public decimal? Length { get; set; }

        public decimal? Weight { get; set; }

        public string WhenItLived { get; set; }

        public List<string> FoundIn { get; set; } = new List<string>();

        public string Type { get; set; }
    }
}