using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Wall_E_Return_s;

namespace WindowsFormsApplication1
{
    public partial class ObjectView : Form
    {
        private Obstacle obstacle; //En caso de que se haya iniciado con un obstáculo, se guardará aquí
        private Robot robot; //Y en caso de que sea un WallE, se guardará aquí
        private List<Matlanland> routines; //En caso de que sea un WallE, debemos tener su lista de rutinas
        private int actualroutine = 0; //Mediante este contador sabemos en que rutina nos encontramos
        private int fills = 1; //Aquí está la cantidad de filas para añadir un matlanland nuevo
        private int columns = 1;//Aquí está la cantidad de columnas para añadir un matlanland nuevo
        private bool AddRemoveInstructions = true;//Este bool indica si está presionado el botón Añadir (true) o el Remover (false)
        private Instruction instruction; //Esto indica qué instrucción es la que está en los RadioButtons 

        #region Constructor
        public ObjectView(AllObject a)
        {
            InitializeComponent();
            string startup = Application.StartupPath; //Aquí cargamos el directivo de la carpeta en al que se encuentran las imágenes
            if (a is Obstacle) //Revisamos qué es el objeto, y dependiendo de ello lo guardamos con especificaciones distintas
            {
                this.obstacle = (Obstacle)a;//Le damos al obstáculo el parámetro de entrada
                WFMatlanLandPanel.Enabled = false; //Hacemos que no sea manipulable ninguna de las cosas que permiten modificar el matlanland de los robot
                WFAddRutineGroupBox.Enabled = false;
                WFFlowGroupBox.Enabled = false;
                WFInstructionsGroupBox.Enabled = false;
                WFRobotObjectGroupBox.Enabled = false;
                WFSetRegistryGroupBox.Enabled = false;
                WFAddInstructionButton.Enabled = false;
                WFRemoveInstructionButton.Enabled = false;
                WFActualRoutineGroupBox.Enabled = false;
                WFSaveLoadGroupBox.Enabled = false;
                //Si es un obstáculo, cargamos su foto mediante el cógido shape + size + color
                WFObjectPictureBox.Image = Image.FromFile((startup + "\\Images\\" + (this.obstacle.shape.Number).ToString() + (this.obstacle.size.Number).ToString()) + (this.obstacle.color.Number).ToString() + ".png");
            }
            else
            {
                this.robot = (Robot)a; //Si es un WallE le damos el parámetro de entrada
                this.routines = this.robot.runtimes; //Copiamos por referencia el runtimes del robot para acceder más fácilmente a él
                WFFlowLabel.Text = "Sur"; //Colocamos el flujo en sur por defecto
                //Si es un Wall-E, cargamos su foto mediante el código 4 + direction + color
                WFObjectPictureBox.Image = Image.FromFile((startup + "\\Images\\" + "4" + "2" + (this.robot.color.Number).ToString() + ".png"));
                //Como lo que tenemos es un robot, debemos revisar si tiene un objeto dentro, y en ese caso pintarlo
                if (this.robot.smallobject != null)
                    WFRobotObjectPictureBox.Image = Image.FromFile((startup + "\\Images\\" + (this.robot.smallobject.shape.Number).ToString() + (this.robot.smallobject.size.Number).ToString()) + (this.robot.smallobject.color.Number).ToString() + ".png");
                WFActualRoutineNumeric.Maximum = this.robot.runtimes.Count - 1; //Debemos aumentar el máximo del numeric para poder acceder a todas las rutinas
            }
            //Luego le damos sus parámetros a los diferentes Label que indican las características del objeto
            EnglishSpanishTraductor traductor = new EnglishSpanishTraductor(); //Creamos un diccionario nuevo
            traductor.AgregateColorsDefaultWords(); //Le agregamos todas las palabras que necesitamos
            traductor.AgregateShapesDefaultWords();
            traductor.AgregateSizesDefaultWords();
            //Luego le damos sus parámetros a los diferentes Label que indican las características del objeto
            WFObjectCodeLabel.Text = a.Code.ToString();
            WFObjectColorLabel.Text = traductor.Traduce(a.Color.Name);
            WFObjectSizeLabel.Text = traductor.Traduce(a.Size.Name);
            WFObjectShapeLabel.Text = traductor.Traduce(a.Shape.Name);
        }

