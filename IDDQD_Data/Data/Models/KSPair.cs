using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDDQD.Data
{
    public class KSPair
    {

        public int Id {get; set;}
        public KnowledgeElement KnowledgeElement {get; set;}        
        public SkillLevel SkillLevel {get; set;}
        public int AtomicCompetencyId{get; set;}    
        public AtomicCompetency AtomicCompetency{get; set;}
    }
}