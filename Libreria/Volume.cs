using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [Serializable]
    public class Volume
    {
        public int serialNumber {  get; set; }
        public Book book { get; set; }
        private Volume(Book book, int serialNumber)
        {
            this.book = book;
            this.serialNumber = serialNumber;
        }
        private Volume() { }
        public static Volume newVolume(Book book)
        {
            return new Volume(book, book.totalVolumes++);
        }
    }
}
