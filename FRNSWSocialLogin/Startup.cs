using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;

namespace FRNSWSocialLogin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
         public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // ...

        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
        //    })
        //        .AddCookie()
        //        .AddGoogle(options =>
        //        {
        //            options.ClientId = Configuration["Authentication:Google:ClientId"];

        //            options.ClientSecret = Configuration["Authentication:Google:ClientSecret"] ;

        //            options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
        //        });

        //    // ...
        //}


        public void ConfigureServices(IServiceCollection services)
        {
            // Add other services as needed

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.ClientId = "36524932123-lt2b52bhiv8ju3ro7lu84ism4bq6ssn2.apps.googleusercontent.com";
            //        options.ClientSecret = "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";
            //    });


            //services.AddAuthentication()
            //    .AddFacebook(options =>
            //    {
            //        options.ClientId = "36524932123-lt2b52bhiv8ju3ro7lu84ism4bq6ssn2.apps.googleusercontent.com";
            //        options.ClientSecret = "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";
            //    });

            // Add other configurations and services
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // ...
            });
        }


    }
}
