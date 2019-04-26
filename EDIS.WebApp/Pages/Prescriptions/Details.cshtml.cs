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
    public class DetailsModel : PageModel
    {
        private readonly EDIS.WebApp.Models.EDISContext _context;

        public DetailsModel(EDIS.WebApp.Models.EDISContext context)
        {
            _context = context;
        }

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
    }
}
