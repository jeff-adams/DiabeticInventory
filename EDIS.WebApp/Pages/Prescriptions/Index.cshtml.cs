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
    public class IndexModel : PageModel
    {
        private readonly EDIS.WebApp.Models.EDISContext _context;

        public IndexModel(EDIS.WebApp.Models.EDISContext context)
        {
            _context = context;
        }

        public IList<Prescription> Prescription { get;set; }

        public async Task OnGetAsync()
        {
            Prescription = await _context.Prescription
                .Include(p => p.StockNumberNavigation).ToListAsync();
        }
    }
}
