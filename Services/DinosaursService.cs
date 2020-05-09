using DinosaurApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using DinosaurApi.Models.Filters;
using DinosaurApi.Settings;
using System.Threading.Tasks;
using System.Collections;
using Repository.BuscaStrategies;

namespace DinosaurApi.Services
{
    public class DinosaursService
    {
        private readonly IMongoCollection<Dinossaur> _dinos;
        private readonly IEnumerable<IDinosaurFilterStrategy> _filters;

        public DinosaursService(IDinosDatabaseSettings settings, 
            IEnumerable<IDinosaurFilterStrategy> filters)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dinos = database.GetCollection<Dinossaur>(settings.DinosCollectionName);
            _filters = filters;
        }

        public async Task<List<Dinossaur>> Get(DinossaurFilter filter)
        {
            var constructor = Builders<Dinossaur>.Filter;

            FilterDefinition<Dinossaur> condition = constructor.Empty;

            foreach(var f in _filters)
            {
                condition = condition & f.Apply(constructor, condition, filter);
            }

            return await _dinos.Find(condition).ToListAsync();
        }

        public async Task<List<Dinossaur>> Get() =>
            await _dinos.Find(dino => true).ToListAsync();

        public async Task<Dinossaur> Get(string id) =>
            await _dinos.Find<Dinossaur>(dino => dino.Id == id).FirstOrDefaultAsync();

        public async Task<Dinossaur> Create(Dinossaur dino)
        {
            await _dinos.InsertOneAsync(dino);
            return dino;
        }

        public async Task Update(string id, Dinossaur dinoIn) =>
            await _dinos.ReplaceOneAsync(dino => dino.Id == id, dinoIn);

        public async Task Remove(Dinossaur dinoIn) =>
            await _dinos.DeleteOneAsync(dino => dino.Id == dinoIn.Id);

        public async Task Remove(string id) =>
            await _dinos.DeleteOneAsync(dino => dino.Id == id);
    }
}