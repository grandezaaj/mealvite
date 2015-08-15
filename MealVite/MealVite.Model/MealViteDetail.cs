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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealVite.Model
{
    // MealViteDetails
    public partial class MealViteDetail
    {

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int MealViteDetailsId { get; set; } // MealViteDetailsId (Primary key)

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int MealviteId { get; set; } // MealviteId

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int CustomerId { get; set; } // CustomerId

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string Status { get; set; } // Status

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string Comment { get; set; } // Comment

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int? Rating { get; set; } // Rating

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public bool? IsDeleted { get; set; } // IsDeleted

        // Foreign keys
        public virtual Mealvite Mealvite { get; set; } // FK_MealViteDetails_Mealvite
    }

}
