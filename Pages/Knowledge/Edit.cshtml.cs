using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IDDQD.Data;
using IDDQD.Models;

namespace IDDQD.Pages.Knowledge
{
    public class EditModel : PageModel
    {
        private readonly IDDQD.Data.KNEContext _context;

        public EditModel(IDDQD.Data.KNEContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KnowledgeElements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowledgeElementsExists(KnowledgeElements.ID))
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

        private bool KnowledgeElementsExists(int id)
        {
            return _context.KnowledgeElements.Any(e => e.ID == id);
        }
    }
}
