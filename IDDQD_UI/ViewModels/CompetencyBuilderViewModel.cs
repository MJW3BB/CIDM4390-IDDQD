using System;
using System.Collections.Generic;

namespace IDDQD.ViewModels
{
    public class CompetencyBuilderViewModel
    {
        public string CompetencyName {get; set;}
        public string CompetencyDescription {get; set;}
        public int[] DispositionIndicies {get; set;}
        public int[] ConstituentCompetenciesIndicies {get; set;}
        public int[] KSPairsIndicies {get; set;}
    }
}