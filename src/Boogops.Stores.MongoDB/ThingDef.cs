using MongoDB.Bson.Serialization.Attributes;

namespace Boogops.Stores.MongoDB;

public class ThingDef : Stores.ThingDef
{
    [BsonId] public string Id { get; set; }
}