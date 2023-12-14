using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// o Start SWAGGER. =================================================================================>>>
builder.Services.AddSwaggerGen(sg => {
    // Swagger -> JWT section.
    sg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authotization",
        Type = SecuritySchemeType.Http,//ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Here Enter JWT with bearer format lie Bearer {token}"
    });
    // Agrega el esquema de seguridad Bearer a nivel global
    sg.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });

});
// _ End SWAGGER.


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
