using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppContext>(opt => opt.UseInMemoryDatabase("TarefasDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/tarefa", async (AppContext db) => await db.Tarefas.ToListAsync());

app.MapGet("/tarefas/{id}", async (int id, AppContext db) =>
    await db.Tarefas.FindAsync(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound());

app.MapGet("/tarefas/concluida", async (AppContext db) =>
    await db.Tarefas.Where(t => t.IsConcluida == true).ToListAsync());

app.MapPost("/tarefas", async (Tarefa tarefa, AppContext db) =>
{
    db.Tarefas.Add(tarefa);
    await db.SaveChangesAsync();
    return Results.Created($"/Tarefas/{tarefa.Id}", tarefa);
});

app.MapPut("/tarefas/{id}", async (int id, Tarefa inputTarefa, AppContext db) =>
{
    var tarefa = await db.Tarefas.FindAsync(id);

    if (tarefa is null)
    {
        return Results.NotFound();
    }
    tarefa.Nome = inputTarefa.Nome;
    tarefa.IsConcluida = inputTarefa.IsConcluida;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/tarefas/{id}", async (int id, AppContext db) =>
{
    if (await db.Tarefas.FindAsync(id) is Tarefa tarefa)
    {
        db.Tarefas.Remove(tarefa);
        await db.SaveChangesAsync();
        return Results.Ok(tarefa);
    }
    return Results.NotFound();
});
app.Run();

class Tarefa
{
    [JsonIgnore]
    public int Id { get; set; }

    public string? Nome { get; set; }

    public bool IsConcluida { get; set; }

}


//usando EF in Memory
class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> opitions) : base(opitions)
    {

    }

    public DbSet<Tarefa> Tarefas => Set<Tarefa>();
}