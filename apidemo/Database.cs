using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using apidemo.Models;

namespace apidemo
{
    public class Database
    {
        protected static Database _self = null;
        public static Database Db
        {
            get
            {
                if (_self == null)
                {
                    _self = new Database();
                }
                return _self;
            }
        }

        protected const string DbName = "cs-api-demo";

        protected IMongoClient _client = null;
        protected IMongoClient MongoClient {
            get {
                if (_client == null) {
                    _client = new MongoClient("mongodb://172.17.0.3:27017");
                }
                return _client;
            }
        }

        protected IMongoDatabase _db = null;
        protected IMongoDatabase MongoDatabase {
            get {
                if (_db == null) {
                    _db = MongoClient.GetDatabase(DbName);
                }
                return _db;
            }
        }

        protected IMongoCollection<User> _collection = null;
        protected IMongoCollection<User> Collection {
            get {
                if (_collection == null) {
                    _collection = MongoDatabase.GetCollection<User>("demo-collection");
                }
                return _collection;
            }
        }

        public async Task<List<User>> UserList() {
            return await Collection.Find<User>(user => true).ToListAsync();
        }

        public async void Create(User doc)
        {
            await Collection.InsertOneAsync(doc);
        }
    }
}
