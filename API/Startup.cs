﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Entities;
using API.Core.Interfaces;
using API.Core.SharedKernel;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("VehcilesDB"));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); 

            services.AddCors();

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            return services.BuildServiceProvider();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            var dbContext = app.ApplicationServices.GetRequiredService<AppDbContext>();
            //Initialize with test data.
            AddTestData(dbContext);

            ///AllowAll CORS
            app.UseCors(builder =>
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            );

            ///Change default route to Vehicles controller
            app.UseMvc(routes =>
                   routes.MapRoute(
                   name: "default",
                   template: "{controller=Values}/{action=Index}/{id?}")
            );
        }
        // Adding test data on initialization of database.
        private static void AddTestData(AppDbContext context)
        {
            var vehicle1 = context.Vehicles.Add(new Vehicle
            {
                Id = 10,
                Make = "Tesla",
                Model = "Model S",
                Year = 2016,
                //CreatedAt = DateTimeOffset.UtcNow
            }).Entity;
            var vehicle2 = context.Vehicles.Add(new Vehicle
            {
                Id = 11,
                Make = "Tesla",
                Model = "Model S",
                Year = 2018,
                //CreatedAt = DateTimeOffset.UtcNow
            }).Entity;

            context.SaveChanges();
        }
    }
}