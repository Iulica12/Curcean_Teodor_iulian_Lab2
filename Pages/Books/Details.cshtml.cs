using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Curcean_Teodor_iulian_Lab2.Data;
using Curcean_Teodor_iulian_Lab2.Models;

namespace Curcean_Teodor_iulian_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Curcean_Teodor_iulian_Lab2.Data.Curcean_Teodor_iulian_Lab2Context _context;

        public DetailsModel(Curcean_Teodor_iulian_Lab2.Data.Curcean_Teodor_iulian_Lab2Context context)
        {
            _context = context;
        }

      public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.Include(a=>a.Author).FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
