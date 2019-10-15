using LibaryUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LibaryWebApi
{
    public class Service
    {
        public Service(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


             services
                    .AddTransient<IPostToWebservice, PostToWebservice>()
                    .AddTransient<IStudentInformation, StudentInformation>()
                    .AddTransient<IMainMenu, MainMenu>();

    

            // create a service provider from the service collection
            // resolve the dependency graph
            //var appService = serviceProvider.GetService<IAppService>();


        }

            
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    }
}
