// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.EntityFrameworkCore;
// using IDDQD.Data;
// using IDDQD.Models;

// namespace IDDQD.Pages.Skills
// {
//     public class DetailsModel : PageModel
//     {
//         private readonly IDDQD.Data.SKLContext _context;

//         public DetailsModel(IDDQD.Data.SKLContext context)
//         {
//             _context = context;
//         }

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
//     }
// }
