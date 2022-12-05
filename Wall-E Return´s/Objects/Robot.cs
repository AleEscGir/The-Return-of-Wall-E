using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Robot : AllObject //La clase robot hereda de Allobject
    {
        public Direction direction { get; protected set; } //Punto cardinal hacia el que está orientado el robot
        //0-North
        //1-East
        //2-South
        //3-West
        public int time { get; protected set; } //Cantidad de rondas de simulación del robot
        public Position position {get; protected set; } //Esta es la posición en la que se encuentra el robot en el Simufield
        public List<Matlanland> runtimes { get; protected set; } //Aquí está la rutina principal y las subrutinas del robot
        public Stack<Matlanland> recursivity { get; protected set; } //Aquí tenemos todas las recursividades que hayan sido abiertas
        public Simuland simufield { get; private set; } //Aquí está la referencia del Simuland
        public Stack<int> stack { get; protected set; } //Esta es la pila interna del robot
        public int[] LinealMemory { get; protected set; } //Esta es la memoria lineal del robot donde se pueden guardar y sacar números
        public List<int> LinealMemoryIndex { get; protected set; }
        public int mathlancounter { get; protected set; } //Aquí se tienen la cantidad de matlan creados, para que ellos tengan su número
        public string message { get; protected set; } //Este string es el que le permite al robot guardar ciertas palabras o frases
        public Obstacle smallobject { get; protected set; } //El robot también puede tener un objeto dentro suyo

        public Robot(Shape shape, Size size, Color color, int code, Direction direction, Simuland simufield) : base(new RobotForm(), new Large(), color, code)
        {//El robot hereda todas características de AllObject a excepción de su forma que es definida robot y de su tamaño que es definido grande 
            this.direction = direction; //Le conferimos sus valores
            this.time = 0; //Iniciamos el tiempo de vida del robot
            this.runtimes = new List<Matlanland>();
            this.recursivity = new Stack<Matlanland>();
            this.simufield = simufield;
            this.stack = new Stack<int>();
            this.LinealMemory = new int[1000000];
            this.mathlancounter = 0;
            this.LinealMemoryIndex = new List<int>();
            this.message = "";
            this.smallobject = null;
        }

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
        public abstract void Turn(); //Los robot tienen como propiedad realizar uno de los turnos en su código MatLan
        public abstract bool DebugTurn(); //También tienen como propiedad poder debuguear instrucción a instrución sus matlanlands
        public abstract void AddMatlanland(int fills, int columns); //Otra propiedad de los robots es que le puedes añadir un Matlanland a su lista de rutinas
        public abstract void AddMatlanland(string directory); //Mediante este método podemos añadir una rutina teniendo un directorio de un archivo mediante el parser
        public abstract void RemoveMatlanland(int pos); //También pueden eliminar un Matlanland de su lista de rutinas

        //Estas son las posibles acciones que puede realizar el robot
        public abstract void ForwardsMove(); //El robot se mueve hacia adelante
        public abstract void BackWardsMove(); //El robot se mueve hacia atrás
        public abstract void LeftRotate(); //El robot gira hacia la izquierda
        public abstract void RightRotate(); //El robot gira hacia la derecha
        public abstract void ObjectAction(); //Esta propiedad ejecuta la acción del robot correspondiente a su objeto

        //Estos son los sensores del robot
        public abstract int Ultrasonic(); //Indica la cantidad de casillas vacías frente al robot
        public abstract int Webcam(); //Indica el color del objeto frente al robot
        public abstract int Kinect(); //Indica la forma del objeto frente al robot
        public abstract int BarcodeScanner(); //Indica el código del objeto frente al robot
        public abstract int Weight(); //Pesa: Indica si hay un objeto dentro del robot
        public abstract int Chronometer(); //Cronómetro: Devuelve el tiempo de vida del robot
        public abstract int Compass(); //Brújula: Indica la orientación del robot
        public abstract void StringChanger(string Word); //Permite cambiar el mensaje del string
    }
}
