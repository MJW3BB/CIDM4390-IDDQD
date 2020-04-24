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
    public class DeleteModel : PageModel
    {
        private readonly IDDQD.Data.KNEContext _context;

        public DeleteModel(IDDQD.Data.KNEContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KnowledgeElements KnowledgeElements { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnowledgeElements = await _context.KnowledgeElements.FirstOrDefaultAsync(m => m.ID == id);

            if (KnowledgeElements == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KnowledgeElements = await _context.KnowledgeElements.FindAsync(id);

            if (KnowledgeElements != null)
            {
                _context.KnowledgeElements.Remove(KnowledgeElements);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
