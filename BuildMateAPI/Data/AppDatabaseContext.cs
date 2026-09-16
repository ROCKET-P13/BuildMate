using BuildMateAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildMateAPI.Data;

public class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : DbContext(options)
{
	public DbSet<User> Users { get; set; }
	public DbSet<DeveloperProfile> DeveloperProfiles { get; set; }
	public DbSet<Project> Projects { get; set; }
	public DbSet<ProjectNeed> ProjectNeeds { get; set; }
	public DbSet<ProjectInterest> ProjectInterests { get; set; }
	public DbSet<ProjectMember> ProjectMembers { get; set; }
	public DbSet<Technology> Technologies { get; set; }
	public DbSet<UserTechnology> UserTechnologies { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>(entity =>
		{
			entity.ToTable("Users");
			entity.Property(user => user.Id).HasColumnName("id");
			entity.Property(user => user.Auth0Id).HasColumnName("auth0_id");
			entity.Property(user => user.Email).HasColumnName("email");
			entity.Property(user => user.FirstName).HasColumnName("first_name");
			entity.Property(user => user.LastName).HasColumnName("last_name");
			entity.Property(user => user.CreatedAt).HasColumnName("created_at");

			entity.HasIndex(user => user.Auth0Id).IsUnique();

			entity.HasKey(user => user.Id);
		});

		modelBuilder.Entity<DeveloperProfile>(entity =>
		{
			entity.ToTable("DeveloperProfiles");
			entity.Property(developerProfile => developerProfile.Id).HasColumnName("id");
			entity.Property(developerProfile => developerProfile.UserId).HasColumnName("user_id");
			entity.Property(developerProfile => developerProfile.Bio).HasColumnName("bio");
			entity
				.Property(developerProfile => developerProfile.AvialabilityHours)
				.HasColumnName("availability_hours");
			entity
				.Property(developerProfile => developerProfile.ExperienceLevel)
				.HasColumnName("experience_level");
			entity
				.Property(developerProfile => developerProfile.LookingFor)
				.HasColumnName("looking_for");
			entity
				.Property(developerProfile => developerProfile.Timezone)
				.HasColumnName("timezone");
		});

		modelBuilder.Entity<Project>(entity =>
		{
			entity.ToTable("Projects");
			entity.Property(project => project.Id).HasColumnName("id");
			entity.Property(project => project.OwnerId).HasColumnName("owner_id");
			entity.Property(project => project.Name).HasColumnName("name");
			entity.Property(project => project.Description).HasColumnName("description");
			entity.Property(project => project.Stage).HasColumnName("stage");
			entity.Property(project => project.Type).HasColumnName("type");
			entity.Property(project => project.Commitment).HasColumnName("commitment");
			entity.Property(project => project.RepositoryUrl).HasColumnName("repository_url");
			entity.Property(project => project.CreatedAt).HasColumnName("created_at");

			entity
				.HasMany(project => project.Members)
				.WithOne()
				.HasForeignKey(projectMember => projectMember.ProjectId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		modelBuilder.Entity<ProjectNeed>(entity =>
		{
			entity.ToTable("ProjectNeeds");
			entity.Property(projectNeed => projectNeed.Id).HasColumnName("id");
			entity.Property(projectNeed => projectNeed.ProjectId).HasColumnName("project_id");
			entity.Property(projectNeed => projectNeed.Role).HasColumnName("role");
			entity.Property(projectNeed => projectNeed.Description).HasColumnName("description");
			entity.Property(projectNeed => projectNeed.Required).HasColumnName("required");
		});

		modelBuilder.Entity<ProjectInterest>(entity =>
		{
			entity.ToTable("ProjectInterests");
			entity.Property(projectInterest => projectInterest.Id).HasColumnName("id");
			entity
				.Property(projectInterest => projectInterest.ProjectId)
				.HasColumnName("project_id");
			entity.Property(projectInterest => projectInterest.UserId).HasColumnName("user_id");
			entity.Property(projectInterest => projectInterest.Message).HasColumnName("message");
			entity.Property(projectInterest => projectInterest.Status).HasColumnName("status");
			entity
				.Property(projectInterest => projectInterest.CreatedAt)
				.HasColumnName("created_at");
		});

		modelBuilder.Entity<ProjectMember>(entity =>
		{
			entity.ToTable("ProjectMembers");
			entity.Property(projectMember => projectMember.Id).HasColumnName("id");
			entity.Property(projectMember => projectMember.ProjectId).HasColumnName("project_id");
			entity.Property(projectMember => projectMember.UserId).HasColumnName("user_id");
			entity.Property(projectMember => projectMember.Role).HasColumnName("role");
			entity.Property(projectMember => projectMember.JoinedAt).HasColumnName("joined_at");
		});

		modelBuilder.Entity<Technology>(entity =>
		{
			entity.ToTable("Technologies");
			entity.Property(technology => technology.Id).HasColumnName("id");
			entity.Property(technology => technology.Name).HasColumnName("name");
		});

		modelBuilder.Entity<UserTechnology>(entity =>
		{
			entity.ToTable("UserTechnologies");
			entity.Property(userTechnology => userTechnology.Id).HasColumnName("id");
			entity.Property(userTechnology => userTechnology.UserId).HasColumnName("user_id");
			entity
				.Property(userTechnology => userTechnology.ProficiencyLevel)
				.HasColumnName("proficiency_level");
			entity
				.Property(userTechnology => userTechnology.YearsOfExperience)
				.HasColumnName("years_of_experience");
		});
	}
}
