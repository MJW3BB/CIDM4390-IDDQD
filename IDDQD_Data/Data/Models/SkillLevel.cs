using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDDQD.Data
{
    public class SkillLevel
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Description {get; set;}
        public int CartesianIndex {get; set;}
    }
}