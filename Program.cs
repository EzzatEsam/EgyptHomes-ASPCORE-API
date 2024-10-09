using System.Text;
using System.Text.Json.Serialization;
using EgyptHomes.Models;
using EgyptHomes.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
          
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=EgyptHomesDbLocal;Username=postgres;Password=22;"
));
builder.Services.AddIdentity<User, IdentityRole>(opts =>
{
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<PropertyManagementService>();
builder.Services.AddScoped<ImageDbService>();
builder.Services.AddScoped<ImageIOService>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration["JwtAuth:secret"]!
                ))
            };
        });
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
// app.MapIdentityApi<IdentityUser>();
app.MapControllers();

app.Run();
