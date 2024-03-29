using EmartProd.Application.Interfaces;
using EmartProd.Infrastructure.EmartContext;
using EmartProd.Infrastructure.Repositories;
using EmartProd.Infrastructure.SeedFile;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmartProdDbContext>(opt=>{
    opt.UseSqlite(builder.Configuration.GetConnectionString("EmartProdConnection"));
});
builder.Services.AddScoped<IProductRepository,ProductRepository>();

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

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context  = services.GetRequiredService<EmartProdDbContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try{
    await context.Database.MigrateAsync();
    await EmartProdContextSeed.SeedAppDataAysnc(context);
}catch(Exception ex){
   logger.LogError(ex,"Error while applying migrations!!!");
}

app.Run();
