using ApiCoreCrudDepartamentos.Data;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<RepositoryDepartamentos>();
string connectionString = builder.Configuration.GetConnectionString("SqlHospitales");
builder.Services.AddDbContext<DepartamentosContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options=>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hoy es el día",
        Description = "Api de departamentos",
        Version ="v1"

    });
}
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Crud Champions v1");
    options.RoutePrefix = "";
});
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
