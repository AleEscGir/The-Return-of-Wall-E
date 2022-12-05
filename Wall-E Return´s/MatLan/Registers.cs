using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public class Registers
    {
        private int[] registers; //Este es el array donde se guardan los registros

        public Registers() //Nuestro constructor está vacío puesto que lo único que tenemos es el array con las 27 letras
        {
            this.registers = new int[27];
        }

        public void AddRegister(int number, int pos) //Podemos añadir un número a los registro mediante un pos
        {
            if (pos < 0 || pos > 27)
                throw new InvalidOperationException("Índice fuera del Registro (Tamaño 27)");
            this.registers[pos] = number; //Colocamos lo que nos dan en el registro
        }

        public int RemoveRegister(int pos) //También podemos sacar un número del registro mediante el pos
        {
            if (pos < 0 || pos > 27)
                throw new InvalidOperationException("Índice fuera del Registro (Tamaño 27)");
            return registers[pos]; //Devolvemos lo que está en el registro
        }

        public int[] RegisterList() //Mediante esta propiedad podemos obtener una copia del array que está por detrás del registro
        {
            int[] a = new int[27];
            for(int i = 0; i < 27; i++)
            {
                a[i] = this.registers[i];
            }
            return a;
        }
    }
}
