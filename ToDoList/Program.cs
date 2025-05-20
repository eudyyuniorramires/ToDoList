using Microsoft.EntityFrameworkCore;
using ToDoList.AppDbContext;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using System.Text;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // Registrar Servicios

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configurar CORS
            builder.Services.AddCors(opciones =>
            {
                var frontedURL = builder.Configuration.GetValue<string>("FrontendURL");

                opciones.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontedURL).AllowAnyMethod().AllowAnyHeader();
                });
            });

            // Configurar autenticación con JWT
            var Expires = DateTime.UtcNow.AddHours(1); // Duración del token: 1 hora
            var key = builder.Configuration["Jwt:Key"];
            var issuer = builder.Configuration["Jwt:Issuer"];
            var audience = builder.Configuration["Jwt:Audience"];

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
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

            // Aplicar la política de CORS
            app.UseCors();

            // Agregar autenticación y autorización
            app.UseAuthentication();  // Importante: Agregar antes de UseAuthorization()
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
