using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projeto.Data;
using projeto.Models;

var builder = WebApplication.CreateBuilder(args);



if (builder.Environment.IsDevelopment())
{   
    //USANDO SQLITE
    
    builder.Services.AddDbContext<projetoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("projetoContext") ?? throw new InvalidOperationException("Connection string 'projetoContext' not found.")));
    
}

else
{   //USANDO MYSQL
      string mySqlConnection =
              builder.Configuration.GetConnectionString("eadAsync");
           
       //                          O contexto de dados
      builder.Services.AddDbContextPool<projeto.Data.projetoContext>(options => 
                options.UseMySql( 
                    mySqlConnection, 
                    new MySqlServerVersion(new Version())));
}



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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