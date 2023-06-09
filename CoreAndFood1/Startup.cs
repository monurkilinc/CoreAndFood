using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CoreAndFood1
{
    public class Startup
    {
        public void ConfigureService(IServiceCollection services)
        {
			services.AddMvc();	


			//Authentication işlemi
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)

			 .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>

			 {


				 options.LoginPath = "/Login/GirisYap/";

			 });

			//Authorize işlemini controller seviyesine cıkarır
			
		}
		public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();
			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Category}/{action=Index}/{id?}");

            });
            app.UseCookiePolicy();
        }
    }
}
