using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Size
    {
        int number;
        string name;

        public Size(int number, string name)
        {
            this.number = number;
            this.name = name;
        }
        public int Number
        {
            get
            {
                return this.number;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        } 
    }

    public class Small : Size
    {
        public Small() : base (1, "Small")
        {
        }
    }

    public class Medium : Size
    {
        public Medium(): base(2, "Medium")
        {
        }
    }

    public class Large : Size
    {
        public Large() : base(3, "Large")
        {
        }
    }
}
