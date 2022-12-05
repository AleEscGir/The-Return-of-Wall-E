using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    class Program
    {
        static void Main(string[] args)
        {
            //Constructor del Simuland: fila, columna
            //Contructor del WallE : int shape, int size, int color, int code, int direction, Position position, Simuland simufield
            //AddMatlanland: int fills, int columns, int Cursorfill, int Cursorcolumn
            //a.runtimes: Rutinas del robot (donde 0 es la principal y las demás son las subrutinas
            //AddInstruction: Instruction a, int fill, int column
            //Contructor de Instruction: Robot robot, Matlanland matfield
            //Constructor de esferas int shape, int size, int color, int code, Simuland simufield, Position position
            //Constructor de cajas: int shape, int size, int color, int code, Simuland simufield, Position position



            Simuland simufield = new Simuland(10, 10);

            WallE w1 = new WallE(new RobotForm(), new Large(), new Red(), 1, new Sourth(), null, null);
            w1.AddMatlanland(7, 1);
            w1.RemoveMatlanland(0);
            w1.runtimes[0].AddInstruction(new Start(null, null), 0, 0);
            w1.runtimes[0].AddInstruction(new Forward(null, null), 1, 0);
            w1.runtimes[0].AddInstruction(new Forward(null, null), 2, 0);
            w1.runtimes[0].AddInstruction(new Backward(null, null), 4, 0);
            w1.runtimes[0].AddInstruction(new Drop(null, null), 5, 0);
            w1.runtimes[0].AddInstruction(new Right(null, null), 6, 0);
            simufield.AddAllObject(w1, 2, 2);

            //Ponerle al robot un método que añada una nueva instrucción


            WallE w3 = new WallE(new RobotForm(), new Large(), new Green(), 2, new Sourth(), null, null);
            w3.AddMatlanland(7, 1);
            w3.RemoveMatlanland(0);
            w3.runtimes[0].AddInstruction(new Start(null, null), 0, 0);
            w3.runtimes[0].AddInstruction(new Forward(null, null), 1, 0);
            w3.runtimes[0].AddInstruction(new Forward(null, null), 2, 0);
            w3.runtimes[0].AddInstruction(new Backward(null, null), 3, 0);
            w3.runtimes[0].AddInstruction(new Drop(null, null), 5, 0);
            w3.runtimes[0].AddInstruction(new Right(null, null), 6, 0);
            simufield.AddAllObject(w3, 7, 7);

            WallE w4 = new WallE(new RobotForm(), new Large(), new Yellow(), 3, new Sourth(), null, null);
            w4.AddMatlanland(7, 1);
            w4.RemoveMatlanland(0);
            w4.runtimes[0].AddInstruction(new Start(null, null), 0, 0);
            w4.runtimes[0].AddInstruction(new Forward(null, null), 1, 0);
            w4.runtimes[0].AddInstruction(new Forward(null, null), 2, 0);
            w4.runtimes[0].AddInstruction(new Backward(null, null), 3, 0);
            w4.runtimes[0].AddInstruction(new Drop(null, null), 5, 0);
            w4.runtimes[0].AddInstruction(new Right(null, null), 6, 0);
            simufield.AddAllObject(w4, 5, 5);

            Box c = new Box(new BoxForm(), new Small(), new Red(), 1, null, null);
            simufield.AddAllObject(c, 5, 6);

            Box d = new Box(new BoxForm(), new Small(), new Red(), 2, null, null);
            simufield.AddAllObject(d, 5, 3);

            Box l = new Box(new BoxForm(), new Small(), new Red(), 3, null, null);
            simufield.AddAllObject(l, 6, 3);

            Sphere e = new Sphere(new SphereForm(), new Small(), new Red(), 4, null, null);
            simufield.AddAllObject(e, 4, 8);

            Sphere f = new Sphere(new SphereForm(), new Small(), new Red(), 5, null, null);
            simufield.AddAllObject(f, 4, 5);

            Sphere j = new Sphere(new SphereForm(), new Small(), new Red(), 6, null, null);
            simufield.AddAllObject(j, 6, 7);

            Plant g = new Plant(new PlantForm(), new Small(), new Red(), 7, null, null);
            //simufield.AddAllObject(g, 5, 2);

            Plant h = new Plant(new PlantForm(), new Small(), new Red(), 8, null, null);
            //simufield.AddAllObject(h, 2, 5);

            Plant k = new Plant(new PlantForm(), new Small(), new Red(), 9, null, null);
            //simufield.AddAllObject(k, 5, 1);

             while (1 > 0)
             {
                 for (int i = 0; i < 20000000; i++)
                 {
                 }
                 Print(simufield);
                 simufield.RobotTurn();
             }
        }

        public static void Print(Simuland simufield)
        {
            Console.Clear();
            for (int i = 0; i < simufield.fills; i++)
            {
                for (int j = 0; j < simufield.columns; j++)
                {
                    if (simufield.simufield[i, j] == null)
                    {
                        Console.Write(0);
                        Console.Write(" ");
                    }
                    else
                    {
                        if(simufield.simufield[i,j] is Robot)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("R");
                            Console.ResetColor();
                            Console.Write(" ");
                        }
                        if(simufield.simufield[i,j] is Box)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.Write("B");
                            Console.ResetColor();
                            Console.Write(" ");
                        }
                        if (simufield.simufield[i, j] is Sphere)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("S");
                            Console.ResetColor();
                            Console.Write(" ");
                        }
                        if (simufield.simufield[i, j] is Plant)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("P");
                            Console.ResetColor();
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        //Para trabajar con txt:
        /*
        StreamWriter s = new StreamWriter("C/Algoahí");
        s.WriteLine("Algo");
        s.Flush();
        */
    }
}