using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDemo.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiDemo.Services
{
    public class Database
    {
        private static Database _self;
        public static Database Db => _self ?? (_self = new Database());

        private const string DbName = "cs-api-demo";

        private IMongoClient _client;
        private IMongoClient MongoClient => _client ?? (_client = new MongoClient("mongodb://mongo:27017"));

        private IMongoDatabase _db;
        private IMongoDatabase MongoDatabase => _db ?? (_db = MongoClient.GetDatabase(DbName));

        private IMongoCollection<User> _collection;
        private IMongoCollection<User> Collection => _collection ?? (_collection = MongoDatabase.GetCollection<User>("demo-collection"));

        public async Task<List<User>> UserList() => await Collection.Find(user => true).ToListAsync(); // bool function (user) => { return user.AnyProperty == 'its value'; }
        public async Task<User> UserDetails(string id) => await Collection.Find(user => user.Id == id).SingleOrDefaultAsync();

        public async Task Create(User doc) => await Collection.InsertOneAsync(doc, new InsertOneOptions { BypassDocumentValidation = false });

        public async Task<UpdateResult> Update(string userId, string password = null, int? age = null)
        {
            var set = new BsonDocument();
            if (password != null)
            {
                set.Add("password", password);
            }

            if (age != null)
            {
                set.Add("age", age);
            }

            return await Collection.UpdateOneAsync(u => u.Id == userId, new BsonDocument("$set", set));
        }

        public async Task<DeleteResult> Delete(string id) => await Collection.DeleteOneAsync(u => u.Id == id);
    }
}
