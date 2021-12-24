using System.Threading.Tasks;
using Boogops.Core;
using FluentAssertions;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Boogops.Stores.MongoDB.Tests;

public class ThingDefStoreTests
{
    public ThingDefStoreTests()
    {
        _mongoCollectionMock = new Mock<IMongoCollection<ThingDef>>();

        var metasMongoCollectionMock = new Mock<IGetThingDefsMongoCollection<ThingDef>>();
        metasMongoCollectionMock.Setup(x => x.Get())
            .Returns(_mongoCollectionMock.Object);

        _thingDefManager = new ThingDefManager<ThingDef>(
            new ThingDefStore<ThingDef>(metasMongoCollectionMock.Object));
    }

    private readonly Mock<IMongoCollection<ThingDef>> _mongoCollectionMock;
    private readonly ThingDefManager<ThingDef> _thingDefManager;

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