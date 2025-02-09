using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class AdmissionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdmissionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Admission
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Admission>>> GetAdmissions()
    {
        return await _context.Admissions.ToListAsync();
    }

    // POST: api/Admission
    [HttpPost]
    public async Task<ActionResult<Admission>> PostAdmission(Admission admission)
    {
        _context.Admissions.Add(admission);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAdmissions", new { id = admission.Id }, admission);
    }
}
