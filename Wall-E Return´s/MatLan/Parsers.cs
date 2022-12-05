using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Se agrega esta librería para cargar archivos

namespace Wall_E_Return_s
{
    public class MatlanChargerParser
    {//Esta clase es el Parser con el que podemos cargar una rutina, trabaja simulando un diccionario, teniendo uno real por detrás
        private Dictionary<string, Instruction> parser;
        public MatlanChargerParser()
        {
            this.parser = new Dictionary<string, Instruction>();
        }

        //Para no obligar al usuario a implementar nuestras palabras con instrucciones, le damos a elegir mediante un método algunas palabras para ingresar por default
        public void AgregateSpecialInstructionDefaultWords() //Palabras referidas a SpecialInstructions
        {
            this.parser.Add("start", new Start(null, null));
            this.parser.Add("return", new Return(null, null));
            this.parser.Add("print", new Print(null, null));
    }

        public void AgregateCommandDefaultWords() //Palabras referidas a Command
        {
            this.parser.Add("forward", new Forward(null, null));
            this.parser.Add("backward", new Backward(null, null));
            this.parser.Add("right", new Right(null, null));
            this.parser.Add("left", new Left(null, null));
            this.parser.Add("drop", new Drop(null, null));
        }

        public void AgregateOperatorWords() //Palabras referidas a Operators
        {
            this.parser.Add("number", new Number(null, null));
            this.parser.Add("zero", new Zero(null, null));
            this.parser.Add("one", new One(null, null));
            this.parser.Add("add", new Add(null, null));
            this.parser.Add("sub", new Sub(null, null));
            this.parser.Add("mul", new Mul(null, null));
            this.parser.Add("div", new Div(null, null));
            this.parser.Add("mod", new Mod(null, null));
            this.parser.Add("inc", new Inc(null, null));
            this.parser.Add("dec", new Dec(null, null));
            this.parser.Add("land", new Land(null, null));
            this.parser.Add("lor", new Lor(null, null));
            this.parser.Add("lxor", new Lxor(null, null));
            this.parser.Add("lnot", new Lnot(null, null));
            this.parser.Add("and", new And(null, null));
            this.parser.Add("or", new Or(null, null));
            this.parser.Add("not", new Not(null, null));
            this.parser.Add("eq", new Eq(null, null));
            this.parser.Add("neq", new Neq(null, null));
            this.parser.Add("lt", new Lt(null, null));
            this.parser.Add("leq", new Leq(null, null));
            this.parser.Add("gt", new Gt(null, null));
            this.parser.Add("geq", new Geq(null, null));
            this.parser.Add("ternary", new Ternary(null, null));
        }

        public void AgregateLinealMemoryDefaultWords() //Palabras referidas a LinealMemorys
        {
            this.parser.Add("getAt", new GetAt(null, null));
            this.parser.Add("setAt", new SetAt(null, null));
        }

        public void AgregateSensorWords() //Palabras referidas a Sensors
        {
            this.parser.Add("distance", new Ultrasonic(null, null));
            this.parser.Add("color", new Webcam(null, null));
            this.parser.Add("shape", new Kinect(null, null));
            this.parser.Add("code", new BarcodeScanner(null, null));
            this.parser.Add("loaded", new Weight(null, null));
            this.parser.Add("time", new Chronometer(null, null));
            this.parser.Add("direction", new Compass(null, null));
        }

        public void AgregateFlowControllerWords() //Palabras referidas a FlowControllers
        {
            this.parser.Add("NE", new NE(null, null));
            this.parser.Add("SE", new SE(null, null));
            this.parser.Add("NW", new NW(null, null));
            this.parser.Add("SW", new SW(null, null));
            this.parser.Add("branch", new Branch(null, null));
            this.parser.Add("TS", new TS(null, null));
            this.parser.Add("TE", new TE(null, null));
            this.parser.Add("TN", new TN(null, null));
            this.parser.Add("TW", new TW(null, null));
        }

        public void AgregateRoutineWords() //Palabras referidas a Routines
        {
            this.parser.Add("call", new Call(null, null));
            this.parser.Add("routine", new Routine(null, null));
            this.parser.Add("recCall", new ReCall(null, null));
        }

