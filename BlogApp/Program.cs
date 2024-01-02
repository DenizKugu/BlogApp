using BlogApp.Data.Abstract;
using BlogApp.Data.Concreate.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options =>
{
	var config = builder.Configuration;
	var conString = config.GetConnectionString("sqlite_database");
	//var version = new MySqlServerVersion(new Version(8,1,0));
	options.UseSqlite(conString);
});

builder.Services.AddScoped<IPostRepository, EfCorePostRepository>();
builder.Services.AddScoped<ITagRepository, EfCoreTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCoreCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfCoreUserRepository>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
	options.LoginPath = "/Users/Login";
});

var app = builder.Build();

TestVerileri.TestVerileriEkle(app);



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();
// localhost://posts/aspnet-core
// localhost://posts/webdeveloper


app.MapControllerRoute(
	name: "post_details",
	pattern: "post/detay/{url}",
	defaults: new {controller="Post",action="Detail"}
	);
app.MapControllerRoute(
	name: "post_by_tag",
	pattern: "post/tag/{tag}",
	defaults: new { controller = "Post", action = "Index" }
	);
app.MapControllerRoute(
	name: "user_profile",
	pattern: "profile/{username}",
	defaults: new { controller = "Users", action = "Profile" }
	);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Post}/{action=Index}/{id?}");

app.Run();
