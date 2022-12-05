using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wall_E_Return_s
{
    public class WallE : Robot //Aquí tenemos al robot genérico: WallE
    {

        public WallE(Shape shape, Size size, Color color, int code, Direction direction, Position position, Simuland simufield) : base(shape, size, color, code, direction, simufield)
        {//WallE hereda todas las características de Robot
            AddMatlanland(1, 1);
            this.runtimes[0].AddInstruction(new Start(null, null), 0, 0);
        }

        private WallE(Shape shape, Size size, Color color, int code, Direction direction, Position position, Simuland simufield, List<Matlanland> runtimes) : base(shape, size, color, code, direction, null) //Este constructor es únicamente para el clonador
        {//Primeramente, realizará lo mismo que el anterior constructor, luego, añadimos las rutinas
            for (int i = 0; i < runtimes.Count; i++)
            {
                this.runtimes.Add(runtimes[i].ClonewithRobotReference(this)); //Copiamos todas las rutinas
            }
            this.mathlancounter = runtimes.Count;
        }

        public override void Turn() //Este método le permite a WallE ejecutar su turno
        {
            this.time++; //Cuando llegamos a un turno de Wall-E, aumentamos en 1 su tiempo de vida
            if (this.recursivity.Count() == 0)//En caso de no tener nada en recursividad, agregamos la rutina principal (o sea, un clon de ella) y la comenzamos
            {
                this.recursivity.Push(this.runtimes[0].Clone()); 
            }
            while (this.recursivity.Count() > 0) //Mediante un while vamos ejecutando matland por matland (y si no entró al if anterior, ejecuta los que estaban en en la pila comenzando por el último)
            {
            if (this.recursivity.Peek().MatTurn()) //Si un matlanland termina, debemos sacarlo de la pila y continuar con el while
                this.recursivity.Pop();
            else//Si no terminó, y en su lugar llegó a un command, detenemos el while
                return;
            }
         }

        public override bool DebugTurn() //Este método le permite a WallE ejecutar su turno
        {
            if (this.recursivity.Count() == 0)//En caso de no tener nada en recursividad, agregamos la rutina principal (o sea, un clon de ella) y la comenzamos
            {
                this.recursivity.Push(this.runtimes[0].Clone());
            }
            else
            {
                Tuple<bool, bool> a = this.recursivity.Peek().DebugMatTurn();
                if (a.Item1 == true) //Si un matlanland termina, debemos sacarlo de la pila y continuar con el while
                {
                    this.recursivity.Pop();
                }
                else
                {
                    if (a.Item2 == true)
                        return true;
                }
                if (this.recursivity.Count == 0)
                    return true;
                return false;
            }
            return false;
        }

        public override void AddMatlanland(int fills, int columns) //Mediante este método añadiremos un MatlanLand a la lista con la referencia de WallE
        {
            runtimes.Add(new Matlanland(fills, columns, this, mathlancounter));
            this.mathlancounter++; //Aumentamos el contador
        }
        public override void AddMatlanland(string directory)//Mediante este método podemos cargar de una archivo legible una rutina
        {
            //Para ellos utilizamos la sintaxis:
            //Un número N con la cantidad de instrucciones
            //En el resto de las líneas:
            //Fila Columna NombredelaInstrucción

            MatlanChargerParser dictionary = new MatlanChargerParser(); //Creamos una instancia del diccionario

            dictionary.AgregateCommandDefaultWords(); //Le agregamos todas las palabras con instrucciones
            dictionary.AgregateFlowControllerWords();
            dictionary.AgregateGetLetterWords();
            dictionary.AgregateLinealMemoryDefaultWords();
            dictionary.AgregateOperatorWords();
            dictionary.AgregateRoutineWords();
            dictionary.AgregateSensorWords();
            dictionary.AgregateSetLetterWords();
            dictionary.AgregateSpecialInstructionDefaultWords();

            StreamReader charger = new StreamReader(directory); //Mediante esta clase (tomada de System.IO), podemos leer lo que está escrito en un documento legible

            int instructionsnumber = int.Parse(charger.ReadLine()); //Guardamos la cantidad de instrucciones que nos van a pasar (primera línea)
            //Luego, guardamos en arrays cada fila, columna e instrucción, y a su vez vemos el máximo entre las filas
            //y entre las columnas para poder crear la rutina

            int[] fills = new int[instructionsnumber]; //Array de filas
            int maxfill = 0;//Máximo entre las filas
            int[] columns = new int[instructionsnumber];//Array de columnas
            int maxcolumn = 0;//Máximo entre las columnas
            string[] instructions = new string[instructionsnumber];//Array de instrucciones


            for (int i = 0; i < instructionsnumber; i++)
            {
                string[] temporal = charger.ReadLine().Split(' '); //Guardamos en un array de string temporal cada valor de la línea de lectura del ReadLine
                fills[i] = int.Parse(temporal[0]);
                columns[i] = int.Parse(temporal[1]);
                instructions[i] = temporal[2];
                maxfill = Math.Max(maxfill, fills[i]);
                maxcolumn = Math.Max(maxcolumn, columns[i]);
            }

            Matlanland routine = new Matlanland(maxfill + 1, maxcolumn + 1, this, mathlancounter); //Creamos una rutina que tendrá el máximo de filas + 1 y el máximo de columans + 1

            for(int i = 0; i < instructionsnumber; i++)
            {
                //Agregamos la instrucción según cada string en la posición correspondiente
                routine.AddInstruction(dictionary.CreateInstruction(instructions[i]), fills[i], columns[i]);
            }
            //Luego revisamos que la rutina tenga solo un start
            bool start = false;
            for(int i = 0; i < routine.fills; i++)
            {
                for(int j = 0; j < routine.columns; j++)
                {
                    if(routine.matfield[i,j] != null && routine.matfield[i,j] is Start)
                    {
                        if (start == false)
                            start = true;
                        else
                            throw new Exception("Solo puede haber un Start a la vez en la rutina");
                    }
                }
            }
            if (start == false)
                throw new Exception("Debe haber un Start en la rutina");

            this.runtimes.Add(routine); //Al terminar agregamos la rutina
            this.mathlancounter++; //Aumentamos el contador
        }

        public override void RemoveMatlanland(int pos)
        {
            if (pos < 0 || pos >= this.runtimes.Count && this.runtimes.Count != 1)//El pos debe estar en los límites de la lista y debe haber más de un matlanland
                throw new InvalidOperationException();
            this.runtimes.RemoveAt(pos); //Extreamos el matlanland de la posición
            this.mathlancounter--; //Disminuímos el contador
            for(int i = 0; i < mathlancounter; i++) //Puesto que extrajimos un matlanland cualquiera, debemos cambiar los number de todos los matlanland
            {
                this.runtimes[i].number = i; //Igualamos el number a la posición
            }
        }

        public override bool CanMove(Direction direction) //Wall-E no puede ser movido por nadie
        {
            return false;
        }

        public override void ForwardsMove()
        {//Si estamos en el límite del simufield no hacemos nada
            if (this.position.fill + this.direction.X < 0 || this.position.fill + this.direction.X >= this.simufield.fills || this.position.column + this.direction.Y < 0 || this.position.column + this.direction.Y >= this.simufield.columns)
                return;
            else
            {
                if (this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] == null)//Si es vacío, nos movemos a esa posición
                {
                    this.position = this.position + this.direction;//Actualizamos position
                    this.simufield.simufield[this.position.fill, this.position.column] = this;//Nos copiamos
                    this.simufield.simufield[this.position.fill - this.direction.X, this.position.column - this.direction.Y] = null;//Nos borramos de la posición anterior
                }
                else
                {
                    if ((this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] is Sphere || this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] is Box) && this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y].Size.Number== 1 && this.smallobject == null) //Si lo que tenemos adelante es un objeto pequeño, siendo caja o esfera, y no tenemos objeto dentro de nosotros
                    {
                        if (this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] is Box) //Debemos revisar si es una caja o una esfera
                        {
                            this.smallobject = (Box)this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y];//La pasamos al robot casteada
                            this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] = null; //Luego colocamos esa posición en null
                        }
                        if (this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] is Sphere)
                        {
                            this.smallobject = (Sphere)this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y];
                            this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] = null;
                        }
                        this.position = this.position + this.direction;//Actualizamos position
                        this.simufield.simufield[this.position.fill, this.position.column] = this;//Nos copiamos
                        this.simufield.simufield[this.position.fill - this.direction.X, this.position.column - this.direction.Y] = null;//Nos borramos de la posición anterior

                    }
                    else //Si no se cumple alguna de las condiciones, debemos ver si podemos mover al objeto
                    {
                        if (this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y].CanMove(direction))//Si se puede mover lo empujamos y nos copiamos a su posición
                            ((Obstacle)this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y]).Moveby(direction);
                        else //Si no, nos detenemos
                            return;
                        this.position = this.position + this.direction;//Actualizamos position
                        this.simufield.simufield[this.position.fill, this.position.column] = this;//Nos copiamos
                        this.simufield.simufield[this.position.fill - this.direction.X, this.position.column - this.direction.Y] = null;//Nos borramos de la posición anterior
                    }
                }
            }
        }

        public override void BackWardsMove()//Mediante esta propiedad podemos movernos hacia atrás
        {
            if (this.position.fill - this.direction.X < 0 || this.position.fill - this.direction.X >= this.simufield.fills || this.position.column - this.direction.Y < 0 || this.position.column - this.direction.Y >= this.simufield.columns)
                return;
            else //En caso contrario
            {
                this.position = this.position - this.direction;//Actualizamos position
                this.simufield.simufield[this.position.fill, this.position.column] = this; //Nos movemos a la posición anterior
                this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] = null;//Nos borramos de la posición pasada
            }
            }

        public override void LeftRotate()
        {
            switch (this.direction.Number)//Dependiendo de la posición de WallE giramos a la izquierda
            {
                case 0:
                    this.direction = new West();
                    break;
                case 1:
                    this.direction = new North();
                    break;
                case 2:
                    this.direction = new East();
                    break;
                case 3:
                    this.direction = new Sourth();
                    break;
            }
        }

        public override void RightRotate()
        {
            switch (this.direction.Number)//Dependiendo de la posición giramos a WallE a la derecha
            {
                case 0:
                    this.direction = new East();
                    break;
                case 1:
                    this.direction = new Sourth();
                    break;
                case 2:
                    this.direction = new West();
                    break;
                case 3:
                    this.direction = new North();
                    break;
            }
        }

        public override void ObjectAction() //Mediante esta propiedad ejecutamos el comando que corresponda al objeto (en este caso, WallE suelta el objeto que tiene dentro si tiene)
        {//Revisamos si tenemos un objeto dentro, en caso de tenerlo, revisamos que no estemos en el borde
            if (smallobject == null || this.position.fill + direction.X < 0 || this.position.fill + direction.X >= this.simufield.fills || this.position.column + direction.Y < 0 || this.position.column + direction.Y >= this.simufield.columns || this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] != null)
                return;
            else
            {
                this.simufield.simufield[this.position.fill + this.direction.X, this.position.column + this.direction.Y] = smallobject;//Colocamos el objeto en la posición
                this.smallobject = null;//Hacemos null el objeto que estaba dentro de Wall-E
            }
        }

        public override int Ultrasonic()
        {
            int contador = 0; //Creamos un contador con el que llevaremos la cantidad de espacios vacíos frente a WallE
            for (int i = this.position.fill + this.direction.X, j = this.position.column + this.direction.Y; i >= 0 && i < this.simufield.fills && j >= 0 && j < this.simufield.columns; i += this.direction.X, j += this.direction.Y)//Mediante un for vamos por cada posición, si es null, aumentamos el contador, si no, lo devolvemos
            {
                if (this.simufield.simufield[i, j] == null)
                    contador++;//Si llegamos a un objeto devolvemos lo que llevamos contador
                else
                    return contador;
            }
            return contador;//Si el for termina, significa que llegamos a los límites del simufield, por tanto, devolvemos el contador       
        }

        public override int Webcam()
        {//Si está en un límite o lo que está delante es null, devolvemos 0
            if (this.position.fill + direction.X < 0 || this.position.fill + direction.X >= this.simufield.fills || this.position.column + direction.Y < 0 || this.position.column + direction.Y >= this.simufield.columns || this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] == null)
                return 0;
            else //En otro caso devolvemos el atributo correspondiente
                return this.simufield.simufield[this.position.fill - 1, this.position.column].Color.Number;
        }

        public override int Kinect()
        {//Si está en un límite o lo que está delante es null, devolvemos 0
            if (this.position.fill + direction.X < 0 || this.position.fill + direction.X >= this.simufield.fills || this.position.column + direction.Y < 0 || this.position.column + direction.Y >= this.simufield.columns || this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] == null)
                return 0;
            else //En otro caso devolvemos el atributo correspondiente
                return this.simufield.simufield[this.position.fill - 1, this.position.column].Shape.Number;
        }

        public override int BarcodeScanner()
        {
            //Si está en un límite o lo que está delante es null, devolvemos 0
            if (this.position.fill + direction.X < 0 || this.position.fill + direction.X >= this.simufield.fills || this.position.column + direction.Y < 0 || this.position.column + direction.Y >= this.simufield.columns || this.simufield.simufield[this.position.fill + direction.X, this.position.column + direction.Y] == null)
                return 0;
            else //En otro caso devolvemos el atributo correspondiente
                return this.simufield.simufield[this.position.fill - 1, this.position.column].Code;
        }

        public override int Weight() //Devuelve 1 si hay un objeto dentro del robot y 0 si no
        {
            if (this.smallobject == null)
                return 0;
            else
                return 1;
        }

        public override int Chronometer() //Devuelve el tiempo de vida del robot
        {
            return this.time;
        }

        public override int Compass()//Devuelve el número correspondiente a la dirección del robot
        {
            return this.direction.Number;
        }

        public override AllObject Clone()//Esta propiedad devuelve el objeto sin referencias
        {
            return new WallE(this.shape, this.size, this.color, this.code, this.direction.Clone(), null, null, this.runtimes);
        }

        public override void StringChanger(string Word)
        {
            if (Word == null)
                throw new Exception("No puedes ingresar una palabra vacía en el robot");
            this.message = Word;
        }
    }
}