using CompensationRetirementEstimator.Api.Data;
using CompensationRetirementEstimator.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompensationRetirementEstimator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RetirementProjectionsController : ControllerBase
{
    private readonly AppDbContext _db;

    public RetirementProjectionsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<ActionResult<RetirementProjection>> Create([FromBody] RetirementProjection input)
    {
        // Simple placeholder formula – we’ll refine later
        var yearsToRetirement = input.RetirementAge - 30; // assume starting age 30 for now
        var projectedMonthly = (input.ContributionRate + input.EmployerMatchRate) * yearsToRetirement * 100;

        input.ProjectedMonthlyIncome = projectedMonthly;

        _db.RetirementProjections.Add(input);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RetirementProjection>> GetById(int id)
    {
        var proj = await _db.RetirementProjections.FindAsync(id);
        if (proj is null) return NotFound();
        return proj;
    }
}
