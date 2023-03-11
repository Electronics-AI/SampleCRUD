using Task5_CRUD.Infrastructure.Repositories;
using Task5_CRUD.Domain.Interfaces;
using Task5_CRUD.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<CrudContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("CrudDbConnectionString")));

builder.Services.AddScoped<IDrillBlockRepository, DrillBlockRepository>();
builder.Services.AddScoped<IDrillBlockPointSetRepository, DrillBlockPointSetRepository>();
builder.Services.AddScoped<IHoleRepository, HoleRepository>();
builder.Services.AddScoped<IHolePointSetRepository, HolePointSetRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
