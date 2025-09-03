using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StoreOrder
    {
        [Key]
        public Guid StoreOrderId { get; set; } = Guid.NewGuid();

        #region User Relation

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        #endregion
        #region Items Relation
        public ICollection<OrderItem>? OrderItems { get; set; } = new HashSet<OrderItem>(); 
        #endregion
        public Address Address { get; set; } = null!;
        public decimal Subtotal { get; set; } = 0;
        public string? ZIPCode { get; set; }
        public decimal Total { get; set; } = 0;
        public decimal ShipmentCost { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;
        public DateOnly OrderDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly DeliveryDate { get; set; } = DateOnly.FromDateTime(DateTime.Now).AddDays(5);
        public TypePayment PaymentMethod { get; set; }
        public Guid? PaymentId { get; set; }//For visa only
        public OrderStatues OrderStatues { get; set; } = OrderStatues.Pending;
    }
}
