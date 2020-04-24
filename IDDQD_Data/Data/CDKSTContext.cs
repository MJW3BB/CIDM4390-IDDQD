using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using IDDQD_Data.Data.Models;
using IDDQD_Repo;
using IDDQD_Repo.DependencyInjection;

namespace IDDQD_Data.Data
{
    public class CDKSTContext : DbContext
    {
        public CDKSTContext(DbContextOptions<CDKSTContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }        

        public DbSet<Competency> Competencies { get; set;}
        public DbSet<AtomicCompetency> AtomicCompetencies {get; set;}
        public DbSet<CompositeCompetency> CompositeCompetencies {get; set;}
        public DbSet<ConstituentCompetency> ConstituentCompetencies {get; set;}
        public DbSet<Disposition> Dispositions { get; set; }
        public DbSet<CompetencyDisposition> CompetencyDispositions {get; set;}
        public DbSet<KnowledgeElement> KnowledgeElements { get; set;}
        public DbSet<SkillLevel> SkillLevels {get; set;}
        public DbSet<KSPair> KSPairs {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }        
    }
}