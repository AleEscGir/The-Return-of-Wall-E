using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wall_E_Return_s;

namespace WindowsFormsApplication1
{
    public partial class WFPlayDebugFormulary : Form
    {
        private Simuland simuland { get; set; } //Aquí tenemos el Simuland que nos pasan por argumento
        private Matlanland matfield { get; set; } //Este será el Matfield actual que estamos pintando
        private Robot robot { get; set; } //Este es el robot que se está ejecutando en el momento que se toque un botón de turno
        private int robotsprites { get; set; } //Mediante este int conocemos que sprites de los robots cargar
        public WFPlayDebugFormulary(Simuland simuland)
        {
            InitializeComponent();
            this.simuland = simuland;
            this.robotsprites = 1;
            //Antes que nada debemos revisar que haya al menos un robot en el simufield
            bool ItsRobots = false; //Creamos un bool que no informará si hay alguno
            for(int i = 0; i < this.simuland.fills; i++)
            {
                for(int j = 0; j < this.simuland.columns; j++)
                {
                    if(this.simuland.simufield[i,j] != null && this.simuland.simufield[i,j] is Robot)
                    {
                        ItsRobots = true; //Si lo encontramos, hacemos true el bool y hacemos break para no iterar sin sentido
                        break;
                    }
                    if (ItsRobots == true)
                        break;
                }
            }
            if(ItsRobots == false) //En caso de que no hayamos encontrado ninguno
            {
                WFPlayButton.Enabled = false; //Dejamos en false los botones de turno, quedando solo el de stop
                WFPauseButton.Enabled = false;
                WFDebugTurnButton.Enabled = false;
                WFInstructionDebugButton.Enabled = false;
            }
        }

        #region Buttons
        private void WFPlayButton_Click(object sender, EventArgs e) //Cuando tocamos el botón de play, le damos start al timer
        {
            if(this.simuland.robotlist.Count == 0) //Antes que nada revisamos que existan robots para trabajar
            {
                MessageBox.Show("Robots no existen o están en mal estado");
                return;
            }
            WFSimufieldPlayTimer.Start();
        }

        private void WFPauseButton_Click(object sender, EventArgs e) //Cuando tocamos el botón de pause, le damos stop al timer
        {
            WFSimufieldPlayTimer.Stop(); //Cuando nos detenemos debemos cargar el picture box y los text box del último robot que se haya estado ejecutando
            WFMatlanlandPictureBox.Refresh();
            if (this.robot != null)
            {
                if (this.robot.message != "") //En caso de que el robot haya mandado un mensaje
                    WFPrintingTextBox.Text = this.robot.message;
            }
            TextBoxRefresh();
        }

        private void WFStopButton_Click(object sender, EventArgs e) //Cuando tocamos el botón de stop, cerramos el formulario
        {
            Close();
        }

        private void WFDebugTurnButton_Click(object sender, EventArgs e) //Cuando tocamos el botón de DebugTurn, hacemos que un robot tome su turno
        {
            WFSimufieldPlayTimer.Stop();//Antes que nada, en caso de que el timer esté andando, lo detenemos
            if (this.simuland.robotlist.Count == 0) //Antes que nada revisamos que existan robots para trabajar
            {
                MessageBox.Show("Robots no existen o están en mal estado");
                return;
            }
            try //Mediante el try intentamos realizar el turno del robot
            {
                this.simuland.RobotTurn();
                WFSimufieldPictureBox.Refresh();
                WFMatlanlandPictureBox.Refresh();
                TextBoxRefresh();
                if (this.robot != null && this.robot.message != "") //En caso de que el robot haya mandado un mensaje
                    WFPrintingTextBox.Text = this.robot.message;
            }
            catch (Exception a) //Mediante el catch, si fue lanzada una excepción durante la ejecución, nos detenemos, la capturamos y trabajamos con ella
            {
                WFMatlanlandPictureBox.Refresh();
                MessageBox.Show(a.Message); //Lanzamos a modo de Message Box el mensaje que dio la excepción
                this.simuland.IgnoreActualRobot(); //Sacamos al robot de la lista para que los demás puedan continuar
            }
        }
        

