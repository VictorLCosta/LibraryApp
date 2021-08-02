using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages.Publishers
{
    public class Register : PageModel
    {
        private readonly IUnitOfWork _unit;

        public Register(IUnitOfWork unit)
        {
            _unit = unit;
        }
        
        [BindProperty]
        public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            await _unit.PublisherRepository.Add(Publisher);
            await _unit.Complete();
            _unit.Dispose();

            return RedirectToPage("./Index");
        }
    }
}