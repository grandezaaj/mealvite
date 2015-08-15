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
    // Mealvite
    public partial class Mealvite
    {

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int MealviteId { get; set; } // MealviteId (Primary key)

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int HostId { get; set; } // HostId

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string Title { get; set; } // Title

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public decimal Price { get; set; } // Price

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string Location { get; set; } // Location

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string Description { get; set; } // Description

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string Status { get; set; } // Status

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string MealViteDate { get; set; } // MealViteDate

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string Tags { get; set; } // Tags

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTimeOffset DateCreated { get; set; } // DateCreated

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTimeOffset LastDateUpdated { get; set; } // LastDateUpdated

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public bool IsDeleted { get; set; } // IsDeleted

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string ImagePath { get; set; } // ImagePath

        // Reverse navigation
        public virtual ICollection<MealViteDetail> MealViteDetails { get; set; } // MealViteDetails.FK_MealViteDetails_Mealvite

        // Foreign keys
        public virtual Profile Profile { get; set; } // FK_Mealvite_Profile
        
        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public Mealvite()
        {
            MealViteDetails = new List<MealViteDetail>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
