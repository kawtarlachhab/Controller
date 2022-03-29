#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EtudiantCRUD.Data;
using EtudiantCRUD.Models;
using Microsoft.AspNetCore.Authorization;

namespace EtudiantCRUD.Pages.Etudiants
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly EtudiantCRUD.Data.EtudiantCRUDContext _context;

        public DeleteModel(EtudiantCRUD.Data.EtudiantCRUDContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListEtudiant = await _context.ListEtudiant.FindAsync(id);

            if (ListEtudiant != null)
            {
                _context.ListEtudiant.Remove(ListEtudiant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
