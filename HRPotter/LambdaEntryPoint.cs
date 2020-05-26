using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

///
/// NOTE: the Lambda handler field on AWS should be set to HRPotter::HRPotter.LambdaEntryPoint::FunctionHandlerAsync
/// 
/// NOTE2: If we want to use Application Load Balancer change:
/// Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction -> Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction
/// 
/// NOTE3: If we want to use HTTP API use (I didn't test it yet):
/// Amazon.Lambda.AspNetCoreServer.APIGatewayHttpApiV2ProxyFunction
/// or
/// Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction



namespace HRPotter
{
    /// <summary>
    /// This class extends from APIGatewayProxyFunction which contains the method FunctionHandlerAsync which is the 
    /// actual Lambda function entry point. 
    /// </summary>
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        /// <summary>
        /// The builder has configuration, logging and Amazon API Gateway already configured. The startup class
        /// needs to be configured in this method using the UseStartup<>() method.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<Startup>();
        }

        /// <summary>
        /// Use this override to customize the services registered with the IHostBuilder. 
        /// It is recommended not to call ConfigureWebHostDefaults to configure the IWebHostBuilder inside this method.
        /// Instead customize the IWebHostBuilder in the Init(IWebHostBuilder) overload.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Init(IHostBuilder builder)
        {
        }
    }
}
