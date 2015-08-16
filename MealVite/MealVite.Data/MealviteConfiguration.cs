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
    // Mealvite
    internal partial class MealviteConfiguration : EntityTypeConfiguration<Mealvite>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public MealviteConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Mealvite");
            HasKey(x => x.MealviteId);

            Property(x => x.MealviteId).HasColumnName("MealviteId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.HostId).HasColumnName("HostId").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Price).HasColumnName("Price").IsRequired().HasPrecision(18,2);
            Property(x => x.Location).HasColumnName("Location").IsRequired();
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.MealViteDate).HasColumnName("MealViteDate").IsRequired();
            Property(x => x.Tags).HasColumnName("Tags").IsOptional();
            Property(x => x.MaxAttendees).HasColumnName("MaxAttendees").IsOptional();
            Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired();
            Property(x => x.LastDateUpdated).HasColumnName("LastDateUpdated").IsRequired();
            Property(x => x.IsDeleted).HasColumnName("IsDeleted").IsRequired();
            Property(x => x.ImagePath).HasColumnName("ImagePath").IsOptional();

            // Foreign keys
            HasRequired(a => a.Profile).WithMany(b => b.Mealvites).HasForeignKey(c => c.HostId); // FK_Mealvite_Profile
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
