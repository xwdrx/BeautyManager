using BeautyManagerApp;
using BeautyManagerApp.Core;
using BeautyManagerApp.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BeautyManagerAppDbContext>(options =>
    options.UseSqlServer("Server=.; Database=BeautyManagerAppDataBase; Trusted_Connection=True;"));

builder.Services.AddTransient<IDCosmetologyRepository, CosmetologyRepository>();
builder.Services.AddTransient<IDBeautyServicesRepository, BeautyServicesRepository>();
builder.Services.AddTransient<IDBeautySpecialistRepository, BeautySpecialistRepository>();

builder.Services.AddTransient<DTOmapper>();
builder.Services.AddTransient<ViewModelMapper>();

builder.Services.AddTransient<IBeautySpecialistmanager, BeautySpecialistManager>();


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

//add migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BeautyManagerAppDbContext>();
    db.Database.Migrate();
}
app.Run();
