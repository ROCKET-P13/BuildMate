using Amazon.Lambda.AspNetCoreServer;

namespace BuildMateAPI;

public class LambdaEntryPoint : APIGatewayHttpApiV2ProxyFunction
{
	protected override void Init(IWebHostBuilder builder)
	{
		builder.UseStartup<LambdaStartup>();
	}
}
