using AutoMapper;
using AutoMapper.QueryableExtensions;
using Boogops.Rest.Dtos;
using Boogops.Rest.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boogops.Rest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThingsController : Controller
{
    private readonly BoogopsDbContext _db;
    private readonly IMapper _mapper;

    public ThingsController(BoogopsDbContext context, IMapper mapper)
    {
        _db = context;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var retval = _db.Units
            .ProjectTo<ThingDto>(_mapper.ConfigurationProvider)
            .SingleOrDefault(u => u.Id == id);

        if (retval == null)
            return NotFound();

        return Ok(retval);
    }
}