using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [Serializable]
    public class Loan
    {
        public static int numLoansCreated { get; set; } = 0;
        public Volume volume { get; set; }
        public Client client { get; set; }
        public DateTime date {  get; set; }
        public int cod { get; set; }
        public Loan(Client client, Volume volume)
        {
            this.volume = volume;
            this.client = client;
            this.date = DateTime.Now;
            cod = numLoansCreated++;
        }
        public Loan() { }
    }
}
