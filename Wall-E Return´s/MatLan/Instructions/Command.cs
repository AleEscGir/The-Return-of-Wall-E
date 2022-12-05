using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Command : Instruction
    {
        public Command(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
        }
    }
    
    public class Forward : Command
    {
        public Forward(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Simplemente ejecutamos el comando de Moverse Adelante del Robot
            this.number = 0;
        }

        public override void Execute()
        {
            this.robot.ForwardsMove();
        }

        public override Instruction Clone()
        {
            return new Forward(null, null);
        }
    }

    public class Backward : Command
    {
        public Backward(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Ejecutamos el comando de Moverse Atrás del Robot
            this.number = 1;
        }

        public override void Execute()
        {
            this.robot.BackWardsMove();
        }

        public override Instruction Clone()
        {
            return new Backward(null, null);
        }
    }

    public class Right : Command
    {
        public Right(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Ejecutamos el comando de Rotar a la derecha del robot
            this.number = 2;
        }

        public override void Execute()
        {
            this.robot.RightRotate();   
        }
        public override Instruction Clone()
        {
            return new Right(null, null);
        }
    }

    public class Left : Command
    {
        public Left(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Ejecutamos el comando de Girar hacia la izquierda del robot
            this.number = 3;
        }

        public override void Execute()
        {
            this.robot.LeftRotate();
        }
        public override Instruction Clone()
        {
            return new Left(null, null);
        }
    }

    public class Drop : Command
    {
        public Drop(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Ejecutamos el comando de Acción del objeto del robot
            this.number = 4;
        }

        public override void Execute()
        {
            this.robot.ObjectAction();
        }
        public override Instruction Clone()
        {
            return new Drop(null, null);
        }
    }
}
