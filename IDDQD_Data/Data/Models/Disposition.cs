using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDDQD.Data
{
    public class Disposition
    {

        [Key]
        public int Id {get; set;}
        [StringLength(100)]
        public string Name { get; set;}
        public string Category{get; set;}
        public string Discipline {get; set;}
        
        //data type is good to enfore that this will be text (e.g. richtext)
        [DataType(DataType.Text)]
        public string Description {get; set;}
    }
}