        public void AgregateSetLetterWords() //Palabras referidas a la instrucción SetLetter
        {
            this.parser.Add("setA", new SetLetter(null, null, 'a'));
            this.parser.Add("setB", new SetLetter(null, null, 'b'));
            this.parser.Add("setC", new SetLetter(null, null, 'c'));
            this.parser.Add("setD", new SetLetter(null, null, 'd'));
            this.parser.Add("setE", new SetLetter(null, null, 'e'));
            this.parser.Add("setF", new SetLetter(null, null, 'f'));
            this.parser.Add("setG", new SetLetter(null, null, 'g'));
            this.parser.Add("setH", new SetLetter(null, null, 'h'));
            this.parser.Add("setI", new SetLetter(null, null, 'i'));
            this.parser.Add("setJ", new SetLetter(null, null, 'j'));
            this.parser.Add("setK", new SetLetter(null, null, 'k'));
            this.parser.Add("setL", new SetLetter(null, null, 'l'));
            this.parser.Add("setM", new SetLetter(null, null, 'm'));
            this.parser.Add("setN", new SetLetter(null, null, 'n'));
            this.parser.Add("setÑ", new SetLetter(null, null, 'ñ'));
            this.parser.Add("setO", new SetLetter(null, null, 'o'));
            this.parser.Add("setP", new SetLetter(null, null, 'p'));
            this.parser.Add("setQ", new SetLetter(null, null, 'q'));
            this.parser.Add("setR", new SetLetter(null, null, 'r'));
            this.parser.Add("setS", new SetLetter(null, null, 's'));
            this.parser.Add("setT", new SetLetter(null, null, 't'));
            this.parser.Add("setU", new SetLetter(null, null, 'u'));
            this.parser.Add("setV", new SetLetter(null, null, 'v'));
            this.parser.Add("setW", new SetLetter(null, null, 'w'));
            this.parser.Add("setX", new SetLetter(null, null, 'x'));
            this.parser.Add("setY", new SetLetter(null, null, 'y'));
            this.parser.Add("setZ", new SetLetter(null, null, 'z'));
        }

        public void AgregateGetLetterWords() //Palabras referidas a la instrucción GetLetter
        {
            this.parser.Add("getA", new GetLetter(null, null, 'a'));
            this.parser.Add("getB", new GetLetter(null, null, 'b'));
            this.parser.Add("getC", new GetLetter(null, null, 'c'));
            this.parser.Add("getD", new GetLetter(null, null, 'd'));
            this.parser.Add("getE", new GetLetter(null, null, 'e'));
            this.parser.Add("getF", new GetLetter(null, null, 'f'));
            this.parser.Add("getG", new GetLetter(null, null, 'g'));
            this.parser.Add("getH", new GetLetter(null, null, 'h'));
            this.parser.Add("getI", new GetLetter(null, null, 'i'));
            this.parser.Add("getJ", new GetLetter(null, null, 'j'));
            this.parser.Add("getK", new GetLetter(null, null, 'k'));
            this.parser.Add("getL", new GetLetter(null, null, 'l'));
            this.parser.Add("getM", new GetLetter(null, null, 'm'));
            this.parser.Add("getN", new GetLetter(null, null, 'n'));
            this.parser.Add("getÑ", new GetLetter(null, null, 'ñ'));
            this.parser.Add("getO", new GetLetter(null, null, 'o'));
            this.parser.Add("getP", new GetLetter(null, null, 'p'));
            this.parser.Add("getQ", new GetLetter(null, null, 'q'));
            this.parser.Add("getR", new GetLetter(null, null, 'r'));
            this.parser.Add("getS", new GetLetter(null, null, 's'));
            this.parser.Add("getT", new GetLetter(null, null, 't'));
            this.parser.Add("getU", new GetLetter(null, null, 'u'));
            this.parser.Add("getV", new GetLetter(null, null, 'v'));
            this.parser.Add("getW", new GetLetter(null, null, 'w'));
            this.parser.Add("getX", new GetLetter(null, null, 'x'));
            this.parser.Add("getY", new GetLetter(null, null, 'y'));
            this.parser.Add("getZ", new GetLetter(null, null, 'z'));
        }

        public void Add(string key, Instruction value)
        { //Para añadir una palabra necesitamos que nos entre un key y un value, que deben ser diferentes de null
            if (key == null || key == "" || value == null)
                throw new Exception("No puedes ingresar palabras ni instrucciones vacías");

            foreach (string x in parser.Keys)
            {
                if (key == x)
                    throw new Exception("No puedes ingresar dos palabras iguales");
            }

            this.parser.Add(key, value);
        }

        public Instruction CreateInstruction(string key) //Aquí podemos devolver una palabra a partir de un key
        {
            if (!parser.ContainsKey(key))//Primero revisamos que el objeto se encuentre en el diccionario
                throw new Exception("Palabra no aceptada");
            else
            return this.parser[key].Clone();
        }
    }

    public class MatlanSaverParser
    {//Esta clase es el Parser con el que podemos salvar una rutina, trabaja simulando un diccionario, teniendo uno real por detrás
        private Dictionary<int, string> parser;
        public MatlanSaverParser()
        {
            this.parser = new Dictionary<int, string>();
        }

