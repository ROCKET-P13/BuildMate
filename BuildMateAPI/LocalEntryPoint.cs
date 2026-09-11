namespace BuildMateAPI;

/// <summary>
/// The Main function can be used to run the ASP.NET Core application locally using the Kestrel webserver.
/// </summary>
public class LocalEntryPoint
{
	public static async Task Main(string[] args)
	{
		var applicationBuilder = WebApplication.CreateBuilder(args);
		LocalStartup.ConfigureWebApplication(applicationBuilder);

		var application = applicationBuilder.Build();
	}
}
