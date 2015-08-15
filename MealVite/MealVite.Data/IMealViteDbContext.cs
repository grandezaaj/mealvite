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
    public interface IMealViteDbContext : IDisposable
    {
        IDbSet<Mealvite> Mealvites { get; set; } // Mealvite
        IDbSet<MealViteDetail> MealViteDetails { get; set; } // MealViteDetails
        IDbSet<Profile> Profiles { get; set; } // Profile

        int SaveChanges();
        
        // Stored Procedures
    }

}
