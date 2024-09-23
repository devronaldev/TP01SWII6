using TP01SWII6.Models;

namespace TP01SWII6.Repository
{
    public class RepositoryBooks
    {
        private static readonly string nameFile = @"C:\dev\TP01SWII6\TP01SWII6\Repository\Books.csv";

        //METÓDO QUE TESTA A CLASSE BOOK E AUTHOR
        public static void Testar() {
            //TESTANDO TODOS OS MÉTODOS DA CLASSE LIVRO EXCETO CONSTRUTORES
            Book livro = new Book
            {
                Authors = new Author[]
                {
                    new Author
                    {
                        Name = "Ronald Pereira Evangelista",
                        Email = "Ronald.Evangelista@gmail.com",
                        Gender = 'M'
                    },
                    new Author
                    {
                        Name = "Ketheleen Cristine Simão dos Santos",
                        Email = "Kethellen.Cristine@gmail.com",
                        Gender = 'F'
                    }
                },
                Name = "Testando construtor vazio",
                Qty = 125,
                Price = 45.25
            };

            Console.WriteLine(livro.ToString());
            Console.WriteLine(livro.GetAuthorNames());

            //TESTANDO METÓDOS CONSTRUTORES

            Book livro2 = new Book
                (
                    "Testando construtor 2",
                    new Author[]
                    {
                        new Author
                        {
                            Name = "Ronald Pereira Evangelista",
                            Email = "Ronald.Evangelista@gmail.com",
                            Gender = 'M'
                        },
                        new Author
                        {
                            Name = "Ketheleen Cristine Simão dos Santos",
                            Email = "Kethellen.Cristine@gmail.com",
                            Gender = 'F'
                        }
                    },
                    50.25,
                    35
                );

            Console.WriteLine(livro2.ToString());
            Console.WriteLine(livro2.GetAuthorNames());

            Book livro3 = new Book
                (
                    "Testando construtor 3",
                    new Author[]
                    {
                        new Author
                        {
                            Name = "Ronald Pereira Evangelista",
                            Email = "Ronald.Evangelista@gmail.com",
                            Gender = 'M'
                        },
                        new Author
                        {
                            Name = "Ketheleen Cristine Simão dos Santos",
                            Email = "Kethellen.Cristine@gmail.com",
                            Gender = 'F'
                        }
                    },
                    50.25
                );

            Console.WriteLine(livro3.ToString());
            Console.WriteLine(livro3.GetAuthorNames());
        }

        public static Book BuscarLivro(string name)
        {
            Book livro = new Book();
            using (var file = File.OpenText(nameFile)) 
            {
                while (!file.EndOfStream)
                {
                    //REALIZAR LEITURA DA LINHA
                    var textoLivro = file.ReadLine();
                    
                    //VERIFICA SE EXISTE INFORMAÇÃO NA LINHA. CASO NÃO, PULA O LOOP WHILE
                    if (string.IsNullOrEmpty(textoLivro))
                    {
                        continue;
                    }

                    //SEPARA AS INFORMAÇÕES DO LIVRO
                    var infoLivro = textoLivro.Split(';');
                    
                    //VERIFICA SE O NOME DO LIVRO É IGUAL AO PROCURADO
                    if (infoLivro[0].Equals(name))
                    {
                        //SEPARA DEVIDAMENTE AS INFORMAÇÕES DO LIVRO E DOS AUTORES CORRETAMENTE
                        livro.Name = infoLivro[0];
                        livro.Price = double.Parse(infoLivro[1]);
                        livro.Qty = int.Parse(infoLivro[2]);
                        string[] authors = infoLivro[3].Split('/');
                        foreach (var item in authors)
                        {
                            var infoAuthor = item.Split(',');
                            Author author = new Author()
                            {
                                Name = infoAuthor[0],
                                Email = infoAuthor[1],
                                Gender = char.Parse(infoAuthor[2])
                            };
                            livro.Authors.Append(author);
                        }

                        //APÓS TER O OBJETO COMPLETO ELE SAI DO LOOP WHILE
                        continue;
                    }
                }
            }

            return livro;
        }
    } 
}
