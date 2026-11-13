using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

Context.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IWriterMessageDal, EfWriterMessageDal>();
builder.Services.AddScoped<IWriterMessageService, WriterMessageManager>();

builder.Services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddMvc();

 
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Writer/Login/Index/";
    options.AccessDeniedPath = "/ErrorPage/Index/";
    // Yazar sayfaları yazar girişine, admin sayfaları admin girişine yönlendirilir
    options.Events.OnRedirectToLogin = context =>
    {
        var loginPath = context.Request.Path.StartsWithSegments("/Writer") ? "/Writer/Login/Index/" : "/AdminLogin/Index/";
        var returnUrl = context.Request.PathBase + context.Request.Path + context.Request.QueryString;
        context.Response.Redirect(loginPath + "?returnUrl=" + Uri.EscapeDataString(returnUrl));
        return Task.CompletedTask;
    };
});

var app = builder.Build();

// "Admin" rolünü oluştur; appsettings.json'daki AdminUserName kullanıcısını bu role ekle
using (var scope = app.Services.CreateScope())
{
    try
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<WriterRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<WriterUser>>();
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new WriterRole { Name = "Admin" });
        }
        var adminUserName = builder.Configuration["AdminUserName"];
        if (!string.IsNullOrEmpty(adminUserName))
        {
            var adminUser = await userManager.FindByNameAsync(adminUserName);
            if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
    catch (Exception ex)
    {
        app.Logger.LogWarning(ex, "Admin rolü hazırlanamadı (veritabanı erişilebilir mi?)");
    }
}
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}");

app.Run();
