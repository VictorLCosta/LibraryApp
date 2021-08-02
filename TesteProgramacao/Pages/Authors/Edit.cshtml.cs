using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages.Authors
{
    public class Edit : PageModel
    {
        private readonly IUnitOfWork _unit;

        public Edit(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [BindProperty]
        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Author = await _unit.AuthorRepository.Get(id);
            if (Author == null)
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
            
            _unit.AuthorRepository.Update(Author);

            try
            {
                await _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Cliente {Author.Id} não encontrado !");
            }
            
            _unit.Dispose();
            return RedirectToPage("./Index");
        }
    }    
}