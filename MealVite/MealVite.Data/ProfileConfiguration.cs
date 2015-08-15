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
    // Profile
    internal partial class ProfileConfiguration : EntityTypeConfiguration<Profile>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public ProfileConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Profile");
            HasKey(x => x.ProfileId);

            Property(x => x.ProfileId).HasColumnName("profile_id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName).HasColumnName("first_name").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.MiddleName).HasColumnName("middle_name").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.LastName).HasColumnName("last_name").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.BusinessName).HasColumnName("business_name").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.FacebookUrl).HasColumnName("facebook_url").IsOptional();
            Property(x => x.InstagramUrl).HasColumnName("instagram_url").IsOptional();
            Property(x => x.WebsiteUrl).HasColumnName("website_url").IsOptional();
            Property(x => x.DateCreated).HasColumnName("date_created").IsOptional();
            Property(x => x.LastDateUpdated).HasColumnName("last_date_updated").IsOptional();
            Property(x => x.IsDeleted).HasColumnName("is_deleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
