using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public class Position
    { //Esta clase está hecha para conocer la posición de un objeto en el SimuLand o del flujo en el MatLand
        public int fill { get; private set; }
        public int column { get; private set; }

        public Position(int fill, int column)
        {
            this.fill = fill;
            this.column = column;
        }

        public static Position operator +(Position a, Direction b) //Mediante los operadores de suma y resta podemos avanzar o retroceder nuestro Posición mediante una dirección
        {
            a.fill = a.fill + b.X;//Simplemente a las filas y columnas de a le sumamos el X e Y de b
            a.column = a.column + b.Y;
            return a;//Devolvemos a para no perder su referencia
        }

        public static Position operator -(Position a, Direction b)
        {
            a.fill = a.fill - b.X;
            a.column = a.column - b.Y;
            return a;
        }
    }
}
