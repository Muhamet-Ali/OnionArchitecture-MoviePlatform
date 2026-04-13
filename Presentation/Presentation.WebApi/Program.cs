using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MoveApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MoveApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MoveApi.Application.Features.MediatornDesignPattern.Commands.UserRegister;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;
using MovieApi.Persistence.Interfaces;
using MovieApi.Persistence.Services;


var builder = WebApplication.CreateBuilder(args);



// DbContext
builder.Services.AddDbContext<MovieContext>();


builder.Services.AddControllers();
builder.Services.AddScoped<ITokenService, JwtTokenService>(); // artık çalışır


// CQRS Handlers (senin eski sistem)
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();


var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});


// MediatR (handler'ları otomatik bulsun)mohamr
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateUserRegisterCommand>());

// ✅ Identity: TEK KERE EKLENECEK 
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<MovieContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); 


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
    });
}

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return; // <-- kritik
    }

    await next();
});





app.UseHttpsRedirection();

// ✅ Identity için şart: önce Authentication, sonra Authorization
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();