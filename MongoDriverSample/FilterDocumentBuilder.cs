using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDriverSample
{
    public class FilterDocumentBuilder 
    {
        private BsonDocument filter;
        public FilterDocumentBuilder()
        {
            filter = new BsonDocument();
        }

        public FilterDocumentBuilder FilterByCode(string code)
        {
            filter.Add(nameof(ICHIDocument.Code), code);
            return this;
        }
        public FilterDocumentBuilder FilterByTitle(string title)
        {
            filter.Add(nameof(ICHIDocument.Title), new BsonRegularExpression(new Regex(title)));
            return this;
        }
        public FilterDocumentBuilder FilterByDescription(string description)
        {
            filter.Add(nameof(ICHIDocument.Description), new BsonRegularExpression(new Regex(description)));
            return this;
        }
        public FilterDocumentBuilder FilterBySuggestions(string suggestions)
        {
            filter.Add(nameof(ICHIDocument.Suggestions), new BsonRegularExpression(new Regex(suggestions)));
            return this;
        }
        public FilterDocumentBuilder FilterByPath(string path)
        {
            filter.Add(nameof(ICHIDocument.Path), path);
            return this;
        }

        public BsonDocument Build()
        {
            return filter;
        }

    }
}