        private void WFInstructionDebugButton_Click(object sender, EventArgs e) //Cuando tocamos el botón de InstructionDebugTurn, hacemos que un robot ejecute solo una instrucción
        {
            WFSimufieldPlayTimer.Stop();//Antes que nada, en caso de que el timer esté andando, lo detenemos
            if (this.simuland.robotlist.Count == 0) //Antes que nada revisamos que existan robots para trabajar
            {
                MessageBox.Show("Robots no existen o están en mal estado");
                return;
            }
            try
            {
                this.simuland.RobotDebugTurn(); //Ejecutamos un turno de intrucción del robot
                WFSimufieldPictureBox.Refresh(); //Repintamos el Picture Box del matfield
                if (this.simuland.actualrobot != null) //Si nos quedamos todavía en algún robot del simuland
                {
                    this.robot = (Robot)this.simuland.actualrobot; //Le pasamos a WallE el WallE del simuland
                    if (this.robot.recursivity.Count != 0) //Mientras que su pila de recursividad no esté vacía será aquella que mostraremos
                        this.matfield = this.robot.recursivity.Peek();
                    else
                        this.matfield = this.robot.runtimes[0]; //En caso de que no haya nada en su pila de recursividad, mostramos lo que está en la rutina principal
                }
                WFMatlanlandPictureBox.Refresh(); //Refrescamos el Picture Box del Matfield
                TextBoxRefresh();
                if (this.robot != null && this.robot.message != "") //En caso de que el robot haya mandado un mensaje
                    WFPrintingTextBox.Text = this.robot.message;
            }
            catch (Exception a) //Mediante el catch, si fue lanzada una excepción durante la ejecución, nos detenemos, la capturamos y trabajamos con ella
            {

                MessageBox.Show(a.Message); //Lanzamos a modo de Message Box el mensaje que dio la excepción
                this.simuland.IgnoreActualRobot(); //Sacamos al robot de la lista para que los demás puedan continuar
            }
        }
        #endregion

        #region Value Changeds
        private void WFTimeElapsedNumeric_ValueChanged(object sender, EventArgs e) //Mediante este numeric cambiamos el tiempo que tarda el Timer en ejecutarse
        {
            WFSimufieldPlayTimer.Interval = (int)WFTimeElapsedNumeric.Value;
        }
        #endregion

        #region Timer
        private void WFSimufieldPlayTimer_Tick(object sender, EventArgs e)//Mediante este Timer le damos el turno a los robots
        { //Básicamente hacemos con el Tick lo mismo que con el DebugTurnButton más arriba
            if (this.simuland.robotlist.Count == 0) //Antes que nada revisamos que existan robots para trabajar
            {
                MessageBox.Show("Robots no existen o están en mal estado");
                return;
            }
            try
            {
                this.simuland.RobotTurn();
                WFSimufieldPictureBox.Refresh();
                if (this.robot != null && this.robot.message != "") //En caso de que el robot haya mandado un mensaje
                    WFPrintingTextBox.Text = this.robot.message;
            }
            catch (Exception a)
            {
                WFSimufieldPlayTimer.Stop(); //La única diferencia es que debemos detener el Timer
                MessageBox.Show(a.Message); //Lanzamos a modo de Message Box el mensaje que dio la excepción
                this.simuland.IgnoreActualRobot(); //Sacamos al robot de la lista para que los demás puedan continuar 
            }
            
        }
        #endregion

        #region Simufield Picture Box
        private void WFSimufieldPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //Usamos esto para no pedir constantemente el Graphics de e
            SolidBrush b = new SolidBrush(System.Drawing.Color.White); //Creamos una brocha que pintará en blanco el fondo de las casillas

