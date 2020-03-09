using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDriverSample
{
     public  class Products
    {
        [BsonId]
        public ObjectId Id { get; set; }

    }
}
