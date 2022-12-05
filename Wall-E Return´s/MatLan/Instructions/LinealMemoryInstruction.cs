using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class LinealMemoryInstruction : Instruction
    {//Estas son las instrucciones que modifican la memoria lineal de robot
        
        public LinealMemoryInstruction(Robot robot, Matlanland matfield) : base(robot, matfield)
        {           
        }
    }

    public class GetAt : LinealMemoryInstruction
    {
        public GetAt(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 33;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 0) //Si no podemos extraer un valor de la pila, lanzamos la excepción
                throw new Exception("Pila Vacía. GetAt no puede ser ejecutado");
            int pos = robot.stack.Pop(); //Extraemos de la pila el índice del número que vamos a colocar en la pila... que trabalenguas
            this.robot.stack.Push(robot.LinealMemory[pos]); //Simplemente colocamos el valor
        }
        public override Instruction Clone()
        {
            return new GetAt(null, null);
        }
    }

    public class SetAt : LinealMemoryInstruction
    {
        public SetAt(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 34;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count < 2) //Si tenemos menos de dos valores en la pila, no podemos ejecutar la instrucción
                throw new Exception("Pila insuficiente. SetAt no puede ser ejecutado");
            int pos = robot.stack.Pop(); //Extraemos de la pila el índice de la memoria lineal en el que vamos a colocar un número
            int number = robot.stack.Pop(); //Extraemos de la pila el valor que vamos a colocar en la memoria lineal
            this.robot.LinealMemory[pos] = number; //Colocamos el valor en la memoria lineal
            if (!(this.robot.LinealMemoryIndex.Contains(pos))) //Antes que nada debemos revisar si la posición ya está para no repetirla, en caso de no estar continuamos
            this.robot.LinealMemoryIndex.Add(pos); //Añadimos a la lista de index de la memoria lineal la posición en la que fue puesta el registro
            this.robot.LinealMemoryIndex.Sort();//Luego ordenamos esos valores
        }

        public override Instruction Clone()
        {
            return new SetAt(null, null);
        }
    }
}
