using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDDQD.Data
{
    public class Competency
    {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        [DataType(DataType.Text)]
        public string Description {get; set;}
        public ICollection<CompetencyDisposition> CompetencyDispostions {get; set;}

    }

    public class AtomicCompetency : Competency 
        {
            public List<KSPair> KSPairs{get; set;}
        }
    public class CompositeCompetency : Competency
         {
    ICollection<ConstituentCompetency> ConstituentCompetencies {get; set;}
    }
}