﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Curcean_Teodor_iulian_Lab2.Data;
using Curcean_Teodor_iulian_Lab2.Models;

namespace Curcean_Teodor_iulian_Lab2.Pages.Authors
{
    public class DeleteModel : PageModel
    {
        private readonly Curcean_Teodor_iulian_Lab2.Data.Curcean_Teodor_iulian_Lab2Context _context;

        public DeleteModel(Curcean_Teodor_iulian_Lab2.Data.Curcean_Teodor_iulian_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);

            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }
            var author = await _context.Author.FindAsync(id);

            if (author != null)
            {
                Author = author;
                _context.Author.Remove(Author);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
