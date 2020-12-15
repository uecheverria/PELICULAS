using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PELICULAS.Data;
using PELICULAS.Modelos;

namespace PELICULAS.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly PELICULAS.Data.PELICULASContext _context;

        public IndexModel(PELICULAS.Data.PELICULASContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
