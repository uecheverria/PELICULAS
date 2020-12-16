using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty(SupportsGet = true)]
        public string filtro { get; set; }   //filtro de busqueda

        public SelectList lst_generos { get; set; } //lista de generos de bdd

        [BindProperty(SupportsGet = true)]
        public string sel_genero { get; set; } //genero seleccionado por usuario


        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(filtro))
            {
                movies = movies.Where(s => s.Title.Contains(filtro));
            }

            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;
            if (!string.IsNullOrEmpty(sel_genero))
            {
                movies = movies.Where(x => x.Genre == sel_genero);
            }

            lst_generos = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
            //Movie = await _context.Movie.ToListAsync();
        }
    }
}
