using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using IDDQD_Data.Data.Models;
using IDDQD_Repo;

namespace IDDQD_UI.Pages.SkillLevels  
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<SkillLevel> SkillLevelsList {get; set;}

        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _UOW;

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;            
        }

        public async Task OnGetAsync()
        {
            //var repository = _UOW.GetRepository<Skill>();
            var repository = _UOW.GetRepositoryAsync<SkillLevel>();
            _logger.Log(LogLevel.Information, "Skills Retrieved");
            _logger.Log(LogLevel.Information, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            SkillLevelsList = await repository.GetListAsync();
        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.EntityFrameworkCore;
// using IDDQD_Data;
// using IDDQD_Repo;
// using 
// // using IDDQD.Models; Models relocated to Data folder




// // namespace IDDQD.Pages.Skills
// // {
// //     public class IndexModel : PageModel
// //     {
// //         private readonly IDDQD.Data.SKLContext _context;

// //         public IndexModel(IDDQD.Data.SKLContext context)
// //         {
// //             _context = context;
// //         }

// //         public IList<SkillLevel> SkillLevel { get;set; }

// //         public async Task OnGetAsync()
// //         {
// //             SkillLevel = await _context.SkillLevel.ToListAsync();
// //         }
// //     }
// // }
