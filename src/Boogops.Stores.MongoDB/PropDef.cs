using MongoDB.Bson.Serialization.Attributes;

namespace Boogops.Stores.MongoDB;

public class PropDef : Stores.PropDef
{
    [BsonId]
    public string Id { get; set; }
}