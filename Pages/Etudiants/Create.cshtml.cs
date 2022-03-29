#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EtudiantCRUD.Data;
using EtudiantCRUD.Models;
using Microsoft.AspNetCore.Authorization;

namespace EtudiantCRUD.Pages.Etudiants
{
    [Authorize] 
    public class CreateModel : PageModel
    {
        private readonly EtudiantCRUD.Data.EtudiantCRUDContext _context;

        public CreateModel(EtudiantCRUD.Data.EtudiantCRUDContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ListEtudiant ListEtudiant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ListEtudiant.Add(ListEtudiant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
