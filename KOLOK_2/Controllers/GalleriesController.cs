using KOLOK_2.Exceptions;
using KOLOK_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLOK_2.Controllers;


[ApiController]
[Route("api/[controller]")]
public class GalleriesController : ControllerBase
{
    private readonly IDbService _dbService;

    public GalleriesController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> getClientInfoById(int id)
    {
        try
        {
            var g_info = await _dbService.GetGalleriesInfo(id);
            return Ok(g_info);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
    
}