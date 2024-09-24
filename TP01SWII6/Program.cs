using TP01SWII6;
using TP01SWII6.Repository;

/* AUTORES:
 Nome: Ronald Pereira Evangelista
 Prontu�rio: CB3020282
 
 Nome: Ketheleen Cristine Sim�o dos�Santos
 Prontu�rio: CB3011836
 */

IWebHost host = new WebHostBuilder().UseKestrel().UseStartup<Startup>().Build();
host.Run();

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Configure the HTTP request pipeline.
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