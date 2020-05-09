using MongoDB.Driver;
using DinosaurApi.Models;
using DinosaurApi.Models.Filters;

namespace Repository.BuscaStrategies
{
    public interface IDinosaurFilterStrategy
    {
        FilterDefinition<Dinossaur> Apply(FilterDefinitionBuilder<Dinossaur> constructor, FilterDefinition<Dinossaur> condition, DinossaurFilter filter);

    }
}