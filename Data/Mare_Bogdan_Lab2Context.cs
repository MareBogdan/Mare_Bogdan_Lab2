using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mare_Bogdan_Lab2.Models;

namespace Mare_Bogdan_Lab2.Data
{
    public class Mare_Bogdan_Lab2Context : DbContext
    {
        public Mare_Bogdan_Lab2Context (DbContextOptions<Mare_Bogdan_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Mare_Bogdan_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Mare_Bogdan_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Mare_Bogdan_Lab2.Models.Author> Author { get; set; } = default!;
    }
}
