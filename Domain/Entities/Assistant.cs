using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum AssistantType
    {
        Volunteer,
        Paid
    };
    public class Assistant
    {
        //Done
        [Key]
        public Guid AssistantId { get; set; } =Guid.NewGuid();

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Range(0,5)]
        public double Rating { get; set; } = 0;
        [Required]

        public int NumberOfOrders { get; set; } = 0;
        public string? Decription { get; set; }

        [Required]
        public List<CaseCategory> Experiences { get; set; } = new List<CaseCategory>();

        [Required]
        public AssistantType Type { get; set; }

        [DataType(DataType.Url)]
        public string? PictureUrl { get; set; }

        #region Review Relation
        public ICollection<Reviews> ListOfReviews { get; set; } = new HashSet<Reviews>(); 
        #endregion

    }
}
