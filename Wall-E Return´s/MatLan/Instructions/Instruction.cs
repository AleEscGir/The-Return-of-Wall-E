using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Instruction //Esta es la clase de instrucciones  de la que heredarán el resto de los diferentes tipos de instrucciones
    {
        protected Robot robot { get; set; } //Este es el robot que se le pasará por referencia a la instrucción
        protected Matlanland matfield { get; set; }//Este es el matfield que se le pasará por referencia a la instrucción
        public int number { get; protected set; } //Este número jugará un papel fundamental en la parte gráfica
        public Instruction(Robot robot, Matlanland matfield)
        {
            this.robot = robot;
            this.matfield = matfield;
        }
        public abstract void Execute(); //Lo único que tendrá esta clase es el método Execute, que le dirá a cada instrucción que realice su función
        public abstract Instruction Clone(); //Mediante este método podemos hacer un clon de las instrucciones

        public void AddRobot(Robot a)//Mediante este método podemos añadirle a una instrucción un robot solo si no ha sido puesto uno previamente
        {
            if (a == null)
                throw new Exception("Debes pasar un robot que no sea null");
                this.robot = a;
        }

        public void AddMatlanLand(Matlanland a)//Mediante este método podemos añadirle a una instrucción una MatlanLand solo si no ha sido puesto uno previamente
        {
            if (a == null)
                throw new Exception("Debes pasar un Matlanland que no sea null");
            this.matfield = a;
        }

    }
}