            g.FillRectangle(b, e.ClipRectangle); //Ni idea...

            Pen p = new Pen(System.Drawing.Color.Black, 1); //Creamos un lapiz que dibujará en negro las casillas

            float width = 60; //Le conferimos ancho al panel
            float height = 60; //Le conferimos el largo al panel

            WFSimufieldPictureBox.Height = this.simuland.fills * 60; //Cambiamos el largo y ancho del Picture Box
            WFSimufieldPictureBox.Width = this.simuland.columns * 60;

            for (int i = 1; i < this.simuland.columns; i++) //Dibujamos las rayas verticales
            {
                g.DrawLine(p, i * width - 1, 0, i * width - 1, WFSimufieldPictureBox.Height);
            }

            for (int i = 1; i < this.simuland.fills; i++)//Dibujamos las rayas horizontales
            {
                g.DrawLine(p, 0, i * height - 1, WFSimufieldPictureBox.Width, i * height - 1);
            }
            string startup = Application.StartupPath; //Aquí cargamos el directivo de la carpeta en al que se encuentran las imágenes
            for (int i = 0; i < this.simuland.fills; i++) //Aquí buscamos en todas las posiciones del simufield para pintar en el panel lo que haya en él
            {
                for (int j = 0; j < this.simuland.columns; j++)
                {
                    if (this.simuland.simufield[i, j] != null) //Si el panel no es null, entonces hay un objeto en él
                    {
                        if (this.simuland.simufield[i, j] is WallE)//Si es un Wall-E, cargamos su foto mediante el código 4 + direction + color
                        {
                            if (this.simuland.actualrobot != null && this.simuland.simufield[i, j] == this.simuland.actualrobot) //Si el robot que está ejecutando el turno es el que está en el parámetro actualrobot, pintamos su fondo de azul (para que se sepa que se está ejecutando ese robot)
                                g.DrawImage(Image.FromFile((startup + "\\Images\\Blue.png")), j * width, i * height, width - 1, height - 1);
                            //Luego dibujamos el robot
                            if (((WallE)this.simuland.simufield[i, j]).message != "Robot Fuera de Servicio")
                                g.DrawImage(Image.FromFile((startup + "\\Images\\" + "4" + (((WallE)this.simuland.simufield[i, j]).direction.Number).ToString()) + (this.simuland.simufield[i, j].color.Number).ToString() + ".png"), j * width, i * height, width - 1, height - 1);
                            else
                            {
                                g.DrawImage(Image.FromFile((startup + "\\Images\\" + "4" + (((WallE)this.simuland.simufield[i, j]).direction.Number).ToString()) + (this.simuland.simufield[i, j].color.Number).ToString() + this.robotsprites.ToString() + ".png"), j * width, i * height, width - 1, height - 1);
                                if (this.robotsprites != 3)
                                    this.robotsprites++;
                                else
                                    this.robotsprites = 1;
                            }
                            }
                        if (this.simuland.simufield[i, j] is Obstacle) //Si es un obstáculo, cargamos su foto mediante el cógido shape + size + color
                            g.DrawImage(Image.FromFile((startup + "\\Images\\" + (this.simuland.simufield[i, j].shape.Number).ToString() + (this.simuland.simufield[i, j].size.Number).ToString()) + (this.simuland.simufield[i, j].color.Number).ToString() + ".png"), j * width, i * height, width - 1, height - 1);
                    }
                }
            }
        }

        private void WFSimufieldPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            WFMatlanlandPictureBox.Visible = true; //Hacemos siempre el controlador visible, ya que si anterioemente fue elegido un objeto, ahora estaría en falso

