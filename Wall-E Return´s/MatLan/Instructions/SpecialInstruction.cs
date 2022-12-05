using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class SpecialInstruction : Instruction
    {
        public SpecialInstruction(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Los SpecialInstruction son las instrucciones de start, return y print
        }
    }

    public class Start : SpecialInstruction
    {
        public Start(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Esta instrucción es la que indica el inicio de la ejecución del matfield 
            this.number = 5;
        }

        public override void Execute()
        {//La instrucción Start reinicia el flujo
            this.matfield.ChangeFlow(new Sourth());
        }

        public override Instruction Clone()
        {
            return new Start(null, null);
        }
    }

    public class Return : SpecialInstruction
    {
        public Return(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//El return no hace nada interesante puesto que la función de return está recogida en el MatLan
            this.number = 6;
        }

        public override void Execute()
        {
            return;
        }
        public override Instruction Clone()
        {
            return new Return(null, null);
        }
    }

    public class Print : SpecialInstruction
    {
        public Print(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Esta instrucción básicamente se usa en la parte gráfica 
            this.number = 54;
        }

        public override void Execute()
        {
            if(this.robot.stack.Count == 0)
                throw new Exception("Pila vacía. Instrucción Imprimir no puede ser ejecutada");
            EnglishSpanishTraductor traductor = new EnglishSpanishTraductor(); //Llamamos a una instancia del traductor, para poder colocar las características del robot
            traductor.AgregateColorsDefaultWords(); //Le agregamos todas las palabras que conocemos
            this.robot.StringChanger("Robot " + traductor.Traduce(this.robot.color.Name) + " N." + this.robot.code.ToString() + " ha imprimido " + this.robot.stack.Pop().ToString());
        }
        public override Instruction Clone()
        {
            return new Print(null, null);
        }
    }
}
