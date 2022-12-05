using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public class Matlanland
    {//Esta será la matriz donde estará el código del robot
        public readonly Robot robot; //Aquí estará la referencia del robot al que le pertenece este Matlanland, para así poder modificarlo
        public Instruction[,] matfield { get; private set; } //El MatField será un bidimensional de instrucciones
        public int fills { get; private set; }
        public int columns { get; private set; }
        public Direction flow { get; private set; } //Este es el flujo en el que se encuentra el cursor
        //0-North
        //1-East
        //2-Sourth
        //3-West
        public Position Cursor { get; private set; } //Este cursor es el lugar donde se encuentra la ejecución del MatLan, que comienza en el comando start
        public Registers registers { get; }//Aquí están los registros referentes al MatlLand
        public int number { get; internal set; } //Este es el número de la posición del matland en el runtime del robot
        private bool Start; //Este bool le permite saber al matland si ya hay un start

        public Matlanland(int fills, int columns,  Robot robot, int number) //Este es el constructor que se usa normalmente
        {
            if (fills < 1 || columns < 1)
                throw new Exception();
            this.fills = fills;
            this.columns = columns;
            matfield = new Instruction[fills, columns];
            this.Cursor = null;//Iniciamos el cursor en null puesto que el start es quien le da su su posición de inicio
            this.flow = new Sourth(); //Se inicializa el flujo en dirección sur
            this.robot = robot; //Añadimos la referencia del robot
            this.registers = new Registers();
            this.number = number;
            this.Start = false;
        }

        private Matlanland(Instruction[,] matfield, Robot robot, int fill, int column, int number) //Este constructor es private puesto que es exclusivo del clonador
        {
            //this.matfield = matfield;
            this.robot = robot; //Le pasamos el robot que nos dan
            this.fills = matfield.GetLength(0); //Las filas y las columnas dependen del Matfield
            this.columns = matfield.GetLength(1);
            this.flow = new Sourth(); //El flujo comienza hacia el sur
            this.registers = new Registers(); //Reiniciamos los registros
            this.Cursor = new Position(fill, column); //El cursor comenzará en la fila y columna que nos pasaron
            //Creamos un nuevo matfield, y le pasamos las instrucciones con la referencia del robot
            this.matfield = new Instruction[matfield.GetLength(0), matfield.GetLength(1)];
            this.number = number; //Copiamos el número del matland que nos pasan
            for (int i = 0; i < this.matfield.GetLength(0); i++)
            {
                for (int j = 0; j < this.matfield.GetLength(1); j++)
                {
                    if(matfield[i,j] != null)
                    this.AddInstruction(matfield[i, j].Clone(), i, j);
                }
            }
        }

        public void AddInstruction(Instruction a, int fill, int column) //Mediante esta propiedad puede ser añadido una instrucción al MatField
        {
            if (fill < 0 || fill > this.fills || column < 0 || column > this.columns) //Si la posición es inválida se lanza una excepción
                throw new Exception("Debe elegir una posición dentro del matfield");
            if (a is Start)//Si es un start el comando que se nos agrega, entonces debemos ver si no hay ninguno puesto, ya que solo puede haber uno
            {
                if (Start == false)//Si no hay ninguno puesto, cambiamos el bool y le damos al cursor su posición inicial
                {
                    Start = true;
                    this.Cursor = new Position(fill, column);
                }
                else//Si ya hay uno, el programa no puede continuar
                {
                    throw new InvalidOperationException("Solo puede haber un Start a la vez");
                }
            }
            if (this.matfield[fill, column] != null)
                throw new Exception("Colocó una instrucción donde ya había una");
            this.matfield[fill, column] = a;//Colocamos la instrucción en su posición
            this.matfield[fill, column].AddMatlanLand(this); //Le damos a la instrucción la referencia del matfield y el robot de la misma
            this.matfield[fill, column].AddRobot(this.robot);
        }

        public void RemoveInstruction(int fill, int column) //También podemos remover directamente una instrucción
        {
            if(this.matfield[fill,column] != null && this.matfield[fill, column] is Start) //Si el comando es un start, debemos quitar el bool y dejar en null el cursor
            {
                this.Start = false;
                this.Cursor = null;
            }
            this.matfield[fill, column] = null;//Hacemos null la posición
        }

         public bool MatTurn() //Esto hace al Matlanland realizar su turno
         {
         //Si el MatLand devuelve true es que terminó, si no, es que llegó a un comando
             while ((flow.Number != 0 || Cursor.fill != 0) && (flow.Number != 1 || Cursor.column != (matfield.GetLength(1) - 1)) && (flow.Number != 2 || Cursor.fill != (matfield.GetLength(0) - 1)) && (flow.Number != 3 || Cursor.column != 0))
             {
                //Haber, el while está algo raro, pero es básicamente negar (utilizando lo aprendido en la asignatura de lógica) a la expresión siguiente:
                //(flow == 0 && cursor.fill == 0) || (flow == 1 && cursor.column == (matfield.GetLength(1) - 1)) || (flow == 2 && cursor.fill == (matfield.GetLength(0) - 1)) || (flow == 3 && cursor.column == 0)
                //Que son las condiciones para que se detenga el while... vaya, que por algo se da esta asignatura no?

                if (this.Equals(this.robot.recursivity.Peek()) == false) //A ver, si cuando vas a ejecutar una vuelta del while yo no soy lo que está en el tope de la recursividad, entonces hay otra abierta, por tanto devuelvo false porque no he parado
                    return false;

                //Procedemos a movernos (es lo primero que hacemos puesto que siempre habremos ejecutado la acción de la casilla en el turno anterior, y si este es el primero, estamos en el start que no hace nada
                
                this.Cursor =  this.Cursor + this.flow;//Básicamente avanzamos una paso sumándole al cursor el flujo

                if (matfield[Cursor.fill, Cursor.column] != null && matfield[Cursor.fill, Cursor.column] is Return) //Si llegamos a un return, entonces damo por finalizado el matlanland
                    return true;

                if (matfield[Cursor.fill, Cursor.column] != null) //Si dicha instrucción es diferente de null
                {
                    matfield[Cursor.fill, Cursor.column].Execute(); //Ejecuta la instrucción que esté en la posición
                    if (matfield[Cursor.fill, Cursor.column] is Command) //Y es un comando, terminamos la ejecución
                        return false;
                    if(matfield[Cursor.fill, Cursor.column] is Call || matfield[Cursor.fill, Cursor.column] is ReCall)
                    {
                        if (this.robot.recursivity.Peek().MatTurn())
                            this.robot.recursivity.Pop();
                        else
                            return false;
                    }
                }
             }
             return true; //Si se rompe el while, detenemos el matlanland
         }

        public Tuple<bool, bool>DebugMatTurn() //Esto hace al Matlanland realizar su turno debugueando
        {//La razón por la que devolvemos una tupla es porque tenemos 3 opciones, terminamos el matlanland pero no fue completado,
         //fue compleado el matlanland o simplemente se llegó a una intrucción, donde de los dos bool de la tupla, el primero
         //indica si fue terminado el matlan, en caso de que sea true, significa que terminó porque llegó a un comando, 
         //o sea, que tenemos que detener al robot completo hasta su próximo turno, en caso de que sea false es que
         //simplemente ejecutó su instrucción correspondiente
         //Resumen:
         //True-True, llegamos a un return o al límite de un matlanland
         //True-False, llegamos a un return o al límite de un matlanland
         //False-True, significa que llegamos a un comando
         //False-False, significa que solo vimos otra instrucción
            if ((flow.Number != 0 || Cursor.fill != 0) && (flow.Number != 1 || Cursor.column != (matfield.GetLength(1) - 1)) && (flow.Number != 2 || Cursor.fill != (matfield.GetLength(0) - 1)) && (flow.Number != 3 || Cursor.column != 0))
            {
                //Haber, el if está algo raro, pero es básicamente negar (utilizando lo aprendido en la asignatura de lógica) a la expresión siguiente:
                //(flow == 0 && cursor.fill == 0) || (flow == 1 && cursor.column == (matfield.GetLength(1) - 1)) || (flow == 2 && cursor.fill == (matfield.GetLength(0) - 1)) || (flow == 3 && cursor.column == 0)
                //Que son las condiciones para que entre al if... vaya, que por algo se da esta asignatura no?

                if (this.Equals(this.robot.recursivity.Peek()) == false) //A ver, si cuando vas a ejecutar una vuelta del if yo no soy lo que está en el tope de la recursividad, entonces hay otra abierta, por tanto devuelvo false porque no he parado
                    return new Tuple<bool, bool>(false, false);

                //Procedemos a movernos (es lo primero que hacemos puesto que siempre habremos ejecutado la acción de la casilla en el turno anterior, y si este es el primero, estamos en el start que no hace nada

                this.Cursor = this.Cursor + this.flow;//Básicamente avanzamos una paso sumándole al cursor el flujo

                if (matfield[Cursor.fill, Cursor.column] != null && matfield[Cursor.fill, Cursor.column] is Return) //Si llegamos a un return, entonces damos por finalizado el matlanland
                    return new Tuple<bool, bool>(true, true);

                if (matfield[Cursor.fill, Cursor.column] != null) //Si dicha instrucción es diferente de null
                {
                    if (matfield[Cursor.fill, Cursor.column] is RoutineInstruction) //Si es una instrucción de rutina, envés de llamarla mediante su execute normal, puesto que estamos debugueando la llamamos con DebugExecute
                    {
                        ((RoutineInstruction)matfield[Cursor.fill, Cursor.column]).DebugExecute();
                        //Luego de realizar el DebugExecute, debemos revisar antes que nada que sigamos siendo los que estamos en el tope de la pila, en caso negativo, no debemos ejecutarnos
                        if (this.Equals(this.robot.recursivity.Peek()) == false) //A ver, si cuando vas a ejecutar una vuelta del if yo no soy lo que está en el tope de la recursividad, entonces hay otra abierta, por tanto devuelvo false porque no he parado
                            return new Tuple<bool, bool>(false, false);
                    }
                    else
                        matfield[Cursor.fill, Cursor.column].Execute(); //Ejecuta la instrucción que esté en la posición
                    if (matfield[Cursor.fill, Cursor.column] is Command) //Y es un comando, terminamos la ejecución
                        return new Tuple<bool, bool>(false, true);
                }
                return new Tuple<bool, bool>(false, false);
            }
            else
                return new Tuple<bool, bool>(true, true);
        }

        public Matlanland Clone() //El clonador básicamente utiliza un constructor hecho para él solo, donde pasa el matfield y el robot por referencia, y crea todo lo demás de nuevo
        {
            return new Matlanland(this.matfield, this.robot, Cursor.fill, Cursor.column, this.number);
        }

        public Matlanland ClonewithRobotReference(Robot a) //Básicamente le cambiamos la referencia del robot también
        {
            return new Matlanland(this.matfield, a, Cursor.fill, Cursor.column, this.number);
        }

        public void ChangeFlow(Direction newflow) //Mediante este método podemos cambiar el flujo a uno nuevo en otras clases, evitando que sea null la nueva entrada
        {
            if (newflow == null)
                throw new Exception("El flujo no puede ser vacío");
            this.flow = newflow;
        }

        public void Resize(int fills, int columns) //Mediante este método podemos rehacer el bidimensional de instrucciones, copiándole las instrucciones ya puestas si es posible
        {
            if (fills < 1 || columns < 1) //Primeramente verificamos que los parámetros de entrada sean válidos
                throw new InvalidOperationException("La cantidad de filas y columnas deben ser mayor que 0");

            Instruction[,] Temporal = new Instruction[fills, columns]; //Creamos un nuevo bidimensional de instrucciones con las nuevas filas y columnas
            this.Cursor = null;//Antes que nada, puesto que no sabemos si copiaremos el start en la anterior (si es que hay), debemos reinicar estos parámetros
            this.Start = false;
            for (int i = 0; i < Math.Min(fills, this.fills); i++) //Puesto que las filas y columnas del anterior y el nuevo puede ser diferentes, copiamos usando el mínimo entre filas y columnas
            {
                for (int j = 0; j < Math.Min(columns, this.columns); j++)
                {
                    if(this.matfield[i,j] != null && this.matfield[i,j] is Start) //En caso de encontrarnos con el start, colocamos el Start y el Cursor en sus respectivos estados
                    {
                        this.Start = true;
                        this.Cursor = new Position(i, j);
                    }
                    Temporal[i, j] = this.matfield[i, j]; //Colcoamos la instrucción
                }
            }
            this.matfield = Temporal; //Cambiamos el bidimensional de instrucciones
            this.fills = fills; //Cambiamos la cantidad de columnas y filas
            this.columns = columns;
        }
    }
}
