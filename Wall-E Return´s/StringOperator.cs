using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    static class StringOperator //Esta clase estática está hecha solo para realizar operaciones matemáticos con grandes números en forma de strings
    {
        public static string StringMultiplication(string a, string b) //Aquí estará el método para multiplicar strings
        {
            if (a[0] != '0' && a[0] != '1' && a[0] != '2' && a[0] != '3' && a[0] != '4' && a[0] != '5' && a[0] != '6' && a[0] != '7' && a[0] != '8' && a[0] != '9' && a[0] != '-')
                throw new Exception("Ambos valores deben ser números");
            if (b[0] != '0' && b[0] != '1' && b[0] != '2' && b[0] != '3' && b[0] != '4' && b[0] != '5' && b[0] != '6' && b[0] != '7' && b[0] != '8' && b[0] != '9' && b[0] != '-')
                throw new Exception("Ambos valores deben ser números");

            for (int i = 1; i < a.Length; i++) //Primero revisamos que ambos string sean números
            {
                if (a[i] != '0' && a[i] != '1' && a[i] != '2' && a[i] != '3' && a[i] != '4' && a[i] != '5' && a[i] != '6' && a[i] != '7' && a[i] != '8' && a[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }
            for (int i = 1; i < b.Length; i++)
            {
                if (b[i] != '0' && b[i] != '1' && b[i] != '2' && b[i] != '3' && b[i] != '4' && b[i] != '5' && b[i] != '6' && b[i] != '7' && b[i] != '8' && b[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }
            bool negative = false; //Mediante este bool sabremos si el resultado que debemos devolver es negativo o positivo
            if (a[0] == '-') //Simplemente, si alguno de los dos en su posición 0 tiene el menos
            {
                if (negative == false) //Cambiamos el estado del bool y le quitamos el -
                {
                    negative = true;
                    a = a.Substring(1, a.Length - 1);
                }
                else
                {
                    negative = false;
                    a = a.Substring(1, a.Length - 1);
                }
            }
            if (b[0] == '-')
            {
                if (negative == false)
                {
                    negative = true;
                    b = b.Substring(1, b.Length - 1);
                }
                else
                {
                    negative = false;
                    b = b.Substring(1, b.Length - 1);
                }
            }
            string Result = "0"; //Lo primero es crear el string que será la multiplicación de ambos números
            string c = "";  //Luego creamos una variable que nos ayudará más tarde... en plan la mousekerramienta misteriosa
            int counter = 0; //Iniciamos nuestro clásico contador que nos dirá cuánto debemos sumarle al número multiplicado
            //Para no volvernos locos, lo que haremos será un método que multiplique cualquier número por otro de una cifra, y luego, lo multiplicamos cifra por cifra

            for (int i = 0; i < b.Length; i++) //Este será el for que pasará cifra por cifra del segundo número
            {

                c = ""; //Reiniciamos c
                        //Aquí estará el método (por así decirlo) que multiplicará el primer número, por una de las cifras del segundo
                a = "0" + a; //Le sumamos un cero adelante, para facilitar el caso donde se obtenga un número mayor que a

                for (int k = 1; k <= a.Length; k++) //Este será el for que haga la multiplicación de strings
                {

                    int Multiple = 0; //Inicializamos una variable en 0, que se reiniciará con cada iteración
                    Multiple = int.Parse(a[a.Length - k].ToString()) * int.Parse(b[i].ToString());

                    if (counter > 0)
                    {
                        Multiple = Multiple + counter; //Si nuestro contador está por encima de 0, lo sumamos a la multiplicación y luego lo reiniciamos
                        counter = 0;
                    }
                    if (Multiple > 9) //Si nuestro múltiplo excedió 9, significa que hay tiene más de una cifra
                    {
                        counter = Multiple / 10; //Nuestro contador será igual a la cifra de las decenas
                        Multiple = Multiple % 10; //Y nuestro múltiplo se quedará en 1 cifra
                    }

                    c = Multiple.ToString() + c; //Y le sumaremos esa cifra al múltiplo... he aquí nuestra mousekerramiento misteriosa


                }

                if (int.Parse(c[0].ToString()) == 0 && c.Length != 1) //Si la primera cifra sigue siendo 0, entonces el número obtenido no fue mayor que el anterior, sin embargo, 00 X 0 = 0, por tanto, esto solo se cumple si tiene más de una cifra, por eso la segunda condicional
                    c = c.Substring(1, c.Length - 1); //Devolvemos el número sin ese cero

                for (int n = b.Length - 1 - i; n > 0; n--) //Esta operación nos ayudará a sumar cifra obtenida por cifra obtenida más fácilmente
                {
                    c = c + "0";
                }

                Result = StringAddition(Result, c);

            }
            if (negative == false) //Si el número era positivo lo devolvemos tras pasarle por el método Limpiar
                return Clean(Result);
            else
            {
                string h = Clean(Result); //Guardamos Result sin los ceros adicionales
                if (h[0] == '0')
                    return "0";
                else
                    return "-" + Clean(Result);
            }
        }

        public static string StringAddition(string a, string b) //Aquí estará el método para sumar strings
        {
            bool negative = false;
            if (a[0] == '-' && b[0] == '-') //Si ambos números son negativos, sería lo mismo que sumarlos, le quitamos los - y se los devolvemos al final
            {
                a = a.Substring(1, a.Length - 1);
                b = b.Substring(1, b.Length - 1);
                negative = true;
            }
            else
            {
                if (a[0] == '-')
                {
                    a = a.Substring(1, a.Length - 1);
                    return StringSustraction(b, a);
                }
                if (b[0] == '-')
                {
                    b = b.Substring(1, b.Length - 1);
                    return StringSustraction(a, b);
                }
            }

            for (int i = 0; i < a.Length; i++) //Primero revisamos que ambos string sean números
            {
                if (a[i] != '0' && a[i] != '1' && a[i] != '2' && a[i] != '3' && a[i] != '4' && a[i] != '5' && a[i] != '6' && a[i] != '7' && a[i] != '8' && a[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] != '0' && b[i] != '1' && b[i] != '2' && b[i] != '3' && b[i] != '4' && b[i] != '5' && b[i] != '6' && b[i] != '7' && b[i] != '8' && b[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }

            if (a.Length > b.Length) //Con estos dos if, si alguno de los dos números es mayor que el otro, entonces, súmandole ceros a la izquierda al menor, lo igualamos al mayor
            {
                int Tam = b.Length; //Esta variable se crea puesto que va a ser modificado más tarde el Length de b
                for (int i = 0; i < a.Length - Tam; i++)
                {
                    b = "0" + b;
                }
            }
            if (a.Length < b.Length)
            {
                int Tam = a.Length;
                for (int i = 0; i < b.Length - Tam; i++)
                {
                    a = "0" + a;
                }
            } //Si son iguales no entra a ninguno de los dos if

            a = "0" + a;
            b = "0" + b; //A ambos números se le agrega un cero a la izquierda, puesto que si no se hiciera, más tarde sería complicado saber si la suma de ambos números da una cifra mayor que ambos

            string result = ""; //Iniciamos el string que será la suma de ambos strings
            int counter = 0; //Este contador nos ayudará más tarde

            for (int i = a.Length - 1; i >= 0; i--) //Hacemos un for que vaya desde la última posición del string a la primera
            {
                int d = 0; //Iniciamos dentro del for un número entero, lo hacemos al principio porque necesitamos que se reinicie en cada iteración

                d = int.Parse(Convert.ToString(a[i])) + int.Parse(Convert.ToString(b[i])); //Los valores que queremos sumar son char, por tanto, los convertimos a string y luego a int

                if (counter == 1) //Si el contador está en 1, quiere decir que debemos sumar 1
                {
                    d = d + 1; //Se lo sumamos
                    counter--; //Y luego devolvemos el contador a 0
                }


                if (d > 9) //Si el número es mayor que 9, necesitamos dejarlo en 1 cifra y aumentar el contador para que sepa que debemos agregarle 1 al próximo número
                {
                    d = d % 10; //Dejamos el resto del número como el entero que necesitamos

                    counter++; //Si el número excedió 9, entonces, le aumentamos 1 al contador
                }

                result = Convert.ToString(d) + result; //Sumamos cifra por cifra al string
            }
            if (negative == false) //En caso de que ambos números no hubieran sido negativos
                return Clean(result); //Retornamos finalmente el resultado luego de limpiarlo
            else //En caso de que lo fueran, los devolvemos negativos
                return "-" + Clean(result);
        }
        public static string StringSustraction(string a, string b)
        {
            bool negative = false; //Este bool nos indicará más tarde si el número que devolvemos es negativo o positivo
            if (a[0] == '-' && b[0] == '-') //Si ambos números son negativos (-a - -b), anulamos el menos del operador con el de b, y restamos a de b
            {
                a = a.Substring(1, a.Length - 1);
                b = b.Substring(1, b.Length - 1);
                return StringSustraction(b, a);
            }
            else
            {
                if (a[0] == '-') //Si solo a es negativo, es equivalente a sumarlos ambos y entregarlos negativos
                {
                    a = a.Substring(a.Length - 1);
                    return "-" + StringAddition(a, b);
                }
                if (b[0] == '-') //Si solo b en negativo, anulamos el menos del operador con el de b y los sumamos
                {
                    b = b.Substring(1, b.Length - 1);
                    return StringAddition(a, b);
                }
                if (StringHigher(b, a)) //En caso de que el segundo sea mayor que el primero, debemos intercambiarlos y poner negativo el resultado
                    return "-" + StringSustraction(b, a);
            }
            if (a[0] != '0' && a[0] != '1' && a[0] != '2' && a[0] != '3' && a[0] != '4' && a[0] != '5' && a[0] != '6' && a[0] != '7' && a[0] != '8' && a[0] != '9' && a[0] != '-')
                throw new Exception("Ambos valores deben ser números");
            if (b[0] != '0' && b[0] != '1' && b[0] != '2' && b[0] != '3' && b[0] != '4' && b[0] != '5' && b[0] != '6' && b[0] != '7' && b[0] != '8' && b[0] != '9' && b[0] != '-')
                throw new Exception("Ambos valores deben ser números");

            for (int i = 1; i < a.Length; i++) //Primero revisamos que ambos string sean números
            {
                if (a[i] != '0' && a[i] != '1' && a[i] != '2' && a[i] != '3' && a[i] != '4' && a[i] != '5' && a[i] != '6' && a[i] != '7' && a[i] != '8' && a[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }
            for (int i = 1; i < b.Length; i++)
            {
                if (b[i] != '0' && b[i] != '1' && b[i] != '2' && b[i] != '3' && b[i] != '4' && b[i] != '5' && b[i] != '6' && b[i] != '7' && b[i] != '8' && b[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }

            if (a.Length > b.Length) //Con estos dos if, si alguno de los dos números es mayor que el otro, entonces, súmandole ceros a la izquierda al menor, lo igualamos al mayor
            {
                int Tam = b.Length; //Esta variable se crea puesto que va a ser modificado más tarde el Length de b
                for (int i = 0; i < a.Length - Tam; i++)
                {
                    b = "0" + b;
                }
            }
            if (a.Length < b.Length)
            {
                int Tam = a.Length;
                for (int i = 0; i < b.Length - Tam; i++)
                {
                    a = "0" + a;
                }
            }

            string result = ""; //Iniciamos el string que será la resta de ambos strings
            int counter = 0; //Este contador nos ayudará más tarde

            for (int i = a.Length - 1; i >= 0; i--) //Hacemos un for que vaya desde la última posición del string a la primera
            {
                int d = 0; //Iniciamos dentro del for un número entero, lo hacemos al principio porque necesitamos que se reinicie en cada iteración

                d = int.Parse(Convert.ToString(a[i])) - int.Parse(Convert.ToString(b[i])); //Los valores que queremos sumar son char, por tanto, los convertimos a string y luego a int

                if (counter == 1) //Si el contador está en 1, quiere decir que debemos restar 1
                {
                    d = d - 1; //Se lo sumamos
                    counter--; //Y luego devolvemos el contador a 0
                }


                if (d < 0) //Si el número es menor que 0, necesitamos restárselo a 10 y aumentar el contador para que sepa que debemos restarle 1 al próximo número
                {
                    if (i != 0)
                    {
                        d = 10 + d; //Dejamos la resta de 10 y el número como el entero que necesitamos
                        counter++; //Como el número fue negativo, debemos aumentar el contador
                    }
                    else
                    {
                        d = d * -1;
                        negative = true;
                    }

                }
                result = Convert.ToString(d) + result; //Sumamos cifra por cifra al string
            }
            if (negative == false)
                return Clean(result); //Retornamos finalmente el resultado luego de limpiarlo
            else
                return "-" + Clean(result);
        }

        private static string Clean(string a) //Con este método quitamos todos los ceros a la izquierda que queden en el número
        {
            int temporal = a.Length;

            for (int i = 0; i < temporal - 1; i++)
            {
                if (int.Parse(a[0].ToString()) == 0)
                {
                    a = a.Substring(1, a.Length - 1);
                }
            }
            return a;
        }

        public static bool StringHigher(string a, string b)
        {//Con Higher nos referimos a (a > b), como si fueran int
            if (a[0] != '0' && a[0] != '1' && a[0] != '2' && a[0] != '3' && a[0] != '4' && a[0] != '5' && a[0] != '6' && a[0] != '7' && a[0] != '8' && a[0] != '9' && a[0] != '-')
                throw new Exception("Ambos valores deben ser números");
            if (b[0] != '0' && b[0] != '1' && b[0] != '2' && b[0] != '3' && b[0] != '4' && b[0] != '5' && b[0] != '6' && b[0] != '7' && b[0] != '8' && b[0] != '9' && b[0] != '-')
                throw new Exception("Ambos valores deben ser números");

            for (int i = 1; i < a.Length; i++) //Primero revisamos que ambos string sean números
            {
                if (a[i] != '0' && a[i] != '1' && a[i] != '2' && a[i] != '3' && a[i] != '4' && a[i] != '5' && a[i] != '6' && a[i] != '7' && a[i] != '8' && a[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }
            for (int i = 1; i < b.Length; i++)
            {
                if (b[i] != '0' && b[i] != '1' && b[i] != '2' && b[i] != '3' && b[i] != '4' && b[i] != '5' && b[i] != '6' && b[i] != '7' && b[i] != '8' && b[i] != '9')
                    throw new Exception("Ambos valores deben ser números");
            }
            if (a[0] != '-' && b[0] != '-')
            {
                if (a.Length > b.Length) //Si el tamaño del primer número es mayor, entonces el número es mayor
                    return true;
                if (a.Length < b.Length) //En caso de que sea menor, entonces este número es el menor
                    return false;
                //En caso de que sus tamaños sean iguales, solo resta compararlos de izquierda a derecha hasta encontrar cuál es mayor, si ambos son iguales también se entrega false

                for (int i = 0; i < a.Length; i++) //Recorremos ambos string
                {
                    if (int.Parse(a[i].ToString()) > int.Parse(b[i].ToString())) //Casteando cada uno de sus dígitos, los comparamos y devolvemos un valor dependiendo de la comparación
                        return true;
                    if (int.Parse(a[i].ToString()) < int.Parse(b[i].ToString()))
                        return false;
                }
                return false;//En caso de que sean iguales devolvemos falso
            }
            else //Si alguno de los números es negativo, debemos revisar las distintas posibilidades
            {
                if (a[0] == '-' && b[0] == '-') //Si ambos números son negativos, simplemente invertimos lo que devolvemos
                {
                    a = a.Substring(1, a.Length - 1);
                    b = b.Substring(1, b.Length - 1);

                    if (a.Length > b.Length)
                        return false;
                    if (a.Length < b.Length)
                        return true;

                    for (int i = 0; i < a.Length; i++)
                    {
                        if (int.Parse(a[i].ToString()) > int.Parse(b[i].ToString()))
                            return false;
                        if (int.Parse(a[i].ToString()) < int.Parse(b[i].ToString()))
                            return true;
                    }
                    return false;//En caso de que sean iguales devolvemos falso
                }
                else //Si los dos no son números negativos ni números positivos a la vez, entonces tienen signos opuestos
                {
                    if (a[0] == '-') //Si a es negativo, devolvemos falso puesto que es menor
                        return false;
                    else //Si no es él, entonces b es negativo y devolvemos true
                        return true;
                }
            }
        }
    }
}
