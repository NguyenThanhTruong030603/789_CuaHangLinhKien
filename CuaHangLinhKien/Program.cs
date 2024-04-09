using Microsoft.EntityFrameworkCore;
using CuaHangLinhKien.Dataaccess;
using CuaHangLinhKien.Repositories;
using Microsoft.AspNetCore.Identity;





var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);//thời gian hết hạn
	options.Cookie.HttpOnly = true;//Cookie chỉ được truy cập bằng HTTP
	options.Cookie.IsEssential = true;//Cookie là bắt buộc cho phiên
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebApplication1Context>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
		.AddDefaultTokenProviders()
		.AddDefaultUI()
		.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();





var app = builder.Build();
//app.MapControllerRoute(
//		  name: "admin",
//		  pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
//	  );

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();



app.UseAuthorization();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




