using BuildMateAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildMateAPI.Data;

public class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : DbContext(options)
{
	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>(entity =>
		{
			entity.ToTable("Users");
			entity.Property(user => user.Id).HasColumnName("id");
			entity.Property(user => user.Auth0Id).HasColumnName("i");
			entity.Property(user => user.Email).HasColumnName("email");
			entity.Property(user => user.FirstName).HasColumnName("first_name");
			entity.Property(user => user.LastName).HasColumnName("last_name");
			entity.Property(user => user.CreatedAt).HasColumnName("created_at");

			entity.HasIndex(user => user.Auth0Id).IsUnique();

			entity.HasKey(user => user.Id);
		});
	}
}
