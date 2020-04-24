using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IDDQD.Data;
using IDDQD.Models;

namespace IDDQD.Pages.Knowledge
{
    public class IndexModel : PageModel
    {
        private readonly IDDQD.Data.KNEContext _context;

        public IndexModel(IDDQD.Data.KNEContext context)
        {
            _context = context;
        }

        public IList<KnowledgeElements> KnowledgeElements { get;set; }

        public async Task OnGetAsync()
        {
            KnowledgeElements = await _context.KnowledgeElements.ToListAsync();
        }
    }
}
