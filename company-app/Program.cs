using company_app.Data;
using company_app.GrapghQL;
using company_app.Repositories;
using company_app.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register db context
string? connectionString = builder.Configuration.GetConnectionString("MySQLConnect");
builder.Services.AddDbContext<CompanyContext>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient);

// register repository layer
builder.Services.AddScoped<EmployeeRepository>();

// register service layer
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// register graphQL server
builder.Services.AddGraphQLServer().AddQueryType<EmployeeQuery>().AddMutationType<EmployeeMutation>().AddMutationConventions(true);

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

// add graphQL
app.MapGraphQL();

app.Run();
