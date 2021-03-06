using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unit;

        public IndexModel(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<Book> Books { get; private set; }

        public async Task OnGetAsync()
        {
            Books = await _unit.BooksRepository.GetAllWithAuthor();
            _unit.Dispose();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _unit.BooksRepository.Delete(id);
            await _unit.Complete();
            _unit.Dispose();

            return RedirectToPage();
        }
    }
}
