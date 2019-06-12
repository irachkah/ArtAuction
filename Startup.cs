using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ArtAuction.Models;
using ArtAuction.Models.Collections;
using ArtAuction.Models.FileManager;

namespace ArtAuction
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IUserCollection>(_ => new UserCollection(Configuration["mongoStr"]));
            services.AddScoped<IAuctionCollection>(_ => new AuctionCollection(Configuration["mongoStr"]));
            services.AddScoped<IEditableCollection<Artist>>(_ => new ArtistCollection(Configuration["mongoStr"]));
            services.AddScoped<IEditableCollection<Gallery>>(_ => new GalleryCollection(Configuration["mongoStr"]));
            services.AddScoped<IPaintingCollection>(_ => new PaintingCollection(Configuration["mongoStr"]));

            services.AddScoped<IFileManager, FileManager>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Authentication/Login");
                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes => { routes.MapRoute("Default", "{controller=Authentication}/{action=Login}/{Id?}"); });
            app.UseFileServer();
            
        }
    }
}
