using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public class EnglishSpanishTraductor
    {//Esta clase sirve solamente como traductor, trabaja simulando un diccionario, teniendo uno real por detrás
        private Dictionary<string, string> traductor;
        public EnglishSpanishTraductor()
        {
            this.traductor = new Dictionary<string, string>();
        }

        //Para no obligar al usuario a implementar nuestras palabras, le damos a elegir mediante un método algunas palabras para ingresar por default
        public void AgregateColorsDefaultWords() //Palabras referidas a colores
        {
            this.Add("Red", "Rojo");
            this.Add("Yellow", "Amarillo");
            this.Add("Green", "Verde");
            this.Add("Blue", "Azul");
            this.Add("Brown", "Marrón");
            this.Add("White", "Blanco");
            this.Add("Black", "Negro");
        }

        public void AgregateSizesDefaultWords() //Palabras referidas a tamaños
        {
            this.Add("Small", "Pequeño");
            this.Add("Medium", "Mediano");
            this.Add("Large", "Grande");
        }

        public void AgregateShapesDefaultWords() //Palabras referidas a formas
        {
            this.Add("Robot", "Robot");
            this.Add("Plant", "Planta");
            this.Add("Box", "Caja");
            this.Add("Sphere", "Esfera");
        }

        public void AgregateDirectionsDefaultWords() //Palabras referidas a direcciones
        {
            this.Add("North", "Norte");
            this.Add("East", "Este");
            this.Add("West", "Oeste");
            this.Add("Sourth", "Sur");
        }

        public void Add(string key, string value)
        { //Para añadir una palabra necesitamos que nos entre un key y un value, que deben ser diferentes de null
            if (key == null || key == "" || value == null || value == "")
                throw new Exception("No puedes ingresar palabras vacías");

            foreach(string x in traductor.Keys)
            {
                if (key == x)
                    throw new Exception("No puedes ingresar dos palabras iguales");
            }

            this.traductor.Add(key, value);
        }

        public string Traduce(string key) //Aquí podemos devolver una palabra a partir de un key
        {
            if (!traductor.ContainsKey(key))//Primero revisamos que el objeto se encuentre en el diccionario
                throw new Exception("Palabra no aceptada");
            else
                return this.traductor[key];
        }


    }
}