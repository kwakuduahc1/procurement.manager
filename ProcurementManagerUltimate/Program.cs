using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProcurementManagerUltimate.Context;
using ProcurementManagerUltimate.Model;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/// Add services to the container.
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true
    );
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), op =>
    {
        op.UseRelationalNulls(true);
    }));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = true;
    x.Password.RequiredLength = 8;
    x.Password.RequireNonAlphanumeric = true;
    x.Password.RequireDigit = true;
    x.Password.RequireUppercase = true;
    x.Password.RequireLowercase = true;
    x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
})
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddSingleton<AppFeatures>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppFeatures").GetSection("RandomKey").Value)),
        ValidateIssuer = true,
        RequireExpirationTime = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration.GetSection("AppFeatures").GetSection("Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("AppFeatures").GetSection("Audience").Value
    };
});
builder.Services.AddDataProtection();
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "XSRF-TOKEN";
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("bStudioApps",
        x => x.WithOrigins("https://admissions.pshc.me", "http://localhost:4200")
        .WithHeaders("Content-Type", "Accept", "Origin", "Authorization", "X-XSRF-TOKEN", "XSRF-TOKEN", "enctype", "Access-Control-Allow-Origin")
        .WithMethods("GET", "POST", "OPTIONS", "PUT", "DELETE")
        .AllowCredentials());
});
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});
//builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(x => x.KeepAliveInterval = TimeSpan.FromSeconds(10));

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

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("bStuioApps");
app.UseAuthentication();
app.UseAuthorization();
var antiforgery = app.Services.GetRequiredService<IAntiforgery>();

app.Use((context, next) =>
{
    var tokenSet = antiforgery.GetAndStoreTokens(context);
    context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
        new CookieOptions { HttpOnly = false, IsEssential = true, Secure = true, SameSite = SameSiteMode.Lax });
    return next(context);
});

app.MapControllers();

app.Run();
