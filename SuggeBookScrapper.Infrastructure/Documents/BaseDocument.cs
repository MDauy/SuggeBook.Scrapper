
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggeBookScrapper.Infrastructure.Documents
{
    public abstract class BaseDocument
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Oid{ get; set; }
    }
}
