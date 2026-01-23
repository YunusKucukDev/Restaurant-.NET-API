using Microsoft.Extensions.Options;
using Restaurant.Catalog.Settings;
using System.Reflection;
using Restaurant.Catalog.Services.Branch1_InformationService;
using Restaurant.Catalog.Services.Branch2_InformationService;
using Restaurant.Catalog.Services.AboutService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


builder.Services.AddScoped<IBranch_InformationService, Branch1_InformationService>();
builder.Services.AddScoped<IBranch2_InformationService, Branch2_InformationService>();
builder.Services.AddScoped<IAboutService, AboutService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
