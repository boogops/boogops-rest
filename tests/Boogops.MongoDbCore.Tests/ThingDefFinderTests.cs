using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Boogops.MongoDbCore.Tests;

public class ThingDefFinderTests
{
    private readonly Mock<IMongoCollectionFacade<ThingDef>> _mongoCollectionMock;
    private readonly ThingDefFinder<ThingDef> _thingDefFinder;

    public ThingDefFinderTests()
    {
        _mongoCollectionMock = new Mock<IMongoCollectionFacade<ThingDef>>();

        var findFluentMock = new Mock<IFindFluentFacade<ThingDef>>();
        findFluentMock.Setup(x => x.SingleAsync())
            .ReturnsAsync(new ThingDef { Id = "1" });
        _mongoCollectionMock.Setup(x => x.Find(It.IsAny<FilterDefinition<ThingDef>>()))
            .Returns(findFluentMock.Object);
        
        var getThingDefsMongoCollectionMock = new Mock<IGetThingDefsMongoCollection<ThingDef>>();
        getThingDefsMongoCollectionMock.Setup(x => x.Get())
            .Returns(_mongoCollectionMock.Object);

        _thingDefFinder = new ThingDefFinder<ThingDef>(getThingDefsMongoCollectionMock.Object);
    }

    [Fact]
    public async Task Find_FindsThingDef()
    {
        // Arrange
        const string id = "Bo Bandy";

        // Act
        var found = await _thingDefFinder.FindByIdAsync(id);

        // Assert
        _mongoCollectionMock.Verify(
            x => x.Find(It.IsAny<FilterDefinition<ThingDef>>()), Times.Once);
        found.Should().NotBeNull();
    }
}