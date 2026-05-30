// =====================================================================
// Program.cs — registra TODOS los servicios del proyecto MyVaccine
// Agrega o reemplaza el tuyo con este contenido
// =====================================================================
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.WebApi.Configurations;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.UsersAllergy;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Repositories.Implementations;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;
using MyVaccine.WebApi.Validators;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ── Controllers ────────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── Database ────────────────────────────────────────────────────────────
builder.Services.AddDbContext<MyVaccineAppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ── Identity ────────────────────────────────────────────────────────────
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<MyVaccineAppDbContext>()
    .AddDefaultTokenProviders();

// ── JWT Authentication ───────────────────────────────────────────────────
var jwtKey = builder.Configuration["Jwt:Key"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer           = false,
        ValidateAudience         = false,
        ValidateLifetime         = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
    };
});

// ── AutoMapper ───────────────────────────────────────────────────────────
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ── Repositories ─────────────────────────────────────────────────────────
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ── Services ─────────────────────────────────────────────────────────────
builder.Services.AddScoped<IUserService,          UserService>();
builder.Services.AddScoped<IAllergyService,       AllergyService>();
builder.Services.AddScoped<IFamilyGroupService,   FamilyGroupService>();
builder.Services.AddScoped<IDependentService,     DependentService>();
builder.Services.AddScoped<IVaccineCategoryService, VaccineCategoryService>();
builder.Services.AddScoped<IVaccineService,       VaccineService>();
builder.Services.AddScoped<IVaccineRecordService, VaccineRecordService>();
builder.Services.AddScoped<IUsersAllergyService,  UsersAllergyService>();
builder.Services.AddScoped<SaveProfileImageUserService>();

// ── FluentValidation ─────────────────────────────────────────────────────
builder.Services.AddScoped<IValidator<AllergyRequestDto>,       AllergyRequestDtoValidator>();
builder.Services.AddScoped<IValidator<DependentRequestDto>,     DependentRequestDtoValidator>();
builder.Services.AddScoped<IValidator<FamilyGroupRequestDto>,   FamilyGroupRequestDtoValidator>();
builder.Services.AddScoped<IValidator<VaccineRequestDto>,       VaccineRequestDtoValidator>();
builder.Services.AddScoped<IValidator<VaccineCategoryRequestDto>, VaccineCategoryRequestDtoValidator>();
builder.Services.AddScoped<IValidator<VaccineRecordRequestDto>, VaccineRecordRequestDtoValidator>();
builder.Services.AddScoped<IValidator<UsersAllergyRequestDto>,  UsersAllergyRequestDtoValidator>();

// ── CORS (opcional para desarrollo local) ────────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