            int i = e.Y / 60; //Mediante estos cálculos verificamos la posición del click
            int j = e.X / 60;
            string startup = Application.StartupPath; //Aquí cargamos el directivo de la carpeta en al que se encuentran las imágenes
            if (this.simuland.simufield[i, j] != null) //Este if es para que el picture box no intente dibujar algo si todavía no se ha dado click
            {
                if (this.simuland.simufield[i, j] is Obstacle) //Revisamos qué es el objeto, y dependiendo de ello lo guardamos con especificaciones distintas
                {
                    //Si es un obstáculo, cargamos su foto mediante el cógido shape + size + color
                    WFObjectPictureBox.Image = Image.FromFile((startup + "\\Images\\" + (this.simuland.simufield[i, j].shape.Number).ToString() + (this.simuland.simufield[i, j].size.Number).ToString()) + (this.simuland.simufield[i, j].color.Number).ToString() + ".png");
                    //Luego reiniciamos todo lo que tenga que ver con el robot
                    WFFlowLabel.Text = "Flujo";
                    WFStackTextBox.Text = "";
                    WFRegistryTextBox.Text = "";
                    WFLinealMemoryTextBox.Text = "";
                    WFOpenRoutinesTextBox.Text = "";
                    WFRobotObjectPictureBox.Image = null;
                    WFMatlanlandPictureBox.Visible = false; //Si fue elegido un objeto, debemos colocar el visible de la rutina en falso para que borre lo que estaba dibujado
                }

                if (this.simuland.simufield[i, j] is WallE)
                {
                    {
                        WFFlowLabel.Text = "Sur"; //Colocamos el flujo en sur por defecto
                        this.robot = (WallE)this.simuland.simufield[i, j]; //Igualamos el WallE que tenemos a este, para así luego colocar los valores de su pila y demás en los TextBox
                        //Si es un Wall-E, cargamos su foto mediante el código 4 + direction + color
                        if(((WallE)this.simuland.simufield[i,j]).message != "Robot Fuera de Servicio")
                        WFObjectPictureBox.Image = Image.FromFile((startup + "\\Images\\" + "4" + "2" + (this.simuland.simufield[i, j].color.Number).ToString() + ".png"));
                        else
                            WFObjectPictureBox.Image = Image.FromFile((startup + "\\Images\\" + "4" + "2" + (this.simuland.simufield[i, j].color.Number).ToString() + "1" + ".png"));
                        //Como lo que tenemos es un robot, debemos revisar si tiene un objeto dentro, y en ese caso pintarlo
                        if (((WallE)this.simuland.simufield[i, j]).smallobject != null)
                            WFRobotObjectPictureBox.Image = Image.FromFile((startup + "\\Images\\" + (((WallE)this.simuland.simufield[i, j]).smallobject.shape.Number).ToString() + (((WallE)this.simuland.simufield[i, j]).smallobject.size.Number).ToString()) + (((WallE)this.simuland.simufield[i, j]).smallobject.color.Number).ToString() + ".png");
                    }
                }

                EnglishSpanishTraductor traductor = new EnglishSpanishTraductor(); //Creamos un diccionario nuevo
                traductor.AgregateColorsDefaultWords(); //Le agregamos todas las palabras que necesitamos
                traductor.AgregateShapesDefaultWords();
                traductor.AgregateSizesDefaultWords();
                //Luego le damos sus parámetros a los diferentes Label que indican las características del objeto
                WFObjectCodeLabel.Text = this.simuland.simufield[i, j].Code.ToString();
                WFObjectColorLabel.Text = traductor.Traduce(this.simuland.simufield[i, j].Color.Name);
                WFObjectSizeLabel.Text = traductor.Traduce(this.simuland.simufield[i, j].Size.Name);
                WFObjectShapeLabel.Text = traductor.Traduce(this.simuland.simufield[i, j].Shape.Name);

                if (this.simuland.simufield[i, j] is WallE) //Luego, si lo que elegimos fue un WallE, cargamos su matfield (ya sea lo último en la pila de recursividad o la rutina principal)
                {
                    if (((WallE)this.simuland.simufield[i, j]).recursivity.Count != 0)
                        this.matfield = ((WallE)this.simuland.simufield[i, j]).recursivity.Peek();
                    else
                        this.matfield = ((WallE)this.simuland.simufield[i, j]).runtimes[0];
                    WFMatlanlandPictureBox.Refresh();
                    TextBoxRefresh();
                }
            }
        }
        #endregion

        #region Matlanland Picture Box

        private void WFMatlanlandPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.matfield != null)
            {
                Graphics g = e.Graphics; //Usamos esto para no pedir constantemente el Graphics de e
                SolidBrush b = new SolidBrush(System.Drawing.Color.White); //Creamos una brocha que pintará en blanco el fondo de las casillas

                g.FillRectangle(b, e.ClipRectangle); //Ni idea...

                Pen p = new Pen(System.Drawing.Color.Black, 1); //Creamos un lapiz que dibujará en negro las casillas

                float width = 60;//Le conferimos el largo y ancho a las casillas
                float height = 60;

                WFMatlanlandPictureBox.Height = this.matfield.fills * 60;
                WFMatlanlandPictureBox.Width = this.matfield.columns * 60;

                for (int i = 1; i < this.matfield.columns; i++) //Dibujamos las rayas verticales
                {
                    g.DrawLine(p, i * width - 1, 0, i * width - 1, WFMatlanlandPictureBox.Height);
                }

                for (int i = 1; i < this.matfield.fills; i++)//Dibujamos las rayas horizontales
                {
                    g.DrawLine(p, 0, i * height - 1, WFMatlanlandPictureBox.Width, i * height - 1);
                }
                string startup = Application.StartupPath; //Aquí cargamos el directivo de la carpeta en al que se encuentran las imágenes

                for (int i = 0; i < this.matfield.fills; i++) //Aquí buscamos en todas las posiciones del matlanland para pintar en el panel lo que haya en él
                {
                    for (int j = 0; j < matfield.columns; j++)
                    {
                        if (this.matfield.Cursor.fill == i && this.matfield.Cursor.column == j) //Si llegamos a la posición en la que nos encontramos actualmente en el matfield, pintamos el cuadro de azul
                            g.DrawImage(Image.FromFile((startup + "\\Images\\Blue.png")), j * width, i * height, width - 1, height - 1);

                        if (this.matfield.matfield[i, j] != null) //Si el matlanland la posición no es null, entonces hay una instrucción en él
                        {
                            if (this.matfield.Cursor.fill == i && this.matfield.Cursor.column == j) //Si nos encontramos la actual la dibujamos con dimensiones más pequeñas para que se note el color azul
                            {
                                //Si encontramos un instrucción, cargamos su foto, revisando primero si es un registro
                                if (this.matfield.matfield[i, j] is Registry) //Los registro se cargan mediante: Número del Registro + "-" + letra del registro
                                {//Pero para lograrlo debemos guardar el número y mediante substring colocarle el "-" entre los dos primeros números y el resto
                                    string number = this.matfield.matfield[i, j].number.ToString();
                                    number = number.Substring(0, 2) + "-" + number.Substring(2, number.Length - 2);
                                    g.DrawImage(Image.FromFile((startup + "\\Images\\" + number + ".png")), j * width + 10, i * height + 10, width - 20, height - 20);
                                }
                                else //El resto de las instrucciones se cargan normalmente mediante su número
                                    g.DrawImage(Image.FromFile((startup + "\\Images\\" + this.matfield.matfield[i, j].number.ToString() + ".png")), j * width + 10, i * height + 10, width - 20, height - 20);
                            }
                            else
                            {
                                //Si encontramos un instrucción y nos es la que está actualmente en ejecución, la pintamos normalmente
                                //Cargamos su foto, revisando primero si es un registro
                                if (this.matfield.matfield[i, j] is Registry) //Los registro se cargan mediante: Número del Registro + "-" + letra del registro
                                {
                                    string number = this.matfield.matfield[i, j].number.ToString();
                                    number = number.Substring(0, 2) + "-" + number.Substring(2, number.Length - 2);
                                    g.DrawImage(Image.FromFile((startup + "\\Images\\" + number + ".png")), j * width, i * height, width - 1, height - 1);
                                }
                                else //El resto de las instrucciones se cargan normalmente mediante su número
                                    g.DrawImage(Image.FromFile((startup + "\\Images\\" + this.matfield.matfield[i, j].number.ToString() + ".png")), j * width, i * height, width - 1, height - 1);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Text Boxs
        public void TextBoxRefresh()
        {
            //Este método básicamente escribe lo que haya en la Memoria Lineal, la pila, la pila de recursividades y
            //el registro en los Text Box, para así poder revisarlos (además de cambiar el flujo de la rutina)
            WFRegistryTextBox.Text = ""; //Antes que nada borramos los textos de los TextBox
            WFLinealMemoryTextBox.Text = "";
            WFStackTextBox.Text = "";
            WFOpenRoutinesTextBox.Text = "";

            if (this.robot != null) //Revisamos que el robot sea diferente de null para evitar que ocurra un NullReferenceException
            {
                for (int i = 0; i < this.robot.LinealMemoryIndex.Count; i++) //Pasamos por la lista de índices ocupados de la memoria lineal, y con esos índices revisamos a la Memoria Lineal
                {
                        if (WFLinealMemoryTextBox.Text == "") //Si el texto está vacío, colocamos la primera línea, en otro caso continuamos con las anteriores
                        WFLinealMemoryTextBox.Text = "Posición N." + i.ToString() + ": " + this.robot.LinealMemory[this.robot.LinealMemoryIndex[i]].ToString();
                        else
                        WFLinealMemoryTextBox.Text += " Posición N." + i.ToString() + ": " + this.robot.LinealMemory[this.robot.LinealMemoryIndex[i]].ToString();
                }

                int[] temporal = this.matfield.registers.RegisterList(); //Luego colocamos los registros en un temporal
                for(int i = 0; i < 27; i++) //Igualmente los colocamos todos
                {
                    if (WFRegistryTextBox.Text == "")
                        WFRegistryTextBox.Text = "Posición N." + i.ToString() + ": " + temporal[i].ToString();
                    else
                        WFRegistryTextBox.Text += " Posición N." + i.ToString() + ": " + temporal[i].ToString();
                }

                int counter = 0; //Con este contador revisamos cuántos elementos tenemos en las pilas, para así colocarlos todos
                foreach(int x in this.robot.stack.Reverse()) //Revisamos la pila dándole .Reverse() porque la pila devuelve su enumerable al revés
                {
                    counter++;
                    if (WFStackTextBox.Text == "")
                        WFStackTextBox.Text = "Posición N." + counter.ToString() + ": " + x.ToString();
                    else
                        WFStackTextBox.Text += " Posición N." + counter.ToString() + ": " + x.ToString();
                }

                counter = 0; //Lo mismo hacemos con la pila de rutinas
                foreach (Matlanland x in this.robot.recursivity.Reverse())
                {
                    counter++;
                    if (WFOpenRoutinesTextBox.Text == "")
                        WFOpenRoutinesTextBox.Text = "Rutina N." + counter.ToString() + ": " + x.number.ToString();
                    else
                        WFOpenRoutinesTextBox.Text += " Rutina N." + counter.ToString() + ": " + x.number.ToString();
                }

                WFPrintingTextBox.Text = this.robot.message; //Colocamos el mensaje del robot en la consola

                if (this.robot.recursivity.Count > 0) //En caso de que quede alguna rutina en la pila colocamos en el TextBox su flujo
                {
                    EnglishSpanishTraductor a = new EnglishSpanishTraductor();
                    a.AgregateDirectionsDefaultWords();
                    WFFlowLabel.Text = a.Traduce(this.robot.recursivity.Peek().flow.Name);
                }
            }
        }
        #endregion
    }
}
