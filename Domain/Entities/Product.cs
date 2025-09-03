using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        //Done1
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();

        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [Required, DataType(DataType.Url)]
        public string PictureUrl { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100)]
        public decimal Discount { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Range(0, 5)]
        public double? Rating { get; set; } = null;

        #region Reviews relation
        public ICollection<Reviews> Reviews { get; set; } = new HashSet<Reviews>();
        #endregion
    }
}
