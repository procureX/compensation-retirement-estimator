using CompensationRetirementEstimator.Api.Data;
using CompensationRetirementEstimator.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompensationRetirementEstimator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetirementProjectionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RetirementProjectionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RetirementProjection projection)
    {
        _context.RetirementProjections.Add(projection);
        await _context.SaveChangesAsync();
        return Ok(projection);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var projection = await _context.RetirementProjections.FindAsync(id);

        if (projection == null)
            return NotFound();

        return Ok(projection);
    }
}
