using MongoDB.Driver;
using DinosaurApi.Models;
using DinosaurApi.Models.Filters;
using System.Linq;

namespace Repository.BuscaStrategies.Filters
{
    public class FoundInFilter: IDinosaurFilterStrategy
    {
        public FilterDefinition<Dinossaur> Apply(FilterDefinitionBuilder<Dinossaur> constructor, 
        FilterDefinition<Dinossaur> condition, DinossaurFilter filter)
        {
            if(!filter.FoundIn.Any()) return condition;

            foreach (var found in filter.FoundIn)
            {
                condition = condition & constructor.AnyEq(d => d.FoundIn, found);
            }

            return condition;
        }

    }
}