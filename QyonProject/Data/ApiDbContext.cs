using Microsoft.EntityFrameworkCore;
using QyonProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonProject.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Speedway> Speedways { get; set; }
        public DbSet<Historic> Historics { get; set; }
    }
}
