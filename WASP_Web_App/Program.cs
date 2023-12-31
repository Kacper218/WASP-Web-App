using Microsoft.EntityFrameworkCore;
using WASP_Web_App;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

//builder.Services.AddDbContext<DBContext>(options =>
//        options.UseNpgsql("Host=balarama.db.elephantsql.com;Port=5432;Database=kwhuxftu;User Id=kwhuxftu;Password=m2vos2b9Lq2F8XEIJfPBTYFXYY_hlUVO"));
builder.Services.AddDbContext<DBContext>(options =>
        options.UseNpgsql("Host=cornelius.db.elephantsql.com;Port=5432;Database=hxsnsuxz;User Id=hxsnsuxz;Password=c1h7Y_Iw2lZNbolvfZY5b35J6weckB36"));

builder.Services.AddScoped<ApiClient>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
