using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Libreria
{
    public class Vista
    {
        public Vista() {
        }
        public int Menu()
        {
            Console.Write(
                "      - Librería -\n" +
                "0 - Salir\n" +
                "1 - Registrar cliente\n" +
                "2 - Registrar libro\n" +
                "3 - Registrar volumen\n" +
                "4 - Registrar reserva\n" +
                "5 - Gestionar devolución\n" +
                "6 - Listar clientes\n" +
                "7 - Listar libros\n" +
                "8 - Listar volumenes\n" +
                "9 - Listar reservas\n"
                );

            return AskForIntRange("Elige una opción:", 0, 9);
        }
        public int AskForIntRange(string mensaje, int minIncluded, int maxIncluded)
        {
            int response;
            bool isInRange = false;
            do
            {
                response = AskForInt(mensaje);
                isInRange = minIncluded <= response && response <= maxIncluded;
                if (!isInRange) Console.WriteLine($"El número seleccionado no está en el rango [{minIncluded}, {maxIncluded}], introduce un número en el rango, límites incluidos:");
            } while (!isInRange);
            return response;
        }
        public int AskForInt(string mensaje)
        {
            string response;
            bool isInt = false;
            do
            {
                response = AskForString(mensaje);
                isInt = Regex.IsMatch(response, @"^-?\d+$");
                if (!isInt) Console.WriteLine("Has de introducir un entero:");
            } while (!isInt);
            return int.Parse(response);
        }
        public bool AskForBool(String mensaje)
        {
            string response;
            bool invalidResponse = true;
            do
            {
                invalidResponse = false;
                response = AskForString(mensaje);
                if (response.Equals("si", StringComparison.OrdinalIgnoreCase)) return true;
                else if (response.Equals("no", StringComparison.OrdinalIgnoreCase)) return false;
                else invalidResponse = true;
                if(invalidResponse) Console.WriteLine("Has de introducir Si / No:");
            } while (invalidResponse);
            return false;
        }
        public string AskForString(String mensaje)
        {
            Console.WriteLine(mensaje);
            return AskForString();
        }
        public string AskForString()
        {
            string output = "";
            bool empty = true;
            do
            {
                output = Console.ReadLine().Trim().Replace("\r", "").Replace("\n", "");
                empty = output.Length == 0;
                if (empty) Console.WriteLine("No has introducido nada, introduce el dato solicitado:");
            } while (empty);
            return output;
        }
    }
}
