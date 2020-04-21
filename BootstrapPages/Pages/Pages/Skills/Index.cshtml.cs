using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IDDQD.Data;
using IDDQD.Models;

namespace IDDQD.Pages.Skills
{
    public class IndexModel : PageModel
    {
        private readonly IDDQD.Data.SKLContext _context;

        public IndexModel(IDDQD.Data.SKLContext context)
        {
            _context = context;
        }

        public IList<SkillLevel> SkillLevel { get;set; }

        public async Task OnGetAsync()
        {
            SkillLevel = await _context.SkillLevel.ToListAsync();
        }
    }
}
