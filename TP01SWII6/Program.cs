using TP01SWII6.Repository;

/* AUTORES:
 Nome: Ronald Pereira Evangelista
 Prontu�rio: CB3020282
 
 Nome: Kethellen Cristine Sim�o dos Santos
 Prontu�rio: CB3011836
 */

var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
RepositoryBooks.Testar();
var livro = RepositoryBooks.BuscarLivro("O Hobbit");
if (livro != null)
{
    Console.WriteLine(livro.ToString());
}
else
{
    Console.WriteLine("Livro n�o encontrado");
}
app.Run();
