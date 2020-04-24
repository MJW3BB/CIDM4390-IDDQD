// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.EntityFrameworkCore;
// using IDDQD.Data;
// using IDDQD.Models;

// namespace IDDQD.Pages.Disposition
// {
//     public class DeleteModel : PageModel
//     {
//         private readonly IDDQD.Data.DISPContext _context;

//         public DeleteModel(IDDQD.Data.DISPContext context)
//         {
//             _context = context;
//         }

//         [BindProperty]
//         public Dispositions Dispositions { get; set; }

//         public async Task<IActionResult> OnGetAsync(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             Dispositions = await _context.Dispositions.FirstOrDefaultAsync(m => m.ID == id);

//             if (Dispositions == null)
//             {
//                 return NotFound();
//             }
//             return Page();
//         }

//         public async Task<IActionResult> OnPostAsync(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             Dispositions = await _context.Dispositions.FindAsync(id);

//             if (Dispositions != null)
//             {
//                 _context.Dispositions.Remove(Dispositions);
//                 await _context.SaveChangesAsync();
//             }

//             return RedirectToPage("./Index");
//         }
//     }
// }
