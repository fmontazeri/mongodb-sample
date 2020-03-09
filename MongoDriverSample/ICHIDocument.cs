using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDriverSample
{
    [DataContract]
    public class ICHIDocument
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }
        [BsonElement]
        [DataMember]
        public string Type { get; set; }
        [BsonElement]
        [DataMember]
        public string Code { get; set; }
        [BsonElement]
        [DataMember]
        public string Path { get; set; }
        [BsonElement]
        [DataMember]
        public string Title { get; set; }
        [BsonElement]
        [DataMember]
        public string Description { get; set; }
        [BsonElement]
        [DataMember]
        public string Extension { get; set; }
        [BsonElement]
        [DataMember]
        public string Suggestions { get; set; }
    }
}
