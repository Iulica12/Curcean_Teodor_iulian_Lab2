﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Curcean_Teodor_iulian_Lab2.Data;
using Curcean_Teodor_iulian_Lab2.Models;

namespace Curcean_Teodor_iulian_Lab2.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private readonly Curcean_Teodor_iulian_Lab2.Data.Curcean_Teodor_iulian_Lab2Context _context;

        public CreateModel(Curcean_Teodor_iulian_Lab2.Data.Curcean_Teodor_iulian_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
