using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using TesteProgramacao.Entities;
using TesteProgramacao.Interfaces;

namespace TesteProgramacao.Pages
{
    public class Register : PageModel
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

        public Register(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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

            await _unit.BooksRepository.Add(Book);
            await _unit.Complete();
            _unit.Dispose();

            return RedirectToPage("./Index");
        }
    }
}