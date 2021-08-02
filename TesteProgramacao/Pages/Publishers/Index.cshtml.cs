using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages.Publishers
{
    public class Index : PageModel
    {
        private readonly IUnitOfWork _unit;

        public Index(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IEnumerable<Publisher> Publishers { get; private set; }

        public async Task OnGetAsync()
        {
            Publishers = await _unit.PublisherRepository.GetAll();
            _unit.Dispose();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _unit.PublisherRepository.Delete(id);
            await _unit.Complete();
            _unit.Dispose();

            return RedirectToPage();
        }
    }
}