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
    // Profile
    public partial class Profile
    {

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public int ProfileId { get; set; } // profile_id (Primary key)

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string FirstName { get; set; } // first_name

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string MiddleName { get; set; } // middle_name

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string LastName { get; set; } // last_name

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string BusinessName { get; set; } // business_name

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string FacebookUrl { get; set; } // facebook_url

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string InstagramUrl { get; set; } // instagram_url

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public string WebsiteUrl { get; set; } // website_url

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTime? DateCreated { get; set; } // date_created

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public DateTime? LastDateUpdated { get; set; } // last_date_updated

        [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "1.0.0.0")]
        public bool? IsDeleted { get; set; } // is_deleted
    }

}
