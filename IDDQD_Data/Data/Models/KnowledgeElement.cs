using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDDQD.Data
{
    public class KnowledgeElement
    {
        public int Id {get; set;}

        public string Name {get; set;}
        [DataType(DataType.Text)]
        public string Description {get; set;}

        public int CartesianIndex {get; set;}
        public int SemioticIndex {get; set;}
        public string Etymology {get; set;}

    }
}