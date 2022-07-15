using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Boogops.MongoDbCore.Tests;

public class ThingDefCreatorTests
{
    private readonly Mock<IMongoCollectionFacade<ThingDef>> _mongoCollectionMock;
    private readonly ThingDefCreator<ThingDef> _thingDefCreator;

    public ThingDefCreatorTests()
    {
        _mongoCollectionMock = new Mock<IMongoCollectionFacade<ThingDef>>();

        _mongoCollectionMock.Setup(x => x.InsertOneAsync(It.IsAny<ThingDef>()))
            .Returns(Task.CompletedTask);
        var getThingDefsMongoCollectionMock = new Mock<IGetThingDefsMongoCollection<ThingDef>>();
        getThingDefsMongoCollectionMock.Setup(x => x.Get())
            .Returns(_mongoCollectionMock.Object);

        _thingDefCreator = new ThingDefCreator<ThingDef>(getThingDefsMongoCollectionMock.Object);
    }

    [Fact]
    public async Task Create_CreatesThingDef()
    {
        // Arrange
        var thingDef = new ThingDef { Id = "Bo Bandy" };
        
        // Act
        var documentResult = await _thingDefCreator.CreateAsync(thingDef);
        
        // Assert
        _mongoCollectionMock.Verify(x => x.InsertOneAsync(thingDef), Times.Once);
        documentResult.Succeeded.Should().BeTrue();
    }
}