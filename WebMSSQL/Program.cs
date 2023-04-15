using Hangfire;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using WebMSSQL.Models.entities;


// c������ �������� ������������ ���� �� �������� � ��������� � ������������ rabbit mq
// hangfire ����� ���������� � ����������� ������� ����� � �����������
// �������� ���������� � ����� ���������
// ������ �����

var builder = WebApplication.CreateBuilder();

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("MSSQLString");
string localConnection = builder.Configuration.GetConnectionString("MSSQLString");

// Add services to the container.
builder.Services.AddHangfire(conf => 
conf.UseSqlServerStorage(localConnection));
builder.Services.AddHangfireServer();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProjectContext>(options =>
    options.UseSqlServer(connection));


builder.Services.AddAuthentication
    (CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {

        option.LoginPath = new PathString("/Account/Login");
        option.AccessDeniedPath = new PathString("/Account/Login");
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
 
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseHangfireDashboard("/dashboard");
app.UseRouting();
 
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
    name: "startupPage",
    pattern: "{controller=Account}/{action=Login}/{id?}");

    //app.MapControllerRoute(
    //name: "default",
    //pattern: "{controller=Nornikel}/{action=Index}/{id?}");

    //app.MapControllerRoute( //MapAreaControllerRoute
    //    name: "admin",
    //    pattern: "{area:exists}/{controller=Nornikel}/{action=Index}/{id?}");

}
    );

app.Run();