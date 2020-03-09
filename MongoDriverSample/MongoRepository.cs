using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoDriverSample
{
    public class MongoRepository : IReositoty
    {

        private readonly IMongoCollection<ICHIDocument> collection;

        public MongoRepository()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("ichi");
            collection = database.GetCollection<ICHIDocument>("codings");

        }
        public async Task Add(ICHIDocument ichi)
        {
            await collection.InsertOneAsync(new ICHIDocument(){ Code =  "xxx" , Title = "Fatemeh" , Description ="Montazeri" });
        }

        public Task Update(ICHIDocument ichi)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByCode(string code)
        {
            var filter = new BsonDocument("Code" , code);
            await collection.DeleteOneAsync(filter);
        }

        public async  Task Foreach(BsonDocument filter)
        {

          await collection.Find(filter)
                .ForEachAsync(document => Console.WriteLine(document?.ToJson()));
        }

        public async Task<ICHIDocument> GetByCodeAsync(string code)
        {

            var result = await collection.FindSync(i => i.Code == code).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<ICHIDocument>> GetByFilterAsync(string term)
        {
            #region FindAsync
            //var result = new List<ICHIDocument>();
            //using (var cursor = await collection.FindAsync(filter))
            //{
            //    while (await cursor.MoveNextAsync())
            //    {
            //        var batch = cursor.Current;
            //        foreach (var document in batch)
            //        {
            //            // process document
            //            result.Add(document);
            //        }
            //    }
            //}
            //return result;

            //--------------------
            var result = await collection.FindSync(i => i.Code == term ||
                                                        i.Title.Contains(term) ||
                                                        i.Description.Contains(term) ||
                                                        i.Suggestions.Contains(term)).ToListAsync();
            return result;
            #endregion

            //var result = await collection.Find(filter).ToListAsync();
            //return result;

        }

        public async Task<List<ICHIDocument>> GetByFilterAsync(BsonDocument filter)
        {
            var result = await collection.Find(filter).ToListAsync();
            return result;

        }


    }
}