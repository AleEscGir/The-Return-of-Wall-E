using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Color //Esta clase solo existe para que puedan ser agregados más colores...
    {
        string name;//Tiene el nombre del color y el número que tiene asociado
        int number;

        public Color(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }
        }
    }

    public class Red : Color
    {
        public Red() : base ("Red", 1)
        {
        }
    }

    public class Yellow : Color
    {
        public Yellow(): base("Yellow", 2)
        {
        }
    }

    public class Green : Color
    {
        public Green() : base("Green", 3)
        {
        }
    }

    public class Blue : Color
    {
        public Blue() : base("Blue", 4)
        {
        }
    }

    public class Brown : Color
    {
        public Brown() : base("Brown", 5)
        {
        }
    }

    public class Black : Color
    {
        public Black() : base("Black", 6)
        {
        }
    }

    public class White : Color
    {
        public White() : base("White", 7)
        {
        }
    }
}
