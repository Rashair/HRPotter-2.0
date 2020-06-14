using HRPotter.Authorization;
using HRPotter.Data;
using HRPotter.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace HRPotter
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
            services.AddAuthentication(AzureADB2CDefaults.CookieScheme)
                .AddAzureADB2C(options =>
                {
                    Configuration.Bind("AzureAdB2C", options);
                });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.Configure<RazorViewEngineOptions>(opt =>
            {
                opt.ViewLocationFormats.Add("/Views/{1}/HR/{0}" + RazorViewEngine.ViewExtension);
            });


            string connectionString = GetConnectionString("AWSConnection");
            services.AddDbContext<HRPotterContext>(options =>
            {
                options.UseMySql(connectionString, mySqlOptions =>
                {
                });
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRPotter API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            });

            // TODO: Is it needed?
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(GetConnectionString("BlobStorageConnection"));
            });
        }

        private string GetConnectionString(string name)
        {
            string conn = Configuration.GetConnectionString(name);
            if (conn.StartsWith("<P", StringComparison.InvariantCulture))
            {
                conn = Environment.GetEnvironmentVariable(name);
            }

            if (conn == null)
            {
                conn = AwsTools.GetSecret(name);
            }

            return conn;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRPotter API");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "wwwroot")),
                RequestPath = ""
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<AuthorizationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapRazorPages();
            });
        }
    }
}
