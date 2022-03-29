#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EtudiantCRUD.Models;

namespace EtudiantCRUD.Data
{
    public class EtudiantCRUDContext : DbContext
    {
        public EtudiantCRUDContext (DbContextOptions<EtudiantCRUDContext> options)
            : base(options)
        {
        }

        public DbSet<EtudiantCRUD.Models.ListEtudiant> ListEtudiant { get; set; }

        public DbSet<EtudiantCRUD.Models.Admin> Admin { get; set; }
    }
}
