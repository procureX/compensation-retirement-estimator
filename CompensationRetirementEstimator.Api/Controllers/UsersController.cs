using CompensationRetirementEstimator.Api.Data;
using CompensationRetirementEstimator.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompensationRetirementEstimator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;

    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    // CREATE
    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    // READ ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        return await _db.Users.ToListAsync();
    }

    // READ ONE
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();
        return user;
    }

    // UPDATE
    [HttpPut("{id:int}")]
    public async Task<ActionResult<User>> Update(int id, [FromBody] User updated)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();

        user.Name = updated.Name;
        user.Age = updated.Age;
        user.CurrentSalary = updated.CurrentSalary;

        await _db.SaveChangesAsync();
        return user;
    }

    // DELETE
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user is null) return NotFound();

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
