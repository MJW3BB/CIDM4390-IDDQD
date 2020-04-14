using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDDQD.Data
{
    public class ConstituentCompetency
    {
        public int Id {get; set;}
        // Should not be memeber but should know it is not. Prevents errors
        public Competency MemberCompetency{get; set;}

        [ForeignKey("Competency")]
        public int CompetencyId{get; set;}    
        public Competency Competency{get; set;}        
    }
}