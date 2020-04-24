// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using IDDQD.Data;
// using IDDQD.Models;

// namespace IDDQD.Pages.Disposition
// {
//     public class EditModel : PageModel
//     {
//         private readonly IDDQD.Data.DISPContext _context;

//         public EditModel(IDDQD.Data.DISPContext context)
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

//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//         // more details see https://aka.ms/RazorPagesCRUD.
//         public async Task<IActionResult> OnPostAsync()
//         {
//             if (!ModelState.IsValid)
//             {
//                 return Page();
//             }

//             _context.Attach(Dispositions).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!DispositionsExists(Dispositions.ID))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return RedirectToPage("./Index");
//         }

//         private bool DispositionsExists(int id)
//         {
//             return _context.Dispositions.Any(e => e.ID == id);
//         }
//     }
// }
