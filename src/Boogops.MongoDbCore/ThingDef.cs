using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boogops.MongoDbCore;

public class ThingDef : Core.ThingDef
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
}