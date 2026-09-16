namespace BuildMateAPI;

public class LocalStartup(IConfiguration configuration)
{
	public IConfiguration Configuration { get; } = configuration;

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
	}

	public void Configure(IApplicationBuilder app)
	{
		// app.UseHttpsRedirection();
		app.UseRouting();
		app.UseEndpoints(endpoints => endpoints.MapControllers());
	}
}
