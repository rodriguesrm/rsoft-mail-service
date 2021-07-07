using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RSoft.Framework.Infra.Data.MongoDb.Documents
{

    public class DocumentBase : IDocument
    {

        /// <inheritdoc/>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
