using System.Text;

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

        public Book() 
        {

        }
        public Book(string name, Author[] authors, double price) 
        { 
            Name = name; 
            Price = price; 
            Authors = authors;
        }

        override public string ToString()
        {
            StringBuilder answer = new StringBuilder();
            answer.Append($"Book[name={Name},authors=");
            foreach (var author in Authors)
            {
                answer.Append("{Author[");
                answer.Append($"name={author.Name},");
                answer.Append($"email={author.Email},");
                answer.Append($"gender={author.Gender}]");
            }
            answer.Append($"price={Price},{Qty}]");
            return answer.ToString();
        }

        public string GetAuthorNames()
        {
            StringBuilder answer = new StringBuilder();
            foreach (var author in Authors)
            {
                answer.Append($"{author.Name},");
   
            }
            answer.Remove(answer.Length - 1, 1);
            return answer.ToString();
        }
    }
}
