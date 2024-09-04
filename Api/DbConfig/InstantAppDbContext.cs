using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.DbConfig
{
    public class InstantAppDbContext : DbContext
    {
        public InstantAppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> products{ get; set; }
    }
}