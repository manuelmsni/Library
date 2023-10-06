using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Controlador
    {
        public Vista v;
        public Modelo m;

        public Controlador()
        {
            v = new Vista();
            m = new Modelo();
            programLoop();
        }
        private void programLoop()
        {
            bool doAnotherCycle = true;
            do
            {
                doAnotherCycle = Menu();
            } while (doAnotherCycle);
        }
        private bool Menu()
        {
            switch (v.Menu())
            {
                case 0:
                    return false; // Salir del programa
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:
                    m.library.listClients();
                    break;
                case 7:
                    m.library.listBooks();
                    break;
                case 8:
                    m.library.listVolumes();
                    break;
                case 9:
                    m.library.listLoans();
                    break;
                default:
                    Console.WriteLine("No he una opción válida.");
                    return true; // Reiniciar el menú
            }
            m.saveData();
            return !v.AskForBool("¿Deseas salir del programa? Escribe si / no:");
        }
    }
}
