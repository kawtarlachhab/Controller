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
    public class IndexModel : PageModel
    {
        private readonly EtudiantCRUD.Data.EtudiantCRUDContext _context;

        public IndexModel(EtudiantCRUD.Data.EtudiantCRUDContext context)
        {
            _context = context;
        }

        public IList<ListEtudiant> ListEtudiant { get;set; }

        public async Task OnGetAsync()
        {
            ListEtudiant = await _context.ListEtudiant.ToListAsync();
        }
    }
}
