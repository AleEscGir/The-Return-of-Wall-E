using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class AllObject
    {
        //Esta clase comprende todos los objetos que existen en el Entorno Simulado
        public Shape shape { get; protected set; }//Forma del objeto
        //0-Nothing
        //1-Sphere
        //2-Box
        //3-Plant
        //4-Robot
        public Size size { get; protected set; } //Tamaño del objeto
      //0-Empty
      //1-Small
      //2-Medium
      //3-Largue
        public Color color { get; protected set; } //Color del objeto
        //0-Transparent
        //1-Red
        //2-Yellow
        //3-Green
        //4-Blue
        //5-Brown
        //6-Black
        //7-Write
        public int code { get; protected set; } //Código de barra del objeto
        public AllObject(Shape shape, Size size, Color color, int code) //Constructor de la clase
        {
            //Conferimos los valores a las características del objeto
            this.shape = shape;
            this.size = size;
            this.color = color;
            this.code = code;
        }
        //Aquí tenemos los get de la clase
        public Shape Shape
        {
            get
            {
                return this.shape;
            }
        }

        public Size Size
        {
            get
            {
                return this.size;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
        }

        public int Code
        {
            get
            {
                return this.code;
            }
        }
        public abstract bool CanMove(Direction direction); //Esta propiedad le permite a un objeto saber si otro se puede mover
        public abstract AllObject Clone(); //Esta propiedad permite a los objetos hacer un clon de sí mismos sin referencias
    }
}
