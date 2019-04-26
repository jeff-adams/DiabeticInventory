using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDIS.WebApp.Models;

namespace EDIS.WebApp.Pages.Prescriptions
{
    public class CreateModel : PageModel
    {
        private readonly EDIS.WebApp.Models.EDISContext _context;

        public CreateModel(EDIS.WebApp.Models.EDISContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StockNumber"] = new SelectList(_context.Inventory, "StockNumber", "StockNumber");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}