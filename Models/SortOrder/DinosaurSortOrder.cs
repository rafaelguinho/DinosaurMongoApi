using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DinosaurApi.Models.Filters
{
    public class DinosaurSortOrder
    {
        public string SortOrder { get; set; }
    }
}