using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mare_Bogdan_Lab2.Data;
using Mare_Bogdan_Lab2.Models;

namespace Mare_Bogdan_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Mare_Bogdan_Lab2Context _context;

        public IndexModel(Mare_Bogdan_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public required BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        // Metoda unificată OnGetAsync
        public async Task OnGetAsync(int? id = null, int? categoryID = null)
        {
            BookD = new BookData();

            // Include Publisher și BookCategories pentru a prelua datele de care ai nevoie
            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            // Verifică dacă există un ID specificat pentru a selecta o carte
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value)
                    .Single();

                // Preia categoriile cărții selectate
                BookD.Categories = book.BookCategories?.Select(s => s.Category) ?? Enumerable.Empty<Category>();
            }
        }
    }
}
