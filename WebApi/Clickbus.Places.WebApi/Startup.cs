using Clickbus.Places.Core.DataService.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Clickbus.Places.WebApi
{
    using Clickbus.Places.DataServices.EFCore;
    using Clickbus.Places.DataServices.EFCore.DataContext;
    using Core.DataService;
    using Core.DomainService;
    using DataServices.Interfaces;
    using DomainServices;
    using EFCore.Setup;

    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;

            DbContextDataInitializer.Initialize(new InMemoryDbContext());
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //generic services

            services.AddScoped<DbContext, InMemoryDbContext>();

            services.AddTransient(typeof(IEntityDataService<>), typeof(EntityDataService<>));

            services.AddTransient(typeof(DomainService<,>));

            //custom services

            services.AddScoped<AppDbContext, InMemoryDbContext>();

            services.AddTransient<IPlaceDataService, PlaceDataService>();
            services.AddTransient<PlaceDomainService>();

            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Clickbus.Places.WebApi",
                    Version = "v1.0",
                    Description = "Challenge for ClickBus backend developer",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Leo Lima",
                        Email = "leolima@leolima77.com.br",
                        Url = "https://clickbus.places.github.io/clickbus.places.webapi"
                    }
                });
            });

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
                app.UseExceptionHandler("/Home/Error");
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clickbus.Places.WebApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseMvc();
        }
    }
}
