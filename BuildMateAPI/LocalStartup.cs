using BuildMateAPI.Data;
using BuildMateAPI.Data.UnitOfWork;
using BuildMateAPI.Data.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BuildMateAPI;

public class LocalStartup(IConfiguration configuration)
{
	public IConfiguration Configuration { get; } = configuration;

	public void ConfigureServices(IServiceCollection services)
	{
		var connectionString =
			Configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("Set ConnectionStrings:DefaultConnection (env: ConnectionStrings__DefaultConnection) for local development.");

		services.AddDbContext<AppDatabaseContext>(options => options.UseNpgsql(connectionString));

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		services.AddControllers();
		services.AddEndpointsApiExplorer();
	}

	public void Configure(IApplicationBuilder app)
	{
		app.UseRouting();
		app.UseEndpoints(endpoints => endpoints.MapControllers());
	}
}
