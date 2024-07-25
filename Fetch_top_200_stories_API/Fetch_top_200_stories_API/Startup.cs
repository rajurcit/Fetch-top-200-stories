using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Fetch_top_200_stories_API.Utilities.Interfaces;
using Fetch_top_200_stories_API.Utilities;
using StoryService;
using Fetch_top_200_stories_API.Services;

namespace Fetch_top_200_stories_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public static string Connectionstring { get; private set; }

        public static string WebApiLogLevel { get; private set; }

        public static string LogTableName { get; private set; }
      

         
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMemoryCache();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(typeof(ISerilogLogger), typeof(ExceptionLogger));            
            services.AddSingleton<IStoryService, StoryServiceData.StoryService>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fetch top 200 stories",
                    Description = "Api Description",
                    Version = "v1"
                });
                //  c.IncludeXmlComments("WebApiTemplate.xml");
            });



            services.AddCors(options =>
            {
                options.AddPolicy("CorsApi",
                    builder => builder.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddHttpClient();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Fetch top 200 stories");
                c.DefaultModelsExpandDepth(-1);
            });
            app.UseCors(builder => builder
              .AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .AllowCredentials()
          );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
           
            WebApiLogLevel = Configuration["Logging:LogLevel:Default"];
            LogTableName = Configuration["LogTableName"];


            app.UseRouting();
            app.UseCors();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
    }
}