        //Para no obligar al usuario a implementar nuestros números con string, le damos a elegir mediante un método algunas palabras para ingresar por default
        public void AgregateSpecialInstructionDefaultWords() //Números referidas a SpecialInstructions
        {
            this.parser.Add(new Start(null, null).number, "start");
            this.parser.Add(new Return(null,null).number, "return");
            this.parser.Add(new Print(null, null).number, "print");
        }

        public void AgregateCommandDefaultWords() //Palabras referidas a Command
        {
            this.parser.Add(new Forward(null, null).number, "forward");
            this.parser.Add(new Backward(null, null).number, "backward");
            this.parser.Add(new Right(null, null).number, "right");
            this.parser.Add(new Left(null, null).number, "left");
            this.parser.Add(new Drop(null, null).number, "drop");
        }

        public void AgregateOperatorWords() //Palabras referidas a Operators
        {
            this.parser.Add(new Number(null, null).number, "number");
            this.parser.Add(new Zero(null, null).number, "zero");
            this.parser.Add(new One(null, null).number, "one");
            this.parser.Add(new Add(null, null).number, "add");
            this.parser.Add(new Sub(null, null).number, "sub");
            this.parser.Add(new Mul(null, null).number, "mul");
            this.parser.Add(new Div(null, null).number, "div");
            this.parser.Add(new Mod(null, null).number, "mod");
            this.parser.Add(new Inc(null, null).number, "inc");
            this.parser.Add(new Dec(null, null).number, "dec");
            this.parser.Add(new Land(null, null).number, "land");
            this.parser.Add(new Lor(null, null).number, "lor");
            this.parser.Add(new Lxor(null, null).number, "lxor");
            this.parser.Add(new Lnot(null, null).number, "lnot");
            this.parser.Add(new And(null, null).number, "and");
            this.parser.Add(new Or(null, null).number, "or");
            this.parser.Add(new Not(null, null).number, "not");
            this.parser.Add(new Eq(null, null).number, "eq");
            this.parser.Add(new Neq(null, null).number, "neq");
            this.parser.Add(new Lt(null, null).number, "lt");
            this.parser.Add(new Leq(null, null).number, "leq");
            this.parser.Add(new Gt(null, null).number, "gt");
            this.parser.Add(new Geq(null, null).number, "geq");
            this.parser.Add(new Ternary(null, null).number, "ternary");
        }

        public void AgregateLinealMemoryDefaultWords() //Palabras referidas a LinealMemorys
        {
            this.parser.Add(new GetAt(null, null).number, "getAt");
            this.parser.Add(new SetAt(null, null).number, "setAt");
        }

        public void AgregateSensorWords() //Palabras referidas a Sensors
        {
            this.parser.Add(new Ultrasonic(null, null).number, "distance");
            this.parser.Add(new Webcam(null, null).number, "color");
            this.parser.Add(new Kinect(null, null).number, "shape");
            this.parser.Add(new BarcodeScanner(null, null).number, "code");
            this.parser.Add(new Weight(null, null).number, "loaded");
            this.parser.Add(new Chronometer(null, null).number, "time");
            this.parser.Add(new Compass(null, null).number, "direction");
        }

        public void AgregateFlowControllerWords() //Palabras referidas a FlowControllers
        {
            this.parser.Add(new NE(null, null).number, "NE");
            this.parser.Add(new SE(null, null).number, "SE");
            this.parser.Add(new NW(null, null).number, "NW");
            this.parser.Add(new SW(null, null).number, "SW");
            this.parser.Add(new Branch(null, null).number, "branch");
            this.parser.Add(new TS(null, null).number, "TS");
            this.parser.Add(new TE(null, null).number, "TE");
            this.parser.Add(new TN(null, null).number, "TN");
            this.parser.Add(new TW(null, null).number, "TW");
        }

        public void AgregateRoutineWords() //Palabras referidas a Routines
        {
            this.parser.Add(new Call(null, null).number, "call");
            this.parser.Add(new Routine(null, null).number, "routine");
            this.parser.Add(new ReCall(null, null).number, "recCall");
        }

