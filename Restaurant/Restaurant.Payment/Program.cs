using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Restaurant.Payment.Contex;
using Restaurant.Payment.Mapping;
using Restaurant.Payment.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(GeneralMapping));

builder.Services.AddDbContext<PaymentDbContex>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("OrderConnection"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceOrder";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<IPaymentService, PaymentService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
