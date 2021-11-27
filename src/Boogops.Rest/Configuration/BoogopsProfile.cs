using AutoMapper;
using Boogops.Rest.Dtos;
using Boogops.Rest.Models;

namespace Boogops.Rest.Configuration;

public class BoogopsProfile : Profile
{
    public BoogopsProfile()
    {
        CreateMap<Thing, ThingDto>();
    }
}