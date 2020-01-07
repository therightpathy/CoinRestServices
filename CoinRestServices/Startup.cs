﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CoinRestServices
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
            services.AddCors();
            services.AddSwaggerGen(
                (c) => c.SwaggerDoc("v1",
                    new Info()
                    {
                        Title = "Coins API",
                        Version = "v1.0"
                    }
                ));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // setup swagger
            app.UseSwagger();
            app.UseSwaggerUI(
                (c) =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Obligatorisk Coins API v1.0");
                    c.RoutePrefix = "help";
                }
            );

            //Setup CORS
            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().WithMethods("GET", "POST", "PUT", "DELETE")); //all methods

            app.UseMvc();
        }
    }
}
