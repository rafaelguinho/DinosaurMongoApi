using MongoDB.Driver;
using DinosaurApi.Models;
using DinosaurApi.Models.Filters;

namespace Repository.BuscaStrategies.Filters
{
    public class NameFilter : IDinosaurFilterStrategy
    {
        public FilterDefinition<Dinossaur> Apply(FilterDefinitionBuilder<Dinossaur> constructor,
        FilterDefinition<Dinossaur> condition, DinossaurFilter filter)
        {
            if (string.IsNullOrEmpty(filter.Name)) return condition;

            return condition & constructor.Eq(d => d.Name, filter.Name);
        }

    }
}