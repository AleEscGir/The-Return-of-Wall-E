namespace WindowsFormsApplication1
{
    partial class WFWallEWorldFormulary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WFShapeObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.WFObjectsLabel = new System.Windows.Forms.Label();
            this.WFRobotsLabel = new System.Windows.Forms.Label();
            this.WFShapePlantRButton = new System.Windows.Forms.RadioButton();
            this.WFShapeSphereRButton = new System.Windows.Forms.RadioButton();
            this.WFShapeBoxRButton = new System.Windows.Forms.RadioButton();
            this.WFRobotWallERButton = new System.Windows.Forms.RadioButton();
            this.WFWorldSelectorGroupBox = new System.Windows.Forms.GroupBox();
            this.WFRestartWorldButton = new System.Windows.Forms.Button();
            this.WFColumnsNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFFillsNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFColumnsLabel = new System.Windows.Forms.Label();
            this.WFFillsLabel = new System.Windows.Forms.Label();
            this.WFSizeObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.WFSizeLargeRButton = new System.Windows.Forms.RadioButton();
            this.WFSizeMediumRButton = new System.Windows.Forms.RadioButton();
            this.WFSizeSmallRButton = new System.Windows.Forms.RadioButton();
            this.WFColorObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.WFColorWhiteRButton = new System.Windows.Forms.RadioButton();
            this.WFColorBlackRButton = new System.Windows.Forms.RadioButton();
            this.WFColorBrownRButton = new System.Windows.Forms.RadioButton();
            this.WFColorBlueRButton = new System.Windows.Forms.RadioButton();
            this.WFColorGreenRButton = new System.Windows.Forms.RadioButton();
            this.WFColorYellowRButton = new System.Windows.Forms.RadioButton();
            this.WFColorRedRButton = new System.Windows.Forms.RadioButton();
            this.WFAddButton = new System.Windows.Forms.Button();
            this.WFRemoveButton = new System.Windows.Forms.Button();
            this.WFCodeNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFDirectionObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.WFDirectionWestRadioButton = new System.Windows.Forms.RadioButton();
            this.WFDirectionEastRadioButton = new System.Windows.Forms.RadioButton();
            this.WFDirectionSourthRadioButton = new System.Windows.Forms.RadioButton();
            this.WFDirectionNorthRadioButton = new System.Windows.Forms.RadioButton();
            this.WFChangeButton = new System.Windows.Forms.Button();
            this.WFSimufieldLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.WFSimufieldPictureBox = new System.Windows.Forms.PictureBox();
            this.WFCodeGroupBox = new System.Windows.Forms.GroupBox();
            this.WFStartButton = new System.Windows.Forms.Button();
            this.WFResizeWorldButton = new System.Windows.Forms.Button();
            this.WFShapeObjectGroupBox.SuspendLayout();
            this.WFWorldSelectorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFColumnsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFFillsNumeric)).BeginInit();
            this.WFSizeObjectGroupBox.SuspendLayout();
            this.WFColorObjectGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFCodeNumeric)).BeginInit();
            this.WFDirectionObjectGroupBox.SuspendLayout();
            this.WFSimufieldLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFSimufieldPictureBox)).BeginInit();
            this.WFCodeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // WFShapeObjectGroupBox
            // 
            this.WFShapeObjectGroupBox.Controls.Add(this.WFObjectsLabel);
            this.WFShapeObjectGroupBox.Controls.Add(this.WFRobotsLabel);
            this.WFShapeObjectGroupBox.Controls.Add(this.WFShapePlantRButton);
            this.WFShapeObjectGroupBox.Controls.Add(this.WFShapeSphereRButton);
            this.WFShapeObjectGroupBox.Controls.Add(this.WFShapeBoxRButton);
            this.WFShapeObjectGroupBox.Controls.Add(this.WFRobotWallERButton);
            this.WFShapeObjectGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFShapeObjectGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFShapeObjectGroupBox.Location = new System.Drawing.Point(575, 78);
            this.WFShapeObjectGroupBox.Name = "WFShapeObjectGroupBox";
            this.WFShapeObjectGroupBox.Size = new System.Drawing.Size(383, 72);
            this.WFShapeObjectGroupBox.TabIndex = 4;
            this.WFShapeObjectGroupBox.TabStop = false;
            this.WFShapeObjectGroupBox.Text = "Elija un Robot u Obstáculo";
            // 
            // WFObjectsLabel
            // 
            this.WFObjectsLabel.AutoSize = true;
            this.WFObjectsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFObjectsLabel.ForeColor = System.Drawing.Color.Red;
            this.WFObjectsLabel.Location = new System.Drawing.Point(6, 47);
            this.WFObjectsLabel.Name = "WFObjectsLabel";
            this.WFObjectsLabel.Size = new System.Drawing.Size(43, 13);
            this.WFObjectsLabel.TabIndex = 5;
            this.WFObjectsLabel.Text = "Objetos";
            // 
            // WFRobotsLabel
            // 
            this.WFRobotsLabel.AutoSize = true;
            this.WFRobotsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFRobotsLabel.ForeColor = System.Drawing.Color.Red;
            this.WFRobotsLabel.Location = new System.Drawing.Point(6, 22);
            this.WFRobotsLabel.Name = "WFRobotsLabel";
            this.WFRobotsLabel.Size = new System.Drawing.Size(44, 13);
            this.WFRobotsLabel.TabIndex = 4;
            this.WFRobotsLabel.Text = "Robots:";
            // 
            // WFShapePlantRButton
            // 
            this.WFShapePlantRButton.AutoSize = true;
            this.WFShapePlantRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFShapePlantRButton.ForeColor = System.Drawing.Color.Red;
            this.WFShapePlantRButton.Location = new System.Drawing.Point(286, 45);
            this.WFShapePlantRButton.Name = "WFShapePlantRButton";
            this.WFShapePlantRButton.Size = new System.Drawing.Size(55, 17);
            this.WFShapePlantRButton.TabIndex = 3;
            this.WFShapePlantRButton.Text = "Planta";
            this.WFShapePlantRButton.UseVisualStyleBackColor = true;
            this.WFShapePlantRButton.CheckedChanged += new System.EventHandler(this.WFShapePlantRButton_CheckedChanged);
            // 
            // WFShapeSphereRButton
            // 
            this.WFShapeSphereRButton.AutoSize = true;
            this.WFShapeSphereRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFShapeSphereRButton.ForeColor = System.Drawing.Color.Red;
            this.WFShapeSphereRButton.Location = new System.Drawing.Point(193, 45);
            this.WFShapeSphereRButton.Name = "WFShapeSphereRButton";
            this.WFShapeSphereRButton.Size = new System.Drawing.Size(55, 17);
            this.WFShapeSphereRButton.TabIndex = 2;
            this.WFShapeSphereRButton.Text = "Esfera";
            this.WFShapeSphereRButton.UseVisualStyleBackColor = true;
            this.WFShapeSphereRButton.CheckedChanged += new System.EventHandler(this.WFShapeSphereRButton_CheckedChanged);
            // 
            // WFShapeBoxRButton
            // 
            this.WFShapeBoxRButton.AutoSize = true;
            this.WFShapeBoxRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFShapeBoxRButton.ForeColor = System.Drawing.Color.Red;
            this.WFShapeBoxRButton.Location = new System.Drawing.Point(110, 45);
            this.WFShapeBoxRButton.Name = "WFShapeBoxRButton";
            this.WFShapeBoxRButton.Size = new System.Drawing.Size(46, 17);
            this.WFShapeBoxRButton.TabIndex = 1;
            this.WFShapeBoxRButton.Text = "Caja";
            this.WFShapeBoxRButton.UseVisualStyleBackColor = true;
            this.WFShapeBoxRButton.CheckedChanged += new System.EventHandler(this.WFShapeBoxRButton_CheckedChanged);
            // 
            // WFRobotWallERButton
            // 
            this.WFRobotWallERButton.AutoSize = true;
            this.WFRobotWallERButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFRobotWallERButton.ForeColor = System.Drawing.Color.Red;
            this.WFRobotWallERButton.Location = new System.Drawing.Point(110, 19);
            this.WFRobotWallERButton.Name = "WFRobotWallERButton";
            this.WFRobotWallERButton.Size = new System.Drawing.Size(56, 17);
            this.WFRobotWallERButton.TabIndex = 0;
            this.WFRobotWallERButton.Text = "Wall-E";
            this.WFRobotWallERButton.UseVisualStyleBackColor = true;
            this.WFRobotWallERButton.CheckedChanged += new System.EventHandler(this.WFRobotWallERButton_CheckedChanged);
            // 
            // WFWorldSelectorGroupBox
            // 
            this.WFWorldSelectorGroupBox.Controls.Add(this.WFResizeWorldButton);
            this.WFWorldSelectorGroupBox.Controls.Add(this.WFRestartWorldButton);
            this.WFWorldSelectorGroupBox.Controls.Add(this.WFColumnsNumeric);
            this.WFWorldSelectorGroupBox.Controls.Add(this.WFFillsNumeric);
            this.WFWorldSelectorGroupBox.Controls.Add(this.WFColumnsLabel);
            this.WFWorldSelectorGroupBox.Controls.Add(this.WFFillsLabel);
            this.WFWorldSelectorGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFWorldSelectorGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFWorldSelectorGroupBox.Location = new System.Drawing.Point(578, 3);
            this.WFWorldSelectorGroupBox.Name = "WFWorldSelectorGroupBox";
            this.WFWorldSelectorGroupBox.Size = new System.Drawing.Size(386, 69);
            this.WFWorldSelectorGroupBox.TabIndex = 5;
            this.WFWorldSelectorGroupBox.TabStop = false;
            this.WFWorldSelectorGroupBox.Text = "Elija las dimensiones del mundo";
            // 
            // WFRestartWorldButton
            // 
            this.WFRestartWorldButton.ForeColor = System.Drawing.Color.Black;
            this.WFRestartWorldButton.Location = new System.Drawing.Point(283, 11);
            this.WFRestartWorldButton.Name = "WFRestartWorldButton";
            this.WFRestartWorldButton.Size = new System.Drawing.Size(75, 52);
            this.WFRestartWorldButton.TabIndex = 10;
            this.WFRestartWorldButton.Text = "Reiniciar Mundo";
            this.WFRestartWorldButton.UseVisualStyleBackColor = true;
            this.WFRestartWorldButton.Click += new System.EventHandler(this.WFRestartWorldButton_Click);
            // 
            // WFColumnsNumeric
            // 
            this.WFColumnsNumeric.ForeColor = System.Drawing.Color.Black;
            this.WFColumnsNumeric.Location = new System.Drawing.Point(125, 37);
            this.WFColumnsNumeric.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.WFColumnsNumeric.Name = "WFColumnsNumeric";
            this.WFColumnsNumeric.Size = new System.Drawing.Size(38, 20);
            this.WFColumnsNumeric.TabIndex = 9;
            this.WFColumnsNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.WFColumnsNumeric.ValueChanged += new System.EventHandler(this.WFColumnsNumeric_ValueChanged);
            // 
            // WFFillsNumeric
            // 
            this.WFFillsNumeric.ForeColor = System.Drawing.Color.Black;
            this.WFFillsNumeric.Location = new System.Drawing.Point(125, 14);
            this.WFFillsNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WFFillsNumeric.Name = "WFFillsNumeric";
            this.WFFillsNumeric.Size = new System.Drawing.Size(38, 20);
            this.WFFillsNumeric.TabIndex = 8;
            this.WFFillsNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WFFillsNumeric.ValueChanged += new System.EventHandler(this.WFFillsNumeric_ValueChanged);
            // 
            // WFColumnsLabel
            // 
            this.WFColumnsLabel.AutoSize = true;
            this.WFColumnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColumnsLabel.ForeColor = System.Drawing.Color.Red;
            this.WFColumnsLabel.Location = new System.Drawing.Point(6, 37);
            this.WFColumnsLabel.Name = "WFColumnsLabel";
            this.WFColumnsLabel.Size = new System.Drawing.Size(113, 13);
            this.WFColumnsLabel.TabIndex = 1;
            this.WFColumnsLabel.Text = "Cantidad de Columnas";
            // 
            // WFFillsLabel
            // 
            this.WFFillsLabel.AutoSize = true;
            this.WFFillsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFFillsLabel.ForeColor = System.Drawing.Color.Red;
            this.WFFillsLabel.Location = new System.Drawing.Point(6, 16);
            this.WFFillsLabel.Name = "WFFillsLabel";
            this.WFFillsLabel.Size = new System.Drawing.Size(88, 13);
            this.WFFillsLabel.TabIndex = 0;
            this.WFFillsLabel.Text = "Cantidad de Filas";
            // 
            // WFSizeObjectGroupBox
            // 
            this.WFSizeObjectGroupBox.Controls.Add(this.WFSizeLargeRButton);
            this.WFSizeObjectGroupBox.Controls.Add(this.WFSizeMediumRButton);
            this.WFSizeObjectGroupBox.Controls.Add(this.WFSizeSmallRButton);
            this.WFSizeObjectGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFSizeObjectGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFSizeObjectGroupBox.Location = new System.Drawing.Point(575, 156);
            this.WFSizeObjectGroupBox.Name = "WFSizeObjectGroupBox";
            this.WFSizeObjectGroupBox.Size = new System.Drawing.Size(383, 49);
            this.WFSizeObjectGroupBox.TabIndex = 6;
            this.WFSizeObjectGroupBox.TabStop = false;
            this.WFSizeObjectGroupBox.Text = "Elija un tamaño";
            // 
            // WFSizeLargeRButton
            // 
            this.WFSizeLargeRButton.AutoSize = true;
            this.WFSizeLargeRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFSizeLargeRButton.ForeColor = System.Drawing.Color.Red;
            this.WFSizeLargeRButton.Location = new System.Drawing.Point(291, 19);
            this.WFSizeLargeRButton.Name = "WFSizeLargeRButton";
            this.WFSizeLargeRButton.Size = new System.Drawing.Size(60, 17);
            this.WFSizeLargeRButton.TabIndex = 2;
            this.WFSizeLargeRButton.Text = "Grande";
            this.WFSizeLargeRButton.UseVisualStyleBackColor = true;
            this.WFSizeLargeRButton.CheckedChanged += new System.EventHandler(this.WFSizeLargeRButton_CheckedChanged);
            // 
            // WFSizeMediumRButton
            // 
            this.WFSizeMediumRButton.AutoSize = true;
            this.WFSizeMediumRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFSizeMediumRButton.ForeColor = System.Drawing.Color.Red;
            this.WFSizeMediumRButton.Location = new System.Drawing.Point(149, 19);
            this.WFSizeMediumRButton.Name = "WFSizeMediumRButton";
            this.WFSizeMediumRButton.Size = new System.Drawing.Size(66, 17);
            this.WFSizeMediumRButton.TabIndex = 1;
            this.WFSizeMediumRButton.Text = "Mediano";
            this.WFSizeMediumRButton.UseVisualStyleBackColor = true;
            this.WFSizeMediumRButton.CheckedChanged += new System.EventHandler(this.WFSizeMediumRButton_CheckedChanged);
            // 
            // WFSizeSmallRButton
            // 
            this.WFSizeSmallRButton.AutoSize = true;
            this.WFSizeSmallRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFSizeSmallRButton.ForeColor = System.Drawing.Color.Red;
            this.WFSizeSmallRButton.Location = new System.Drawing.Point(6, 19);
            this.WFSizeSmallRButton.Name = "WFSizeSmallRButton";
            this.WFSizeSmallRButton.Size = new System.Drawing.Size(68, 17);
            this.WFSizeSmallRButton.TabIndex = 0;
            this.WFSizeSmallRButton.Text = "Pequeño";
            this.WFSizeSmallRButton.UseVisualStyleBackColor = true;
            this.WFSizeSmallRButton.CheckedChanged += new System.EventHandler(this.WFSizeSmallRButton_CheckedChanged);
            // 
            // WFColorObjectGroupBox
            // 
            this.WFColorObjectGroupBox.Controls.Add(this.WFColorWhiteRButton);
            this.WFColorObjectGroupBox.Controls.Add(this.WFColorBlackRButton);
            this.WFColorObjectGroupBox.Controls.Add(this.WFColorBrownRButton);
            this.WFColorObjectGroupBox.Controls.Add(this.WFColorBlueRButton);
            this.WFColorObjectGroupBox.Controls.Add(this.WFColorGreenRButton);
            this.WFColorObjectGroupBox.Controls.Add(this.WFColorYellowRButton);
            this.WFColorObjectGroupBox.Controls.Add(this.WFColorRedRButton);
            this.WFColorObjectGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorObjectGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFColorObjectGroupBox.Location = new System.Drawing.Point(575, 211);
            this.WFColorObjectGroupBox.Name = "WFColorObjectGroupBox";
            this.WFColorObjectGroupBox.Size = new System.Drawing.Size(383, 91);
            this.WFColorObjectGroupBox.TabIndex = 7;
            this.WFColorObjectGroupBox.TabStop = false;
            this.WFColorObjectGroupBox.Text = "Elija un color";
            // 
            // WFColorWhiteRButton
            // 
            this.WFColorWhiteRButton.AutoSize = true;
            this.WFColorWhiteRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorWhiteRButton.ForeColor = System.Drawing.Color.Red;
            this.WFColorWhiteRButton.Location = new System.Drawing.Point(201, 49);
            this.WFColorWhiteRButton.Name = "WFColorWhiteRButton";
            this.WFColorWhiteRButton.Size = new System.Drawing.Size(58, 17);
            this.WFColorWhiteRButton.TabIndex = 6;
            this.WFColorWhiteRButton.Text = "Blanco";
            this.WFColorWhiteRButton.UseVisualStyleBackColor = true;
            this.WFColorWhiteRButton.CheckedChanged += new System.EventHandler(this.WFColorWhiteRButton_CheckedChanged);
            // 
            // WFColorBlackRButton
            // 
            this.WFColorBlackRButton.AutoSize = true;
            this.WFColorBlackRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorBlackRButton.ForeColor = System.Drawing.Color.Red;
            this.WFColorBlackRButton.Location = new System.Drawing.Point(110, 49);
            this.WFColorBlackRButton.Name = "WFColorBlackRButton";
            this.WFColorBlackRButton.Size = new System.Drawing.Size(54, 17);
            this.WFColorBlackRButton.TabIndex = 5;
            this.WFColorBlackRButton.Text = "Negro";
            this.WFColorBlackRButton.UseVisualStyleBackColor = true;
            this.WFColorBlackRButton.CheckedChanged += new System.EventHandler(this.WFColorBlackRButton_CheckedChanged);
            // 
            // WFColorBrownRButton
            // 
            this.WFColorBrownRButton.AutoSize = true;
            this.WFColorBrownRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorBrownRButton.ForeColor = System.Drawing.Color.Red;
            this.WFColorBrownRButton.Location = new System.Drawing.Point(9, 49);
            this.WFColorBrownRButton.Name = "WFColorBrownRButton";
            this.WFColorBrownRButton.Size = new System.Drawing.Size(58, 17);
            this.WFColorBrownRButton.TabIndex = 4;
            this.WFColorBrownRButton.Text = "Marrón";
            this.WFColorBrownRButton.UseVisualStyleBackColor = true;
            this.WFColorBrownRButton.CheckedChanged += new System.EventHandler(this.WFColorBrownRButton_CheckedChanged);
            // 
            // WFColorBlueRButton
            // 
            this.WFColorBlueRButton.AutoSize = true;
            this.WFColorBlueRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorBlueRButton.ForeColor = System.Drawing.Color.Red;
            this.WFColorBlueRButton.Location = new System.Drawing.Point(295, 26);
            this.WFColorBlueRButton.Name = "WFColorBlueRButton";
            this.WFColorBlueRButton.Size = new System.Drawing.Size(45, 17);
            this.WFColorBlueRButton.TabIndex = 3;
            this.WFColorBlueRButton.Text = "Azul";
            this.WFColorBlueRButton.UseVisualStyleBackColor = true;
            this.WFColorBlueRButton.CheckedChanged += new System.EventHandler(this.WFColorBlueRButton_CheckedChanged);
            // 
            // WFColorGreenRButton
            // 
            this.WFColorGreenRButton.AutoSize = true;
            this.WFColorGreenRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorGreenRButton.ForeColor = System.Drawing.Color.Red;
            this.WFColorGreenRButton.Location = new System.Drawing.Point(201, 26);
            this.WFColorGreenRButton.Name = "WFColorGreenRButton";
            this.WFColorGreenRButton.Size = new System.Drawing.Size(53, 17);
            this.WFColorGreenRButton.TabIndex = 2;
            this.WFColorGreenRButton.Text = "Verde";
            this.WFColorGreenRButton.UseVisualStyleBackColor = true;
            this.WFColorGreenRButton.CheckedChanged += new System.EventHandler(this.WFColorGreenRButton_CheckedChanged);
            // 
            // WFColorYellowRButton
            // 
            this.WFColorYellowRButton.AutoSize = true;
            this.WFColorYellowRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorYellowRButton.ForeColor = System.Drawing.Color.Red;
            this.WFColorYellowRButton.Location = new System.Drawing.Point(110, 26);
            this.WFColorYellowRButton.Name = "WFColorYellowRButton";
            this.WFColorYellowRButton.Size = new System.Drawing.Size(61, 17);
            this.WFColorYellowRButton.TabIndex = 1;
            this.WFColorYellowRButton.Text = "Amarillo";
            this.WFColorYellowRButton.UseVisualStyleBackColor = true;
            this.WFColorYellowRButton.CheckedChanged += new System.EventHandler(this.WFColorYellowRButton_CheckedChanged);
            // 
            // WFColorRedRButton
            // 
            this.WFColorRedRButton.AutoSize = true;
            this.WFColorRedRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFColorRedRButton.ForeColor = System.Drawing.Color.Red;
            this.WFColorRedRButton.Location = new System.Drawing.Point(9, 26);
            this.WFColorRedRButton.Name = "WFColorRedRButton";
            this.WFColorRedRButton.Size = new System.Drawing.Size(47, 17);
            this.WFColorRedRButton.TabIndex = 0;
            this.WFColorRedRButton.Text = "Rojo";
            this.WFColorRedRButton.UseVisualStyleBackColor = true;
            this.WFColorRedRButton.CheckedChanged += new System.EventHandler(this.WFColorRedRButton_CheckedChanged);
            // 
            // WFAddButton
            // 
            this.WFAddButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.WFAddButton.ForeColor = System.Drawing.Color.Black;
            this.WFAddButton.Location = new System.Drawing.Point(715, 359);
            this.WFAddButton.Name = "WFAddButton";
            this.WFAddButton.Size = new System.Drawing.Size(75, 24);
            this.WFAddButton.TabIndex = 8;
            this.WFAddButton.Text = "Agregar";
            this.WFAddButton.UseVisualStyleBackColor = false;
            this.WFAddButton.Click += new System.EventHandler(this.WFAddButton_Click);
            // 
            // WFRemoveButton
            // 
            this.WFRemoveButton.ForeColor = System.Drawing.Color.Black;
            this.WFRemoveButton.Location = new System.Drawing.Point(796, 360);
            this.WFRemoveButton.Name = "WFRemoveButton";
            this.WFRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.WFRemoveButton.TabIndex = 9;
            this.WFRemoveButton.Text = "Remover";
            this.WFRemoveButton.UseVisualStyleBackColor = true;
            this.WFRemoveButton.Click += new System.EventHandler(this.WFRemoveButton_Click);
            // 
            // WFCodeNumeric
            // 
            this.WFCodeNumeric.ForeColor = System.Drawing.Color.Black;
            this.WFCodeNumeric.Location = new System.Drawing.Point(9, 19);
            this.WFCodeNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.WFCodeNumeric.Name = "WFCodeNumeric";
            this.WFCodeNumeric.Size = new System.Drawing.Size(85, 20);
            this.WFCodeNumeric.TabIndex = 10;
            this.WFCodeNumeric.ValueChanged += new System.EventHandler(this.WFCodeNumeric_ValueChanged);
            // 
            // WFDirectionObjectGroupBox
            // 
            this.WFDirectionObjectGroupBox.Controls.Add(this.WFDirectionWestRadioButton);
            this.WFDirectionObjectGroupBox.Controls.Add(this.WFDirectionEastRadioButton);
            this.WFDirectionObjectGroupBox.Controls.Add(this.WFDirectionSourthRadioButton);
            this.WFDirectionObjectGroupBox.Controls.Add(this.WFDirectionNorthRadioButton);
            this.WFDirectionObjectGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFDirectionObjectGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFDirectionObjectGroupBox.Location = new System.Drawing.Point(578, 313);
            this.WFDirectionObjectGroupBox.Name = "WFDirectionObjectGroupBox";
            this.WFDirectionObjectGroupBox.Size = new System.Drawing.Size(383, 40);
            this.WFDirectionObjectGroupBox.TabIndex = 17;
            this.WFDirectionObjectGroupBox.TabStop = false;
            this.WFDirectionObjectGroupBox.Text = "Elija una dirección";
            // 
            // WFDirectionWestRadioButton
            // 
            this.WFDirectionWestRadioButton.AutoSize = true;
            this.WFDirectionWestRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFDirectionWestRadioButton.ForeColor = System.Drawing.Color.Red;
            this.WFDirectionWestRadioButton.Location = new System.Drawing.Point(291, 15);
            this.WFDirectionWestRadioButton.Name = "WFDirectionWestRadioButton";
            this.WFDirectionWestRadioButton.Size = new System.Drawing.Size(53, 17);
            this.WFDirectionWestRadioButton.TabIndex = 3;
            this.WFDirectionWestRadioButton.TabStop = true;
            this.WFDirectionWestRadioButton.Text = "Oeste";
            this.WFDirectionWestRadioButton.UseVisualStyleBackColor = true;
            this.WFDirectionWestRadioButton.CheckedChanged += new System.EventHandler(this.WFDirectionWestRadioButton_CheckedChanged);
            // 
            // WFDirectionEastRadioButton
            // 
            this.WFDirectionEastRadioButton.AutoSize = true;
            this.WFDirectionEastRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFDirectionEastRadioButton.ForeColor = System.Drawing.Color.Red;
            this.WFDirectionEastRadioButton.Location = new System.Drawing.Point(201, 16);
            this.WFDirectionEastRadioButton.Name = "WFDirectionEastRadioButton";
            this.WFDirectionEastRadioButton.Size = new System.Drawing.Size(46, 17);
            this.WFDirectionEastRadioButton.TabIndex = 2;
            this.WFDirectionEastRadioButton.TabStop = true;
            this.WFDirectionEastRadioButton.Text = "Este";
            this.WFDirectionEastRadioButton.UseVisualStyleBackColor = true;
            this.WFDirectionEastRadioButton.CheckedChanged += new System.EventHandler(this.WFDirectionEastRadioButton_CheckedChanged);
            // 
            // WFDirectionSourthRadioButton
            // 
            this.WFDirectionSourthRadioButton.AutoSize = true;
            this.WFDirectionSourthRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFDirectionSourthRadioButton.ForeColor = System.Drawing.Color.Red;
            this.WFDirectionSourthRadioButton.Location = new System.Drawing.Point(107, 16);
            this.WFDirectionSourthRadioButton.Name = "WFDirectionSourthRadioButton";
            this.WFDirectionSourthRadioButton.Size = new System.Drawing.Size(41, 17);
            this.WFDirectionSourthRadioButton.TabIndex = 1;
            this.WFDirectionSourthRadioButton.TabStop = true;
            this.WFDirectionSourthRadioButton.Text = "Sur";
            this.WFDirectionSourthRadioButton.UseVisualStyleBackColor = true;
            this.WFDirectionSourthRadioButton.CheckedChanged += new System.EventHandler(this.WFDirectionSourthRadioButton_CheckedChanged);
            // 
            // WFDirectionNorthRadioButton
            // 
            this.WFDirectionNorthRadioButton.AutoSize = true;
            this.WFDirectionNorthRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WFDirectionNorthRadioButton.ForeColor = System.Drawing.Color.Red;
            this.WFDirectionNorthRadioButton.Location = new System.Drawing.Point(3, 16);
            this.WFDirectionNorthRadioButton.Name = "WFDirectionNorthRadioButton";
            this.WFDirectionNorthRadioButton.Size = new System.Drawing.Size(51, 17);
            this.WFDirectionNorthRadioButton.TabIndex = 0;
            this.WFDirectionNorthRadioButton.TabStop = true;
            this.WFDirectionNorthRadioButton.Text = "Norte";
            this.WFDirectionNorthRadioButton.UseVisualStyleBackColor = true;
            this.WFDirectionNorthRadioButton.CheckedChanged += new System.EventHandler(this.WFDirectionNorthRadioButton_CheckedChanged);
            // 
            // WFChangeButton
            // 
            this.WFChangeButton.ForeColor = System.Drawing.Color.Black;
            this.WFChangeButton.Location = new System.Drawing.Point(877, 360);
            this.WFChangeButton.Name = "WFChangeButton";
            this.WFChangeButton.Size = new System.Drawing.Size(75, 23);
            this.WFChangeButton.TabIndex = 18;
            this.WFChangeButton.Text = "Modificar";
            this.WFChangeButton.UseVisualStyleBackColor = true;
            this.WFChangeButton.Click += new System.EventHandler(this.WFChangeButton_Click);
            // 
            // WFSimufieldLayoutPanel
            // 
            this.WFSimufieldLayoutPanel.AutoScroll = true;
            this.WFSimufieldLayoutPanel.Controls.Add(this.WFSimufieldPictureBox);
            this.WFSimufieldLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.WFSimufieldLayoutPanel.Name = "WFSimufieldLayoutPanel";
            this.WFSimufieldLayoutPanel.Size = new System.Drawing.Size(572, 406);
            this.WFSimufieldLayoutPanel.TabIndex = 19;
            // 
            // WFSimufieldPictureBox
            // 
            this.WFSimufieldPictureBox.Location = new System.Drawing.Point(3, 3);
            this.WFSimufieldPictureBox.Name = "WFSimufieldPictureBox";
            this.WFSimufieldPictureBox.Size = new System.Drawing.Size(96, 72);
            this.WFSimufieldPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.WFSimufieldPictureBox.TabIndex = 0;
            this.WFSimufieldPictureBox.TabStop = false;
            this.WFSimufieldPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.WFSimufieldPictureBox_Paint);
            this.WFSimufieldPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WFSimufieldPictureBox_MouseClick);
            // 
            // WFCodeGroupBox
            // 
            this.WFCodeGroupBox.Controls.Add(this.WFCodeNumeric);
            this.WFCodeGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFCodeGroupBox.Location = new System.Drawing.Point(578, 359);
            this.WFCodeGroupBox.Name = "WFCodeGroupBox";
            this.WFCodeGroupBox.Size = new System.Drawing.Size(133, 46);
            this.WFCodeGroupBox.TabIndex = 4;
            this.WFCodeGroupBox.TabStop = false;
            this.WFCodeGroupBox.Text = "Código:";
            // 
            // WFStartButton
            // 
            this.WFStartButton.Location = new System.Drawing.Point(796, 383);
            this.WFStartButton.Name = "WFStartButton";
            this.WFStartButton.Size = new System.Drawing.Size(75, 23);
            this.WFStartButton.TabIndex = 20;
            this.WFStartButton.Text = "Iniciar";
            this.WFStartButton.UseVisualStyleBackColor = true;
            this.WFStartButton.Click += new System.EventHandler(this.WFStartButton_Click);
            // 
            // WFResizeWorldButton
            // 
            this.WFResizeWorldButton.ForeColor = System.Drawing.Color.Black;
            this.WFResizeWorldButton.Location = new System.Drawing.Point(190, 11);
            this.WFResizeWorldButton.Name = "WFResizeWorldButton";
            this.WFResizeWorldButton.Size = new System.Drawing.Size(75, 52);
            this.WFResizeWorldButton.TabIndex = 11;
            this.WFResizeWorldButton.Text = "Cambiar Mundo";
            this.WFResizeWorldButton.UseVisualStyleBackColor = true;
            this.WFResizeWorldButton.Click += new System.EventHandler(this.WFResizeWorldButton_Click);
            // 
            // WFWallEWorldFormulary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(979, 409);
            this.Controls.Add(this.WFStartButton);
            this.Controls.Add(this.WFCodeGroupBox);
            this.Controls.Add(this.WFSimufieldLayoutPanel);
            this.Controls.Add(this.WFChangeButton);
            this.Controls.Add(this.WFDirectionObjectGroupBox);
            this.Controls.Add(this.WFRemoveButton);
            this.Controls.Add(this.WFAddButton);
            this.Controls.Add(this.WFColorObjectGroupBox);
            this.Controls.Add(this.WFSizeObjectGroupBox);
            this.Controls.Add(this.WFWorldSelectorGroupBox);
            this.Controls.Add(this.WFShapeObjectGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WFWallEWorldFormulary";
            this.Text = "The Return of Wall-E";
            this.WFShapeObjectGroupBox.ResumeLayout(false);
            this.WFShapeObjectGroupBox.PerformLayout();
            this.WFWorldSelectorGroupBox.ResumeLayout(false);
            this.WFWorldSelectorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFColumnsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFFillsNumeric)).EndInit();
            this.WFSizeObjectGroupBox.ResumeLayout(false);
            this.WFSizeObjectGroupBox.PerformLayout();
            this.WFColorObjectGroupBox.ResumeLayout(false);
            this.WFColorObjectGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFCodeNumeric)).EndInit();
            this.WFDirectionObjectGroupBox.ResumeLayout(false);
            this.WFDirectionObjectGroupBox.PerformLayout();
            this.WFSimufieldLayoutPanel.ResumeLayout(false);
            this.WFSimufieldLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFSimufieldPictureBox)).EndInit();
            this.WFCodeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox WFShapeObjectGroupBox;
        private System.Windows.Forms.GroupBox WFWorldSelectorGroupBox;
        private System.Windows.Forms.Label WFFillsLabel;
        private System.Windows.Forms.GroupBox WFSizeObjectGroupBox;
        private System.Windows.Forms.GroupBox WFColorObjectGroupBox;
        private System.Windows.Forms.RadioButton WFShapePlantRButton;
        private System.Windows.Forms.RadioButton WFShapeSphereRButton;
        private System.Windows.Forms.RadioButton WFShapeBoxRButton;
        private System.Windows.Forms.RadioButton WFRobotWallERButton;
        private System.Windows.Forms.NumericUpDown WFColumnsNumeric;
        private System.Windows.Forms.NumericUpDown WFFillsNumeric;
        private System.Windows.Forms.Label WFColumnsLabel;
        private System.Windows.Forms.RadioButton WFSizeLargeRButton;
        private System.Windows.Forms.RadioButton WFSizeMediumRButton;
        private System.Windows.Forms.RadioButton WFSizeSmallRButton;
        private System.Windows.Forms.RadioButton WFColorWhiteRButton;
        private System.Windows.Forms.RadioButton WFColorBlackRButton;
        private System.Windows.Forms.RadioButton WFColorBrownRButton;
        private System.Windows.Forms.RadioButton WFColorBlueRButton;
        private System.Windows.Forms.RadioButton WFColorGreenRButton;
        private System.Windows.Forms.RadioButton WFColorYellowRButton;
        private System.Windows.Forms.RadioButton WFColorRedRButton;
        private System.Windows.Forms.Label WFObjectsLabel;
        private System.Windows.Forms.Label WFRobotsLabel;
        private System.Windows.Forms.Button WFRestartWorldButton;
        private System.Windows.Forms.Button WFAddButton;
        private System.Windows.Forms.Button WFRemoveButton;
        private System.Windows.Forms.NumericUpDown WFCodeNumeric;
        private System.Windows.Forms.GroupBox WFDirectionObjectGroupBox;
        private System.Windows.Forms.RadioButton WFDirectionWestRadioButton;
        private System.Windows.Forms.RadioButton WFDirectionEastRadioButton;
        private System.Windows.Forms.RadioButton WFDirectionSourthRadioButton;
        private System.Windows.Forms.RadioButton WFDirectionNorthRadioButton;
        private System.Windows.Forms.Button WFChangeButton;
        private System.Windows.Forms.PictureBox WFSimufieldPictureBox;
        private System.Windows.Forms.FlowLayoutPanel WFSimufieldLayoutPanel;
        private System.Windows.Forms.GroupBox WFCodeGroupBox;
        private System.Windows.Forms.Button WFStartButton;
        private System.Windows.Forms.Button WFResizeWorldButton;
    }
}

