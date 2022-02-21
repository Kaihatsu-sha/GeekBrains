using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.Core.Logger;
using Kaihatsu.Timesheets.WebAPI.Core;
using Kaihatsu.Timesheets.WebAPI.Data;
using Kaihatsu.Timesheets.Core.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaihatsu.Timesheets.Core.Repository.Service;
using Kaihatsu.Timesheets.WebAPI.Services;
using Kaihatsu.Timesheets.Core.Identity;

namespace Kaihatsu.Timesheets.WebAPI
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

            services.AddControllers();
            services.AddEfContext(Configuration.GetConnectionString("Postgres"));
            services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));
            services.AddScoped(typeof(ILoggerService<>), typeof(LoggerAdapterService<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddIdentity();
            services.AddIdentityService();



            services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kaihatsu.Timesheets.WebAPI", Version = "v1" });
            //});

            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kaihatsu.Timesheets.WebAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kaihatsu.Timesheets.WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
