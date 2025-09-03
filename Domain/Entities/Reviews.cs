using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //Done
    public enum DestinationType
    {
        Product, Assistant
    };
    public class Reviews
    {
        [Key]
        public Guid ReviewId { get; set; } = Guid.NewGuid();

        [Range(0, 5)]
        public double Rate { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; } = null!;

        public DestinationType Type { get; set; }

        #region User Relation
		[ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!; 
#endregion
        #region Assistant Relation
        [ForeignKey(nameof(Assistant))]
        public Guid? AssistantId { get; set; }
        public Assistant? Assistant { get; set; } 
        #endregion
        #region Product Relation
        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; } 
        public Product? Product { get; set; }
        #endregion


    }
}
