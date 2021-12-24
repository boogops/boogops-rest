using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Boogops.Rest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ThingDefsController : Controller
{
    private readonly IMapper _mapper;

    public ThingDefsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        throw new NotImplementedException();
        // var retval = _db.Things
        //     .ProjectTo<ThingDto>(_mapper.ConfigurationProvider)
        //     .SingleOrDefault(u => u.Id == id);
        //
        // if (retval == null)
        //     return NotFound();
        //
        // return Ok(retval);
    }
}