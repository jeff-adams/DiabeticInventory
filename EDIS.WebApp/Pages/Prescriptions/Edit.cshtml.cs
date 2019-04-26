using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDIS.WebApp.Models;

namespace EDIS.WebApp.Pages.Prescriptions
{
    public class EditModel : PageModel
    {
        private readonly EDIS.WebApp.Models.EDISContext _context;

        public EditModel(EDIS.WebApp.Models.EDISContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prescription Prescription { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prescription = await _context.Prescription
                .Include(p => p.StockNumberNavigation).FirstOrDefaultAsync(m => m.RxNumber == id);

            if (Prescription == null)
            {
                return NotFound();
            }
           ViewData["StockNumber"] = new SelectList(_context.Inventory, "StockNumber", "StockNumber");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Prescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(Prescription.RxNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PrescriptionExists(string id)
        {
            return _context.Prescription.Any(e => e.RxNumber == id);
        }
    }
}
