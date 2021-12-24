using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace Boogops.Core.Tests;

public class ThingDefManagerTests
{
    public ThingDefManagerTests()
    {
        _thingDefStoreMock = new Mock<ITestThingDefStore>();
        _thingDefManager = new ThingDefManager<TestThingDef>(_thingDefStoreMock.Object);
    }

    private readonly Mock<ITestThingDefStore> _thingDefStoreMock;
    private readonly ThingDefManager<TestThingDef> _thingDefManager;

    [Fact]
    public async Task Create_Creates()
    {
        // Arrange
        var testThingDef = new TestThingDef();

        _thingDefStoreMock.Setup(x => x.CreateAsync(testThingDef))
            .ReturnsAsync(BoogopsManagerResult.Success);

        // Act
        var result = await _thingDefManager.CreateAsync(testThingDef);

        // Assert
        result.Should().Be(BoogopsManagerResult.Success);
        _thingDefStoreMock.Verify(x => x.CreateAsync(testThingDef), Times.Once);
    }
}