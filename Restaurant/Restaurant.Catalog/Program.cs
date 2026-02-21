using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Restaurant.Catalog.Dtos.SpecialMenuDtos;
using Restaurant.Catalog.Services.AboutService;
using Restaurant.Catalog.Services.Branch1_InformationService;
using Restaurant.Catalog.Services.Branch2_InformationService;
using Restaurant.Catalog.Services.CategoryService;
using Restaurant.Catalog.Services.ContactService;
using Restaurant.Catalog.Services.DailyReportService;
using Restaurant.Catalog.Services.FinalReportService;
using Restaurant.Catalog.Services.FixedExpenseService;
using Restaurant.Catalog.Services.IncomeService;
using Restaurant.Catalog.Services.OutComeService;
using Restaurant.Catalog.Services.ProductService;
using Restaurant.Catalog.Services.SpecialMenuService;
using Restaurant.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:5001";
                options.Audience = "ResourceCatalog";
            });

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

// EKSÝK OLAN KISIM: IMongoClient kaydý
builder.Services.AddSingleton<MongoDB.Driver.IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IDatabaseSettings>();
    return new MongoDB.Driver.MongoClient(settings.ConnectionString);
});


builder.Services.AddScoped<IBranch_InformationService, Branch1_InformationService>();
builder.Services.AddScoped<IBranch2_InformationService, Branch2_InformationService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISpecialMenuService, SpecialMenuService>();


builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IOutcomeService, OutcomeService>();
builder.Services.AddScoped<IFixedExpenseService, FixedExpenseService>();
builder.Services.AddScoped<IDailyReportService, DailyReportService>();
builder.Services.AddScoped<IFinalReportService, FinalReportService>();
builder.Services.AddScoped<IContactService, ContactService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
