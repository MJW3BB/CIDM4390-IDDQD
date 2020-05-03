using System;
using System.Collections.Generic;

namespace IDDQD.ViewModels
{
    public class KnowledgeSkillSelectorModel
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public int CartesianIndex {get; set;}
        public int SemioticIndex {get; set;}
        public string Etymology {get; set;}
        public bool Selected {get; set;}
        public int SkillLevel {get;set;}

    }
}