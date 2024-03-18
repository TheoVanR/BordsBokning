using BordsBokning.Models;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class BokningsContext : DbContext
    {
        public DbSet<Bokning> Bokningar { get; set; }

        public BokningsContext(DbContextOptions options) : base(options)
        { }
    }

}

