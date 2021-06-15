using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.DBContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineBookStore.Exceptions;
using OnlineBookStore.Interfaces;
using OnlineBookStore.Security;
using OnlineBookStore.Security.Basic;
using OnlineBookStore.Settings;


namespace OnlineBookStore
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
            // configure basic authentication - Needs BasicAuthenticationHandler.
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddSingleton(Configuration);// enable Configuration Services 

            services.Configure<ApiSettings>(Configuration.GetSection("Api"));
            services.Configure<ApiSecuritySettings>(Configuration.GetSection("ApiSecurity"));
            services.AddTransient<IOnlineBookStoreAuthentication, OnlineBookStoreAuthentication>();
            var ConnectionString = Configuration.GetConnectionString("SqlConnectionString");
            Utilities.Configuration.ConnectionString = ConnectionString;
            services.AddDbContext<OnlineBookStoreContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString"));
            });

            services.AddSwaggerGen(sw=> { sw.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Online Book Store", Version = "v2" }); });

            StartUpConfig.OnlineBookStore.Register(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v2/swagger.json","Online Book Store"); });
            app.UseMiddleware<ExceptionsHandlingMiddleware>();
            app.UseCors("Default");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
