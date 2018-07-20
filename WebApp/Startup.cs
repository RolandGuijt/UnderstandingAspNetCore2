using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Services;

namespace WebApp
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddSingleton<IConferenceService, ConferenceApiService>();
            services.AddSingleton<IProposalService, ProposalApiService>();
            services.AddHttpClient("GlobomanticsApi", c => 
                c.BaseAddress = new Uri("http://localhost:5000"));
            services.AddHttpClient<IConferenceService, ConferenceApiService>();
            
            services.Configure<GlobomanticsOptions>(configuration.GetSection("Globomantics"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Conference}/{action=Index}/{id?}");
            });
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        }
    }
}
