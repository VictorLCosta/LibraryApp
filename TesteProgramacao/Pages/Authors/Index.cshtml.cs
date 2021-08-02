using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages.Authors
{
    public class Index : PageModel
    {
        private readonly IUnitOfWork _unit;

        public Index(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<Author> Authors { get; private set; }

        public async Task OnGetAsync()
        {
            Authors = await _unit.AuthorRepository.GetAll();
            _unit.Dispose();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _unit.AuthorRepository.Delete(id);
            await _unit.Complete();
            _unit.Dispose();

            return RedirectToPage();
        }
    }
}