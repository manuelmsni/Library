using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [Serializable]
    public class Author
    {
        public static int numAuthorsCreated { get; set; } = 0;
        public string name { get; set; }
        public int cod { get; set; }
        public Author(String name)
        {
            this.name = name;
            cod = numAuthorsCreated++;
        }
        public Author() { }
    }
}
