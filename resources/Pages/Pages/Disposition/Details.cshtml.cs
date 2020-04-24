using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IDDQD.Data;
using IDDQD.Models;

namespace IDDQD.Pages.Disposition
{
    public class DetailsModel : PageModel
    {
        private readonly IDDQD.Data.DISPContext _context;

        public DetailsModel(IDDQD.Data.DISPContext context)
        {
            _context = context;
        }

        public Dispositions Dispositions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dispositions = await _context.Dispositions.FirstOrDefaultAsync(m => m.ID == id);

            if (Dispositions == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
