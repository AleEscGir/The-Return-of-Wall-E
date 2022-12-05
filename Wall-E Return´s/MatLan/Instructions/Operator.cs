using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wall_E_Return_s
{
    public abstract class Operator : Instruction
    {
        public Operator(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
        }
    }

    public class Number : Operator
    {
        public Number(Robot robot, Matlanland matfield) : base(robot, matfield)
        {//Operador #
            this.number = 7;
        }

        public override void Execute()
        {//Apila el valor 0
            if (this.robot.stack.Count == 1000000)
                throw new Exception("Pila sobrecargada. Ha sobrepasado el millón de elementos. Instrucción Number no puede ser ejecutada");
            this.robot.stack.Push(0);
        }

        public override Instruction Clone()
        {
            return new Number(null, null);
        }
    }
    public class Zero : Operator
    {//Operador 0
        public Zero(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 8;
        }

        public override void Execute()
        {//Extrae un valor de la pila y coloca el doble del mismo
            if (this.robot.stack.Count == 0)
                throw new Exception("Pila vacía. Instrucción Cero no puede ser ejecutado");
            int a = this.robot.stack.Pop(); //Tomamos el valor y verificamos que no sobrepase 1000000000 (mil millones)
            if (StringOperator.StringHigher("1000000000", StringOperator.StringMultiplication(a.ToString(), "2")) == false)
                throw new Exception("Operación inválida, un valor ha excedido 1000000000, instrucción Cero no puede ser ejecutada");
            //Básicamente, StringHigher compara con la multiplicación del valor de la pila, si lo sobrepasa, lanzamos una excepción
            this.robot.stack.Push(a * 2); //En caso de que no lo sobrepasa, colocamos los valores en la pila normalmente
        }

        public override Instruction Clone()
        {
            return new Zero(null, null);
        }
    }
    public class One : Operator
    {//Operador 1
        public One(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 9;
        }

        public override void Execute()
        {//Extrae el valor de la pila y coloca el doble incrementado en 1
            if (this.robot.stack.Count == 0)
                throw new Exception("Pila vacía. Instrucción Uno no puede ser ejecutado");
            int a = this.robot.stack.Pop(); //Tomamos el valor y verificamos que no sobrepase 1000000000 (mil millones)
            if (StringOperator.StringHigher("1000000000", StringOperator.StringAddition((StringOperator.StringMultiplication(a.ToString(), "2")), "1")) == false)
                throw new Exception("Operación inválida, un valor ha excedido 1000000000, Instrucción Uno no puede ser ejecutada");
            //Básicamente, StringHigher compara con la multiplicación del valor de la pila, si lo sobrepasa, lanzamos una excepción
            this.robot.stack.Push(a * 2 + 1); //En caso de que no lo sobrepasa, colocamos los valores en la pila normalmente
        }

        public override Instruction Clone()
        {
            return new One(null, null);
        }
    }

    public class Add : Operator
    {//Operador +
        public Add(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 10;

        }

        public override void Execute()
        {//Extraemos dos valores de la pila y colocamos la suma de ambos
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Instrucción Adición no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (StringOperator.StringHigher("1000000000", StringOperator.StringAddition(left.ToString(), right.ToString())) == false)
            throw new Exception("Operación inválida, un valor ha excedido 1000000000, instrucción Adición no puede ser ejecutada");
            this.robot.stack.Push(left + right);
        }

        public override Instruction Clone()
        {
            return new Add(null, null);
        }
    }

    public class Sub : Operator
    {//Operador -
        public Sub(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 11;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y colocamos la resta de ambos
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Instrucción Sustracción no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            //Aquí ocurre al revés, el valor que tengamos no puede ser menor que -1000000000
            if (StringOperator.StringHigher(StringOperator.StringSustraction(left.ToString(), right.ToString()), "-1000000000") == false)
                throw new Exception("Operación inválida, un valor ha caído por debajo de -1000000000, instrucción Sustracción no puede ser ejecutada");
            this.robot.stack.Push(left - right);
        }

        public override Instruction Clone()
        {
            return new Sub(null, null);
        }
    }

    public class Mul : Operator
    {//Operador *
        public Mul(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 12;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y colocamos la multiplicación de ambos
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Instrucción Multiplicación no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (StringOperator.StringHigher("1000000000", StringOperator.StringMultiplication(left.ToString(), right.ToString())) == false)
                throw new Exception("Operación inválida, un valor ha excedido 1000000000, instrucción Multiplicación no puede ser ejecutada");
            this.robot.stack.Push(left * right);
        }

        public override Instruction Clone()
        {
            return new Mul(null, null);
        }
    }

    public class Div : Operator
    {//Operador /
        public Div(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 13;
        }

        public override void Execute()
        {
            {//Extraemos dos valores de la pila y colocamos la división de ambos (mientras el denominador sea diferente de 0)
                if (this.robot.stack.Count < 2)
                    throw new Exception("Pila insuficiente. Instrucción División no puede ser ejecutada");
                int right = this.robot.stack.Pop();
                if (right == 0)
                    throw new Exception("División por 0. Instrucción División no puede ser ejecutada");
                int left = this.robot.stack.Pop();
                this.robot.stack.Push(left / right);
            }
        }
        public override Instruction Clone()
        {
            return new Div(null, null);
        }
    }

    public class Mod : Operator
    {//Operador %
        public Mod(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 14;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y colocamos el resto de la división de ambos
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción Resto no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            if (right == 0)
                throw new Exception("División por 0. Instrucción Resto no puede ser ejecutada");
            int left = this.robot.stack.Pop();
            this.robot.stack.Push(left % right);
        }

        public override Instruction Clone()
        {
            return new Mod(null, null);
        }
    }

    public class Inc : Operator
    {//Operador ++
        public Inc(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 15;
        }

        public override void Execute()
        {//Sacamos el valor de la pila y colocamos el mismo + 1
            if (this.robot.stack.Count == 0)
                throw new Exception("Pila vacía. Instrucción Incrementar no puede ser ejecutada");
            int a = this.robot.stack.Pop();
            if (StringOperator.StringHigher("1000000000", StringOperator.StringAddition(a.ToString(), "1")) == false)
                throw new Exception("Operación inválida, un valor ha excedido 1000000000, instrucción Incrementar no puede ser ejecutada");
            this.robot.stack.Push(a + 1);
        }
        public override Instruction Clone()
        {
            return new Inc(null, null);
        }
    }

    public class Dec : Operator
    {//Operador --
        public Dec(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 16;
        }

        public override void Execute()
        {
            //Sacamos el valor de la pila y colocamos el mismo - 1
            if (this.robot.stack.Count == 0)
                throw new Exception("Pila vacía. Instrucción Decrementar no puede ser ejecutada");
            int a = this.robot.stack.Pop();
            if (StringOperator.StringHigher((a - 1).ToString(), "-1000000000") == false)
                throw new Exception("Operación inválida, un valor ha caído por debajo de -1000000000, instrucción Decrementar no puede ser ejecutada");
            this.robot.stack.Push(a - 1);
        }
        public override Instruction Clone()
        {
            return new Dec(null, null);
        }
    }

    public class Land : Operator
    {//Operador &
        public Land(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 27;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y colocamos el resultado de la operación entre ambos
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción & no puede ser ejecutada");

            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            this.robot.stack.Push(left & right);
        }
        public override Instruction Clone()
        {
            return new Land(null, null);
        }
    }

    public class Lor : Operator
    {//Operador |
        public Lor(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 28;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y colocamos el resultado de la operación entre ambos
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción | no puede ser ejecutada");

            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            this.robot.stack.Push(left | right);
        }
        public override Instruction Clone()
        {
            return new Lor(null, null);
        }
    }

    public class Lxor : Operator
    {//Operador ^
        public Lxor(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 29;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y colocamos el resultado de la operación entre ambos
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción ^ no puede ser ejecutada");

            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            this.robot.stack.Push(left ^ right);
        }
        public override Instruction Clone()
        {
            return new Lxor(null, null);
        }
    }

    public class Lnot : Operator
    {//Operador ~
        public Lnot(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 30;
        }

        public override void Execute() //Si el número tiene como valor de la verdad 1 lo vuelve 0 y viceversa
        {
            if (this.robot.stack.Count == 0)
                throw new Exception("Pila vacía. Intrucción ~ no puede ser ejecutada");
            this.robot.stack.Push(~(this.robot.stack.Pop()));
        }
        public override Instruction Clone()
        {
            return new Lnot(null, null);
        }
    }

    public class And : Operator
    {//Operador &&
        public And(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 24;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción && no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (right == 0 || left == 0)//Si uno de los dos valores es 0, el && devuelve 0 (falso), en otro caso devuelve 1 (verdadero)
                this.robot.stack.Push(0);
            else
                this.robot.stack.Push(1);
        }
        public override Instruction Clone()
        {
            return new And(null, null);
        }
    }

    public class Or : Operator
    {//Operador ||
        public Or(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 25;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción || no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (right != 0 || left != 0) //Si uno de los dos valores es 1, el || devuelve 1 (verdadero), en otro caso devuelve 0 (falso)
                this.robot.stack.Push(1);
            else
                this.robot.stack.Push(0);
        }
        public override Instruction Clone()
        {
            return new Or(null, null);
        }
    }

    public class Not : Operator
    {//Operador !
        public Not(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 26;
        }

        public override void Execute()
        {
            if (this.robot.stack.Count == 0)
                throw new Exception("Pila vacía. Intrucción ! no puede ser ejecutada");
            int temp = this.robot.stack.Pop(); //Sacamos el valor de la pila
            if (temp == 0) //Si el valor es 0 (falso), colocamos 1 en la pila (verdadero)
                this.robot.stack.Push(1);
            else //Si el valor es 1 (verdadero), colcoamos 0 en la pila (falso)
                this.robot.stack.Push(0);

        }
        public override Instruction Clone()
        {
            return new Not(null, null);
        }
    }

    public class Eq : Operator
    {//Operador ==
        public Eq(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 23;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y si ambos son iguales, colocamos 1 en la pila (verdadero), en caso contrario colocamos 0 (falso)
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción == no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (right == left)
                this.robot.stack.Push(1);
            else
                this.robot.stack.Push(0);
        }
        public override Instruction Clone()
        {
            return new Eq(null, null);
        }
    }

    public class Neq : Operator
    {//Operador !=
        public Neq(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 18;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y si ambos son diferentes, colocamos 1 en la pila (verdadero),, en caso contrario colocamos 0 (falso)
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción != no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (right != left)
                this.robot.stack.Push(1);
            else
                this.robot.stack.Push(0);
        }
        public override Instruction Clone()
        {
            return new Neq(null, null);
        }
    }

    public class Lt : Operator
    {//Operador <
        public Lt(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 19;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y si el primero es menor que el segundo, colocamos 1 en la pila (verdadero),, en caso contrario colocamos 0 (falso)
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción < no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (left < right)
                this.robot.stack.Push(1);
            else
                this.robot.stack.Push(0);
        }
        public override Instruction Clone()
        {
            return new Lt(null, null);
        }
    }

    public class Leq : Operator
    {//Operador <=
        public Leq(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 20;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y si el primero es menor o igual que el segundo, colocamos 1 en la pila (verdadero),, en caso contrario colocamos 0 (falso)
            if (this.robot.stack.Count < 2)
                throw new Exception("Pila insuficiente. Intrucción <= no puede ser ejecutada");
            int right = this.robot.stack.Pop();
            int left = this.robot.stack.Pop();
            if (left <= right)
                this.robot.stack.Push(1);
            else
                this.robot.stack.Push(0);
        }
        public override Instruction Clone()
        {
            return new Leq(null, null);
        }
    }

    public class Gt : Operator
    {//Operador >
        public Gt(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 21;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y si el primero es mayor que el segundo, colocamos 1 en la pila (verdadero),, en caso contrario colocamos 0 (falso)
                if (this.robot.stack.Count < 2)
                    throw new Exception("Pila insuficiente. Intrucción > no puede ser ejecutada");
                int right = this.robot.stack.Pop();
                int left = this.robot.stack.Pop();
                if (left > right)
                    this.robot.stack.Push(1);
                else
                    this.robot.stack.Push(0);
            }
        public override Instruction Clone()
        {
            return new Gt(null, null);
        }
    }

    public class Geq : Operator
    {//Operador >=
        public Geq(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 22;
        }

        public override void Execute()
        {//Extraemos dos valores de la pila y si el primero es mayor o igual que el segundo, colocamos 1 en la pila (verdadero),, en caso contrario colocamos 0 (falso)
                if (this.robot.stack.Count < 2)
                    throw new Exception("Pila insuficiente. Intrucción <= no puede ser ejecutada");
                int right = this.robot.stack.Pop();
                int left = this.robot.stack.Pop();
                if (left >= right)
                    this.robot.stack.Push(1);
                else
                    this.robot.stack.Push(0);
            }
        public override Instruction Clone()
        {
            return new Geq(null, null);
        }
    }

    public class Ternary : Operator
    {//Operador ?
        public Ternary(Robot robot, Matlanland matfield) : base(robot, matfield)
        {
            this.number = 17;
        }

        public override void Execute() //Este es el operador ternario
        {
                if (this.robot.stack.Count < 3)
                    throw new Exception("Pila insuficiente. Intrucción Ternaria no puede ser ejecutada");
            int falsevalue = this.robot.stack.Pop(); //El primer valor que sacamos es el falso
            int truevalue = this.robot.stack.Pop(); //El segundo valor que sacamos es el verdadero
            if (this.robot.stack.Pop() != 0) //Si es diferente de 0, entonces es verdadero, si no es falso
                this.robot.stack.Push(truevalue); //En caso de ser verdadero colocamos el truevalue
            else
                this.robot.stack.Push(falsevalue); //En caso de ser falso colocamos el falsevalue
        }
        public override Instruction Clone()
        {
            return new Ternary(null, null);
        }
    }
}
