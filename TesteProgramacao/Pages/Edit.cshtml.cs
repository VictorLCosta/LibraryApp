using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.EntityFrameworkCore;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages
{
    public class Edit : PageModel
    {
        private readonly IUnitOfWork _unit;
        private DynamicViewData _viewBag;

        public dynamic ViewBag
        {
            get
            {
                if (_viewBag == null)
                {
                    _viewBag = new DynamicViewData(() => ViewData);
                }
                return _viewBag;
            }
        }

        public Edit(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Book = await _unit.BooksRepository.Get(id);

            var authors = await _unit.AuthorRepository.GetAll();
            ViewBag.Authors = authors.Select(a => new SelectListItem(a.Name, a.Id.ToString()));

            var pubs = await _unit.PublisherRepository.GetAll();
            ViewBag.Publishers = pubs.Select(a => new SelectListItem(a.Name, a.Id.ToString()));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unit.BooksRepository.Update(Book);

            try
            {
                await _unit.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception($"Cliente {Book.Id} não encontrado !");
            }
            
            _unit.Dispose();
            return RedirectToPage("./Index");
        }
    }
}