using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public class Sphere : Obstacle
    {
        public Sphere(Shape shape, Size size, Color color, int code, Simuland simufield, Position position) : base(new SphereForm(), size, color, code, simufield, position)
        {
            //Las esferas son un tipo de obstáculos que cumplen que pueden ser movidas si detrás de ellas solo hay otras esferas
        }

        public override bool CanMove(Direction direction)
        {
            //A una bola debes preguntarle si está en un extremo, luego si en la posición
            //adyacente no hay nada, luego si es un esfera u otro objeto, y en caso de ser una esfera, preguntarle a esta última si puede moverse... comencemos...
            if (this.position.fill + direction.X < 0 || this.position.fill + direction.X >= this.simufield.fills || this.position.column + direction.Y < 0 || this.position.column + direction.Y >= this.simufield.columns)
                return false;
            else
            {
                if (this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] == null)
                    return true;
                else
                {
                    if (this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] is Sphere && ((Sphere)this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y]).Size.Number != 3)
                        return ((Sphere)this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y]).CanMove(direction);
                    else
                        return false;
                }
            }
        }

        public override void Moveby(Direction direction) //Mediante esta propiedad pueden ser movidas las esferas
        {//La única diferencia con el Moveby de las cajas es que debemos mover la esfera delante nuestro
           if (this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] != null) //Si hay un objeto delante, la única posibilidad es que sea otra esfera, entonces, la movemos primero
                ((Obstacle)this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y]).Moveby(direction);
            this.position = this.position + direction; //actualizamos la posición
            this.simufield.simufield[this.position.fill, this.position.column] = this; //Nos copiamos a la posición nueva
            this.simufield.simufield[this.position.fill - direction.X, this.position.column - direction.Y] = null; //Nos borramos de la posición anterior
        }

        public override AllObject Clone() //Este clonador sirve para copiar un objeto sin las referencias
        {
            return new Sphere(this.shape, this.size, this.color, this.code, null, null);//Devolvemos la esfera
        }
    }
}
