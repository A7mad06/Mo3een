using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        //Missing Composite Primary Key
        #region Product Relation
        [ForeignKey(nameof(Product))]
        [Required]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
        #endregion
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; } = 1 ;

        #region StoreOrder Relation
        [ForeignKey(nameof(StoreOrder))]
        [Required]
        public Guid OrderId { get; set; }
        public StoreOrder StoreOrder { get; set; } = null!; 
        #endregion
    }
}

