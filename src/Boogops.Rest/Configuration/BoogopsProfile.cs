using AutoMapper;
using Boogops.Common.Dtos;
using Boogops.Stores.MongoDB;

namespace Boogops.Rest.Configuration;

public class BoogopsProfile : Profile
{
    public BoogopsProfile()
    {
        CreateMap<ThingDef, ThingDefDto>();
    }
}