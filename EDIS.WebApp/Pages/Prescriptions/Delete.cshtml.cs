using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EDIS.WebApp.Models;

namespace EDIS.WebApp.Pages.Prescriptions
{
    public class DeleteModel : PageModel
    {
        private readonly EDIS.WebApp.Models.EDISContext _context;

        public DeleteModel(EDIS.WebApp.Models.EDISContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prescription = await _context.Prescription.FindAsync(id);

            if (Prescription != null)
            {
                _context.Prescription.Remove(Prescription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
