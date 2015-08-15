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
    // User
    internal partial class UserConfiguration : EntityTypeConfiguration<User>
    {
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public UserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".User");
            HasKey(x => x.UseriId);

            Property(x => x.UseriId).HasColumnName("useri_id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProfileId).HasColumnName("profile_id").IsOptional();
            Property(x => x.Username).HasColumnName("username").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Password).HasColumnName("password").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.DateCreated).HasColumnName("date_created").IsOptional();
            Property(x => x.LastDateUpdated).HasColumnName("last_date_updated").IsOptional();
            Property(x => x.IsActive).HasColumnName("is_active").IsOptional();
            Property(x => x.IsDeleted).HasColumnName("is_deleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
