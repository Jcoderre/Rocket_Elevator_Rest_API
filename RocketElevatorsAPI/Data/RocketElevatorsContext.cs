using Microsoft.EntityFrameworkCore;
using RocketElevatorsAPI.Models;

namespace RocketElevatorsAPI.Data
{
    public class RocketElevatorsContext : DbContext
    {
        public RocketElevatorsContext(DbContextOptions<RocketElevatorsContext> options) : base(options) { }
        public DbSet<Elevator> Elevators { get; set; }
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Column> Columns { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BuildingDetail> BuildingDetails { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
    }
}