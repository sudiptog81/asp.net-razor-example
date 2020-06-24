﻿using Microsoft.EntityFrameworkCore;

namespace WebApplicationRazor.Models
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Book { get; set; }
  }
}
