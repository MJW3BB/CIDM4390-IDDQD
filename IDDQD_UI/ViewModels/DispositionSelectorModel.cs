namespace IDDQD.ViewModels
{
    public class DispositionSelectorModel
    {
        public int Id {get; set;}
        public string Name { get; set;}
        public string Category{get; set;}
        public string Discipline {get; set;}
        public string Description {get; set;}
        public bool Selected {get; set;}
    }
}