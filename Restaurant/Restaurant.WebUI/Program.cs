using Restaurant.WebUI.Services.Catalog.AboutService;
using Restaurant.WebUI.Services.Catalog.Branch1_InformationServices;
using Restaurant.WebUI.Services.Catalog.Branch2_InformationServices;
using Restaurant.WebUI.settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();



builder.Services.AddHttpClient<IBranch1_InformationService, Branch1_InformationService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
});

builder.Services.AddHttpClient<IBranch2_InformationService, Branch2_InformationService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
});

builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}/");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
});

app.Run();
