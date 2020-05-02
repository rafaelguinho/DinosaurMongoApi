namespace DinosaurApi.Settings
{
    public class DinosDatabaseSettings : IDinosDatabaseSettings
    {
        public string DinosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDinosDatabaseSettings
    {
        string DinosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}