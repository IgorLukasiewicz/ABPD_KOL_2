using System.ComponentModel.DataAnnotations;
using KOLOK_2.DTOs;
using KOLOK_2.Exceptions;
using KOLOK_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOLOK_2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExhibitionsController : ControllerBase
{
    private readonly IDbService _dbService;

    public ExhibitionsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddWashingMachine([FromBody] AddNewExhibitionDTO dto)
    {
        try
        {
            await _dbService.AddNewExhibition(dto);
            return StatusCode(201);
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}