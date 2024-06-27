using Microsoft.EntityFrameworkCore;
using music_library_website.Data;
using music_library_website.Data.Interfaces;
using music_library_website.Data.Models;
using music_library_website.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//� ��������
builder.Services.AddDbContext<AppDBContext>(e => e.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VinylRecordsShop;Trusted_Connection=True;"));
builder.Services.AddTransient<IAllVinylRecords, VinylRecordRepository>();
builder.Services.AddTransient<IAllVinylRecordsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  //������ ��������
builder.Services.AddScoped(sp => ShopCart.GetShopCart(sp));
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();
//
var app = builder.Build();

app.Environment.EnvironmentName = "Production";
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
// I write
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseSession();
app.UseMvc(routes =>
{
	routes.MapRoute(
		name: "default",
		template: "{controller=Home}/{action=Index}/{id?}");
	routes.MapRoute(
		name: "CategoryFilter",
		template: "VinylRecords/{action}/{typesOfMusic?}",
		defaults: new { controller = "VinylRecords", action = "ViewResult" });
	//routes.MapRoute(
	//	name: "ViewItem",
	//	template: "{controller=VinylRecords}/{action=ViewItem}/{id?}");
});
//
app.UseHttpsRedirection();
app.UseStaticFiles();
app.Run();
Console.WriteLine("v2");