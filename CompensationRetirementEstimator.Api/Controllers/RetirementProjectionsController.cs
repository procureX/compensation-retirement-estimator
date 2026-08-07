using CompensationRetirementEstimator.Api.Data;
using CompensationRetirementEstimator.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompensationRetirementEstimator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetirementProjectionsController : ControllerBase {
    private readonly AppDbContext _db;

    public RetirementProjectionsController(AppDbContext db) {
        _db = db;
    }

    [HttpPost]
    public async Task<ActionResult<RetirementProjection>> Create([FromBody] RetirementProjection projection) {
        // Validate user exists
        var user = await _db.Users.FindAsync(projection.UserId);
        if (user is null)
            return BadRequest($"User with ID {projection.UserId} does not exist.");

        _db.RetirementProjections.Add(projection);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = projection.Id }, projection);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        var projection = await _db.RetirementProjections.FindAsync(id);

        if (projection == null)
            return NotFound();

        return Ok(projection);
    }
}
