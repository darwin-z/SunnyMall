//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.OrdersDetails = new HashSet<OrdersDetails>();
        }
    
        public int OrdersID { get; set; }
        public string SerialID { get; set; }
        public System.DateTime Orderdate { get; set; }
        public int UserID { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> DeliveryID { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public int States { get; set; }
        public string Remark { get; set; }
        public string ExpressNumber { get; set; }
        public string ExpressType { get; set; }
        public Nullable<int> PayType { get; set; }
    
        public virtual Deliveries Deliveries { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
