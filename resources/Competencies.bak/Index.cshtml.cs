using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using IDDQD_Data.Data.Models;
using IDDQD_Repo;

namespace IDDQD.Pages.Competencies
{

    public class IndexModel : PageModel
    {

        public const string TestSessionKey = "_Test";
        public const string TestSessionValue = "VALUE";

        [BindProperty]
        public IEnumerable<Competency> CompetencyList {get; set;}
        //public IEnumerable<Compete

        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _UOW;        

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;            
        }

        public async Task OnGetAsync()
        {
            var repository = _UOW.GetRepositoryAsync<Competency>();
            _logger.Log(LogLevel.Information, "Competencies Retrieved");
            CompetencyList = await repository.GetListAsync();
            if(CompetencyList == null){
                _logger.Log(LogLevel.Information, "Unable to retreive");
            }
            else{
                _logger.Log(LogLevel.Information, repository.ToString());
            }

        }
    }
}
