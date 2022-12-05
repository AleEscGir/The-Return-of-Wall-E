using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Direction
    {//La clase Direction tiene como objetivo simplemente que cada dirección guarde su número correspondiente, el nombre de la dirección y el X y Y que corresponde a avanzar o retroceder en esa dirección
        int number;
        string name;
        int x;
        int y;

        public Direction(int number, string name, int x, int y)
        {
            this.number = number;
            this.name = name;
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
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

        public abstract Direction Clone();
    }

    public class North : Direction
    {
        public North() : base(0, "North", -1, 0)
        {
        }

        public override Direction Clone()
        {
            return new North();
        }
    }

    public class East : Direction
    {
        public East() : base(1, "East", 0, 1)
        {
        }

        public override Direction Clone()
        {
            return new East();
        }
    }

    public class Sourth : Direction
    {
        public Sourth() : base(2, "Sourth", 1, 0)
        {
        }
        public override Direction Clone()
        {
            return new Sourth();
        }
    }

    public class West : Direction
    {
        public West() : base(3, "West", 0, -1)
        {
        }
        public override Direction Clone()
        {
            return new Sourth();
        }
    }
}
