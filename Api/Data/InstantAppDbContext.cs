using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class InstantAppDbContext : DbContext
    {
        public InstantAppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> products{ get; set; }
        public DbSet<OTPRecord> otprecord { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<CartItems> cart_items { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Store> store { get; set; }
        public DbSet<DeliveryPartner> delivery_partner { get; set; }


    }
}