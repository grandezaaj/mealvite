// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.5
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity.ModelConfiguration;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;
using MealVite.Model;

namespace MealVite.Data
{
    public partial class MealViteDbContext : DbContext, IMealViteDbContext
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public IDbSet<Mealvite> Mealvites { get; set; } // Mealvite

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public IDbSet<MealViteDetail> MealViteDetails { get; set; } // MealViteDetails

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public IDbSet<Profile> Profiles { get; set; } // Profile

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        static MealViteDbContext()
        {
            Database.SetInitializer<MealViteDbContext>(null);
        }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public MealViteDbContext()
            : base("Name=MealViteDbContext")
        {
            InitializePartial();
        }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public MealViteDbContext(string connectionString) : base(connectionString)
        {
            InitializePartial();
        }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public MealViteDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
            InitializePartial();
        }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MealviteConfiguration());
            modelBuilder.Configurations.Add(new MealViteDetailConfiguration());
            modelBuilder.Configurations.Add(new ProfileConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new MealviteConfiguration(schema));
            modelBuilder.Configurations.Add(new MealViteDetailConfiguration(schema));
            modelBuilder.Configurations.Add(new ProfileConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
        
        // Stored Procedures
    }
}
