using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Curcean_Teodor_iulian_Lab2.Models;

namespace Curcean_Teodor_iulian_Lab2.Data
{
    public class Curcean_Teodor_iulian_Lab2Context : DbContext
    {
        public Curcean_Teodor_iulian_Lab2Context (DbContextOptions<Curcean_Teodor_iulian_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Curcean_Teodor_iulian_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Curcean_Teodor_iulian_Lab2.Models.Publisher> Publisher { get; set; }

        public DbSet<Curcean_Teodor_iulian_Lab2.Models.Author> Author { get; set; }
    }
}
