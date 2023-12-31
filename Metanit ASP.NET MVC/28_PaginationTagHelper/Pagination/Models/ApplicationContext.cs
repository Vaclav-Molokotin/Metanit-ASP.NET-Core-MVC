﻿using Microsoft.EntityFrameworkCore;

namespace Pagination.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
