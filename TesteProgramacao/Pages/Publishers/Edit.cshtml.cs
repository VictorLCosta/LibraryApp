using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages.Publishers
{
    public class Edit : PageModel
    {
        private readonly IUnitOfWork _unit;

        public Edit(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [BindProperty]
        public Publisher Publisher { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Publisher = await _unit.PublisherRepository.Get(id);
            if (Publisher == null)
            {
                return RedirectToPage("./Index");
            }
            _unit.Dispose();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _unit.PublisherRepository.Update(Publisher);

            try
            {
                await _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Cliente {Publisher.Id} não encontrado !");
            }
            
            _unit.Dispose();
            return RedirectToPage("./Index");
        }
    }    
}