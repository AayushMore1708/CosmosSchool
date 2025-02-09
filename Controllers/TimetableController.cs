using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TimetableController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TimetableController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Timetable
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Timetable>>> GetTimetables()
    {
        return await _context.Timetables.ToListAsync();
    }

    // POST: api/Timetable
    [HttpPost]
    public async Task<ActionResult<Timetable>> PostTimetable(Timetable timetable)
    {
        _context.Timetables.Add(timetable);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetTimetables", new { id = timetable.Id }, timetable);
    }
}
