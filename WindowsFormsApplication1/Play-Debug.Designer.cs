namespace WindowsFormsApplication1
{
    partial class WFPlayDebugFormulary
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
            this.components = new System.ComponentModel.Container();
            this.WFSimufieldPictureBox = new System.Windows.Forms.PictureBox();
            this.WFSimufieldLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.WFTimeElapsedGroupBox = new System.Windows.Forms.GroupBox();
            this.WFTimeElapsedNumeric = new System.Windows.Forms.NumericUpDown();
            this.WFDebugTurnButton = new System.Windows.Forms.Button();
            this.WFInstructionDebugButton = new System.Windows.Forms.Button();
            this.WFPauseButton = new System.Windows.Forms.Button();
            this.WFStopButton = new System.Windows.Forms.Button();
            this.WFPlayButton = new System.Windows.Forms.Button();
            this.WFSimufieldPlayTimer = new System.Windows.Forms.Timer(this.components);
            this.WFPrintingTextBox = new System.Windows.Forms.TextBox();
            this.WFMatlanlandPictureBox = new System.Windows.Forms.PictureBox();
            this.WFObjectColorGroupBox = new System.Windows.Forms.GroupBox();
            this.WFObjectColorLabel = new System.Windows.Forms.Label();
            this.WFRobotObjectGroupBox = new System.Windows.Forms.GroupBox();
            this.WFRobotObjectPictureBox = new System.Windows.Forms.PictureBox();
            this.WFObjectSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.WFObjectSizeLabel = new System.Windows.Forms.Label();
            this.WFObjectCodeGroupBox = new System.Windows.Forms.GroupBox();
            this.WFObjectCodeLabel = new System.Windows.Forms.Label();
            this.WFObjectShapeGroupBox = new System.Windows.Forms.GroupBox();
            this.WFObjectShapeLabel = new System.Windows.Forms.Label();
            this.WFMatlanLandPanel = new System.Windows.Forms.Panel();
            this.WFFlowGroupBox = new System.Windows.Forms.GroupBox();
            this.WFFlowLabel = new System.Windows.Forms.Label();
            this.WFLinealMemoryGroupBox = new System.Windows.Forms.GroupBox();
            this.WFLinealMemoryTextBox = new System.Windows.Forms.TextBox();
            this.WFRegistryGroupBox = new System.Windows.Forms.GroupBox();
            this.WFRegistryTextBox = new System.Windows.Forms.TextBox();
            this.WFStackGroupBox = new System.Windows.Forms.GroupBox();
            this.WFStackTextBox = new System.Windows.Forms.TextBox();
            this.WFOpenRoutinesGroupBox = new System.Windows.Forms.GroupBox();
            this.WFOpenRoutinesTextBox = new System.Windows.Forms.TextBox();
            this.WFObjectPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WFSimufieldPictureBox)).BeginInit();
            this.WFSimufieldLayoutPanel.SuspendLayout();
            this.WFTimeElapsedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFTimeElapsedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFMatlanlandPictureBox)).BeginInit();
            this.WFObjectColorGroupBox.SuspendLayout();
            this.WFRobotObjectGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFRobotObjectPictureBox)).BeginInit();
            this.WFObjectSizeGroupBox.SuspendLayout();
            this.WFObjectCodeGroupBox.SuspendLayout();
            this.WFObjectShapeGroupBox.SuspendLayout();
            this.WFMatlanLandPanel.SuspendLayout();
            this.WFFlowGroupBox.SuspendLayout();
            this.WFLinealMemoryGroupBox.SuspendLayout();
            this.WFRegistryGroupBox.SuspendLayout();
            this.WFStackGroupBox.SuspendLayout();
            this.WFOpenRoutinesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFObjectPictureBox)).BeginInit();
            this.SuspendLayout();
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
            // WFSimufieldLayoutPanel
            // 
            this.WFSimufieldLayoutPanel.AutoScroll = true;
            this.WFSimufieldLayoutPanel.Controls.Add(this.WFSimufieldPictureBox);
            this.WFSimufieldLayoutPanel.Location = new System.Drawing.Point(3, 48);
            this.WFSimufieldLayoutPanel.Name = "WFSimufieldLayoutPanel";
            this.WFSimufieldLayoutPanel.Size = new System.Drawing.Size(572, 468);
            this.WFSimufieldLayoutPanel.TabIndex = 20;
            // 
            // WFTimeElapsedGroupBox
            // 
            this.WFTimeElapsedGroupBox.Controls.Add(this.WFTimeElapsedNumeric);
            this.WFTimeElapsedGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFTimeElapsedGroupBox.Location = new System.Drawing.Point(6, 522);
            this.WFTimeElapsedGroupBox.Name = "WFTimeElapsedGroupBox";
            this.WFTimeElapsedGroupBox.Size = new System.Drawing.Size(153, 39);
            this.WFTimeElapsedGroupBox.TabIndex = 26;
            this.WFTimeElapsedGroupBox.TabStop = false;
            this.WFTimeElapsedGroupBox.Text = "Tiempo entre turnos (MS)";
            // 
            // WFTimeElapsedNumeric
            // 
            this.WFTimeElapsedNumeric.Location = new System.Drawing.Point(40, 16);
            this.WFTimeElapsedNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WFTimeElapsedNumeric.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WFTimeElapsedNumeric.Name = "WFTimeElapsedNumeric";
            this.WFTimeElapsedNumeric.Size = new System.Drawing.Size(44, 20);
            this.WFTimeElapsedNumeric.TabIndex = 0;
            this.WFTimeElapsedNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.WFTimeElapsedNumeric.ValueChanged += new System.EventHandler(this.WFTimeElapsedNumeric_ValueChanged);
            // 
            // WFDebugTurnButton
            // 
            this.WFDebugTurnButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.TurnDebug;
            this.WFDebugTurnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WFDebugTurnButton.Location = new System.Drawing.Point(165, 0);
            this.WFDebugTurnButton.Name = "WFDebugTurnButton";
            this.WFDebugTurnButton.Size = new System.Drawing.Size(47, 42);
            this.WFDebugTurnButton.TabIndex = 25;
            this.WFDebugTurnButton.UseVisualStyleBackColor = true;
            this.WFDebugTurnButton.Click += new System.EventHandler(this.WFDebugTurnButton_Click);
            // 
            // WFInstructionDebugButton
            // 
            this.WFInstructionDebugButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Instruction_Debug;
            this.WFInstructionDebugButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WFInstructionDebugButton.Location = new System.Drawing.Point(218, 0);
            this.WFInstructionDebugButton.Name = "WFInstructionDebugButton";
            this.WFInstructionDebugButton.Size = new System.Drawing.Size(47, 42);
            this.WFInstructionDebugButton.TabIndex = 24;
            this.WFInstructionDebugButton.UseVisualStyleBackColor = true;
            this.WFInstructionDebugButton.Click += new System.EventHandler(this.WFInstructionDebugButton_Click);
            // 
            // WFPauseButton
            // 
            this.WFPauseButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Pause;
            this.WFPauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WFPauseButton.Location = new System.Drawing.Point(59, 0);
            this.WFPauseButton.Name = "WFPauseButton";
            this.WFPauseButton.Size = new System.Drawing.Size(47, 42);
            this.WFPauseButton.TabIndex = 23;
            this.WFPauseButton.UseVisualStyleBackColor = true;
            this.WFPauseButton.Click += new System.EventHandler(this.WFPauseButton_Click);
            // 
            // WFStopButton
            // 
            this.WFStopButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Stop;
            this.WFStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WFStopButton.Location = new System.Drawing.Point(112, 0);
            this.WFStopButton.Name = "WFStopButton";
            this.WFStopButton.Size = new System.Drawing.Size(47, 42);
            this.WFStopButton.TabIndex = 22;
            this.WFStopButton.UseVisualStyleBackColor = true;
            this.WFStopButton.Click += new System.EventHandler(this.WFStopButton_Click);
            // 
            // WFPlayButton
            // 
            this.WFPlayButton.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Play;
            this.WFPlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WFPlayButton.Location = new System.Drawing.Point(3, 0);
            this.WFPlayButton.Name = "WFPlayButton";
            this.WFPlayButton.Size = new System.Drawing.Size(47, 42);
            this.WFPlayButton.TabIndex = 21;
            this.WFPlayButton.UseVisualStyleBackColor = true;
            this.WFPlayButton.Click += new System.EventHandler(this.WFPlayButton_Click);
            // 
            // WFSimufieldPlayTimer
            // 
            this.WFSimufieldPlayTimer.Tick += new System.EventHandler(this.WFSimufieldPlayTimer_Tick);
            // 
            // WFPrintingTextBox
            // 
            this.WFPrintingTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.WFPrintingTextBox.Location = new System.Drawing.Point(165, 525);
            this.WFPrintingTextBox.Multiline = true;
            this.WFPrintingTextBox.Name = "WFPrintingTextBox";
            this.WFPrintingTextBox.ReadOnly = true;
            this.WFPrintingTextBox.Size = new System.Drawing.Size(410, 36);
            this.WFPrintingTextBox.TabIndex = 27;
            // 
            // WFMatlanlandPictureBox
            // 
            this.WFMatlanlandPictureBox.Location = new System.Drawing.Point(-1, -1);
            this.WFMatlanlandPictureBox.Name = "WFMatlanlandPictureBox";
            this.WFMatlanlandPictureBox.Size = new System.Drawing.Size(100, 50);
            this.WFMatlanlandPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.WFMatlanlandPictureBox.TabIndex = 24;
            this.WFMatlanlandPictureBox.TabStop = false;
            this.WFMatlanlandPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.WFMatlanlandPictureBox_Paint);
            // 
            // WFObjectColorGroupBox
            // 
            this.WFObjectColorGroupBox.Controls.Add(this.WFObjectColorLabel);
            this.WFObjectColorGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFObjectColorGroupBox.Location = new System.Drawing.Point(782, 8);
            this.WFObjectColorGroupBox.Name = "WFObjectColorGroupBox";
            this.WFObjectColorGroupBox.Size = new System.Drawing.Size(67, 37);
            this.WFObjectColorGroupBox.TabIndex = 30;
            this.WFObjectColorGroupBox.TabStop = false;
            this.WFObjectColorGroupBox.Text = "Color:";
            // 
            // WFObjectColorLabel
            // 
            this.WFObjectColorLabel.AutoSize = true;
            this.WFObjectColorLabel.Location = new System.Drawing.Point(6, 16);
            this.WFObjectColorLabel.Name = "WFObjectColorLabel";
            this.WFObjectColorLabel.Size = new System.Drawing.Size(31, 13);
            this.WFObjectColorLabel.TabIndex = 3;
            this.WFObjectColorLabel.Text = "Color";
            // 
            // WFRobotObjectGroupBox
            // 
            this.WFRobotObjectGroupBox.Controls.Add(this.WFRobotObjectPictureBox);
            this.WFRobotObjectGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFRobotObjectGroupBox.Location = new System.Drawing.Point(1154, 8);
            this.WFRobotObjectGroupBox.Name = "WFRobotObjectGroupBox";
            this.WFRobotObjectGroupBox.Size = new System.Drawing.Size(67, 73);
            this.WFRobotObjectGroupBox.TabIndex = 31;
            this.WFRobotObjectGroupBox.TabStop = false;
            this.WFRobotObjectGroupBox.Text = "Objeto:";
            // 
            // WFRobotObjectPictureBox
            // 
            this.WFRobotObjectPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WFRobotObjectPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFRobotObjectPictureBox.Location = new System.Drawing.Point(6, 17);
            this.WFRobotObjectPictureBox.Name = "WFRobotObjectPictureBox";
            this.WFRobotObjectPictureBox.Size = new System.Drawing.Size(50, 50);
            this.WFRobotObjectPictureBox.TabIndex = 21;
            this.WFRobotObjectPictureBox.TabStop = false;
            // 
            // WFObjectSizeGroupBox
            // 
            this.WFObjectSizeGroupBox.Controls.Add(this.WFObjectSizeLabel);
            this.WFObjectSizeGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFObjectSizeGroupBox.Location = new System.Drawing.Point(698, 8);
            this.WFObjectSizeGroupBox.Name = "WFObjectSizeGroupBox";
            this.WFObjectSizeGroupBox.Size = new System.Drawing.Size(67, 37);
            this.WFObjectSizeGroupBox.TabIndex = 32;
            this.WFObjectSizeGroupBox.TabStop = false;
            this.WFObjectSizeGroupBox.Text = "Tamaño:";
            // 
            // WFObjectSizeLabel
            // 
            this.WFObjectSizeLabel.AutoSize = true;
            this.WFObjectSizeLabel.Location = new System.Drawing.Point(6, 16);
            this.WFObjectSizeLabel.Name = "WFObjectSizeLabel";
            this.WFObjectSizeLabel.Size = new System.Drawing.Size(46, 13);
            this.WFObjectSizeLabel.TabIndex = 3;
            this.WFObjectSizeLabel.Text = "Tamaño";
            // 
            // WFObjectCodeGroupBox
            // 
            this.WFObjectCodeGroupBox.Controls.Add(this.WFObjectCodeLabel);
            this.WFObjectCodeGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFObjectCodeGroupBox.Location = new System.Drawing.Point(855, 8);
            this.WFObjectCodeGroupBox.Name = "WFObjectCodeGroupBox";
            this.WFObjectCodeGroupBox.Size = new System.Drawing.Size(67, 37);
            this.WFObjectCodeGroupBox.TabIndex = 33;
            this.WFObjectCodeGroupBox.TabStop = false;
            this.WFObjectCodeGroupBox.Text = "Código:";
            // 
            // WFObjectCodeLabel
            // 
            this.WFObjectCodeLabel.AutoSize = true;
            this.WFObjectCodeLabel.Location = new System.Drawing.Point(6, 16);
            this.WFObjectCodeLabel.Name = "WFObjectCodeLabel";
            this.WFObjectCodeLabel.Size = new System.Drawing.Size(40, 13);
            this.WFObjectCodeLabel.TabIndex = 3;
            this.WFObjectCodeLabel.Text = "Código";
            // 
            // WFObjectShapeGroupBox
            // 
            this.WFObjectShapeGroupBox.Controls.Add(this.WFObjectShapeLabel);
            this.WFObjectShapeGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFObjectShapeGroupBox.Location = new System.Drawing.Point(616, 8);
            this.WFObjectShapeGroupBox.Name = "WFObjectShapeGroupBox";
            this.WFObjectShapeGroupBox.Size = new System.Drawing.Size(67, 37);
            this.WFObjectShapeGroupBox.TabIndex = 34;
            this.WFObjectShapeGroupBox.TabStop = false;
            this.WFObjectShapeGroupBox.Text = "Forma:";
            // 
            // WFObjectShapeLabel
            // 
            this.WFObjectShapeLabel.AutoSize = true;
            this.WFObjectShapeLabel.Location = new System.Drawing.Point(6, 16);
            this.WFObjectShapeLabel.Name = "WFObjectShapeLabel";
            this.WFObjectShapeLabel.Size = new System.Drawing.Size(36, 13);
            this.WFObjectShapeLabel.TabIndex = 3;
            this.WFObjectShapeLabel.Text = "Forma";
            // 
            // WFMatlanLandPanel
            // 
            this.WFMatlanLandPanel.AutoScroll = true;
            this.WFMatlanLandPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFMatlanLandPanel.Controls.Add(this.WFMatlanlandPictureBox);
            this.WFMatlanLandPanel.Location = new System.Drawing.Point(616, 51);
            this.WFMatlanLandPanel.MinimumSize = new System.Drawing.Size(2, 2);
            this.WFMatlanLandPanel.Name = "WFMatlanLandPanel";
            this.WFMatlanLandPanel.Size = new System.Drawing.Size(532, 516);
            this.WFMatlanLandPanel.TabIndex = 29;
            // 
            // WFFlowGroupBox
            // 
            this.WFFlowGroupBox.Controls.Add(this.WFFlowLabel);
            this.WFFlowGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFFlowGroupBox.Location = new System.Drawing.Point(938, 8);
            this.WFFlowGroupBox.Name = "WFFlowGroupBox";
            this.WFFlowGroupBox.Size = new System.Drawing.Size(118, 37);
            this.WFFlowGroupBox.TabIndex = 35;
            this.WFFlowGroupBox.TabStop = false;
            this.WFFlowGroupBox.Text = "Flujo de la Rutina:";
            // 
            // WFFlowLabel
            // 
            this.WFFlowLabel.AutoSize = true;
            this.WFFlowLabel.Location = new System.Drawing.Point(6, 16);
            this.WFFlowLabel.Name = "WFFlowLabel";
            this.WFFlowLabel.Size = new System.Drawing.Size(89, 13);
            this.WFFlowLabel.TabIndex = 3;
            this.WFFlowLabel.Text = "Flujo de la Rutina";
            // 
            // WFLinealMemoryGroupBox
            // 
            this.WFLinealMemoryGroupBox.Controls.Add(this.WFLinealMemoryTextBox);
            this.WFLinealMemoryGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFLinealMemoryGroupBox.Location = new System.Drawing.Point(1154, 266);
            this.WFLinealMemoryGroupBox.Name = "WFLinealMemoryGroupBox";
            this.WFLinealMemoryGroupBox.Size = new System.Drawing.Size(130, 86);
            this.WFLinealMemoryGroupBox.TabIndex = 36;
            this.WFLinealMemoryGroupBox.TabStop = false;
            this.WFLinealMemoryGroupBox.Text = "Memoria Lineal";
            // 
            // WFLinealMemoryTextBox
            // 
            this.WFLinealMemoryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFLinealMemoryTextBox.Location = new System.Drawing.Point(6, 13);
            this.WFLinealMemoryTextBox.Multiline = true;
            this.WFLinealMemoryTextBox.Name = "WFLinealMemoryTextBox";
            this.WFLinealMemoryTextBox.ReadOnly = true;
            this.WFLinealMemoryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WFLinealMemoryTextBox.Size = new System.Drawing.Size(116, 63);
            this.WFLinealMemoryTextBox.TabIndex = 0;
            // 
            // WFRegistryGroupBox
            // 
            this.WFRegistryGroupBox.Controls.Add(this.WFRegistryTextBox);
            this.WFRegistryGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFRegistryGroupBox.Location = new System.Drawing.Point(1154, 163);
            this.WFRegistryGroupBox.Name = "WFRegistryGroupBox";
            this.WFRegistryGroupBox.Size = new System.Drawing.Size(130, 86);
            this.WFRegistryGroupBox.TabIndex = 37;
            this.WFRegistryGroupBox.TabStop = false;
            this.WFRegistryGroupBox.Text = "Registro";
            // 
            // WFRegistryTextBox
            // 
            this.WFRegistryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFRegistryTextBox.Location = new System.Drawing.Point(6, 13);
            this.WFRegistryTextBox.Multiline = true;
            this.WFRegistryTextBox.Name = "WFRegistryTextBox";
            this.WFRegistryTextBox.ReadOnly = true;
            this.WFRegistryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WFRegistryTextBox.Size = new System.Drawing.Size(116, 63);
            this.WFRegistryTextBox.TabIndex = 0;
            // 
            // WFStackGroupBox
            // 
            this.WFStackGroupBox.Controls.Add(this.WFStackTextBox);
            this.WFStackGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFStackGroupBox.Location = new System.Drawing.Point(1154, 370);
            this.WFStackGroupBox.Name = "WFStackGroupBox";
            this.WFStackGroupBox.Size = new System.Drawing.Size(130, 86);
            this.WFStackGroupBox.TabIndex = 38;
            this.WFStackGroupBox.TabStop = false;
            this.WFStackGroupBox.Text = "Pila:";
            // 
            // WFStackTextBox
            // 
            this.WFStackTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFStackTextBox.Location = new System.Drawing.Point(6, 13);
            this.WFStackTextBox.Multiline = true;
            this.WFStackTextBox.Name = "WFStackTextBox";
            this.WFStackTextBox.ReadOnly = true;
            this.WFStackTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WFStackTextBox.Size = new System.Drawing.Size(116, 63);
            this.WFStackTextBox.TabIndex = 0;
            // 
            // WFOpenRoutinesGroupBox
            // 
            this.WFOpenRoutinesGroupBox.Controls.Add(this.WFOpenRoutinesTextBox);
            this.WFOpenRoutinesGroupBox.ForeColor = System.Drawing.Color.Red;
            this.WFOpenRoutinesGroupBox.Location = new System.Drawing.Point(1154, 481);
            this.WFOpenRoutinesGroupBox.Name = "WFOpenRoutinesGroupBox";
            this.WFOpenRoutinesGroupBox.Size = new System.Drawing.Size(130, 86);
            this.WFOpenRoutinesGroupBox.TabIndex = 37;
            this.WFOpenRoutinesGroupBox.TabStop = false;
            this.WFOpenRoutinesGroupBox.Text = "Rutina abiertas";
            // 
            // WFOpenRoutinesTextBox
            // 
            this.WFOpenRoutinesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFOpenRoutinesTextBox.Location = new System.Drawing.Point(6, 13);
            this.WFOpenRoutinesTextBox.Multiline = true;
            this.WFOpenRoutinesTextBox.Name = "WFOpenRoutinesTextBox";
            this.WFOpenRoutinesTextBox.ReadOnly = true;
            this.WFOpenRoutinesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WFOpenRoutinesTextBox.Size = new System.Drawing.Size(116, 63);
            this.WFOpenRoutinesTextBox.TabIndex = 0;
            // 
            // WFObjectPictureBox
            // 
            this.WFObjectPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.WFObjectPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WFObjectPictureBox.Location = new System.Drawing.Point(1235, 12);
            this.WFObjectPictureBox.Name = "WFObjectPictureBox";
            this.WFObjectPictureBox.Size = new System.Drawing.Size(123, 123);
            this.WFObjectPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.WFObjectPictureBox.TabIndex = 39;
            this.WFObjectPictureBox.TabStop = false;
            // 
            // WFPlayDebugFormulary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1370, 582);
            this.Controls.Add(this.WFObjectPictureBox);
            this.Controls.Add(this.WFLinealMemoryGroupBox);
            this.Controls.Add(this.WFStackGroupBox);
            this.Controls.Add(this.WFFlowGroupBox);
            this.Controls.Add(this.WFPrintingTextBox);
            this.Controls.Add(this.WFOpenRoutinesGroupBox);
            this.Controls.Add(this.WFRegistryGroupBox);
            this.Controls.Add(this.WFMatlanLandPanel);
            this.Controls.Add(this.WFTimeElapsedGroupBox);
            this.Controls.Add(this.WFObjectShapeGroupBox);
            this.Controls.Add(this.WFDebugTurnButton);
            this.Controls.Add(this.WFObjectCodeGroupBox);
            this.Controls.Add(this.WFInstructionDebugButton);
            this.Controls.Add(this.WFObjectSizeGroupBox);
            this.Controls.Add(this.WFPauseButton);
            this.Controls.Add(this.WFRobotObjectGroupBox);
            this.Controls.Add(this.WFStopButton);
            this.Controls.Add(this.WFObjectColorGroupBox);
            this.Controls.Add(this.WFPlayButton);
            this.Controls.Add(this.WFSimufieldLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WFPlayDebugFormulary";
            this.Text = "The Return of Wall-E";
            ((System.ComponentModel.ISupportInitialize)(this.WFSimufieldPictureBox)).EndInit();
            this.WFSimufieldLayoutPanel.ResumeLayout(false);
            this.WFSimufieldLayoutPanel.PerformLayout();
            this.WFTimeElapsedGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WFTimeElapsedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WFMatlanlandPictureBox)).EndInit();
            this.WFObjectColorGroupBox.ResumeLayout(false);
            this.WFObjectColorGroupBox.PerformLayout();
            this.WFRobotObjectGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WFRobotObjectPictureBox)).EndInit();
            this.WFObjectSizeGroupBox.ResumeLayout(false);
            this.WFObjectSizeGroupBox.PerformLayout();
            this.WFObjectCodeGroupBox.ResumeLayout(false);
            this.WFObjectCodeGroupBox.PerformLayout();
            this.WFObjectShapeGroupBox.ResumeLayout(false);
            this.WFObjectShapeGroupBox.PerformLayout();
            this.WFMatlanLandPanel.ResumeLayout(false);
            this.WFMatlanLandPanel.PerformLayout();
            this.WFFlowGroupBox.ResumeLayout(false);
            this.WFFlowGroupBox.PerformLayout();
            this.WFLinealMemoryGroupBox.ResumeLayout(false);
            this.WFLinealMemoryGroupBox.PerformLayout();
            this.WFRegistryGroupBox.ResumeLayout(false);
            this.WFRegistryGroupBox.PerformLayout();
            this.WFStackGroupBox.ResumeLayout(false);
            this.WFStackGroupBox.PerformLayout();
            this.WFOpenRoutinesGroupBox.ResumeLayout(false);
            this.WFOpenRoutinesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WFObjectPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WFSimufieldPictureBox;
        private System.Windows.Forms.FlowLayoutPanel WFSimufieldLayoutPanel;
        private System.Windows.Forms.GroupBox WFTimeElapsedGroupBox;
        private System.Windows.Forms.NumericUpDown WFTimeElapsedNumeric;
        private System.Windows.Forms.Button WFDebugTurnButton;
        private System.Windows.Forms.Button WFInstructionDebugButton;
        private System.Windows.Forms.Button WFPauseButton;
        private System.Windows.Forms.Button WFStopButton;
        private System.Windows.Forms.Button WFPlayButton;
        private System.Windows.Forms.Timer WFSimufieldPlayTimer;
        private System.Windows.Forms.TextBox WFPrintingTextBox;
        private System.Windows.Forms.PictureBox WFMatlanlandPictureBox;
        private System.Windows.Forms.GroupBox WFObjectColorGroupBox;
        private System.Windows.Forms.Label WFObjectColorLabel;
        private System.Windows.Forms.GroupBox WFRobotObjectGroupBox;
        private System.Windows.Forms.PictureBox WFRobotObjectPictureBox;
        private System.Windows.Forms.GroupBox WFObjectSizeGroupBox;
        private System.Windows.Forms.Label WFObjectSizeLabel;
        private System.Windows.Forms.GroupBox WFObjectCodeGroupBox;
        private System.Windows.Forms.Label WFObjectCodeLabel;
        private System.Windows.Forms.GroupBox WFObjectShapeGroupBox;
        private System.Windows.Forms.Label WFObjectShapeLabel;
        private System.Windows.Forms.Panel WFMatlanLandPanel;
        private System.Windows.Forms.GroupBox WFFlowGroupBox;
        private System.Windows.Forms.Label WFFlowLabel;
        private System.Windows.Forms.GroupBox WFLinealMemoryGroupBox;
        private System.Windows.Forms.TextBox WFLinealMemoryTextBox;
        private System.Windows.Forms.GroupBox WFRegistryGroupBox;
        private System.Windows.Forms.TextBox WFRegistryTextBox;
        private System.Windows.Forms.GroupBox WFStackGroupBox;
        private System.Windows.Forms.TextBox WFStackTextBox;
        private System.Windows.Forms.GroupBox WFOpenRoutinesGroupBox;
        private System.Windows.Forms.TextBox WFOpenRoutinesTextBox;
        private System.Windows.Forms.PictureBox WFObjectPictureBox;
    }
}