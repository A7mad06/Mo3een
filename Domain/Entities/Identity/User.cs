using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Identity
{
    public enum CaseCategory
    {
        VisuallyImpaired,
        HearingImpaired,
        MobilityImpaired,
        IntellectuallyDisabled,
        Elderly,
        Patients
    };
    public enum Plan
    {
        Free,
        Platinum,
        Gold
    };
    public class User:IdentityUser
    {
        [Required]
        public CaseCategory Case_Category { get; set; }

        [MaxLength(500)]
        public string? About { get; set; }

        [Required]
        public bool TermsAndConditions { get; set; }

        public Plan Plan { get; set; } = Plan.Free;

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();

        [DataType(DataType.Url)]
        public string PictureUrl { get; set; } = null!;

        public int Points { get; set; } = 0;
        
        public ICollection<Reviews> Reviews { get; set; } = new HashSet<Reviews>();
    }
}
