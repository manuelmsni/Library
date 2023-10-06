using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [Serializable]
    public class Client
    {
        public static int numClientsCreated { get; set; } = 0;
        public string name {  get; set; }
        public int cod { get; set; }
        public Client(string name) {
            this.name = name;
            cod = numClientsCreated++;
        }
        public Client() { }
    }
}
