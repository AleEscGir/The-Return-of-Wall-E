using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class FlowController : Instruction
    {
        public FlowController(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//FlowController solamente cambia la dirección del flujo (o sea, el parámetro flow)
        }
    }

    public class NE : FlowController
    {
        public NE(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Controlador North-East
            this.number = 42;
        }

        public override void Execute()
        {
            if (this.matfield.flow.Name == "Sourth") //Si entro por el Norte (voy hacia el sur) cambio para el Este
                this.matfield.ChangeFlow(new East());
            else
            {
                if (this.matfield.flow.Name == "West")//Si entro por el Este (voy hacia el oeste) cambio para el Norte
                    this.matfield.ChangeFlow(new North());
            }
        }
        public override Instruction Clone()
        {
            return new NE(null, null);
        }

    }

    public class SE : FlowController
    {
        public SE(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Controlador Sourth-East
            this.number = 43;
        }

        public override void Execute()
        {
            if (this.matfield.flow.Name == "North") //Si entro por el Sur (voy hacia el Norte) cambio para el Este
                this.matfield.ChangeFlow(new East());
            else
            {
                if (this.matfield.flow.Name == "West")//Si entro por el Este (voy hacia el oeste) cambio para el Sur
                    this.matfield.ChangeFlow(new Sourth());
            }
        }
        public override Instruction Clone()
        {
            return new SE(null, null);
        }
    }

    public class NW : FlowController
    {
        public NW(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Controlador North-West
            this.number = 44;
        }

        public override void Execute()
        {
            if (this.matfield.flow.Name == "Sourth") //Si entro por el Norte (voy hacia el Sur) cambio para el Oeste
                this.matfield.ChangeFlow(new West());
            else
            {
                if (this.matfield.flow.Name == "East")//Si entro por el Oeste (voy hacia el este) cambio para el Norte
                    this.matfield.ChangeFlow(new North());
            }
        }
        public override Instruction Clone()
        {
            return new NW(null, null);
        }
    }

    public class SW : FlowController
    {
        public SW(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Controlador Sourth-West
            this.number = 45;
        }

        public override void Execute()
        {
            if (this.matfield.flow.Name == "North") //Si entro por el Sur (voy hacia el Norte) cambio para el Oeste
                this.matfield.ChangeFlow(new West());
            else
            {
                if (this.matfield.flow.Name == "East")//Si entro por el Oeste (voy hacia el Este) cambio para el Sur
                    this.matfield.ChangeFlow(new Sourth());
            }
        }
        public override Instruction Clone()
        {
            return new SW(null, null);
        }
    }

    public class Branch : FlowController
    {
        public Branch(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Esta instrucción hace de condicional (if)
            this.number = 46;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 0)//Primeramente, si no tenemos que sacar de la pila, lanzamos nosotros mismos la excepción
                throw new Exception("Pila Vacía. Condicional no puede ser ejecutada");
            if(this.robot.stack.Pop() == 0) //Sacamos el valor de la pila, si es igual a 0 (false), gira el flujo hacia la izquierda
            {
                switch (this.matfield.flow.Name) //Mediante un switch cambiamos el flujo
                {
                    case "North":
                        this.matfield.ChangeFlow(new West());
                        break;
                    case "West":
                        this.matfield.ChangeFlow(new Sourth());
                        break;
                    case "Sourth":
                        this.matfield.ChangeFlow(new East());
                        break;
                    case "East":
                        this.matfield.ChangeFlow(new North());
                    break;
                }

            }

            else //Si el valor es diferente de 0 (true), cambiamos el flujo hacia la derecha
            {
                switch(this.matfield.flow.Name)
                {
                    case "North":
                        this.matfield.ChangeFlow(new East());
                        break;
                    case "East":
                        this.matfield.ChangeFlow(new Sourth());
                        break;
                    case "Sourth":
                        this.matfield.ChangeFlow(new West());
                        break;
                    case "West":
                        this.matfield.ChangeFlow(new North());
                        break;
                }
            }
        }
        public override Instruction Clone()
        {
            return new Branch(null, null);
        }
    }

    public class TS : FlowController
    {
        public TS(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//T con entrada aleatoria desde el sur
            this.number = 47;
        }

        public override void Execute()
        {
            switch(this.matfield.flow.Name) //La idea es usar un switch para cambiar las tres direcciones posibles (en el caso de la cuarta no ocurre nada)
            {
                case "West": //si vamos hacia el oeste, cambio al sur
                    this.matfield.ChangeFlow(new Sourth());
                    break;
                case "East"://si vamos hacia el este, cambio al sur
                    this.matfield.ChangeFlow(new Sourth());
                    break;
                case "North": //Si voy hacia el norte, hago un random que me de 0 o 1, y dependiendo del valor que devuelva, cambio el flujo al este o al oeste
                    int a = new Random().Next(2);
                    if (a == 0)
                        this.matfield.ChangeFlow(new East());
                    else
                        this.matfield.ChangeFlow(new West());
                    break;
            }
        }

        public override Instruction Clone()
        {
            return new TS(null, null);
        }
    }
    public class TE : FlowController
    {
        public TE(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//T con entrada aleatoria desde el este
            this.number = 48;
        }

        public override void Execute()
        {
            switch (this.matfield.flow.Name) //La idea es usar un switch para cambiar las tres direcciones posibles (en el caso de la cuarta no ocurre nada)
            {
                case "Sourth": //si vamos hacia el sur, cambio al este
                    this.matfield.ChangeFlow(new East());
                    break;
                case "North"://si vamos hacia el norte, cambio al este
                    this.matfield.ChangeFlow(new East());
                    break;
                case "West": //Si voy hacia el oeste, hago un random que me de 0 o 1, y dependiendo del valor que devuelva, cambio el flujo al norte o al sur
                    int a = new Random().Next(2);
                    if (a == 0)
                        this.matfield.ChangeFlow(new North());
                    else
                        this.matfield.ChangeFlow(new North());
                    break;
            }
        }
        public override Instruction Clone()
        {
            return new TE(null, null);
        }
    }
    public class TN : FlowController
    {
        public TN(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//T con entrada aleatoria desde el norte
            this.number = 49;
        }

        public override void Execute()
        {
            switch (this.matfield.flow.Name) //La idea es usar un switch para cambiar las tres direcciones posibles (en el caso de la cuarta no ocurre nada)
            {
                case "West": //si vamos hacia el oeste, cambio al norte
                    this.matfield.ChangeFlow(new North());
                    break;
                case "East"://si vamos hacia el este, cambio al norte
                    this.matfield.ChangeFlow(new North());
                    break;
                case "Sourth": //Si voy hacia el sur, hago un random que me de 0 o 1, y dependiendo del valor que devuelva, cambio el flujo al este o al oeste
                    int a = new Random().Next(2);
                    if (a == 0)
                        this.matfield.ChangeFlow(new East());
                    else
                        this.matfield.ChangeFlow(new West());
                    break;
            }
        }
        public override Instruction Clone()
        {
            return new TN(null, null);
        }
    }
    public class TW : FlowController
    {
        public TW(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//T con entrada aleatoria desde el oeste
            this.number = 50;
        }

        public override void Execute()
        {
            switch (this.matfield.flow.Name) //La idea es usar un switch para cambiar las tres direcciones posibles (en el caso de la cuarta no ocurre nada)
            {
                case "North": //si vamos hacia el norte, cambio al oeste
                    this.matfield.ChangeFlow(new West());
                    break;
                case "Sourth"://si vamos hacia el sur, cambio al oeste
                    this.matfield.ChangeFlow(new West());
                    break;
                case "East": //Si voy hacia el este, hago un random que me de 0 o 1, y dependiendo del valor que devuelva, cambio el flujo al norte o al sur
                    int a = new Random().Next(2);
                    if (a == 0)
                        this.matfield.ChangeFlow(new North());
                    else
                        this.matfield.ChangeFlow(new Sourth());
                    break;
            }
        }

        public override Instruction Clone()
        {
            return new TW(null, null);
        }
    }
}
