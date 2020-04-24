// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using IDDQD.Data;
// using IDDQD.Models;

// namespace IDDQD.Pages.Skills
// {
//     public class CreateModel : PageModel
//     {
//         private readonly IDDQD.Data.SKLContext _context;

//         public CreateModel(IDDQD.Data.SKLContext context)
//         {
//             _context = context;
//         }

//         public IActionResult OnGet()
//         {
//             return Page();
//         }

//         [BindProperty]
//         public SkillLevel SkillLevel { get; set; }

//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//         // more details see https://aka.ms/RazorPagesCRUD.
//         public async Task<IActionResult> OnPostAsync()
//         {
//             if (!ModelState.IsValid)
//             {
//                 return Page();
//             }

//             _context.SkillLevel.Add(SkillLevel);
//             await _context.SaveChangesAsync();

//             return RedirectToPage("./Index");
//         }
//     }
// }
