using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Roomz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Booker> Bookers { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<BookerRole> BookerRoles { get; set; }

    }
}
