using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EagleEye.DataAccess.Entities;
using EagleEye.DataAccess.SqlDbContext;

namespace EagleEye.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAdminstratorsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ProjectAdminstratorsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectAdminstrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectAdminstrator>>> GetProjectAdminstrators()
        {
            return await _context.ProjectAdminstrators.ToListAsync();
        }

        // GET: api/ProjectAdminstrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectAdminstrator>> GetProjectAdminstrator(int id)
        {
            var projectAdminstrator = await _context.ProjectAdminstrators.FindAsync(id);

            if (projectAdminstrator == null)
            {
                return NotFound();
            }

            return projectAdminstrator;
        }

        // PUT: api/ProjectAdminstrators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectAdminstrator(int id, ProjectAdminstrator projectAdminstrator)
        {
            if (id != projectAdminstrator.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectAdminstrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectAdminstratorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProjectAdminstrators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectAdminstrator>> PostProjectAdminstrator(ProjectAdminstrator projectAdminstrator)
        {
            _context.ProjectAdminstrators.Add(projectAdminstrator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectAdminstrator", new { id = projectAdminstrator.Id }, projectAdminstrator);
        }

        // DELETE: api/ProjectAdminstrators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAdminstrator(int id)
        {
            var projectAdminstrator = await _context.ProjectAdminstrators.FindAsync(id);
            if (projectAdminstrator == null)
            {
                return NotFound();
            }

            _context.ProjectAdminstrators.Remove(projectAdminstrator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectAdminstratorExists(int id)
        {
            return _context.ProjectAdminstrators.Any(e => e.Id == id);
        }
    }
}
