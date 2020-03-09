using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace MongoDriverSample
{
    class Program
    {
        static async  Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var filterBuilder = new FilterDocumentBuilder();

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsetting.json", true, true).Build();

            var serviceProvider = new ServiceCollection()
                .AddScoped<IReositoty, MongoRepository>().BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IReositoty>();

            //var findResult = await service.GetByCodeAsync("03");
            //Console.WriteLine($"Result: {findResult?.ToJson()}");

            var filter = filterBuilder
                .FilterByTitle("Interventions")
                .FilterByCode("03")
                .FilterByDescription("Interventions")
                .Build();
            var findByFilter = await service.GetByFilterAsync(filter);
            Console.WriteLine($"Result: {findByFilter?.ToJson()}");

            Console.WriteLine("----------------------------------------");

            //var result1 = await service.GetByFilterAsync("Interventions");
            //Console.WriteLine($"Result: {result1?.ToJson()}");

            //await  service.Foreach(new BsonDocument("Description", "Interventions on the Ear and Mastoid"));
            Console.ReadLine();
            Console.WriteLine("Press any key to exit ...");



            //var client = new MongoClient();
            //var database = client.GetDatabase("ichi");
            //var collection = database.GetCollection<ICHIDocument>("codings");
            //var result = await collection.FindSync(i=> i.Title == "03 - Interventions on the Ear and Mastoid").ToListAsync();


        }
    }
}
