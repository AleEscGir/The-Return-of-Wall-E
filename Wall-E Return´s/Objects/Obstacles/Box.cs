using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public class Box : Obstacle
    {
        public Box(Shape shape, Size size, Color color, int code, Simuland simufield, Position position) : base(new BoxForm(), size, color, code, simufield, position)
        {
            //Las cajas son un tipo de obstáculos que cumplen que pueden ser movidas las pequeñas y las medianas, pero no las grandes
        }

        public override bool CanMove(Direction direction)
        {
            if (this.size.Number == 3) //Si es una caja grande retorna inmediatamente false
                return false;
            else //en otro caso, la caja es mediana o pequeña, o sea, puede ser movida
            {//Básicamente, si la caja está en un borde o tiene un objeto al lado, no puede ser movida
                if (this.position.fill + direction.X < 0 || this.position.fill + direction.X >= this.simufield.fills || this.position.column + direction.Y < 0 || this.position.column + direction.Y >= this.simufield.columns || this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] != null)
                    return false;
                else
                    return true;
            }
        }

        public override void Moveby(Direction direction) //Mediante este método el objeto puede ser movido por otro objeto
        {//Este método solo será activado cuando haya dado true el CanMove, por tanto, será posible movernos
            this.position = this.position + direction; //actualizamos las posiciones y continuamos
            this.simufield.simufield[this.position.fill, this.position.column] = this; //Nos copiamos a la posición nueva
            this.simufield.simufield[this.position.fill - direction.X, this.position.column - direction.Y] = null; //Nos borramos de la posición anterior
        }

        public override AllObject Clone() //Este clonador sirve para copiar un objeto sin las referencias
        {
            return new Box(this.shape, this.size, this.color, this.code, null, null); //Devolvemos la caja
        }
    }
}

