using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    [Serializable]
    public class Library
    {
        public List<Book> books { get; set; }
        public List<Volume> volumes { get; set; }
        public List<Loan> loans { get; set; }
        public List<Client> clients { get; set; }
        public Library() {
            books = new List<Book>();
            volumes = new List<Volume>();
            loans = new List<Loan>();
            clients = new List<Client>();
        }
        public bool AddVolume(Volume vol)
        {
            if(volumes.Contains(vol)) return false;
            volumes.Add(vol);
            if(!books.Contains(vol.book)) books.Add(vol.book);
            return true;
        }
        public bool lendVolume(int bookCode, Client client)
        {
            Volume volume = getAvaibleVolumeByBookCode(bookCode);
            if(volume == null) return false;
            volumes.Remove(volume);
            loans.Add(new Loan(client, volume));
            return true;
            
        }
        public void newClient(string name)
        {
            clients.Add(new Client(name));
        }
        public Client getClientByCode(int code)
        {
            foreach(Client client in clients)
            {
                if(client.cod == code) return client;
            }
            return null;
        }
        public bool returnVolume(Loan loan)
        {
            if(!loans.Contains(loan)) return false;
            loans.Remove(loan);
            volumes.Add(loan.volume);
            return true;
        }
        public void listBooks()
        {
            StringBuilder sb = new StringBuilder();
            books.ForEach(book =>
            {
                int avaibles = countAvaibleVolumesByBookCode(book.cod);
                int lend = countLendVolumesByBookCode(book.cod);
                sb.AppendLine($"[Código de libro: {book.cod}][Título: {book.title}][Autores: {book.authors.ToArray().ToString()}][Disponibles: {avaibles}][Prestados: {lend}]");
            });
            Console.WriteLine(sb.ToString());
        }
        public void listVolumes()
        {
            StringBuilder sb = new StringBuilder();
            volumes.ForEach(volume =>
            {
                sb.AppendLine($"[Código de libro: {volume.book.cod}][Número de serie de ejemplar: {volume.serialNumber}][Título: {volume.book.title}]");
            });
            Console.WriteLine(sb.ToString());
        }
        public void listLoans()
        {
            StringBuilder sb = new StringBuilder();
            loans.ForEach(loan =>
            {
                sb.AppendLine($"[Código de préstamo: {loan.cod}][Código de libro: {loan.volume.book.cod}][Número de serie de ejemplar: {loan.volume.serialNumber}][Título: {loan.volume.book.title}][Código de cliente: {loan.client.cod}][Nombre de Cliente: {loan.client.name}]");
            });
            Console.WriteLine(sb.ToString());
        }
        public void listClients()
        {
            StringBuilder sb = new StringBuilder();
            clients.ForEach(client =>
            {
                sb.AppendLine($"[Código de cliente: {client.cod}][Nombre de cliente: {client.name}]");
            });
            Console.WriteLine(sb.ToString());
        }
        public Volume getAvaibleVolumeByBookCode(int bookCode)
        {
            foreach (Volume vol in volumes)
            {
                if (vol.book.cod == bookCode) return vol;
            }
            return null;
        }
        public Loan getLoanByCode(int loanCode)
        {
            foreach(Loan loan in loans)
            {
                if(loan.cod == loanCode) return loan;
            }
            return null;
        }
        public int countAvaibleVolumesByBookCode(int bookCode)
        {
            int count = 0;
            volumes.ForEach(volume =>
            {
                if(volume.book.cod == bookCode) count++;
            });
            return count;
        }
        public int countLendVolumesByBookCode(int bookCode)
        {
            int count = 0;
            loans.ForEach(loan =>
            {
                if (loan.volume.book.cod == bookCode) count++;
            });
            return count;
        }
    }
}
