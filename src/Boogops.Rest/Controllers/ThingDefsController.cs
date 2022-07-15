// using AutoMapper;
// using Boogops.Common.Dtos;
// using Boogops.Core;
// using Microsoft.AspNetCore.Mvc;
// using ThingDef = Boogops.MongoDbCore.ThingDef;
//
// namespace Boogops.Rest.Controllers;
//
// [ApiController]
// [Route("api/[controller]")]
// public class ThingDefsController : Controller
// {
//     private readonly IMapper _mapper;
//     private readonly ThingDefManager<ThingDef> _thingDefManager;
//
//     public ThingDefsController(ThingDefManager<ThingDef> thingDefManager, IMapper mapper)
//     {
//         _thingDefManager = thingDefManager;
//         _mapper = mapper;
//     }
//
//     [HttpPost]
//     public async Task<IActionResult> PostAsync([FromBody] ThingDefDto dto)
//     {
//         var entity = _mapper.Map<ThingDef>(dto);
//         var result = await _thingDefManager.CreateAsync(entity);
//
//         if (result.Succeeded)
//             return Created($"api/ThingDefs/{entity.Id}", entity);
//
//         // need to bring in Serilog
//         // foreach (var error in result.Errors)
//         // {
//         //     _logger.Error(error.Description);
//         // }
//         throw new Exception("Unable to persist ThingDef.");
//     }
// }