using System.Threading.Tasks;
using Boogops.Core;
using FluentAssertions;
using MongoDB.Driver;
using Moq;
using Xunit;
using ThingDefStore = Boogops.MongoDbCore.ThingDefStore<Boogops.MongoDbCore.ThingDef>;

namespace Boogops.MongoDbCore.Tests;

public class ThingDefStoreTests
{
    private readonly Mock<IMongoCollection<ThingDef>> _mongoCollectionMock;
    private readonly ThingDefManager<ThingDef> _thingDefManager;

    public ThingDefStoreTests()
    {
        _mongoCollectionMock = new Mock<IMongoCollection<ThingDef>>();

        var metasMongoCollectionMock = new Mock<IGetThingDefsMongoCollection<ThingDef>>();
        metasMongoCollectionMock.Setup(x => x.Get())
            .Returns(_mongoCollectionMock.Object);

        _thingDefManager = new ThingDefManager<ThingDef>(
            new ThingDefStore(metasMongoCollectionMock.Object));
    }

    [Fact]
    public async Task Create_CreatesMeta()
    {
        // Arrange
        var thingDef = new ThingDef { Id = "Bo Bandy" };

        // Act
        var documentResult = await _thingDefManager.CreateAsync(thingDef);

        // Assert
        _mongoCollectionMock.Verify(x =>
            x.InsertOneAsync(thingDef, null, default), Times.Once);
        documentResult.Succeeded.Should().BeTrue();
    }
}