using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IDDQD_Data.Data.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CDKSTContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CDKSTContext>>()))
            {
                context.Database.EnsureCreated();
                List<KnowledgeElement> knowledgeElements = null;
                List<SkillLevel> skillLevels = null;
                List<Disposition> dispositions = null;
                /* KNOWLEDGE ELEMENTS SEED */
                // Look for any KnowledgeElements.
                Task<KnowledgeElement> ke = context.KnowledgeElements.FirstOrDefaultAsync(k => k.Id == 1);
                if (ke.Result == null)
                {
                    knowledgeElements = new List<KnowledgeElement>(){
                        new KnowledgeElement{
                            Id = 1,
                            Name = "Control Structures",
                            Description = "selection, repetition, sequence",
                            CartesianIndex = 1,
                            SemioticIndex = 1,
                            Etymology = "Programming"
                        },
                        new KnowledgeElement{
                            Id = 2,
                            Name = "Design Patterns",
                            Description = "A general, reusable solution to a commonly occurring problem within a given context in software design",
                            CartesianIndex = 1,
                            SemioticIndex = 1,
                            Etymology = "Software Engineering"
                        },
                        new KnowledgeElement{
                            Id = 3,
                            Name = "Data Normalization",
                            Description = "The process of structuring a relational database in accordance with normal forms in order to reduce data redundancy and improve data integrity.",
                            CartesianIndex = 1,
                            SemioticIndex = 1,
                            Etymology = "Database"
                        }
                    };                
                    context.KnowledgeElements.AddRange(knowledgeElements);
                    context.SaveChanges();
                }
                /* SKILL LEVELS SEED */
                // Look for any SkillLevels.
                Task<SkillLevel> sl = context.SkillLevels.FirstOrDefaultAsync(s => s.Id == 1);
                if (sl.Result == null)
                {
                    skillLevels = new List<SkillLevel>(){
                        new SkillLevel{
                            Id = 1,
                            Name = "Remember",
                            Description = "Retrieve relevant knowledge from long-term memory.",
                            CartesianIndex = 1
                        },
                        new SkillLevel{
                            Id = 2,
                            Name = "Understand",
                            Description = "Construct meaning from instructional messages, including oral, written and graphic communication.",
                            CartesianIndex = 2
                        },
                        new SkillLevel{
                            Id = 3,
                            Name = "Apply",
                            Description = "Carry out or use a procedure in a given situation.",
                            CartesianIndex = 3
                        },          
                        new SkillLevel{
                            Id = 4,
                            Name = "Analyze",
                            Description = "Breaking materials or concepts into parts, determining how the parts relate to one another or how they interrelate, or how the parts relate to an overall structure or purpose.",
                            CartesianIndex = 4
                        },
                        new SkillLevel{
                            Id = 5,
                            Name = "Evaluate",
                            Description = "Make judgments based on criteria and standards.",
                            CartesianIndex = 5
                        },
                        new SkillLevel{
                            Id = 6,
                            Name = "Create",
                            Description = "Put elements together to form a coherent whole; reorganize into a new pattern or structure.",
                            CartesianIndex = 6
                        }
                    };
                    context.SkillLevels.AddRange(skillLevels);
                    context.SaveChanges();
                }
                /* DISPOSITIONS SEED */
                // Look for any SkillLevels.
                Task<Disposition> disp = context.Dispositions.FirstOrDefaultAsync(d => d.Id == 1);
                if (disp.Result == null)
                {
                    dispositions = new List<Disposition>(){
                        new Disposition 
                        {
                            Id = 1,
                            Name = "Proactive",
                            Category = "Habits",
                            Discipline = "Information Systems",
                            Description = @"With Initiative (Nwokeji, Stachel, & " +
                                            "Holmes, 2019) / Self-Starter (Clear, 2017) " +
                                            "Shows independence. Ability to assess and " +
                                            "start activities independently without needing " +
                                            "to be told what to do. Willing to take the lead, " +
                                            "not waiting for others to start activities or wait " +
                                            "for instructions."
                        },
                        new Disposition 
                        {
                            Id = 2,
                            Name = "Purpose-Driven",
                            Category = "Qualities",
                            Discipline = "Information Systems",
                            Description = @"Purposefully engaged / Purposefulness " +
                                            "(Nwokeji et al., 2019), (Clear, 2017) " +
                                            "Goal-directed, intentionally acting and " +
                                            "committed to achieve organizational and " +
                                            "project goals. Reflects an attitude towards " +
                                            "the organizational goals served by decisions, " +
                                            "work or work products. e.g., Business acumen."
                        },
                        new Disposition 
                        {
                            Id = 3,
                            Name = "Self-Directed",
                            Category = "Qualities",
                            Discipline = "Information Systems",
                            Description = @"Self-motivated (Clear, 2017) / Self-Directed " +
                                            "(Nwokeji et al., 2019) Demonstrates determination " +
                                            "to sustain efforts to continue tasks. Direction " +
                                            "from others is not required to continue a task " +
                                            "toward its desired ends."
                        }
                    };                
                    context.Dispositions.AddRange(dispositions);
                    context.SaveChanges();                    
                }     
                /* ATOMIC COMPETENCIES SEED */
                // Look for any SkillLevels.
                Task<Competency> comp = context.Competencies.FirstOrDefaultAsync(d => d.Id == 1);
                if (comp.Result == null){
                    List<CompetencyDisposition> cdList =  new List<CompetencyDisposition>{
                        new CompetencyDisposition{
                            Id =  1,
                            Disposition = dispositions[0]
                        },
                        new CompetencyDisposition{
                            Id = 2,
                            Disposition = dispositions[1]
                        }
                    };
                    List<KSPair> kSPairs = new List<KSPair>{
                        new KSPair{
                            KnowledgeElement = knowledgeElements[0],
                            SkillLevel = skillLevels[5],
                        },
                        new KSPair{
                            KnowledgeElement = knowledgeElements[1],
                            SkillLevel = skillLevels[4]
                        }
                    };
                    AtomicCompetency atomic = new AtomicCompetency{
                        Id = 1,
                        Name = "Disposition A",
                        Description = "Do Stuff about A",
                        CompetencyDispostions = cdList,
                        KSPairs = kSPairs
                    };
                    context.Competencies.Add(atomic);
                    context.SaveChanges();  
                }                
            }
        }        
    }
}