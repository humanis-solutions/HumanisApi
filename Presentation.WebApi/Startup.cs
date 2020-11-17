using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanis.Application.Services;
using Humanis.Data.Repository;
using Humanis.Infrastructure.CrossCutting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace Humanis.Presentation.WebApi
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
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Humanis Api", Version = "v1" });
            });

            services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in - needs to be placed after AddSwaggerGen()

            var appSettings = new ApplicationSettings();

            //Map AppSettings
            Configuration.GetSection("App").Bind(appSettings);
            services.AddSingleton<IApplicationSettings>(appSettings);

            // Prepare MongoDB connection to provide to dependencies
            var connectionString = appSettings.MongoDBSettings.ConnectionString;
            var timeoutMs = appSettings.MongoDBSettings.TimeoutMs;

            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var mongoDatabase = new MongoClient(connectionString).GetDatabase(databaseName);



            var personRepository = new Data.Repository.PersonRepository(mongoDatabase, timeoutMs);
            services.AddSingleton<IPersonRepository>(personRepository);
            services.AddSingleton<IPersonService>(new PersonService(personRepository));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Humanis Api V1");
            });
        }
    }
}
