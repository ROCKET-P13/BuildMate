using BuildMateAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BuildMateAPI;

public static class LocalStartup
{
	public static void ConfigureWebApplication(WebApplicationBuilder builder)
	{
		var configuration = builder.Configuration;
		var connectionString =
			configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("Set ConnectionStrings:DefaultConnection (env: ConnectionStrings__DefaultConnection) for local development.");

		builder.Services.AddDbContext<AppDatabaseContext>(options => options.UseNpgsql(connectionString));
	}
}
