#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EtudiantCRUD.Data;
using EtudiantCRUD.Models;

namespace EtudiantCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListEtudiantsController : ControllerBase
    {
        private readonly EtudiantCRUDContext _context;

        public ListEtudiantsController(EtudiantCRUDContext context)
        {
            _context = context;
        }

        // GET: api/ListEtudiants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListEtudiant>>> GetListEtudiant()
        {
            return await _context.ListEtudiant.ToListAsync();
        }

        // GET: api/ListEtudiants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListEtudiant>> GetListEtudiant(int id)
        {
            var listEtudiant = await _context.ListEtudiant.FindAsync(id);

            if (listEtudiant == null)
            {
                return NotFound();
            }

            return listEtudiant;
        }

        // PUT: api/ListEtudiants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListEtudiant(int id, ListEtudiant listEtudiant)
        {
            if (id != listEtudiant.ID)
            {
                return BadRequest();
            }

            _context.Entry(listEtudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListEtudiantExists(id))
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

        // POST: api/ListEtudiants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListEtudiant>> PostListEtudiant(ListEtudiant listEtudiant)
        {
            _context.ListEtudiant.Add(listEtudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListEtudiant", new { id = listEtudiant.ID }, listEtudiant);
        }

        // DELETE: api/ListEtudiants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListEtudiant(int id)
        {
            var listEtudiant = await _context.ListEtudiant.FindAsync(id);
            if (listEtudiant == null)
            {
                return NotFound();
            }

            _context.ListEtudiant.Remove(listEtudiant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListEtudiantExists(int id)
        {
            return _context.ListEtudiant.Any(e => e.ID == id);
        }
    }
}
