using System;
using System.ComponentModel.DataAnnotations;

namespace IDDQD.Models
{
    public class KnowledgeElements
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        
    }
}