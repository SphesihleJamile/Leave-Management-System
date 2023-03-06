global using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Configurations;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Repositories.Abstract;
using LeaveManagement.Web.Repositories.Concrete;
using LeaveManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("LeaveManagementDbConntection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

/****
 * localhost                        : this is the parameter for the server. Where are using localhost because Papercut SMTP only works locally. This will be changed for production
 * 25                               : the default SMTP port
 * no-reply@leavemanagement.com     : the email that the account confirmation will be sent from
 * 
 * we are using AddTransient for dependency injection because we want that for everytime a page or client
 *      requests an email to be sent, a new EmailSender instance is produced for that request
 */
builder.Services.AddTransient<IEmailSender>(sender => new EmailSender("localhost", 25, "no-reply@leavemanagement.com"));

builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
