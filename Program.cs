using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EtudiantCRUD.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


//Authentification
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options => { options.LoginPath = "/Admin/Index"; });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();

builder.Services.AddDbContext<EtudiantCRUDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EtudiantCRUDContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStatusCodePages();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseAuthentication();


//app.UseAuthorization();

app.MapRazorPages();

app.Run();
