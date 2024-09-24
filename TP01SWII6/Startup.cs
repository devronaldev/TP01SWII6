using System.Text;
using TP01SWII6.Models;
using TP01SWII6.Repository;

/* AUTORES:
 Nome: Ronald Pereira Evangelista
 Prontuário: CB3020282
 
 Nome: Ketheleen Cristine Simão dos Santos
 Prontuário: CB3011836
 */

namespace TP01SWII6
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(Roteamento);
        }

        private static Book livro = RepositoryBooks.BuscarLivro("A Guerra dos Tronos");
        public async Task GetNome(HttpContext context)
        {
            await context.Response.WriteAsync(livro.Name);
        }

        public async Task GetToString(HttpContext context)
        {
            await context.Response.WriteAsync(livro.ToString());
        }

        public async Task GetAuthorNames(HttpContext context)
        {
            await context.Response.WriteAsync(livro.GetAuthorNames());
        }

        public async Task GetHTML(HttpContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"<p>Nome: {livro.Name}</p>");
            
            var authors = livro.GetAuthorNames().Split(",");
            stringBuilder.AppendLine("<p> AUTORES </p>");
            foreach ( var author in authors)
            {
                stringBuilder.AppendLine($"<p> {author} </p>");
            }

            await context.Response.WriteAsync(stringBuilder.ToString());
        }

        public Task Roteamento(HttpContext context)
        {
            var Rotas = new Dictionary<string, RequestDelegate>
            {
                {"/Books/GetNome", GetNome},
                {"/Books/GetToString", GetToString},
                {"/Books/GetAuthorsName", GetAuthorNames},
                {"/livro/ApresentarLivro", GetHTML}
            };

            if (Rotas.ContainsKey(context.Request.Path))
            {
                var metodo = Rotas[context.Request.Path];
                return metodo.Invoke(context);
            }
            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho Inexistente.");
        }
    }
}
