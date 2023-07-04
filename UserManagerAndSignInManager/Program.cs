using Microsoft.EntityFrameworkCore;
using UserManagerAndSignInManager.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using UserManagerAndSignInManager.Models;

//using UserManagerAndSignInManagerDBContext context = new UserManagerAndSignInManagerDBContext();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserManagerAndSignInManagerDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserDatabaseConnectionString")));

// Identity Framework Dependency Injection
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<UserManagerAndSignInManagerDBContext>().AddDefaultTokenProviders();

// Create Global Authorization (JUST A TEST. AUTHORIZATION MIGHT BE CHANGED TO LOCAL Controllers)
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();

////////////////////////////
builder.Services.AddAuthentication().AddCookie(options =>
{
    options.LoginPath = "/Home/Login";
    options.AccessDeniedPath = "/Home/AccessDenied";
});

//builder.Services.AddAuthorization(options => {
//    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
//    options.AddPolicy("MustBelongToHRDepartment", policy => policy.RequireClaim("Department", "HR"));
//    options.AddPolicy("HRManagerOnly", policy => policy.RequireClaim("Department", "HR").RequireClaim("Manager"));

//});


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

//ORDER MATTERS!
app.UseRouting();           // Can Be BEFORE "app.UseAuthorization NOT After

// Authentication MiddleWare is also needed
app.UseAuthentication();   // MUST be BEFORE "app.UseAuthorization"
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