        #endregion

        #region Value Changeds
        private void WFFillsNumeric_ValueChanged(object sender, EventArgs e) //Este Numeric es el encargado de designar la cantidad de filas para agregar o modificar una rutina
        {
            this.fills = (int)WFFillsNumeric.Value;
        }

        private void WFColumnNumeric_ValueChanged(object sender, EventArgs e) //Este Numeric hace lo mismo que el anterior pero con las columnas
        {
            this.columns = (int)WFColumnNumeric.Value;
        }

        private void WFActualRoutineNumeric_ValueChanged(object sender, EventArgs e)//Este numeric es el encargado de designar en qué rutina nos encontramos actualmente
        {
            this.actualroutine = (int)WFActualRoutineNumeric.Value;
            WFMatlanlandPictureBox.Refresh(); //Luego de cambiar el valor debemos reiniciar el Picture Box
        }

        #endregion

        #region Radio Buttons
        //Los RadioButtons funcionarán con un array de Length 55 donde cada posición indica una instrucción diferente
        //Cada Radio Button coloca en true su posición luego de rehacer el array
        private void WFForwardRadioButton_CheckedChanged(object sender, EventArgs e)
        {//0
            if (WFForwardRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Forward(null, null);
            }
        }

        private void WFBackwardRadioButton_CheckedChanged(object sender, EventArgs e)
        {//1
            if (WFBackwardRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Backward(null, null);
            }
        }

        private void WFRightRadioButton_CheckedChanged(object sender, EventArgs e)
        {//2
            if (WFRightRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Right(null, null);
            }
        }

        private void WFLeftRadioButton_CheckedChanged(object sender, EventArgs e)
        {//3
            if (WFLeftRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Left(null, null);
            }
        }

        private void WFObjectActionRadioButton_CheckedChanged(object sender, EventArgs e)
        {//4
            if (WFObjectActionRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Drop(null, null);
            }
        }

        private void WFStartRadioButton_CheckedChanged(object sender, EventArgs e)
        {//5
            if (WFStartRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Start(null, null);
            }
        }

        private void WFReturnRadioButton_CheckedChanged(object sender, EventArgs e)
        {//6
            if (WFReturnRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Return(null, null);
            }
        }

        private void WFNumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {//7
            if (WFNumberRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Number(null, null);
            }
        }

        private void WFZeroRadioButton_CheckedChanged(object sender, EventArgs e)
        {//8
            if (WFZeroRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Zero(null, null);
            }
        }

        private void WFOneRadioButton_CheckedChanged(object sender, EventArgs e)
        {//9
            if (WFOneRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new One(null, null);
            }
        }

        private void WFAddRadioButton_CheckedChanged(object sender, EventArgs e)
        {//10
            if (WFAddRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Add(null, null);
            }
        }

        private void WFSubRadioButton_CheckedChanged(object sender, EventArgs e)
        {//11
            if (WFSubRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Sub(null, null);
            }
        }

        private void WFMulRadioButton_CheckedChanged(object sender, EventArgs e)
        {//12
            if (WFMulRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Mul(null, null);
            }
        }

        private void WFDivRadioButton_CheckedChanged(object sender, EventArgs e)
        {//13
            if (WFDivRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Div(null, null);
            }
        }

        private void WFModRadioButton_CheckedChanged(object sender, EventArgs e)
        {//14
            if (WFModRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Mod(null, null);
            }
        }

        private void WFIncRadioButton_CheckedChanged(object sender, EventArgs e)
        {//15
            if (WFIncRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Inc(null, null);
            }
        }

        private void WFDecRadioButton_CheckedChanged(object sender, EventArgs e)
        {//16
            if (WFDecRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Dec(null, null);
            }
        }

