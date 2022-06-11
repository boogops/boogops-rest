using AutoMapper;
using Boogops.Common.Dtos;
using Boogops.Core;
using ThingDef = Boogops.MongoDbCore.ThingDef;

namespace Boogops.Rest.Configuration;

public class BoogopsProfile : Profile
{
    public BoogopsProfile()
    {
        CreateMap<PropDefDto, PropDef>();
        CreateMap<ThingDefDto, ThingDef>();
    }
}