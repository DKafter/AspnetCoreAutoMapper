using System.Reflection;
using dotnetautomapper.Data;
using dotnetautomapper.Interfaces;
using dotnetautomapper.Interfaces.Customer;
using dotnetautomapper.Models.Customer;
using dotnetautomapper.Profiles.Customer;
using dotnetautomapper.Repositories.Customer;
using dotnetautomapper.Repositories.Customer.Customer;
using dotnetautomapper.Validators.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BaseDbContext>(op =>
{
    op.UseSqlite(builder.Configuration["DefaultConnection:ConnectionString"]);
});
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddTransient<IBaseRepository<CustomerBaseModel>, BaseRepository<CustomerBaseModel>>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ExceptionFluentValidateMiddleware>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CustomerProfile>();
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionFluentValidateMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();
