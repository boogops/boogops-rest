using System.ComponentModel.DataAnnotations;

namespace Boogops.Rest.Models;

public class Thing
{
    public string Id { get; set; }
    
    [Required]
    public string Json { get; set; }
}

public class PropDef
{
    public string Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public PropType PropType { get; set; }
}

public enum PropType
{
    String,
    Number,
    Date,
    Boolean
}