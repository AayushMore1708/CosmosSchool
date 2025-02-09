using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class SchoolController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SchoolController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/School
    [HttpGet]
    public async Task<ActionResult<IEnumerable<School>>> GetSchools()
    {
        return await _context.Schools.ToListAsync();
    }

    // POST: api/School
    [HttpPost]
    public async Task<ActionResult<School>> PostSchool(School school)
    {
        _context.Schools.Add(school);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetSchools", new { id = school.Id }, school);
    }
}
