using Lamar;
using Microsoft.Extensions.Configuration;


namespace AssignmentSigortamNet.API.Infrastructure.DI
{
    public class LamarMainRegistry : ServiceRegistry
    {
        public LamarMainRegistry(IConfiguration configuration)
        {
            Scan(x =>
            {
                x.Assembly(typeof(Program).Assembly);
                x.WithDefaultConventions();
                x.Assembly("AssignmentSigortamNet.Service");
                x.Assembly("AssignmentSigortamNet.Data");
                x.Assembly("AssignmentSigortamNet.Integration");
            });
        }
    }
}