using System.Text;

/* AUTORES:
 Nome: Ronald Pereira Evangelista
 Prontuário: CB3020282
 
 Nome: Ketheleen Cristine Simão dos Santos
 Prontuário: CB3011836
 */

namespace TP01SWII6.Models
{
    public class Book
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Author[] Authors { get; set; }
        public int Qty { get; set; }

        public Book(string name, Author[] authors, double price, int qty) 
        {
            Name = name;
            Price = price;
            Authors = authors;
            Qty = qty;
        }
        public Book(string name, Author[] authors, double price) 
        { 
            Name = name; 
            Price = price; 
            Authors = authors;
        }
        public Book() 
        {
            Authors = new Author[0];
        }

        override public string ToString()
        {
            StringBuilder answer = new StringBuilder();
            answer.Append($"Book[name={Name},authors=");
            answer.Append("{");
            foreach (var author in Authors)
            {
                answer.Append("Author[");
                answer.Append($"name={author.Name},");
                answer.Append($"email={author.Email},");
                answer.Append($"gender={author.Gender}]");
            }
            answer.Append("}");
            answer.Append($"price={Price},qty={Qty}]");
            return answer.ToString();
        }

        public string GetAuthorNames()
        {
            StringBuilder answer = new StringBuilder();
            foreach (var author in Authors)
            {
                answer.Append($"{author.Name}, ");
   
            }
            answer.Remove(answer.Length - 2, 2);
            return answer.ToString();
        }
    }
}
