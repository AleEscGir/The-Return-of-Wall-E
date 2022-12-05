using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Shape
    {
        int number;
        string name;

        public Shape(int number, string name)
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

    public class SphereForm : Shape
    {
        public SphereForm() : base(1, "Sphere")
        {
        }
    }

    public class BoxForm : Shape
    {
        public BoxForm() : base (2, "Box")
        {
        }
    }

    public class PlantForm : Shape
    {
        public PlantForm() : base (3, "Plant")
        {
        }
    }

    public class RobotForm : Shape
    {
        public RobotForm() : base(4, "Robot")
        {
        }
    }
}

