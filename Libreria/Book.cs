using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [Serializable]
    public class Book
    {
        public static int numBooksCreated { get; set; } = 0;
        public List<Author> authors { get; set; }
        public string title { get; set; }
        public int totalVolumes { get; set; }
        public int cod {  get; set; }
        public Book(String title, Author[] authors) {
            this.authors = new List<Author>();
            this.title = title;
            authors.ToList().ForEach(author => { 
                this.authors.Add(author);
            });
            totalVolumes = 0;
            cod = numBooksCreated++;
        }
        public Book() { }
        public Volume newVolume()
        {
            return Volume.newVolume(this);
        }
    }
}