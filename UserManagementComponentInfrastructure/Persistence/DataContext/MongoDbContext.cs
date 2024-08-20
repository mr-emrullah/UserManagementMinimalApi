using MongoDB.Driver;

namespace UserManagementComponentInfrastructure;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);
}

public class MongoDbContext : IMongoDbContext
{
    internal readonly MongoClientSettings ConnectionString;
    internal readonly string DatabaseName;
    private readonly IMongoDatabase _database;

    public MongoDbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}