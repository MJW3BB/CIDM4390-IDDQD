using System;
using System.Linq;
using System.Threading;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;

using IDDQD_Data.Data;
using IDDQD_Data.Data.Models;
using IDDQD_Repo;
using IDDQD.ViewModels;

namespace IDDQD.Pages.Competencies
{
    public class Page5Model : PageModel
    {
        
        public const string SerializedCompetencyJSONKey = "_CompetencySerliazed";
        [BindProperty]
        [Display(Name="Competency KS")]
        public List<KnowledgeSkillSelectorModel> KnowledgeDispList{get; set;}
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
        [Display(Name="Knowledge Skill Pair Indicies")]        
        public int[] KSPairsIndicies {get; set;}
        public List <KnowledgeElement> knowledgeElementList = new List <KnowledgeElement>();
        public List <SkillLevel> SkillLevelList = new List <SkillLevel>();
        public List <Disposition> dispositionList = new List <Disposition>();
        public CompetencyBuilderViewModel Cbvm {get; set;}
        private readonly ILogger<Page5Model> _logger;
        private readonly IUnitOfWork _UOW; 

        // public List<Disposition> DispositionList{get;set;}
        // public List<KnowledgeElement> Knowledges{get;set;}
        // public List<SkillLevel> Skills{get;set;}

        public Page5Model(ILogger<Page5Model> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _UOW = uow;            
        }

        public async Task OnGet()
        {
            // wheres my session at
            await HttpContext.Session.LoadAsync();            
            // read serialized object from session variable
            var serializedin = HttpContext.Session.GetString(SerializedCompetencyJSONKey);
            // save it to Cbvm
            Cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);
            _logger.LogInformation($"CBVM: {serializedin.ToString()}");
            // fill my variables with the session contents
            // **We take our object and save data from it to our bind properties to use in the front end file** _MW
            CompetencyName = Cbvm.CompetencyName;
            CompetencyDescription = Cbvm.CompetencyDescription;
            DispositionIndicies = Cbvm.DispositionIndicies;
            KSPairsIndicies = Cbvm.KSPairsIndicies;

            var repok=_UOW.GetRepositoryAsync<KnowledgeElement>();
            var repos=_UOW.GetRepositoryAsync<SkillLevel>();
            var repod=_UOW.GetRepositoryAsync<Disposition>();

            IEnumerable<KnowledgeElement>ListofKE=await repok.GetListAsync();
            IEnumerable<SkillLevel>ListofKS=await repos.GetListAsync();
            IEnumerable<Disposition>ListofDisp=await repod.GetListAsync();

            List <KnowledgeElement> TempKnowledgeElementList = ListofKE.ToList();
            List <SkillLevel> TempSkillLevelList = ListofKS.ToList();
            List <Disposition> TempDispositionList = ListofDisp.ToList();

           foreach(Disposition i in TempDispositionList)
           {    
               foreach(int x in DispositionIndicies)
               {
                   if(i.Id==x)
                   {
                       dispositionList.Add(i);
                   }
               }
           }
           foreach(KnowledgeElement i in TempKnowledgeElementList)
           {    
               foreach(int x in KSPairsIndicies)
               {
                   if(i.Id==x&&x%2==0)
                   {
                       knowledgeElementList.Add(i);
                   }
               }
           }
           foreach(SkillLevel i in TempSkillLevelList)
           {    
               foreach(int x in KSPairsIndicies)
               {
                   if(i.Id==x&&x%2==1)
                   {
                       SkillLevelList.Add(i);
                   }
               }
           }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _logger.LogInformation("IN ON POST ASYNC");

            _logger.LogInformation(knowledgeElementList.Count.ToString());
            _logger.LogInformation(SkillLevelList.Count.ToString());

            await HttpContext.Session.LoadAsync();

            var repok=_UOW.GetRepositoryAsync<KnowledgeElement>();
            var repos=_UOW.GetRepositoryAsync<SkillLevel>();
            var repod=_UOW.GetRepositoryAsync<Disposition>();
            var repoc=_UOW.GetRepositoryAsync<Competency>();

            _logger.LogInformation("ON POST REPO");

