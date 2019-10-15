using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibaryApiCodes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LibaryWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var migrationAssemblyName = typeof(Startup).Assembly.FullName;

            var connectionString = Configuration.GetConnectionString("DefaultConnection");



            services.AddTransient<IRipositoryStudentInfo, RepositoryStudentInfo>()
                    .AddTransient<IServiceEntryStudent, ServiceEntryStudent>()
                    .AddTransient<IRipositoryBookInfo, RipositoryBookInfo>()
                    .AddTransient<IServiceBookAdd, ServiceBookAdd>()
                    .AddTransient<IRipositoryBookIssue, RipositoryBookIssue>()
                    .AddTransient<IServiceBookIssue, ServiceBookIssue>()
                    .AddTransient<IServiceReturnBook, ServiceReturnBook>()
                    .AddTransient<IServiceFine, ServiceFine>()
                    .AddTransient<UnitOfWorkBookIssue>(u => new UnitOfWorkBookIssue(connectionString, migrationAssemblyName))
                    .AddTransient<IUnitOfWorkBookIssue, UnitOfWorkBookIssue>()
                    .AddTransient<UnitOfWorkReturnBook>(u => new UnitOfWorkReturnBook(connectionString, migrationAssemblyName))
                    .AddTransient<IUnitOfWorkReturnBook,UnitOfWorkReturnBook>()
                    .AddTransient<LibaryContext>(l => new LibaryContext(connectionString, migrationAssemblyName));

            services.AddDbContext<LibaryContext>(x => x.UseSqlServer(connectionString, m => m.MigrationsAssembly(migrationAssemblyName)));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
