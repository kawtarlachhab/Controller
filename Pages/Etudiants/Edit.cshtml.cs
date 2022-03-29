#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EtudiantCRUD.Data;
using EtudiantCRUD.Models;
using Microsoft.AspNetCore.Authorization;

namespace EtudiantCRUD.Pages.Etudiants
{
    [Authorize]

    public class EditModel : PageModel
    {
        private readonly EtudiantCRUD.Data.EtudiantCRUDContext _context;

        public EditModel(EtudiantCRUD.Data.EtudiantCRUDContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ListEtudiant ListEtudiant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListEtudiant = await _context.ListEtudiant.FirstOrDefaultAsync(m => m.ID == id);

            if (ListEtudiant == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ListEtudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListEtudiantExists(ListEtudiant.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ListEtudiantExists(int id)
        {
            return _context.ListEtudiant.Any(e => e.ID == id);
        }
    }
}
