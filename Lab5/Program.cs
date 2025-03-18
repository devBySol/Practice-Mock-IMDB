using Lab5.Data;  
using Lab5.Data.Models;  
using Lab5.Data.Repositories;  
using Lab5.Services;  
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


var builder = WebApplication.CreateBuilder(args);


// 환경감지
var env = builder.Environment.EnvironmentName;
Console.WriteLine($"💛 Running Environment: {env} 💛");

// 환경별 appsetting.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// 환경에 맞는 DB
var connectionString = builder.Configuration.GetConnectionString("MovieDBConnection");
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString),
        b => b.MigrationsAssembly("Lab5.Data"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IMovieRepository, MockMovieRepository>(); //Mock리포
builder.Services.AddScoped<IMovieRepository, SQLMovieRepository>();

// 영화관련Api, 뉴스Api서비스
builder.Services.AddSingleton<MovieService>();
builder.Services.AddHttpClient();
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<AppDBContext>()
.AddDefaultTokenProviders();


if (builder.Environment.IsDevelopment())
{
    builder.Logging.SetMinimumLevel(LogLevel.Debug);
}
else if (builder.Environment.IsStaging())
{
    builder.Logging.SetMinimumLevel(LogLevel.Warning);
}
else
{
    builder.Logging.SetMinimumLevel(LogLevel.Error);
}

var app = builder.Build();
//app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");


// 환경별 예외처리
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");

} 
else
{
    app.UseDeveloperExceptionPage();
}


app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
