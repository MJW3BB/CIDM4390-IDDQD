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
<<<<<<< HEAD
using IDDQD_Data.Data.Models;
using IDDQD_Repo;
using IDDQD.ViewModels;

namespace IDDQD_UI.Pages.Competencies
{
    public class Page3Model : PageModel
    {
        public const string SerializedCompetencyJSONKey = "_CompetencySerliazed";
=======
using IDDQD_Data.Data;
using IDDQD_Repo;
using IDDQD.ViewModels;

namespace IDDQD.Pages.Competencies
{
    public class Page3Model : PageModel
    {
         public const string SerializedCompetencyJSONKey = "_CompetencySerliazed";

        [BindProperty]
        [Display(Name="Competency Name")]
        public string CompetencyName {get; set;}

        [BindProperty]
        [Display(Name="Competency Description")]        
        public string CompetencyDescription {get; set;}
        [BindProperty]
        [Display(Name="Disposition Indicies")]        
        public int[] DispositionIndicies {get; set;}

        [BindProperty]
        public string IsComposite { get; set; }
        public string[] CompetencyTypes = new[] { "Atomic", "Composite"};
>>>>>>> devops

        public CompetencyBuilderViewModel Cbvm {get; set;}

        private readonly ILogger<Page1Model> _logger;
        private readonly IUnitOfWork _UOW;        

        public Page3Model(ILogger<Page1Model> logger, IUnitOfWork uow)
        {
            _logger = logger;
<<<<<<< HEAD
            _UOW = uow;            
        }

        public async Task OnGetAsync()
        {

=======
            _UOW = uow;
        }


        public async Task OnGetAsync()
        {
            //wheres my session at
>>>>>>> devops
            await HttpContext.Session.LoadAsync();            

            //read serialized object from session variable
            var serializedin = HttpContext.Session.GetString(SerializedCompetencyJSONKey);
<<<<<<< HEAD
            Cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);
            
        }
    }
}
=======
            //save it to Cbvm
            Cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);
            //fill my variables with the session contents
            //**We take our object and save data from it to our bind properties to use in the front end file** _MW
            CompetencyName = Cbvm.CompetencyName;
            CompetencyDescription = Cbvm.CompetencyDescription;
            DispositionIndicies = Cbvm.DispositionIndicies;
            // Log the info -MW
            _logger.Log(LogLevel.Information, "Page 3 onGet");
            _logger.LogInformation($"COMPNAME: {CompetencyName}");
            _logger.LogInformation($"COMPDESCR: {CompetencyDescription}");
            _logger.LogInformation($"DISPINDICE: {DispositionIndicies[0]}");
        }
         public async Task<IActionResult>  OnPostAsync(){

            _logger.LogInformation("IN ON POST ASYNC");
            _logger.LogInformation($"CompName: {CompetencyName}");
            _logger.LogInformation($"DISP: {DispositionIndicies[0]}");
            await HttpContext.Session.LoadAsync();

                  
            //is my session variable null?
            if(string.IsNullOrEmpty(HttpContext.Session.GetString(SerializedCompetencyJSONKey)))
            {
                //if so, make a new one 
                Cbvm = new CompetencyBuilderViewModel();
                //fill it with what i want
                Cbvm.CompetencyName = CompetencyName;
                Cbvm.CompetencyDescription = CompetencyDescription;
                Cbvm.DispositionIndicies = DispositionIndicies;               
                //pack it up 
                var serialized = JsonSerializer.Serialize(Cbvm);
                //send it out
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serialized);

            }else {
                //open my object
                var serializedin = HttpContext.Session.GetString(SerializedCompetencyJSONKey);
                Cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);

                //fill it with what i want
                Cbvm.CompetencyName = CompetencyName;
                _logger.LogInformation($"IN POST PAGE 3, Session in: {CompetencyName}");
                _logger.LogInformation($"IN POST PAGE 3, Session out: {Cbvm.CompetencyName}");
                Cbvm.CompetencyDescription = CompetencyDescription;
                _logger.LogInformation($"IN POST PAGE 3, Session in: {CompetencyDescription}");
                _logger.LogInformation($"IN POST PAGE 3, Session out: {Cbvm.CompetencyDescription}");
                Cbvm.DispositionIndicies = DispositionIndicies;  
                _logger.LogInformation($"IN POST PAGE 3, Session in: {DispositionIndicies[0]}");
                _logger.LogInformation($"IN POST PAGE 3, Session out: {Cbvm.DispositionIndicies[0]}");              

                //pack it up 
                var serializedout = JsonSerializer.Serialize(Cbvm);
                _logger.LogInformation($"IN POST PAGE 3, Serialized out: {serializedout.ToString()}");
                //send it out
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serializedout);                
            }
            if(IsComposite == "Atomic"){
                 return RedirectToPage("/Competencies/Page4");
            }else{
                 return RedirectToPage("/Competencies/Page4");
            }
           

        }

    }
}
>>>>>>> devops
