using BlazorApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class PeopleDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contract> Contracts { get; set; }

    }
}