        private void WFTernaryRadioButton_CheckedChanged(object sender, EventArgs e)
        {//17
            if (WFTernaryRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Ternary(null, null);
            }
        }

        private void WFNotEqualsRadioButton_CheckedChanged(object sender, EventArgs e)
        {//18
            if (WFNotEqualsRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Neq(null, null);
            }
        }

        private void WFLtRadioButton_CheckedChanged(object sender, EventArgs e)
        {//19
            if (WFLtRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Lt(null, null);
            }
        }

        private void WFLeqRadioButton_CheckedChanged(object sender, EventArgs e)
        {//20
            if (WFLeqRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Leq(null, null);
            }
        }

        private void WFGtRadioButton_CheckedChanged(object sender, EventArgs e)
        {//21
            if (WFGtRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Gt(null, null);
            }
        }

        private void WFGeqRadioButton_CheckedChanged(object sender, EventArgs e)
        {//22
            if (WFGeqRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Geq(null, null);
            }
        }

        private void WFEqualsRadioButton_CheckedChanged(object sender, EventArgs e)
        {//23
            if (WFEqualsRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Eq(null, null);
            }
        }

        private void WFAndRadioButton_CheckedChanged(object sender, EventArgs e)
        {//24
            if (WFAndRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new And(null, null);
            }
        }

        private void WFOrRadioButton_CheckedChanged(object sender, EventArgs e)
        {//25
            if (WFOrRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Or(null, null);
            }
        }

        private void WFNotRadioButton_CheckedChanged(object sender, EventArgs e)
        {//26
            if (WFNotRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Not(null, null);
            }
        }

        private void WFLandRadioButton_CheckedChanged(object sender, EventArgs e)
        {//27
            if (WFLandRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Land(null, null);
            }
        }

        private void WFLorRadioButton_CheckedChanged(object sender, EventArgs e)
        {//28
            if (WFLorRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Lor(null, null);
            }
        }

        private void WFLxorRadioButton_CheckedChanged(object sender, EventArgs e)
        {//29
            if (WFLxorRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Lxor(null, null);
            }
        }
        private void WFLNotRadioButton_CheckedChanged(object sender, EventArgs e)
        {//30
            if (WFLNotRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Lnot(null, null);
            }
        }

        private void WFGetRegistryRadioButton_CheckedChanged(object sender, EventArgs e)
        {//31
            if (WFGetRegistryRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new GetLetter(null, null, 'a'); //Le pasamos a por pasarle algún valor
            }
        }

        private void WFSetRegistryRadioButton_CheckedChanged(object sender, EventArgs e)
        {//32
            if (WFSetRegistryRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new SetLetter(null, null, 'a');
            }
        }

        private void WFGetAtLinealMemoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {//33
            if (WFGetAtLinealMemoryRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new GetAt(null, null);
            }
        }

        private void WFSetAtLinealMemoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {//34
            if (WFSetAtLinealMemoryRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new SetAt(null, null);
            }
        }

        private void WFUltrasonicRadioButton_CheckedChanged(object sender, EventArgs e)
        {//35
            if (WFUltrasonicRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Ultrasonic(null, null);
            }
        }

        private void WFWebcamRadioButton_CheckedChanged(object sender, EventArgs e)
        {//36
            if (WFWebcamRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Webcam(null, null);
            }
        }

        private void WFKinectRadioButton_CheckedChanged(object sender, EventArgs e)
        {//37
            if (WFKinectRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Kinect(null, null);
            }
        }

        private void WFBarcodeScanerRadioButton_CheckedChanged(object sender, EventArgs e)
        {//38
            if (WFBarcodeScanerRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new BarcodeScanner(null, null);
            }
        }

        private void WFWeightRadioButton_CheckedChanged(object sender, EventArgs e)
        {//39
            if (WFWeightRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Weight(null, null);
            }
        }

        private void WFChronometerRadioButton_CheckedChanged(object sender, EventArgs e)
        {//40
            if (WFChronometerRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Chronometer(null, null);
            }
        }

