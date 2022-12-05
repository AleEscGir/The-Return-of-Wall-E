using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Sensor : Instruction
    {
        public Sensor(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Los sensores guardan en la pila un valor dependiendo de lo que haga el sensor asociado a cada robot 
        }
    }

    public class Ultrasonic : Sensor
    {
        public Ultrasonic(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Guarda en la pila la cantidad de casillas vacías frente al robot
            this.number = 35;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha intentado colocar más de 1000000 elementos. Instrucción Ultrasónico no puede ser ejecutada");
            this.robot.stack.Push(this.robot.Ultrasonic());
        }

        public override Instruction Clone()
        {
            return new Ultrasonic(null, null);
        }
    }

    public class Webcam : Sensor
    {
        public Webcam(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Guarda en la pila el color del objeto frente al robot
            this.number = 36;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha intentado colocar más de 1000000 elementos. Instrucción Webcam no puede ser ejecutada");
            this.robot.stack.Push(this.robot.Webcam());
        }
        public override Instruction Clone()
        {
            return new Webcam(null, null);
        }
    }

    public class Kinect : Sensor
    {
        public Kinect(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Guarda en la pila la forma del objeto frente al robot
            this.number = 37;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha intentado colocar más de 1000000 elementos. Instrucción Kinect no puede ser ejecutada");
            this.robot.stack.Push(this.robot.Kinect());
        }
        public override Instruction Clone()
        {
            return new Kinect(null, null);
        }
    }

    public class BarcodeScanner : Sensor
    {
        public BarcodeScanner(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Guarda en la pila el código del objeto frente al robot
            this.number = 38;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha intentado colocar más de 1000000 elementos. Instrucción Escáner de Código no puede ser ejecutada");
            this.robot.stack.Push(this.robot.BarcodeScanner());
        }
        public override Instruction Clone()
        {
            return new BarcodeScanner(null, null);
        }
    }

    public class Weight : Sensor
    {
        public Weight(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Guarda en la pila si hay o no un objeto dentro del robot (Pesa)
            this.number = 39;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha intentado colocar más de 1000000 elementos. Instrucción Pesa no puede ser ejecutada");
            this.robot.stack.Push(this.robot.Weight());
        }
        public override Instruction Clone()
        {
            return new Weight(null, null);
        }
    }

    public class Chronometer : Sensor
    {
        public Chronometer(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Guarda en la pila el tiempo de vida del robot (Cronómetro)
            this.number = 40;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha intentado colocar más de 1000000 elementos. Instrucción Cronómetro no puede ser ejecutada");
            this.robot.stack.Push(this.robot.Chronometer());
        }
        public override Instruction Clone()
        {
            return new Chronometer(null, null);
        }
    }

    public class Compass : Sensor
    {
        public Compass(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Guarda en la pila el valor de la orientación del robot
            this.number = 41;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha intentado colocar más de 1000000 elementos. Instrucción Brújula no puede ser ejecutada");
            this.robot.stack.Push(this.robot.Compass());
        }
        public override Instruction Clone()
        {
            return new Compass(null, null);
        }
    }
}
