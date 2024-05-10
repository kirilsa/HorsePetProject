using Microsoft.EntityFrameworkCore;
using System;
using testPetProject2.Models;

namespace testPetProject2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Person> persons { get; set; }

        public DbSet<Pricing> pricings { get; set; }
    }
}
