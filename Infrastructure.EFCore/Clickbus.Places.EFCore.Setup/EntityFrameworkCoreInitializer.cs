﻿using System;
using Clickbus.Places.DataServices.EFCore.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clickbus.Places.EFCore.Setup
{
    public class EntityFrameworkCoreInitializer
    {
        public static EntityFrameworkCoreInitializer Factory(IServiceCollection services, IConfiguration configuration)
        {
            return new EntityFrameworkCoreInitializer(services, configuration);
        }

        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        public EntityFrameworkCoreInitializer(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            IServiceProvider serviceProvider = _services.BuildServiceProvider();
            _hostingEnvironment = serviceProvider.GetService<IHostingEnvironment>();
        }

        public void AddDbContext()
        {
            if (_hostingEnvironment.IsDevelopment())
                _services.AddScoped<AppDbContext, InMemoryDbContext>();
            else
                _services.AddScoped<AppDbContext>(x => new SqlServerDbContext(_configuration));
        }

        public static void AddSeedDataToDbContext(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            if (hostingEnvironment.IsDevelopment())
                DbContextDataInitializer.Initialize(new InMemoryDbContext());
            else
                DbContextDataInitializer.Initialize(new SqlServerDbContext(configuration));

        }
    }
}