        public void AgregateSetLetterWords() //Palabras referidas a la instrucción SetLetter
        {
            this.parser.Add(new SetLetter(null, null, 'a').number, "setA");
            this.parser.Add(new SetLetter(null, null, 'b').number, "setB");
            this.parser.Add(new SetLetter(null, null, 'c').number, "setC");
            this.parser.Add(new SetLetter(null, null, 'd').number, "setD");
            this.parser.Add(new SetLetter(null, null, 'e').number, "setE");
            this.parser.Add(new SetLetter(null, null, 'f').number, "setF");
            this.parser.Add(new SetLetter(null, null, 'g').number, "setG");
            this.parser.Add(new SetLetter(null, null, 'h').number, "setH");
            this.parser.Add(new SetLetter(null, null, 'i').number, "setI");
            this.parser.Add(new SetLetter(null, null, 'j').number, "setJ");
            this.parser.Add(new SetLetter(null, null, 'k').number, "setK");
            this.parser.Add(new SetLetter(null, null, 'l').number, "setL");
            this.parser.Add(new SetLetter(null, null, 'm').number, "setM");
            this.parser.Add(new SetLetter(null, null, 'n').number, "setN");
            this.parser.Add(new SetLetter(null, null, 'ñ').number, "setÑ");
            this.parser.Add(new SetLetter(null, null, 'o').number, "setO");
            this.parser.Add(new SetLetter(null, null, 'p').number, "setP");
            this.parser.Add(new SetLetter(null, null, 'q').number, "setQ");
            this.parser.Add(new SetLetter(null, null, 'r').number, "setR");
            this.parser.Add(new SetLetter(null, null, 's').number, "setS");
            this.parser.Add(new SetLetter(null, null, 't').number, "setT");
            this.parser.Add(new SetLetter(null, null, 'u').number, "setU");
            this.parser.Add(new SetLetter(null, null, 'v').number, "setV");
            this.parser.Add(new SetLetter(null, null, 'w').number, "setW");
            this.parser.Add(new SetLetter(null, null, 'x').number, "setX");
            this.parser.Add(new SetLetter(null, null, 'y').number, "setY");
            this.parser.Add(new SetLetter(null, null, 'z').number, "setZ");
        }

        public void AgregateGetLetterWords() //Palabras referidas a la instrucción GetLetter
        {
            this.parser.Add(new GetLetter(null, null, 'a').number, "getA");
            this.parser.Add(new GetLetter(null, null, 'b').number, "getB");
            this.parser.Add(new GetLetter(null, null, 'c').number, "getC");
            this.parser.Add(new GetLetter(null, null, 'd').number, "getD");
            this.parser.Add(new GetLetter(null, null, 'e').number, "getE");
            this.parser.Add(new GetLetter(null, null, 'f').number, "getF");
            this.parser.Add(new GetLetter(null, null, 'g').number, "getG");
            this.parser.Add(new GetLetter(null, null, 'h').number, "getH");
            this.parser.Add(new GetLetter(null, null, 'i').number, "getI");
            this.parser.Add(new GetLetter(null, null, 'j').number, "getJ");
            this.parser.Add(new GetLetter(null, null, 'k').number, "getK");
            this.parser.Add(new GetLetter(null, null, 'l').number, "getL");
            this.parser.Add(new GetLetter(null, null, 'm').number, "getM");
            this.parser.Add(new GetLetter(null, null, 'n').number, "getN");
            this.parser.Add(new GetLetter(null, null, 'ñ').number, "getÑ");
            this.parser.Add(new GetLetter(null, null, 'o').number, "getO");
            this.parser.Add(new GetLetter(null, null, 'p').number, "getP");
            this.parser.Add(new GetLetter(null, null, 'q').number, "getQ");
            this.parser.Add(new GetLetter(null, null, 'r').number, "getR");
            this.parser.Add(new GetLetter(null, null, 's').number, "getS");
            this.parser.Add(new GetLetter(null, null, 't').number, "getT");
            this.parser.Add(new GetLetter(null, null, 'u').number, "getU");
            this.parser.Add(new GetLetter(null, null, 'v').number, "getV");
            this.parser.Add(new GetLetter(null, null, 'w').number, "getW");
            this.parser.Add(new GetLetter(null, null, 'x').number, "getX");
            this.parser.Add(new GetLetter(null, null, 'y').number, "getY");
            this.parser.Add(new GetLetter(null, null, 'z').number, "getZ");
        }

        public void Add(int key, string value)
        { //Para añadir una palabra necesitamos que nos entre un key y un value, que deben ser diferentes de null
            if (value == null || value != null)
                throw new Exception("No puedes ingresar palabras vacías");

            foreach (int x in parser.Keys)
            {
                if (key == x)
                    throw new Exception("No puedes ingresar dos números iguales");
            }

            this.parser.Add(key, value);
        }

        public string CreateString(int key) //Aquí podemos devolver una palabra a partir de un key
        {
            if (!parser.ContainsKey(key))//Primero revisamos que el objeto se encuentre en el diccionario
                throw new Exception("Palabra no aceptada");
            else
                return this.parser[key];
        }
    }
    }
