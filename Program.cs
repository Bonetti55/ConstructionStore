using ConstructionStore.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ConstructionDb>(options => options.UseInMemoryDatabase("items"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ConstructionStore API",
        Description = "Это простой строительный магазинчик",
        Version = "v1"
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConstructionStore API V1");
    });
}

app.UseHttpsRedirection();

app.MapGet("/constructions/{id:int}",ConstructionStore.ConstructionDB.GetConstruction);
app.MapGet("/constructions", ConstructionStore.ConstructionDB.GetConstructions);
app.MapPost("/constructions", ConstructionStore.ConstructionDB.CreateConstruction);
app.MapPut("/constructions", ConstructionStore.ConstructionDB.UpdateConstruction);
app.MapDelete("/constructions{id:int}", ConstructionStore.ConstructionDB.RemoveCostruction);

// app.MapGet("/constructions", async (ConstructionDb db) => await db.Constructions.ToListAsync());
// app.MapPost("/construction", async (ConstructionDb db, Construction construction) =>
// {
//     await db.Constructions.AddAsync(construction);
//     await db.SaveChangesAsync();
//     return Results.Created($"/construction/{construction.Id}", construction);
// });


app.Run();