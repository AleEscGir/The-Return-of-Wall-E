using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class RoutineInstruction : Instruction
    {//Estas instrucciones son las que permiten el llamado a otros métodos y la recursividad
        public RoutineInstruction(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
        }

        public abstract void DebugExecute(); //Específicamente los comandos de routine necesitan tner
        //separados el Execute normal de uno que sirve para debuguear, puesto que en ambos casos ocurren cosas distintas
        //En el DebugExecute no tenemos que llamar a la próxima rutina
    }

    public class Call : RoutineInstruction
    {//Esta instrucción llama al matland en la posición que nos de la pila
        public Call(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 51;
        }

        public override void Execute()
        {
            if (this.robot.recursivity.Count == 1000000) //Primero revisamos que no hayan sido abiertas más de 1000000 rutinas
                throw new Exception("Pila sobrecargada. Ha abierto más de 1000000 rutinas, Instrucción Llamada no puede ser ejecutada");
            int a = this.robot.stack.Pop(); //Luego revisamos que se esté dentro de los límites de la lista de rutinas
            if (a > this.robot.runtimes.Count - 1 || a < 0)
                throw new Exception("Ha llamado a una rutina que no existe, Instrucción Llamada no puede ser ejecutada");
            this.robot.recursivity.Push(this.robot.runtimes[a].Clone()); //Aunque esté complicado, básicamente ponemos en recursivity un clon del matlanland del runtime que esté en la posición que nos diga la pila
        }
        public override void DebugExecute() //El string en sí no hace nada, solo sirve como identificador
        {
            if (this.robot.recursivity.Count == 1000000) //Primero revisamos que no hayan sido abiertas más de 1000000 rutinas
                throw new Exception("Pila sobrecargada. Ha abierto más de 1000000 rutinas, Instrucción Llamada no puede ser ejecutada");
            int a = this.robot.stack.Pop(); //Luego revisamos que se esté dentro de los límites de la lista de rutinas
            if (a > this.robot.runtimes.Count - 1 || a < 0)
                throw new Exception("Ha llamado a una rutina que no existe, Instrucción Llamada no puede ser ejecutada");
            this.robot.recursivity.Push(this.robot.runtimes[a].Clone()); //Aunque esté complicado, básicamente ponemos en recursivity un clon del matlanland del runtime que esté en la posición que nos diga la pila
        }
        public override Instruction Clone()
        {
            return new Call(null, null);
        }
    }

    public class Routine : RoutineInstruction
    {//Simplemente apilamos el number de la rutina que estamos ejecutando
        public Routine(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 53;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha colocado más de 1000000 en ella. Instrucción Rutina no puede ser ejecutada");
            this.robot.stack.Push(this.matfield.number); //O sea, eso, apilamos el valor...
        }

        public override void DebugExecute()
        {
            this.Execute(); //El comando Routine no hace nada diferente, así que llama al anterior
        }
        public override Instruction Clone()
        {
            return new Routine(null, null);
        }
    }

    public class ReCall : RoutineInstruction
    {
        public ReCall(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 52;
        }

        public override void Execute()
        {//La recursividad simplemente coloca en la pila y ejecuta el mismo matlanland en el que nos encontramos
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha colocado más de 1000000 en ella. Instrucción Re-LLamada no puede ser ejecutada");
            if (this.robot.recursivity.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha abierto más de 1000000 rutinas, Instrucción Re-Llamada no puede ser ejecutada");
            this.robot.recursivity.Push(this.robot.runtimes[this.matfield.number].Clone());
        }

        public override void DebugExecute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha colocado más de 1000000 en ella. Instrucción Re-LLamada no puede ser ejecutada");
            if (this.robot.recursivity.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha abierto más de 1000000 rutinas, Instrucción Re-Llamada no puede ser ejecutada");
            this.robot.recursivity.Push(this.robot.runtimes[this.matfield.number].Clone());
        }

        public override Instruction Clone()
        {
            return new ReCall(null, null);
        }
    }
}
