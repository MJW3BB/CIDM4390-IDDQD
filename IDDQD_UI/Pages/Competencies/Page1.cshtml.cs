using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using IDDQD_Data.Data.Models;
using IDDQD_Repo;
using IDDQD.ViewModels;

namespace IDDQD.Pages.Competencies
{
    public class Page1Model : PageModel
    {

        public const string SerializedCompetencyJSONKey = "_CompetencySerliazed";

        [BindProperty]
        [Display(Name="Competency Name")]
        public string CompetencyName {get; set;}

        [BindProperty]
        [Display(Name="Competency Description")]        
        public string CompetencyDescription {get; set;}        

        private readonly ILogger<Page1Model> _logger;
        private readonly IUnitOfWork _UOW;        

        public Page1Model(ILogger<Page1Model> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;            
        }        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(){

            _logger.LogInformation("IN ON POST ASYNC");

            CompetencyBuilderViewModel cbvm = new CompetencyBuilderViewModel();            

            await HttpContext.Session.LoadAsync();

            if(string.IsNullOrEmpty(HttpContext.Session.GetString(SerializedCompetencyJSONKey)))
            {
                //trim cuts out leading and training whitespace
                cbvm.CompetencyName = CompetencyName.Trim();
                cbvm.CompetencyDescription = CompetencyDescription.Trim();

                var serialized = JsonSerializer.Serialize(cbvm);

                _logger.LogInformation(serialized.ToString());

                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serialized);

            } else {
                //read from session variable
                var serializedin = HttpContext.Session.GetString(SerializedCompetencyJSONKey);
                cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);

                //read from session variable
                cbvm.CompetencyName = CompetencyName;
                cbvm.CompetencyDescription = CompetencyDescription;
                cbvm.ConstituentCompetenciesIndicies = new int[0];
                cbvm.DispositionIndicies = new int[0];
                cbvm.KSPairsIndicies = new int[0];

                var serializedout = JsonSerializer.Serialize(cbvm);
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serializedout);
            }

            return RedirectToPage("/Competencies/Page2");
        }
    }
}
