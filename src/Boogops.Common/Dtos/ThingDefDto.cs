namespace Boogops.Common.Dtos;

public readonly record struct ThingDefDto(
    string Id,
    IEnumerable<PropDefDto> PropDefs
    );