        private void WFCompassRadioButton_CheckedChanged(object sender, EventArgs e)
        {//41
            if (WFCompassRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Compass(null, null);
            }
        }

        private void WFNorthEastRadioButton_CheckedChanged(object sender, EventArgs e)
        {//42
            if (WFNorthEastRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new NE(null, null);
            }
        }

        private void WFSourthEastRadioButton_CheckedChanged(object sender, EventArgs e)
        {//43
            if (WFSourthEastRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new SE(null, null);
            }
        }

        private void WFNorthWestRadioButton_CheckedChanged(object sender, EventArgs e)
        {//44
            if (WFNorthWestRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new NW(null, null);
            }
        }

        private void WFSourthWestRadioButton_CheckedChanged(object sender, EventArgs e)
        {//45
            if (WFSourthWestRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new SW(null, null);
            }
        }

        private void WFBranchRadioButton_CheckedChanged(object sender, EventArgs e)
        {//46
            if (WFBranchRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Branch(null, null);
            }
        }

        private void WFTSRadioButton_CheckedChanged(object sender, EventArgs e)
        {//47
            if (WFTSRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new TS(null, null);
            }
        }

        private void WFTERadioButton_CheckedChanged(object sender, EventArgs e)
        {//48
            if (WFTERadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new TE(null, null);
            }
        }

        private void WFTNRadioButton_CheckedChanged(object sender, EventArgs e)
        {//49
            if (WFTNRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new TN(null, null);
            }
        }

        private void WFTWRadioButton_CheckedChanged(object sender, EventArgs e)
        {//50
            if (WFTWRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new TW(null, null);
            }
        }

        private void WFCallRadioButton_CheckedChanged(object sender, EventArgs e)
        {//51
            if (WFCallRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Call(null, null);
            }
        }

        private void WFReCallRadioButton_CheckedChanged(object sender, EventArgs e)
        {//52
            if (WFReCallRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new ReCall(null, null);
            }
        }

        private void WFRoutineRadioButton_CheckedChanged(object sender, EventArgs e)
        {//53
            if (WFRoutineRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Routine(null, null);
            }
        }

        private void WFPrintRadioButton_CheckedChanged(object sender, EventArgs e)
        {//54
            if (WFPrintRadioButton.Checked) //Revisamos si fue elegido
            {
                this.instruction = new Print(null, null);
            }
        }

        #endregion

