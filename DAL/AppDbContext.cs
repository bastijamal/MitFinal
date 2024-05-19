using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SondanaSon.Models;

namespace SondanaSon.DAL
{
	public class AppDbContext:IdentityDbContext<User>
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Clients> clients { get; set; }

    }
}

