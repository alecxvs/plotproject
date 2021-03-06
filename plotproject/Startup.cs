﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using plotproject.Models;

namespace plotproject
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
            services.AddMvc()
                .AddSessionStateTempDataProvider();

            services.AddSession();

            services.AddDbContext<PLotContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("dbContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{action=Index}/{id?}",
                    defaults: new { controller = "Home" });

                routes.MapRoute(
                    name: "operator",
                    template: "operator/{action=Index}",
                    defaults: new { controller = "Operator" });

                routes.MapRoute(
                    name: "operatorControls",
                    template: "operator/{controller:regex(^(Vehicles|Tickets|ParkingTypes))}/{action}/{id?}");
            });
        }
    }
}
