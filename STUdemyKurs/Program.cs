using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using STUdemyKurs;
using STUdemyKurs.Data;
using STUdemyKurs.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(p => p.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IGenericRepository  ,  GenericRepository>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(p => p.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=STUdemyDb;"));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
