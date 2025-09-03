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
    //Time of order
    public enum TypeTime{
        Day, 
        Week
    };
    //Payment Method
    public enum TypePayment{
        Cash, 
        Visa
    };
    //Order Statues
    public enum OrderStatues{
        Success, 
        Pending,
        Failed
    };
    public class AssistantOrder
{
        //Done
        [Key]
        public Guid AssistantOrderId { get; set; }=Guid.NewGuid();
        [Required]
        [EmailAddress]
        public Guid AssistantId { get; set; }
        #region User
        [ForeignKey(nameof(User))]
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!; 
        #endregion
        [Required]
        public TypeTime Type { get; set; }
        [Range(1,30)]
        public int Duration { get; set; }
        [Required]
        public Address OrderAddress { get; set; } = null!;
        [Range(0, double.MaxValue)]
        public decimal Total { get; set; } = 0;
        [Required]
        public  TypePayment PaymentMethod { get; set; }
        [Required]
        public OrderStatues OrderStatues { get; set; } = OrderStatues.Pending;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
