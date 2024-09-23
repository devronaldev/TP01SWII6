using TP01SWII6.Models;

namespace TP01SWII6.Repository
{
    public class RepositoryBooks
    {
        private static readonly string nameFile = @"C:\dev\TP01SWII6\TP01SWII6\Repository\Books.csv";

        //CLASSE QUE DEFINE OS LIVROS; CLASSE QUE ACHA O LIVRO CERTO;
        public static void Testar() {
            Book livro = new Book
            {
                Authors[0] = new Author { };
            };
        }
    } 
}
