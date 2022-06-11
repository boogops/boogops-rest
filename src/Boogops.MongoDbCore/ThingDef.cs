using MongoDB.Bson.Serialization.Attributes;

namespace Boogops.MongoDbCore;

public class ThingDef : Core.ThingDef
{
    [BsonId]
    public string Id { get; set; }
}