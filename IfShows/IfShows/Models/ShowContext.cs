using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace IfShows.Models
{
	public class ShowContext : DbContext

	{
        public ShowContext(DbContextOptions<ShowContext> options)
            : base(options)
        {
        }

        public DbSet<Show> Shows { get; set; } = null!;
    }
}

