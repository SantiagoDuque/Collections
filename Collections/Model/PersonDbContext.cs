using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collections.Model
{
    class PersonDbContext: LoggerDbContext
    {
        public DbSet<Person> People { get; set; }

        public PersonDbContext()
            : base(new TraceLoggerProvider())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\;Database=Collection;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        
    }
}
