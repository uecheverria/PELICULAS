using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PELICULAS.Modelos;

namespace PELICULAS.Data
{
    public class PELICULASContext : DbContext
    {
        public PELICULASContext (DbContextOptions<PELICULASContext> options)
            : base(options)
        {
        }

        public DbSet<PELICULAS.Modelos.Movie> Movie { get; set; }
    }
}
