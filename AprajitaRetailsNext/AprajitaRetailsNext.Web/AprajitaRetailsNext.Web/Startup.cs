using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AprajitaRetailsNext.Web
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions> (options =>
             {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                 options.MinimumSameSitePolicy = SameSiteMode.None;
             });

            services.AddControllersWithViews ()
                    .AddNewtonsoftJson ();

            services.AddRazorPages ();

            services.AddSwaggerDocument ();

            services.AddHealthChecks ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if ( env.IsDevelopment () )
                app.UseDeveloperExceptionPage ();
            else
            {
                app.UseExceptionHandler ("/Home/Error");
                app.UseHsts (); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseCookiePolicy ();

            app.UseRouting ();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi ();
            app.UseSwaggerUi3 ();

            app.UseEndpoints (endpoints =>
             {
                 endpoints.MapHealthChecks ("/health");
                 endpoints.MapDefaultControllerRoute ();
                 endpoints.MapRazorPages ();
             });
        }
    }
}