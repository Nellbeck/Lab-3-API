using Lab_3_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab_3_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Hobbys> Hobbys { get; set; }
        public DbSet<Peoples> Peoples { get; set; }
        public DbSet<Webpages> Webpages { get; set; }
        
    }
}
