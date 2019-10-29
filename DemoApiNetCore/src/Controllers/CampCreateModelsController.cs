using CoreCodeCamp.Data;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampCreateModelsController : ControllerBase
    {
        private readonly CampContext _context;

        public CampCreateModelsController(CampContext context)
        {
            _context = context;
        }

        // GET: api/CampCreateModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampCreateModel>>> GetCampCreateModel()
        {
            return await _context.CampCreateModel.ToListAsync();
        }

        // GET: api/CampCreateModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampCreateModel>> GetCampCreateModel(int id)
        {
            var campCreateModel = await _context.CampCreateModel.FindAsync(id);

            if (campCreateModel == null)
            {
                return NotFound();
            }

            return campCreateModel;
        }

        // PUT: api/CampCreateModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampCreateModel(int id, CampCreateModel campCreateModel)
        {
            if (id != campCreateModel.CampId)
            {
                return BadRequest();
            }

            _context.Entry(campCreateModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampCreateModelExists(id))
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

        // POST: api/CampCreateModels
        [HttpPost]
        public async Task<ActionResult<CampCreateModel>> PostCampCreateModel(CampCreateModel campCreateModel)
        {
            _context.CampCreateModel.Add(campCreateModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampCreateModel", new { id = campCreateModel.CampId }, campCreateModel);
        }

        // DELETE: api/CampCreateModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CampCreateModel>> DeleteCampCreateModel(int id)
        {
            var campCreateModel = await _context.CampCreateModel.FindAsync(id);
            if (campCreateModel == null)
            {
                return NotFound();
            }

            _context.CampCreateModel.Remove(campCreateModel);
            await _context.SaveChangesAsync();

            return campCreateModel;
        }

        private bool CampCreateModelExists(int id)
        {
            return _context.CampCreateModel.Any(e => e.CampId == id);
        }
    }
}
