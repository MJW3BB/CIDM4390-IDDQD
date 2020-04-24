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

// namespace IDDQD.Pages.Skills
// {
//     public class EditModel : PageModel
//     {
//         private readonly IDDQD.Data.SKLContext _context;

//         public EditModel(IDDQD.Data.SKLContext context)
//         {
//             _context = context;
//         }

//         [BindProperty]
//         public SkillLevel SkillLevel { get; set; }

//         public async Task<IActionResult> OnGetAsync(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             SkillLevel = await _context.SkillLevel.FirstOrDefaultAsync(m => m.ID == id);

//             if (SkillLevel == null)
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

//             _context.Attach(SkillLevel).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!SkillLevelExists(SkillLevel.ID))
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

//         private bool SkillLevelExists(int id)
//         {
//             return _context.SkillLevel.Any(e => e.ID == id);
//         }
//     }
// }
