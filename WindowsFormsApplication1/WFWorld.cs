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
    public partial class WFWallEWorldFormulary : Form
    {
        private Shape shape; //Aquí tenemos las propiedades que deben tener los objetos, los cuáles nos entran según los eventos de click de los RadioButton correspondientes
        private bool wallE; //Si el shape es un robot, debemos guardar cuál es
        private Wall_E_Return_s.Size size;
        private Wall_E_Return_s.Color color;
        private Direction direction;
        private int code; //Este es el número correspondiente al robot
        private int fills = 10; //Aquí está la cantidad de filas del mundo
        private int columns = 20;//Aquí está la cantidad de columnas del mundo
        private Simuland simuland = new Simuland(10, 20);
        private bool Add = true; //Mediante este bool designamos si colocaremos un objeto
        private bool Remove = false; //Mediante este bool designamos si removeremos un objeto
        private bool Change = false; //Mediante este bool designamos si modificamos el robot
        public WFWallEWorldFormulary()
        {
            InitializeComponent();
        }

        #region Shape RadioButtons
        //Estos son los botones correspondientes a la forma (shape)
        private void WFRobotWallERButton_CheckedChanged(object sender, EventArgs e) //Si es un Wall-E
        {
            this.shape = new RobotForm();//Colocamos en shape Robot, y le damos true a Wall-E
            this.wallE = true;
            //this.size = new Large(); //El tamaño lo colocamos en grande por defecto
            WFSizeLargeRButton.Checked = true; //Colocamos en true el RadioButton de Grande
        }

        private void WFShapeBoxRButton_CheckedChanged(object sender, EventArgs e)//El resto de los objetos dejan en false todos los robots, y ponen su forma correspondiente en shape
        {
            this.shape = new BoxForm();
            this.wallE = false;
        }
        

        private void WFShapeSphereRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.shape = new SphereForm();
            this.wallE = false;
        }

        private void WFShapePlantRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.shape = new PlantForm();
            this.wallE = false;
        }

        #endregion

        #region Size RadioButtons
        //Estos son los RadioButtons correspondientes al tamaño de los objetos
        private void WFSizeSmallRButton_CheckedChanged(object sender, EventArgs e)
        {//Se revisa el .Checked porque siempre se entra en todos los Radio Buttons al elegir uno, pero solo se puede entrar en este si fue elegido
            if(shape != null && this.shape is RobotForm && WFSizeSmallRButton.Checked) //Si es un robot, entonces debemos avisar que no puede ser un tamaño diferente de grande
            {
                WFSizeLargeRButton.Checked = true;
                MessageBox.Show("Los robots solo pueden como tamaño Grande");
            }
            else
            this.size = new Small();
        }

        private void WFSizeMediumRButton_CheckedChanged(object sender, EventArgs e)
        {
            if (shape != null && this.shape is RobotForm && WFSizeMediumRButton.Checked)
            {
                WFSizeLargeRButton.Checked = true;
                MessageBox.Show("Los robots solo pueden como tamaño Grande");
            }
            else
            this.size = new Medium();
        }

        private void WFSizeLargeRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.size = new Large();
        }

        #endregion

        #region Color RadioButtons
        private void WFColorRedRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.color = new Red();
        }

        private void WFColorYellowRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.color = new Yellow();
        }

        private void WFColorGreenRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.color = new Green();
        }

        private void WFColorBlueRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.color = new Blue();
        }

        private void WFColorBrownRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.color = new Brown();
        }

        private void WFColorBlackRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.color = new Black();
        }

        private void WFColorWhiteRButton_CheckedChanged(object sender, EventArgs e)
        {
            this.color = new White();
        }
        #endregion

        #region Direction RadioButtons
        private void WFDirectionNorthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.direction = new North();
        }

        private void WFDirectionSourthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.direction = new Sourth();
        }

        private void WFDirectionEastRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.direction = new East();
        }

        private void WFDirectionWestRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.direction = new West();
        }
        #endregion

        #region Value Changeds
        private void WFCodeNumeric_ValueChanged(object sender, EventArgs e) //Mediante este evento cambiamos el código del robot según lo que ponga el usuario
        {
            this.code = (int)WFCodeNumeric.Value;
        }

        private void WFFillsNumeric_ValueChanged(object sender, EventArgs e) //Mediante este numeric cambiamos la cantidad de filas del simufield
        {
            this.fills = (int)WFFillsNumeric.Value;
        }

        private void WFColumnsNumeric_ValueChanged(object sender, EventArgs e)//Mediante este numeric cambiamos la cantidad de columnas del simufield
        {
            this.columns = (int)WFColumnsNumeric.Value;
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
                            g.DrawImage(Image.FromFile((startup + "\\Images\\" + "4" + (((WallE)this.simuland.simufield[i, j]).direction.Number).ToString()) + (this.simuland.simufield[i, j].color.Number).ToString() + ".png"), j * width, i * height, width - 1, height - 1);
                        }
                        if (this.simuland.simufield[i, j] is Obstacle) //Si es un obstáculo, cargamos su foto mediante el cógido shape + size + color
                            g.DrawImage(Image.FromFile((startup + "\\Images\\" + (this.simuland.simufield[i, j].shape.Number).ToString() + (this.simuland.simufield[i, j].size.Number).ToString()) + (this.simuland.simufield[i, j].color.Number).ToString() + ".png"), j * width, i * height, width - 1, height - 1);
                    }
                }
            }
        }

        private void WFSimufieldPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int i = e.Y / 60; //Mediante estos cálculos verificamos la posición del click (que es la posición entre el tamaño de las casillas)
            int j = e.X / 60; //Para el caso de las filas es el Y del click y para el caso de las columnas es el X

            if (this.Add == true) //Si tenemos el botón de añadir presionado, colocamos el objeto en el simufield
            {
                if (simuland.simufield[i, j] != null) //Si en la posición ya existe un objeto, debemos removerlo primero
                {
                    MessageBox.Show("Ya existe un objeto en ese sitio, retírelo si desea colocar otro");
                    return;
                }

                if (this.shape == null) //En caso de que la forma o el color no hayan sido decididos, lanzamos un mensaje y detenemos la operación
                {
                    MessageBox.Show("Debes elegir un Robot u Obstáculo");
                    return;
                }
                if (this.color == null)
                {
                    MessageBox.Show("Debes elegir un color");
                    return;
                }

                if (this.shape is RobotForm) //Si ya fueron elegido, debemos verificar qué forma fue escogida, si es un robot
                {
                    if (this.direction == null) //Revisamos que su dirección haya sido escogida
                    {
                        MessageBox.Show("Debes elegir una dirección para el robot");
                        return;
                    }
                    if (this.wallE == true) //Si lo es, verificamos qué robot fue escogido, en caso de ser Wall-E, lo añadimos
                        this.simuland.AddAllObject(new WallE(this.shape, this.size, this.color, this.code, this.direction, null, null), i, j);
                }
                if (this.size == null) //si no fue un robot, entonces fue un obstáculo, revisamos si fue elegido su tamaño 
                {
                    MessageBox.Show("Debes elegir un tamaño para el obtáculo");
                    return;
                }

                if (this.shape is BoxForm) //Dependiendo de cuál sea, creamos ese obstáculo
                    this.simuland.AddAllObject(new Box(this.shape, this.size, this.color, this.code, null, null), i, j);
                if (this.shape is SphereForm)
                    this.simuland.AddAllObject(new Sphere(this.shape, this.size, this.color, this.code, null, null), i, j);
                if (this.shape is PlantForm)
                    this.simuland.AddAllObject(new Plant(this.shape, this.size, this.color, this.code, null, null), i, j);
            }

            if (this.Remove == true) //Si tenemos el botón de remover presionado, quitamos el objeto del simufield
            {
                this.simuland.RemoveAllObject(i, j);
            }

            if (this.Change == true && this.simuland.simufield[i, j] != null) //Si tenemos el botón modificar presionado, entonces abrimos un nuevo formulario con las características del objeto
            {
                ObjectView a = new ObjectView(this.simuland.simufield[i, j]); //Creamos una instancia de ObjectView (el otro WFAplication)
                a.ShowDialog();//Lo ejecutamos con ShowDialog para que no pueda ser accedido el WFWorld hasta que hayan terminado con este nuevo abierto
            }

            WFSimufieldPictureBox.Refresh();//Reiniciamos el panel
        }

        #endregion

        #region Buttons

        private void WFRestartWorldButton_Click(object sender, EventArgs e)//Este botón es el que le da la cantidad de casillas al mundo
        {
            this.simuland = new Simuland(this.fills, this.columns); //Creamos un nuevo simuland con la cantidad de filas y columnas actualizadas
            WFSimufieldPictureBox.Refresh();
        }

        private void WFAddButton_Click(object sender, EventArgs e) //Al tocar el botón de añadir, cambiamos el color de los botones para saber externamente cuál está presionado
        {//y cambiamos el bool para saber internamente cuál está presionado
            this.Add = true;
            this.Remove = false;
            this.Change = false;
            WFAddButton.BackColor = System.Drawing.Color.DarkGray;
            WFRemoveButton.BackColor = System.Drawing.Color.White;
            WFChangeButton.BackColor = System.Drawing.Color.White;
        }

        private void WFRemoveButton_Click(object sender, EventArgs e)//Lo mismo que el anterior, pero con Remove
        {
            this.Add = false;
            this.Remove = true;
            this.Change = false;
            WFAddButton.BackColor = System.Drawing.Color.White;
            WFRemoveButton.BackColor = System.Drawing.Color.DarkGray;
            WFChangeButton.BackColor = System.Drawing.Color.White;
        }

        private void WFChangeButton_Click(object sender, EventArgs e)
        {
            this.Add = false;
            this.Remove = false;
            this.Change = true;
            WFAddButton.BackColor = System.Drawing.Color.White;
            WFRemoveButton.BackColor = System.Drawing.Color.White;
            WFChangeButton.BackColor = System.Drawing.Color.DarkGray;
        }

        private void WFStartButton_Click(object sender, EventArgs e) //Mediante este botón abrimos la ventana para dar play
        {
            WFPlayDebugFormulary a = new WFPlayDebugFormulary(this.simuland.Clone()); //A la ventana le pasamos un clon del simuland
            a.ShowDialog();
        }

        private void WFResizeWorldButton_Click(object sender, EventArgs e) //Mediante este botón cambiamos las dimensiones del simuland manteniendo los objetos
        {
            this.simuland.Resize(this.fills, this.columns);
            WFSimufieldPictureBox.Refresh();
        }

        #endregion
    }
}
