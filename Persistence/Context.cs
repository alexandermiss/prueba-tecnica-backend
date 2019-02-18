using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Models;

namespace Persistence
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
