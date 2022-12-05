using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Registry : Instruction
    {
        public int letter { get; protected set; }
        public Registry(Robot robot, Matlanland matfield, char letter) : base(robot, matfield)
        {//La clase en general
            if (letter != 'a' && letter != 'b' && letter != 'c' && letter != 'd' && letter != 'e' && letter != 'f' && letter != 'g' && letter != 'h' && letter != 'i' && letter != 'j' && letter != 'k' && letter != 'l' && letter != 'm' && letter != 'n' && letter != 'ñ' && letter != 'o' && letter != 'p' && letter != 'q' && letter != 'r' && letter != 's' && letter != 't' && letter != 'u' && letter != 'v' && letter != 'w' && letter != 'x' && letter != 'y' && letter != 'z')
                throw new Exception("Debes elegir para el registro una letra minúscula entre a y z");
            if (letter == 'ñ')
                this.letter = 14; //En caso de ser la ñ, su número es el 15
            else//Si es otra, con restarle 97 al char obtenemos su posición en el array (mágicamente)
            {
                if (letter - 97 < 14) //En el caso de los menores que ñ, simplemente los restamos
                    this.letter = letter - 97;
                else //Si son mayores que ñ, le sumamos 1
                this.letter = letter - 96;
            }
        }
    }

    public class GetLetter : Registry
    {
        public GetLetter(Robot robot, Matlanland matfield, char letter) : base(robot, matfield, letter)
        { //En el caso específico de los registros, su número es 31 + el número que respresenta su letra
            this.number = int.Parse("31" + this.letter.ToString());
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha sobrepasado el millón de elementos. Instrucción Apilar del Registro no puede ser ejecutada");

            robot.stack.Push(this.matfield.registers.RemoveRegister(this.letter));
            //Básicamente llamamos a la pila y le colocamos lo que esté en la posición deseada del registro
        }
        public override Instruction Clone()
        {
            if (this.letter == 14)
                return new GetLetter(null, null, 'ñ');
            if (this.letter < 14)
                return new GetLetter(null, null, (char)(this.letter + 97));
            else
                return new GetLetter(null, null, (char)(this.letter + 96));
        }
    }

    public class SetLetter : Registry
    {
        public SetLetter(Robot robot, Matlanland matfield, char letter) : base(robot, matfield, letter)
        {
            this.number = int.Parse("32" + this.letter.ToString());
        }

        public override void Execute()
        {
            this.matfield.registers.AddRegister(robot.stack.Pop(), this.letter);
        }//La línea está larga, pero básicamente llamamos al registro del matfield, y le colocamos lo que esté en el tope de la pila
        //al registro que esté en letter

        public override Instruction Clone()
        {
            if (this.letter == 14)
                return new SetLetter(null, null, 'ñ');
            if (this.letter < 14)
                return new SetLetter(null, null, (char)(this.letter + 97));
            else
                return new SetLetter(null, null, (char)(this.letter + 96));
        }
    }
}
