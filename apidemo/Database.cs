using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using MongoDB.Driver;
using MongoDB.Bson;

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

        protected IMongoCollection<BsonDocument> _collection = null;
        protected IMongoCollection<BsonDocument> Collection {
            get {
                if (_collection == null) {
                    _collection = MongoDatabase.GetCollection<BsonDocument>("demo-collection");
                }
                return _collection;
            }
        }

        public async Task<List<BsonDocument>> LoadDocumentsAsync() {
            BsonDocument filter = new BsonDocument();
            FindOptions options = new FindOptions {
                MaxTime = TimeSpan.FromMilliseconds(200)
            };

            List<BsonDocument> list = await Collection.Find(filter, options).ToListAsync();
            return list;
        }
    }
}