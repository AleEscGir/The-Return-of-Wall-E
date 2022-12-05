using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Obstacle : AllObject //Aquí tenemos todos los objetos, diferentes de robots
    {
        public Simuland simufield { get; private set; }
        public Position position { get; protected set; }
        public Obstacle(Shape shape, Size size, Color color, int code, Simuland simufield, Position position) : base(shape, size, color, code) //Los obstáculos heredan todas sus características de AllObjects
        {
            this.simufield = simufield;
            this.position = position;
        }

        public abstract void Moveby(Direction direction); //Los objetos deben poder ser movidos por robots

        public void AddSimuland(Simuland a)//Mediante este método podemos añadirle a un objeto un simufield únicamente si no lo tiene
        {
            if (this.simufield == null)
                this.simufield = a;
        }

        public void AddPosition(Position a)//Mediante este método podemos añadirle a un objeto un position únicamente si no lo tiene
        {
            if (this.position == null)
                this.position = a;
        }
    }
}