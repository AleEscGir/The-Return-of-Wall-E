using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{ //2do Proyecto de Programación 2018-2019, Alejandro Escobar Giraudy C112
    public class Simuland //Aquí será realizado el entorno simulado
    {
        public AllObject[,] simufield { get; private set; } //Básicamente será una matriz bidimensional que tendrá los objetos posibles
        public List<Robot> robotlist { get; private set; } //Lista que indica las posiciones de los robots
        private int movecont; //Contador de cuántos robots se han movido
        public int fills { get; private set; } //Cantidad de filas de la matriz
        public int columns { get; private set; } //Cantidad de columnas de la matriz
        public Robot actualrobot { get; private set; } //Este robot nos indicará cuál es el que está ejecutando su turno (lo cual ayuda en la parte gráfica principalmente)
        int debugrandom = -1; //Este int sirve principalmente para el método DebugTurn
        public Simuland(int fills, int columns)  //Su contructor tendrá como parámetros la cantidad de filas y de columnas que tendrá la matriz
        {
            if (fills < 1 || columns < 1)
                throw new Exception("Columnas y filas deben ser mayores que uno");
            this.fills = fills;
            this.columns = columns;
            this.simufield = new AllObject[fills, columns];
            this.robotlist = new List<Robot>();
            this.movecont = 0;
        }

        private Simuland(AllObject[,] simufield) //Este constructor existe para poder clonar un simufield
        {
            this.movecont = 0; //Colocamos el contador en 0
            this.fills = simufield.GetLength(0); //Le damos su valor a las filas y columnas
            this.columns = simufield.GetLength(1);
            this.robotlist = new List<Robot>();
            this.simufield = new AllObject[this.fills, this.columns]; //Creamos un nuevo simufield
            for(int i = 0; i < this.fills; i++) //Vamos por filas y columnas
            {
                for(int j = 0; j < this.columns; j++)
                {
                    if (simufield[i, j] != null) //Cuando encontremos un AllObject
                        this.AddAllObject(simufield[i, j].Clone(), i, j); //Lo agregamos usando el método add (así le agregamos la referencia previamente quitada por le clon de los objetos
                }
            }
        }

        public void AddAllObject(AllObject a, int fill, int column) //Mediante esta propiedad podemos añadir un objeto al simuland
        {
            if (fill < 0 || fill > this.fills || column < 0 || column > this.columns) //Si la posición es inválida se lanza una excepción
                throw new Exception();

            if (this.simufield[fill, column] != null)//Si el lugar donde colocamos un objeto ya tiene uno, debemos detenernos
            {//Si se quiere corregir una posición, se debe hacer RemoveAllObject al objeto y luego se puede hacer lo que quiera con la posición
                throw new InvalidOperationException("Un objeto fue colocado donde ya existía otro");
            }
            this.simufield[fill, column] = a; //Colocamos el objeto en su posición

            if (a.Shape.Name == "Robot") //Si es un robot le pasamos la referencia del simufield y la del position
            {
                
                ((Robot)this.simufield[fill, column]).AddSimuland(this);
                ((Robot)this.simufield[fill, column]).AddPosition(new Position(fill, column)); //Le damos al robot su posición en el simufield
                robotlist.Add(((Robot)this.simufield[fill, column])); //Agregamos la referencia del robot a la lista de robots
            }
            else
            {
                ((Obstacle)this.simufield[fill, column]).AddSimuland(this); //Si es un objeto le pasamos la referencia del simufield
                ((Obstacle)this.simufield[fill, column]).AddPosition(new Position(fill, column)); //Le damos al objeto su posición en el simufield
            }
        }

        public void AddAllObjectinMove(AllObject a, int fill, int column) //Mediante esta propiedad podemos añadir un objeto al simuland sin que sea agregado a la lista de robots
        {
            if (fill < 0 || fill > this.fills || column < 0 || column > this.columns) //Si la posición es inválida se lanza una excepción
                throw new Exception();

            if (this.simufield[fill, column] != null)//Si el lugar donde colocamos un objeto ya tiene uno, debemos detenernos
            {//Si se quiere corregir una posición, se debe hacer RemoveAllObject al objeto y luego se puede hacer lo que quiera con la posición
                throw new InvalidOperationException("Un objeto fue colocado donde ya existía otro");
            }
            this.simufield[fill, column] = a; //Colocamos el objeto en su posición

            if (a is Robot) //Si es un robot le pasamos la referencia del simufield
            {

                ((Robot)this.simufield[fill, column]).AddSimuland(this);
                ((Robot)this.simufield[fill, column]).AddPosition(new Position(fill, column)); //Le damos al robot su posición en el simufield
            }
            else
            {
                ((Obstacle)this.simufield[fill, column]).AddSimuland(this); //Si es un objeto le pasamos la referencia del simufield
                ((Obstacle)this.simufield[fill, column]).AddPosition(new Position(fill, column)); //Le damos al objeto su posición en el simufield
            }
        }

        public void RemoveAllObject(int fill, int column) //También es posible remover un AllObject del Simuland
        {
            if(this.simufield[fill, column] != null && this.simufield[fill, column] is Robot) //Si no es null y es un robot (se hace así porque si es null el cortocircuito no le deja llegar al is) debemos eliminar su posición del array de posiciones
            {
                for(int i = 0; i < this.robotlist.Count; i++) //Si entra es porque en el array existe un robot con esa posición
                {
                    if (this.robotlist[i].position.fill == fill && this.robotlist[i].position.column == column) //Mediante un for buscamos cuál es
                    {
                        this.robotlist.RemoveAt(i); //Y cuando lo encontremos lo removemos
                        break; //Hacemos break para que no continúe iterando sin razón
                    }
                }
            }
            this.simufield[fill, column] = null; //Luego removemos el objeto sin ningún problema, haya sido robot o no
        }

        public void RemoveinMoveAllObject(int fill, int column) //También es posible remover un AllObject del Simuland sin borrarlo de la lista de robots
        {
            this.simufield[fill, column] = null; //Simplemente removemos el objeto
        }

        public void RobotTurn() //Este método hace a un robot ejecutar su turno
        {
            //La idea se centrará en tener una lista con los robots, para así, elegir una al azar y hacerlo moverse, luego,
            //cuando el robot termine, como los demás deben tomar su turno, lo enviaremos a la última posición, y con un contador,
            //disminuiremos el rango de robots para escoger
            if (movecont == robotlist.Count()) //Verificamos si el contador llegó a la cantidad de robots, si lo hizo debemos reiniciarlo
                movecont = 0;
            int random = new Random().Next(0, this.robotlist.Count() - this.movecont); //Nuestro random irá desde el tamaño de la lista hasta un punto del mismo

            this.actualrobot = this.robotlist[random]; //Le damos como valor al robot que está en las propiedades el robot actual
            this.robotlist[random].Turn(); //Hacemos que el robot tome su turno
            this.robotlist.Add(this.robotlist[random]); //Le agregamos a la lista (de último) el robot de la posición al azar que elegimos
            this.robotlist.RemoveAt(random); //Eliminamos luego la posición que hicimos que se moviese
            this.actualrobot = null; //Puesto que el turno del robot terminó, le hacemos null a su referencia en el simulad
            movecont += 1; //Aumentamos el contador
        }

        public void RobotDebugTurn() //Este método hace a un robot poder debuguear sus rutinas
        {
            //La idea se centrará en tener una lista con los robots, para así, elegir una al azar y hacerlo moverse, luego,
            //cuando el robot termine, como los demás deben tomar su turno, lo enviaremos a la última posición, y con un contador,
            //disminuiremos el rango de robots para escoger
            if (movecont == robotlist.Count()) //Verificamos si el contador llegó a la cantidad de robots, si lo hizo debemos reiniciarlo
                movecont = 0;
            if(this.debugrandom == -1) //En caso de que el random sea -1, quiere decir que todavía no ha sido elegido
            this.debugrandom = new Random().Next(0, this.robotlist.Count() - this.movecont); //Nuestro random irá desde el tamaño de la lista hasta un punto del mismo

            this.actualrobot = this.robotlist[debugrandom]; //Le damos como valor al robot que está en las propiedades el robot actual
            if (this.robotlist[debugrandom].DebugTurn()) //Hacemos que el robot tome su turno
            {
                this.robotlist.Add(this.robotlist[debugrandom]); //Le agregamos a la lista (de último) el robot de la posición al azar que elegimos
                this.robotlist.RemoveAt(debugrandom); //Eliminamos luego la posición que hicimos que se moviese
                this.actualrobot = null; //Puesto que el turno del robot terminó, le hacemos null a su referencia en el simulad
                movecont += 1; //Aumentamos el contador
                this.debugrandom = -1; //Devolvemos el random a su valor original
            }
        }

        public Simuland Clone() //Este método sirve para hacer un clon sin referencias del Simufield
        {
            return new Simuland(this.simufield); //Simplemente creamos uno nuevo llamando al constructor privado
        }

        public void Resize(int fills, int columns) //Este método sirve para hacer rehacer la rutina con nuevas dimensiones sin referencias del Simufield
        {//Copiamos todos los objetos que sean posible copiar
            this.movecont = 0; //Colocamos el contador en 0
            this.fills = fills; //Le damos su valor a las filas y columnas
            this.columns = columns;
            this.robotlist = new List<Robot>();
            AllObject[,] temporal = this.simufield; //Cambiamos el simufield actual a uno temporal
            this.actualrobot = null;
            this.simufield = new AllObject[this.fills, this.columns]; //Rehacemos el simufield
            for (int i = 0; i < Math.Min(this.fills, temporal.GetLength(0)); i++) //Vamos por el menor entre las filas del nuevo simuland y las nuevas filas
            {
                for (int j = 0; j < Math.Min(this.columns, temporal.GetLength(1)); j++) //Lo mismo para las columnas
                {
                    if (temporal[i, j] != null) //Cuando encontremos un AllObject
                        this.AddAllObject(temporal[i, j].Clone(), i, j); //Lo agregamos usando el método add (así le agregamos la referencia previamente quitada por le clon de los objetos
                }
            }
        }

        public void IgnoreActualRobot() //Est método sirve para que el campo funcione sin uno de los robot (literalmente que lo ignore)
        {
            if(this.actualrobot != null) //Si nuestro robot actual es null no trabajamos
            {
                if (this.movecont != 0) //Si nuestro count es 0 no podemos disminuirlo porque no estamos en ningún robot
                    this.movecont--;
                for(int i = 0; i < this.robotlist.Count; i++) //Mediante un for buscamos al robot actual en la lista de robots, cuando lo encontremos lo sacamos
                {
                    if (object.Equals(this.actualrobot, this.robotlist[i])) //Hacemos la comparación mediante el Equals de object
                        this.robotlist.RemoveAt(i);
                }
                this.actualrobot.StringChanger("Robot Fuera de Servicio"); //Cambiamos el string del robot para saber que dio error
                this.actualrobot = null;
            }
        }
    }
}
