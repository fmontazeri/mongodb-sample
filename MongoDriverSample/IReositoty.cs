using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDriverSample
{
    public  interface IReositoty
    {

        Task Add(ICHIDocument ichi);
        Task Update(ICHIDocument ichi);
        Task DeleteByCode(string code);
        Task<ICHIDocument> GetByCodeAsync(string code);
        Task<List<ICHIDocument>> GetByFilterAsync(BsonDocument filter);
        Task<List<ICHIDocument>> GetByFilterAsync(string term);
        Task Foreach(BsonDocument filter);


    }
}
