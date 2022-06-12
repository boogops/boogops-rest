using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Boogops.MongoDbCore;

public class ThingDef : Core.ThingDef
{
    [BsonId]
    public ObjectId Id { get; set; }
}