        #region MatlanLand Picture Box
        private void WFMatlanlandPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.robot != null)
            {
                Graphics g = e.Graphics; //Usamos esto para no pedir constantemente el Graphics de e
                SolidBrush b = new SolidBrush(System.Drawing.Color.White); //Creamos una brocha que pintará en blanco el fondo de las casillas

                g.FillRectangle(b, e.ClipRectangle); //Ni idea...

                Pen p = new Pen(System.Drawing.Color.Black, 1); //Creamos un lapiz que dibujará en negro las casillas

                float width = 60;//Le conferimos el largo y ancho a las casillas
                float height = 60;

                WFMatlanlandPictureBox.Height = this.routines[this.actualroutine].fills * 60;
                WFMatlanlandPictureBox.Width = this.routines[this.actualroutine].columns * 60;

                for (int i = 1; i < this.routines[this.actualroutine].columns; i++) //Dibujamos las rayas verticales
                {
                    g.DrawLine(p, i * width - 1, 0, i * width - 1, WFMatlanlandPictureBox.Height);
                }

                for (int i = 1; i < this.routines[this.actualroutine].fills; i++)//Dibujamos las rayas horizontales
                {
                    g.DrawLine(p, 0, i * height - 1, WFMatlanlandPictureBox.Width, i * height - 1);
                }
                string startup = Application.StartupPath; //Aquí cargamos el directivo de la carpeta en al que se encuentran las imágenes
                for (int i = 0; i < this.routines[this.actualroutine].fills; i++) //Aquí buscamos en todas las posiciones del matlanland para pintar en el panel lo que haya en él
                {
                    for (int j = 0; j < this.routines[this.actualroutine].columns; j++)
                    {
                        if (this.routines[this.actualroutine].matfield[i, j] != null) //Si el matlanland la posición no es null, entonces hay una instrucción en él
                        {
                            //Si encontramos un instrucción, cargamos su foto, revisando primero si es un registro
                            if (this.routines[this.actualroutine].matfield[i, j] is Registry) //Los registro se cargan mediante: Número del Registro + "-" + letra del registro
                            {//Pero para lograrlo debemos guardar el número y mediante substring colocarle el "-" entre los dos primeros números y el resto
                                string number = this.routines[this.actualroutine].matfield[i, j].number.ToString();
                                number = number.Substring(0, 2) + "-" + number.Substring(2, number.Length - 2);
                                g.DrawImage(Image.FromFile((startup + "\\Images\\" + number + ".png")), j * width, i * height, width - 1, height - 1);
                            }
                            else //El resto de las instrucciones se cargan normalmente mediante su número
                                g.DrawImage(Image.FromFile((startup + "\\Images\\" + this.routines[this.actualroutine].matfield[i, j].number.ToString() + ".png")), j * width, i * height, width - 1, height - 1);
                        }
                    }
                }
                WFFillsNumeric.Value = this.routines[this.actualroutine].fills; //Actualizamos la cantidad de filas y de columnas de los numeric
                WFColumnNumeric.Value = this.routines[this.actualroutine].columns;
            }
        }

        private void WFMatlanlandPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int i = e.Y / 60; //Mediante estos cálculos verificamos la posición del click
            int j = e.X / 60;

            if (this.AddRemoveInstructions == true) //Si tenemos el botón de añadir presionado, colocamos la instrucción en el Matlanland
            {
                if (this.instruction == null)
                {
                    MessageBox.Show("Debe elegir una instrucción");
                    return;
                }

                if (this.routines[this.actualroutine].matfield[i, j] != null) //Si en la posición ya existe una instrucción debemos removerla primero
                {
                    MessageBox.Show("Ya existe una instrucción en ese sitio, retírela si desea colocar otro");
                    return;
                }
                else
                {//si no hay ninguna, vemos cuál debemos colocar y la ponemos en el matlanland actual
                    if (this.instruction is Start) //En este caso, si elegimos un start, aseguramos que ya abrá otro, por tanto, simplmente lo cambiamos de lugar creando uno nuevo y borrando el anterior
                        for (int k = 0; k < this.routines[this.actualroutine].fills; k++)
                        {
                            for (int l = 0; l < this.routines[this.actualroutine].columns; l++) //Recorremos por filas y columnas hasta encontrar el que ya estaba
                            {
                                if (this.routines[this.actualroutine].matfield[k, l] != null && this.routines[this.actualroutine].matfield[k, l] is Start)
                                {
                                    this.routines[this.actualroutine].RemoveInstruction(k, l); //Borramos el start anterior
                                }
                            }
                        }
                    if (this.instruction is Registry)//En caso de que sea un getletter o un set letter, primero debemos asegurarnos de que hay una letra mayúscula en el TextBox referente al Registro
                    {
                        if (WFRegistryInsertTextBox.Text != "A" && WFRegistryInsertTextBox.Text != "B" && WFRegistryInsertTextBox.Text != "C" && WFRegistryInsertTextBox.Text != "D" && WFRegistryInsertTextBox.Text != "E" && WFRegistryInsertTextBox.Text != "F" && WFRegistryInsertTextBox.Text != "G" && WFRegistryInsertTextBox.Text != "H" && WFRegistryInsertTextBox.Text != "I" && WFRegistryInsertTextBox.Text != "J" && WFRegistryInsertTextBox.Text != "K" && WFRegistryInsertTextBox.Text != "L" && WFRegistryInsertTextBox.Text != "M" && WFRegistryInsertTextBox.Text != "N" && WFRegistryInsertTextBox.Text != "Ñ" && WFRegistryInsertTextBox.Text != "O" && WFRegistryInsertTextBox.Text != "P" && WFRegistryInsertTextBox.Text != "Q" && WFRegistryInsertTextBox.Text != "R" && WFRegistryInsertTextBox.Text != "S" && WFRegistryInsertTextBox.Text != "T" && WFRegistryInsertTextBox.Text != "U" && WFRegistryInsertTextBox.Text != "V" && WFRegistryInsertTextBox.Text != "W" && WFRegistryInsertTextBox.Text != "X" && WFRegistryInsertTextBox.Text != "Y" && WFRegistryInsertTextBox.Text != "Z")
                        {
                            MessageBox.Show("Debe elegir una letra Mayúscula entre A y Z para el Registro");
                            return;
                        }
                        if (this.instruction is SetLetter)
                        {
                            //En caso de que sea válida la letra, creamos el SetLetter (para convertir de string a char, convertimos el string en un array de char y le pedimos la posición 0)
                            this.routines[this.actualroutine].AddInstruction(new SetLetter(null, null, ((WFRegistryInsertTextBox.Text.ToLower()).ToCharArray()[0])), i, j);
                        }

                        if (this.instruction is GetLetter) //Igual que en el anterior, revisamos si la letra es válida
                        {
                            //En caso de que sea válida la letra, creamos el SetLetter (para convertir de string a char, convertimos el string en un array de char y le pedimos la posición 0)
                            this.routines[this.actualroutine].AddInstruction(new GetLetter(null, null, ((WFRegistryInsertTextBox.Text.ToLower()).ToCharArray()[0])), i, j);
                        }
                    }
                    else
                    this.routines[this.actualroutine].AddInstruction(this.instruction, i, j); //En caso de que no sea Start o un Registry, colocamos la instrucción
                    }
                   }
                if (this.AddRemoveInstructions == false) //Si tenemos el botón de remover presionado, quitamos la instrucción del matlanland
                { 
                //En caso de que se quiera eliminar una instrucción, debemos revisar que no sea un Start, ya que no podemos eliminarlo
                if(this.routines[this.actualroutine].matfield[i,j] != null && this.routines[this.actualroutine].matfield[i, j] is Start)
                {
                    MessageBox.Show("No puede eliminar el Start, si quiere cambiarlo de lugar agregue en otra casilla y este automáticamente se borrará");
                    return;
                }
                    else //En caso de que no sea un Start simplemente removemos la instrucción
                    this.routines[this.actualroutine].RemoveInstruction(i, j);
                }
                WFMatlanlandPictureBox.Refresh();//Reiniciamos el panel
            }
    #endregion

        #region Buttons
    private void WFAddInstructionButton_Click(object sender, EventArgs e) //Este botón cambia el bool AddRemove
        {//para que se sepa al tocar el panel si se quiere añadir o remover una instrucción
            this.AddRemoveInstructions = true; //Cambiamos el bool
            WFAddInstructionButton.BackColor = System.Drawing.Color.DarkGray; //Cambiamos los colores de los botones para que se sepa cuál está presionado
            WFRemoveInstructionButton.BackColor = System.Drawing.Color.White;
        }

        private void WFRemoveInstructionButton_Click(object sender, EventArgs e) //Lo mismo que el anterior solo que al revés
        {
            this.AddRemoveInstructions = false;
            WFAddInstructionButton.BackColor = System.Drawing.Color.White;
            WFRemoveInstructionButton.BackColor = System.Drawing.Color.DarkGray;
        }

        private void WFChangeRoutinaButton_Click(object sender, EventArgs e) //Este botón permite modificar la rutina actual, cambiando sus proporciones
        {//Antes de cambiarle las proporciones a la rutina, debemos revisar que el usuario no elimine el Start en el proceso
            bool start = false;
            for(int i = 0; i < Math.Min(this.routines[actualroutine].fills, this.fills); i++)
            {
                for(int j = 0; j < Math.Min(this.routines[this.actualroutine].columns, this.columns); j++)
                {
                    if (this.routines[this.actualroutine].matfield[i, j] != null && this.routines[this.actualroutine].matfield[i, j] is Start)
                        start = true;
                }
            }
            if(start == true) //Si encontró un Start en los límites de la nueva matriz, entonces podemos rehacerla
            this.routines[this.actualroutine].Resize(this.fills, this.columns);
            //Llamamos al método Resize de la rutina, para rehacerla copiando las instrucciones
            else //Si no encontró ninguno debemos detener al usuario, puesto que si logra borrar el Start crearía un error
            {
                MessageBox.Show("No puede cambiar el tamaño de una rutina si elimina el Start");
                return;
            }
            WFMatlanlandPictureBox.Refresh();//Reiniciamos el panel
        }

        private void WFAddRoutineButton_Click(object sender, EventArgs e) //Este botón permite añadir una rutina mediante una cantidad de filas y columnas
        {
            this.robot.AddMatlanland(this.fills, this.columns); //Le añadimos a Wall-E una nueva rutina con la nueva cantidad de filas y columnas
            this.robot.runtimes[this.robot.runtimes.Count - 1].AddInstruction(new Start(null, null), 0, 0); //A esta nueva rutina que añadimos le colocamos en la posición 0,0 un Start
            WFActualRoutineNumeric.Maximum = this.routines.Count - 1; //Aumentamos el límite del Numeric referido a la rutina actual
            WFActualRoutineNumeric.Value = WFActualRoutineNumeric.Maximum; //Colocamos el numeric en la nueva rutina
            WFMatlanlandPictureBox.Refresh(); //Reiniciamos el Picture Box
        }

        private void WFRemoveRoutineButton_Click(object sender, EventArgs e) //Este botón elimina la rutina que esté en pantalla
        {
            if(this.routines.Count == 1) //En caso de que solo tengamos una rutina, lanzamos un mensaje y detenemos la ejecución
            {
                MessageBox.Show("No puede eliminar rutinas si solo tiene una");
                return;
            }
            this.robot.RemoveMatlanland(this.actualroutine); //Si tenemos más de una. eliminamos la actual
            WFActualRoutineNumeric.Value = 0; //Reiniciamos el numeric
            WFActualRoutineNumeric.Maximum--; //Disminuímos su tamaño máximo
            WFMatlanlandPictureBox.Refresh(); //Reiniciamos el Picture Box
        }
        private void WFLoadRoutine_Click(object sender, EventArgs e)
        {
            string directory = ""; //Creamos un string vacío que será aquel que guardará el directorio
            OpenFileDialog search = new OpenFileDialog(); //Creamos un OpenFileDialog
            if(search.ShowDialog() == DialogResult.OK) //Mediante su propiedad ShowDialog podemos abrir una ventana en la que el usuario puede elegir un archivo, donde le tomaremos el directorio para poder cargarlo
                directory = search.FileName; //Guardamos el directorio en nuestro string
                
            if (directory == "") //En caso de que el string esté vacío, debemos lanzar un MessageBox y detenemos el método
            {
                MessageBox.Show("Debe elegir un archivo");
                return;
            }

            try //Mediante un try controlamos las posibles excepciones que pueden lanzar
            {
                this.robot.AddMatlanland(directory); //Si no hay problema, llamamos la método del robot que crea una rutina a partir de un directorio
            }
            catch (Exception a) //En caso de que ocurra una excepción, exiten tresposibilidades
            {
                if (a is FormatException) //La primera es que sea debido a que eligieron un archivo no legible, por tanto, le avisamos al usuario de ello
                    MessageBox.Show("Debe elegir un archivo que sea legible(ej: .txt)");

                if (a is NullReferenceException)//La segunda es que hayan dado un números de instrucciones superior a la cantidad de instrucciones, en este caso el split dará un NullReferenceException
                    MessageBox.Show("El número de instrucciones descrito en la primera línea es superior a la cantidad de instrucciones para cargar");

                else //En caso de que no ocurran las anteriores, la otra posibilidad es que sea una excepción de AddMatland, por tanto, informamos al usuario de la excepción
                    MessageBox.Show(a.Message);

                return;
            }
                
            
            WFActualRoutineNumeric.Maximum = this.routines.Count - 1; //Aumentamos el límite del Numeric referido a la rutina actual
            WFActualRoutineNumeric.Value = WFActualRoutineNumeric.Maximum; //Colocamos el numeric en la nueva rutina
            WFMatlanlandPictureBox.Refresh(); //Reiniciamos el Picture Box
        }

        private void WFSaveRoutineButton_Click(object sender, EventArgs e)
        {
            string directory = ""; //Creamos un string vacío que será el que guardará el directorio del lugar en el que queremos almacenar la información
            SaveFileDialog save = new SaveFileDialog(); //Abrimos un SaveFileDialog, encargado de buscar una dirección para colocar ahí el archivo
            if (save.ShowDialog() == DialogResult.OK) //En caso de que haya sido elegido un archivo, guardamos su directorio
                directory = save.FileName;

            if(directory == "") //En caso de que el directorio esté vacío quiere decir que no fue elegido ningún directorio, por tanto avisamos al usuario y nos detenemos
            {
                MessageBox.Show("Debes elegir una ubicación para salvar tu rutina");
                return;
            }
            //En caso de que sea válido utilizamos la clase SteamWrite, la cual, mediante un directorio crea un archivo, le agregamos la extensión txt para que el archivo sea legible a modo de txt
            StreamWriter writer = new StreamWriter(directory + ".txt");

            MatlanSaverParser dictionary = new MatlanSaverParser(); //Creamos un diccionario con todas las palabras que tenemos por defecto
            dictionary.AgregateCommandDefaultWords();
            dictionary.AgregateFlowControllerWords();
            dictionary.AgregateGetLetterWords();
            dictionary.AgregateLinealMemoryDefaultWords();
            dictionary.AgregateOperatorWords();
            dictionary.AgregateRoutineWords();
            dictionary.AgregateSensorWords();
            dictionary.AgregateSetLetterWords();
            dictionary.AgregateSpecialInstructionDefaultWords();

            int fills = this.robot.runtimes[this.actualroutine].fills; //Copiamos las filas y columnas en ints para no pedirlas en el for de adelante todas las veces
            int columns = this.robot.runtimes[this.actualroutine].columns;
            List<Tuple<int, int, string>> list= new List<Tuple<int, int, string>>(); //Creamos una lista de tuplas que están compuesta por dos ints y un string (fila, columna, instrucción)
            int counter = 0; //Creamos un contador

            for(int i = 0; i < fills; i++) //Vamos por filas y por columnas para 
            {
                for(int j = 0; j < columns; j++)
                {
                    if (this.robot.runtimes[this.actualroutine].matfield[i,j] != null) //Siempre que tengamos una instrucción, la guardamos
                    {//Para guardarla, pasamos el int que está por detrás de las instrucciones por el diccionario para convertirlo a string, y lo guardamos con su fila y columna
                        list.Add(new Tuple<int, int,string>(i, j, dictionary.CreateString(this.robot.runtimes[this.actualroutine].matfield[i, j].number)));
                        counter++; //Aumentamos el contador para saber cuántas instrucciones tenemos
                    }
                }
            }

            writer.WriteLine(counter); //Antes que nada, en el tope del txt tenemos la cantidad de instrucciones
            for(int i = 0; i < list.Count; i++) //Mediante un for recorremos toda la lista
            { //Escribimos mediante el StreamWrite y la propiedad WriteLine escribir la línea que deseamos en el txt
                writer.WriteLine(list[i].Item1.ToString() + " " + list[i].Item2.ToString() + " " + list[i].Item3.ToString());
            }
            writer.Dispose();//Mediante el Dispose le damos formato al writer (si no lo hacemos da errores raros...)
            
        }
        #endregion
    }
}