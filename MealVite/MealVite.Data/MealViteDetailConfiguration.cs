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
    // MealViteDetails
    internal partial class MealViteDetailConfiguration : EntityTypeConfiguration<MealViteDetail>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public MealViteDetailConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".MealViteDetails");
            HasKey(x => x.MealViteDetailsId);

            Property(x => x.MealViteDetailsId).HasColumnName("MealViteDetailsId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.MealviteId).HasColumnName("MealviteId").IsRequired();
            Property(x => x.CustomerId).HasColumnName("CustomerId").IsRequired();
            Property(x => x.Status).HasColumnName("Status").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Comment).HasColumnName("Comment").IsOptional();
            Property(x => x.Rating).HasColumnName("Rating").IsOptional();

            // Foreign keys
            HasRequired(a => a.Mealvite).WithMany(b => b.MealViteDetails).HasForeignKey(c => c.MealviteId); // FK_MealViteDetails_Mealvite
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
