using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IDDQD.Data;
using IDDQD.Models;

namespace CIDM4390_IDDQD.IDDQD_UI.Pages.Disposition
{
    public class IndexModel : PageModel
    {
        private readonly IDDQD.Data.DISPContext _context;

        public IndexModel(IDDQD.Data.DISPContext context)
        {
            _context = context;
        }

        public IList<Dispositions> Dispositions { get;set; }

        public async Task OnGetAsync()
        {
            Dispositions = await _context.Dispositions.ToListAsync();
        }
    }
}
