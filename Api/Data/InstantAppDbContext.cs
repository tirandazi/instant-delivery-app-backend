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
    }
}