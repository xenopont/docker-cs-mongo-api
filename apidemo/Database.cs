using System.Collections.Generic;
using System.Threading.Tasks;
using apidemo.Models;
using MongoDB.Driver;

namespace apidemo
{
    public class Database
    {
        private static Database _self;
        public static Database Db => _self ?? (_self = new Database());

        private const string DbName = "cs-api-demo";

        private IMongoClient _client;
        private IMongoClient MongoClient => _client ?? (_client = new MongoClient("mongodb://172.17.0.3:27017"));

        private IMongoDatabase _db;
        private IMongoDatabase MongoDatabase => _db ?? (_db = MongoClient.GetDatabase(DbName));

        private IMongoCollection<User> _collection;
        private IMongoCollection<User> Collection => _collection ?? (_collection = MongoDatabase.GetCollection<User>("demo-collection"));

        public async Task<List<User>> UserList() => await Collection.Find(user => true).ToListAsync();

        public async void Create(User doc) => await Collection.InsertOneAsync(doc);
    }
}
