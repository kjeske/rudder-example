using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rudder;
using RudderExample.Database;

namespace RudderExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();

            services.AddScoped<ICustomersService, CustomersService>();

            services.AddRudder<AppState>(options =>
            {
                options.AddStateInitializer<InitialState>();
                options.AddStateFlows();
                options.AddLogicFlows();

                #if DEBUG
                options.AddJsLogging();
                #endif
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            app.UsePathBase("/sample");
        }
    }
}