            IEnumerable<KnowledgeElement>ListofKE=await repok.GetListAsync();
            IEnumerable<SkillLevel>ListofKS=await repos.GetListAsync();
            IEnumerable<Disposition>ListofDisp=await repod.GetListAsync();

            _logger.LogInformation("ON POST Enumrable");

            List <KnowledgeElement> TempKnowledgeElementList = ListofKE.ToList();
            List <SkillLevel> TempSkillLevelList = ListofKS.ToList();
            List <Disposition> TempDispositionList = ListofDisp.ToList();

            _logger.LogInformation("ON POST TEMP LIST");



           foreach(Disposition i in TempDispositionList)
           {    
               foreach(int x in DispositionIndicies)
               {
                   if(i.Id==x)
                   {
                       dispositionList.Add(i);
                   }
               }
           }

           for(int i = 0; i< KSPairsIndicies.Length; i++){
                //Even indices are my knowledges 
                if(i%2==0)
                {
                    foreach (var item in TempKnowledgeElementList)
                    {
                        if(item.Id == KSPairsIndicies[i])
                        {
                            knowledgeElementList.Add(item);
                        }
                    }
                }
                else
                {//The Odd indices are skills
                   foreach (var item in TempSkillLevelList)
                    {
                        if(item.Id == KSPairsIndicies[i])
                        {
                            SkillLevelList.Add(item);
                        }
                    }
                }
            }
            _logger.LogInformation(SkillLevelList.Count.ToString());
            _logger.LogInformation(knowledgeElementList.Count.ToString());
        //    foreach(KnowledgeElement i in TempKnowledgeElementList)
        //    {    
        //        foreach(int x in KSPairsIndicies)
        //        {
        //            if(i.Id==x&&x%2==0)
        //            {
        //                knowledgeElementList.Add(i);
        //            }
        //        }
        //    }
           
        //    foreach(SkillLevel i in TempSkillLevelList)
        //    {    
        //        foreach(int x in KSPairsIndicies)
        //        {
        //            if(i.Id==x&&x%2==1)
        //            {
        //                SkillLevelList.Add(i);
        //            }
        //        }
        //    }
            List <CompetencyDisposition> CDList=new List <CompetencyDisposition>();
            foreach(var CDDisp in dispositionList)
            {
                CompetencyDisposition CDDispObject = new CompetencyDisposition()
                {
                    Disposition=CDDisp
                };
                CDList.Add(CDDispObject);
            }
            List <KSPair> KSList=new List <KSPair>();
            for(int i =0; i< SkillLevelList.Count(); i++)
            {
               KSPair KSDispList = new KSPair()
               {
                   SkillLevel=SkillLevelList[i],
                   KnowledgeElement=knowledgeElementList[i]
               };
               KSList.Add(KSDispList); 
            }

           AtomicCompetency MyCompetency = new AtomicCompetency()
           {
               Name=CompetencyName,
               Description=CompetencyDescription,
               CompetencyDispostions=CDList,
               KSPairs=KSList
           };



            await repoc.AddAsync(MyCompetency);
            int q =_UOW.SaveChanges();

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
            }
            else 
            {
                //open my object
                var serializedin = HttpContext.Session.GetString(SerializedCompetencyJSONKey);
                Cbvm = JsonSerializer.Deserialize<CompetencyBuilderViewModel>(serializedin);
                //fill it with what i want
                Cbvm.CompetencyName = CompetencyName;
                _logger.LogInformation($"IN POST PAGE 2, Session out: {Cbvm.CompetencyName}");
                Cbvm.CompetencyDescription = CompetencyDescription;
                _logger.LogInformation($"IN POST PAGE 2, Session out: {Cbvm.CompetencyDescription}");
                Cbvm.DispositionIndicies = DispositionIndicies;  
                _logger.LogInformation($"IN POST PAGE 2, Session out: {Cbvm.DispositionIndicies}");              
                //pack it up 
                var serializedout = JsonSerializer.Serialize(Cbvm);
                _logger.LogInformation($"IN POST PAGE 2, Serialized out: {serializedout.ToString()}");
                //send it out
                HttpContext.Session.SetString(SerializedCompetencyJSONKey, serializedout);                
            }
            return RedirectToPage("/Competencies/Index");
        }   
    }
}