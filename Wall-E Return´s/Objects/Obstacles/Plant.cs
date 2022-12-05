using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public class Plant : Obstacle
    {
        public Plant(Shape shape, Size size, Color color, int code, Simuland simufield, Position position) : base(new PlantForm(), size, color, code, simufield, position)
        {
            //Las plantas son un tipo de obstáculos que cumplen que no pueden ser movidas
        }

        public override bool CanMove(Direction direction)
        {
            return false;
        }

        public override void Moveby(Direction direction)
        {
            return;
        }
        public override AllObject Clone() //Este clonador sirve para copiar un objeto sin las referencias
        {
            return new Plant(this.shape, this.size, this.color, this.code, null, null); //Devolvemos la planta
        }
    }
}
