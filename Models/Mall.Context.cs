﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminUsers> AdminUsers { get; set; }
        public virtual DbSet<Appraises> Appraises { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Deliveries> Deliveries { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<OrdersDetails> OrdersDetails { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
    }
}
