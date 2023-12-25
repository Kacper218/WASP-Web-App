using Microsoft.EntityFrameworkCore;
using WASP_Web_App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddMvc();

builder.Services.AddDbContext<DBContext>(options =>
        options.UseNpgsql("Host=cornelius.db.elephantsql.com;Port=5432;Database=hxsnsuxz;User Id=hxsnsuxz;Password=c1h7Y_Iw2lZNbolvfZY5b35J6weckB36"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
