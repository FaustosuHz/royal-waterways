using Dominio.InterfacesLogicaAplicacion;
using Dominio.InterfacesRepositorios;
using Infraestructura.Repositorios.EntityFramework;
using Libreria.WepApi.Services;
using LogicaAplicacion.CasosDeUso.Equipo;
using LogicaAplicacion.CasosDeUso.Usuario;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.CasosUso.AuditoriaPrestamoCU;
using LogicaAplicacion.CasosUso.Equipos;
using LogicaAplicacion.CasosUso.ObjetoCelesteCU;
using LogicaAplicacion.CasosUso.ObservacionCU;
using LogicaAplicacion.CasosUso.Observaciones;
using LogicaAplicacion.CasosUso.Prestamos;
using LogicaAplicacion.Dtos.AuditoriaPrestamo;
using LogicaAplicacion.Dtos.Equipo;
using LogicaAplicacion.Dtos.ObjetoCeleste;
using LogicaAplicacion.Dtos.Observacion;
using LogicaAplicacion.Dtos.Prestamo;
using LogicaAplicacion.Dtos.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// inyecto los repositorios
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamo>();
builder.Services.AddScoped<IRepositorioObjetoCeleste, RepositorioObjetoCeleste>();
builder.Services.AddScoped<IRepositorioObservacion, RepositorioObservacion>();
builder.Services.AddScoped<IRepositorioAuditoriaPrestamo, RepositorioAuditoriaPrestamo>();

// Inyecto caso de uso Usuario
builder.Services.AddScoped<ICUAdd<UsuarioAltaDto>, AddUsuario>();
builder.Services.AddScoped<ICUAdd<EquipoAltaDto>, AddEquipo>();
builder.Services.AddScoped<ICULogin<UsuarioLoginDto, UsuarioLogueadoDto>, Login>();
builder.Services.AddScoped<ICUGetAll<UsuarioListadoDto>, GetAllUsuarios>();
builder.Services.AddScoped<ICUGetById<UsuarioListadoDto>, GetByIdUsuario>();
builder.Services.AddScoped<ICUEdit<UsuarioEditarDto>, EditUsuario>();
builder.Services.AddScoped<ICUDelete, DeleteUsuario>();

// Inyecto caso de uso Prestamo
builder.Services.AddScoped<ICUAddPrestamo<PrestamoAltaDto>, AddPrestamo>();
builder.Services.AddScoped<ICUGetById<PrestamoDto>, GetPrestamoById>();
builder.Services.AddScoped<ICUGetAll<PrestamoDto>, GetAllPrestamos>();
builder.Services.AddScoped<ICUEdit<PrestamoEditDto>, EditPrestamo>();
builder.Services.AddScoped<ICUDeletePrestamo, DeletePrestamo>();
builder.Services.AddScoped<ICUGetByUsuario<PrestamoDetalleDto>, GetPrestamoByUsuario>();
builder.Services.AddScoped<ICUDevolverPrestamo, DevolverPrestamo>();
builder.Services.AddScoped<ICUGetAllByUsuario<PrestamoDetalleDto>, GetAllPrestamoByUsuario>();
builder.Services.AddScoped<ICUGetSociosPorTelescopio<UsuarioListadoDto>, GetSociosPorTelescopio>();


// Inyecto caso de uso Equipo
builder.Services.AddScoped<ICUAdd<EquipoAltaDto>, AddEquipo>();
builder.Services.AddScoped<ICUGetAll<EquipoListadoDto>, GetAllEquipos>();
builder.Services.AddScoped<ICUGetById<EquipoListadoDto>, GetEquipoById>();
builder.Services.AddScoped<ICUEdit<EquipoAltaDto>, EditEquipo>();
builder.Services.AddScoped<ICUDeleteEquipo, DeleteEquipo>();
builder.Services.AddScoped<ICUGetDisponibilidadEquipo, GetDisponibilidadEquipo>();

// Inyecto caso de uso ObjetoCeleste
builder.Services.AddScoped<ICUAdd<ObjetoCelesteDto>, AddObjetoCeleste>();
builder.Services.AddScoped<ICUGetAll<ObjetoCelesteDto>, GetAllObjetosCelestes>();
builder.Services.AddScoped<ICUGetById<ObjetoCelesteDto>, GetObjetoCelesteById>();
builder.Services.AddScoped<ICUDelete, DeleteObjetoCeleste>();

// Inyecto caso de uso Observaciones
builder.Services.AddScoped<ICUGetAll<ObservacionDto>, GetAllObservaciones>();
builder.Services.AddScoped<ICUAdd<ObservacionAltaDto>, AddObservacion>();
builder.Services.AddScoped<ICUEvaluacionConIA<EvaluarObservacionDto, EvaluacionIAResponseDto>, CUEvaluarObservacion>();
builder.Services.AddScoped<GetRankingObjetosCelestes>();

// Inyecto caso de uso Auditoria
builder.Services.AddScoped<ICUGetAll<AuditoriaPrestamoMostrarDto>, GetAllAuditoriaPrestamo>();
builder.Services.AddScoped<ICUGetById<AuditoriaPrestamoMostrarDto>, GetAuditoriaPrestamoById>();

//Precarga
builder.Services.AddScoped<SeedData>();

//Context de la base de datos
//builder.Services.AddDbContext<StellarMindsContext>(
//    option => option.UseSqlServer(builder.Configuration.GetConnectionString("StellarMinds"))
//    );


//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "StellarMinds API",
        Description = "API del sistema"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT"
    });
});



builder.Services.AddDbContext<StellarMindsContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddHttpClient();

// Para darle seguridad a la API
// 1. Obtener configuración JWT desde appsettings.json
var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtSettings>(jwtSection);
var jwtSettings = jwtSection.Get<JwtSettings>();
builder.Services.AddSingleton(jwtSettings);
builder.Services.AddScoped<IJwtGenerator<UsuarioListadoDto>, JwtGenerator>();
var key = Encoding.ASCII.GetBytes(jwtSettings.Key);



builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false; // ?? poner en true para producción
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = false,   // podés poner en true si usás Issuer
                      ValidateAudience = false, // podés poner en true si usás Audience
                  };
              }
           );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
        seeder.Run();
    }


}

// Middleware Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
