using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


//AddAuthentication i�lemi i�in burada i�lem yap�l�r
builder.Services.AddAuthentication()
		.AddCookie(options =>
		{
			options.LoginPath = "/Login/Index/";
		});

builder.Services.AddAuthentication();

//Authorize i�lemini controller seviyesine c�kar�r(Login i�lemi i�in)
builder.Services.AddMvc(config =>
{

	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser().Build();

	config.Filters.Add(new AuthorizeFilter(policy));

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}/{id?}");


app.UseCookiePolicy();

app.Run();
