using AutoMapper;
using Boogops.Common.Dtos;
using Boogops.Stores;
using ThingDef = Boogops.Stores.MongoDB.ThingDef;

namespace Boogops.Rest.Configuration;

public class BoogopsProfile : Profile
{
    public BoogopsProfile()
    {
        CreateMap<PropDefDto, PropDef>();
        CreateMap<ThingDefDto, ThingDef>();
    }
}