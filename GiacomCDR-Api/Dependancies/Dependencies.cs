using GiacomCDR_Api.DataAccessLayer;
using GiacomCDR_Api.DataAccessLayer.CallDetailRecord;
using GiacomCDR_Api.Services;
using System.Reflection;

namespace GiacomCDR_Api.Dependancies
{
    public class Dependencies
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IFileService, FileService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICallDetailRecordRepository, CallDetailRecordRepository>();

            services.AddScoped<ICallDetailRecordService, CallDetailRecordService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
     }
}
