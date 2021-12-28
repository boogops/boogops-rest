namespace Boogops.Common.Dtos;

public class ThingDefDto
{
    public string Id { get; set; }

    public IEnumerable<PropDefDto> PropDefs { get; set; }
}