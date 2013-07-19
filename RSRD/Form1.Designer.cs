namespace RSRD
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ownerSearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusChecklistbox = new System.Windows.Forms.CheckedListBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.breedComboBox = new System.Windows.Forms.ComboBox();
            this.speciesComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.vaccCheckBox = new System.Windows.Forms.CheckBox();
            this.sterilizedCheckBox = new System.Windows.Forms.CheckBox();
            this.dobEstimateCheckBox = new System.Windows.Forms.CheckBox();
            this.crossbreedCheckBox = new System.Windows.Forms.CheckBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.sexLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.dobTextBox = new System.Windows.Forms.TextBox();
            this.dobLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.moveAnimalButton = new System.Windows.Forms.Button();
            this.adoptButton = new System.Windows.Forms.Button();
            this.addRecordButton = new System.Windows.Forms.Button();
            this.viewRecordButton = new System.Windows.Forms.Button();
            this.animalMainPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sexTestBox = new System.Windows.Forms.TextBox();
            this.ColorTextBox = new System.Windows.Forms.TextBox();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.breedTextBox = new System.Windows.Forms.TextBox();
            this.crossBreedTextBox = new System.Windows.Forms.TextBox();
            this.ownerTextBox = new System.Windows.Forms.TextBox();
            this.coatTextBox = new System.Windows.Forms.TextBox();
            this.litterTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalMainPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(987, 463);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(979, 437);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Animal";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.ownerSearchTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.statusChecklistbox);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton2);
            this.splitContainer1.Panel1.Controls.Add(this.radioButton1);
            this.splitContainer1.Panel1.Controls.Add(this.breedComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.speciesComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.litterTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.coatTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.ownerTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.crossBreedTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.breedTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.locationTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.sizeTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.ColorTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.sexTestBox);
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Panel2.Controls.Add(this.vaccCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.sterilizedCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.dobEstimateCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.crossbreedCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.sizeLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.colorLabel);
            this.splitContainer1.Panel2.Controls.Add(this.sexLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.locationLabel);
            this.splitContainer1.Panel2.Controls.Add(this.dobTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.dobLabel);
            this.splitContainer1.Panel2.Controls.Add(this.nameTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.nameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.idLabel);
            this.splitContainer1.Panel2.Controls.Add(this.idTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.moveAnimalButton);
            this.splitContainer1.Panel2.Controls.Add(this.adoptButton);
            this.splitContainer1.Panel2.Controls.Add(this.addRecordButton);
            this.splitContainer1.Panel2.Controls.Add(this.viewRecordButton);
            this.splitContainer1.Panel2.Controls.Add(this.animalMainPictureBox);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(973, 431);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 156);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(231, 267);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.loadSelected);
            // 
            // ownerSearchTextBox
            // 
            this.ownerSearchTextBox.Location = new System.Drawing.Point(136, 52);
            this.ownerSearchTextBox.Name = "ownerSearchTextBox";
            this.ownerSearchTextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerSearchTextBox.TabIndex = 7;
            this.ownerSearchTextBox.Text = "Owner";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status";
            // 
            // statusChecklistbox
            // 
            this.statusChecklistbox.FormattingEnabled = true;
            this.statusChecklistbox.Items.AddRange(new object[] {
            "Lost",
            "Found",
            "Surrendered",
            "Adopted",
            "Fostered"});
            this.statusChecklistbox.Location = new System.Drawing.Point(9, 71);
            this.statusChecklistbox.Name = "statusChecklistbox";
            this.statusChecklistbox.Size = new System.Drawing.Size(120, 79);
            this.statusChecklistbox.TabIndex = 5;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(163, 29);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Female";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(163, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Male";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // breedComboBox
            // 
            this.breedComboBox.FormattingEnabled = true;
            this.breedComboBox.Location = new System.Drawing.Point(5, 31);
            this.breedComboBox.Name = "breedComboBox";
            this.breedComboBox.Size = new System.Drawing.Size(121, 21);
            this.breedComboBox.TabIndex = 1;
            this.breedComboBox.Text = "Breed";
            // 
            // speciesComboBox
            // 
            this.speciesComboBox.FormattingEnabled = true;
            this.speciesComboBox.Location = new System.Drawing.Point(5, 3);
            this.speciesComboBox.Name = "speciesComboBox";
            this.speciesComboBox.Size = new System.Drawing.Size(121, 21);
            this.speciesComboBox.TabIndex = 0;
            this.speciesComboBox.Text = "Species";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(358, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(369, 421);
            this.tabControl2.TabIndex = 28;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBox5);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(361, 395);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Notes/Comments";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(15, 34);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(320, 82);
            this.textBox5.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Notes/ Comments";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(361, 395);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Health";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // vaccCheckBox
            // 
            this.vaccCheckBox.AutoSize = true;
            this.vaccCheckBox.Location = new System.Drawing.Point(144, 28);
            this.vaccCheckBox.Name = "vaccCheckBox";
            this.vaccCheckBox.Size = new System.Drawing.Size(80, 17);
            this.vaccCheckBox.TabIndex = 25;
            this.vaccCheckBox.Text = "Vaccinated";
            this.vaccCheckBox.UseVisualStyleBackColor = true;
            // 
            // sterilizedCheckBox
            // 
            this.sterilizedCheckBox.AutoSize = true;
            this.sterilizedCheckBox.Location = new System.Drawing.Point(144, 7);
            this.sterilizedCheckBox.Name = "sterilizedCheckBox";
            this.sterilizedCheckBox.Size = new System.Drawing.Size(68, 17);
            this.sterilizedCheckBox.TabIndex = 24;
            this.sterilizedCheckBox.Text = "Sterilized";
            this.sterilizedCheckBox.UseVisualStyleBackColor = true;
            // 
            // dobEstimateCheckBox
            // 
            this.dobEstimateCheckBox.AutoSize = true;
            this.dobEstimateCheckBox.Enabled = false;
            this.dobEstimateCheckBox.Location = new System.Drawing.Point(144, 190);
            this.dobEstimateCheckBox.Name = "dobEstimateCheckBox";
            this.dobEstimateCheckBox.Size = new System.Drawing.Size(66, 17);
            this.dobEstimateCheckBox.TabIndex = 23;
            this.dobEstimateCheckBox.Text = "Estimate";
            this.dobEstimateCheckBox.UseVisualStyleBackColor = true;
            // 
            // crossbreedCheckBox
            // 
            this.crossbreedCheckBox.AutoSize = true;
            this.crossbreedCheckBox.Enabled = false;
            this.crossbreedCheckBox.Location = new System.Drawing.Point(189, 268);
            this.crossbreedCheckBox.Name = "crossbreedCheckBox";
            this.crossbreedCheckBox.Size = new System.Drawing.Size(52, 17);
            this.crossbreedCheckBox.TabIndex = 22;
            this.crossbreedCheckBox.Text = "Cross";
            this.crossbreedCheckBox.UseVisualStyleBackColor = true;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(144, 101);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 13);
            this.sizeLabel.TabIndex = 20;
            this.sizeLabel.Text = "Size";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 295);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Coat Type";
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(141, 74);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 18;
            this.colorLabel.Text = "Color";
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(141, 51);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(25, 13);
            this.sexLabel.TabIndex = 17;
            this.sexLabel.Text = "Sex";
            this.sexLabel.Click += new System.EventHandler(this.label11_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Owner";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Breed";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Litter";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(17, 216);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 11;
            this.locationLabel.Text = "Location";
            // 
            // dobTextBox
            // 
            this.dobTextBox.Location = new System.Drawing.Point(83, 188);
            this.dobTextBox.Name = "dobTextBox";
            this.dobTextBox.ReadOnly = true;
            this.dobTextBox.Size = new System.Drawing.Size(52, 20);
            this.dobTextBox.TabIndex = 10;
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Location = new System.Drawing.Point(17, 191);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(30, 13);
            this.dobLabel.TabIndex = 9;
            this.dobLabel.Text = "DOB";
            this.dobLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(83, 137);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(185, 20);
            this.nameTextBox.TabIndex = 8;
            this.nameTextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(17, 140);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name";
            this.nameLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(17, 166);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "ID";
            this.idLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(83, 163);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(185, 20);
            this.idTextBox.TabIndex = 5;
            this.idTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // moveAnimalButton
            // 
            this.moveAnimalButton.Location = new System.Drawing.Point(277, 404);
            this.moveAnimalButton.Name = "moveAnimalButton";
            this.moveAnimalButton.Size = new System.Drawing.Size(75, 23);
            this.moveAnimalButton.TabIndex = 4;
            this.moveAnimalButton.Text = "Move";
            this.moveAnimalButton.UseVisualStyleBackColor = true;
            // 
            // adoptButton
            // 
            this.adoptButton.Location = new System.Drawing.Point(193, 405);
            this.adoptButton.Name = "adoptButton";
            this.adoptButton.Size = new System.Drawing.Size(75, 23);
            this.adoptButton.TabIndex = 3;
            this.adoptButton.Text = "Adopt";
            this.adoptButton.UseVisualStyleBackColor = true;
            this.adoptButton.Click += new System.EventHandler(this.adoptButton_Click);
            // 
            // addRecordButton
            // 
            this.addRecordButton.Location = new System.Drawing.Point(112, 404);
            this.addRecordButton.Name = "addRecordButton";
            this.addRecordButton.Size = new System.Drawing.Size(75, 23);
            this.addRecordButton.TabIndex = 2;
            this.addRecordButton.Text = "Add Record";
            this.addRecordButton.UseVisualStyleBackColor = true;
            this.addRecordButton.Click += new System.EventHandler(this.addRecordButton_Click);
            // 
            // viewRecordButton
            // 
            this.viewRecordButton.Location = new System.Drawing.Point(20, 404);
            this.viewRecordButton.Name = "viewRecordButton";
            this.viewRecordButton.Size = new System.Drawing.Size(86, 23);
            this.viewRecordButton.TabIndex = 1;
            this.viewRecordButton.Text = "View Records";
            this.viewRecordButton.UseVisualStyleBackColor = true;
            this.viewRecordButton.Click += new System.EventHandler(this.viewRecordButton_Click);
            // 
            // animalMainPictureBox
            // 
            this.animalMainPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.animalMainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.animalMainPictureBox.Name = "animalMainPictureBox";
            this.animalMainPictureBox.Size = new System.Drawing.Size(135, 123);
            this.animalMainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.animalMainPictureBox.TabIndex = 0;
            this.animalMainPictureBox.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(979, 437);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Services";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(999, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(999, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFormToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFormToolStripMenuItem
            // 
            this.newFormToolStripMenuItem.Name = "newFormToolStripMenuItem";
            this.newFormToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.newFormToolStripMenuItem.Text = "New Form";
            this.newFormToolStripMenuItem.Click += new System.EventHandler(this.newFormToolStripMenuItem_Click);
            // 
            // sexTestBox
            // 
            this.sexTestBox.Location = new System.Drawing.Point(226, 48);
            this.sexTestBox.Name = "sexTestBox";
            this.sexTestBox.ReadOnly = true;
            this.sexTestBox.Size = new System.Drawing.Size(100, 20);
            this.sexTestBox.TabIndex = 29;
            // 
            // ColorTextBox
            // 
            this.ColorTextBox.Location = new System.Drawing.Point(226, 71);
            this.ColorTextBox.Name = "ColorTextBox";
            this.ColorTextBox.ReadOnly = true;
            this.ColorTextBox.Size = new System.Drawing.Size(100, 20);
            this.ColorTextBox.TabIndex = 30;
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Location = new System.Drawing.Point(226, 98);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.ReadOnly = true;
            this.sizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeTextBox.TabIndex = 31;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(83, 213);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.ReadOnly = true;
            this.locationTextBox.Size = new System.Drawing.Size(100, 20);
            this.locationTextBox.TabIndex = 32;
            // 
            // breedTextBox
            // 
            this.breedTextBox.Location = new System.Drawing.Point(83, 265);
            this.breedTextBox.Name = "breedTextBox";
            this.breedTextBox.ReadOnly = true;
            this.breedTextBox.Size = new System.Drawing.Size(100, 20);
            this.breedTextBox.TabIndex = 33;
            // 
            // crossBreedTextBox
            // 
            this.crossBreedTextBox.Location = new System.Drawing.Point(247, 268);
            this.crossBreedTextBox.Name = "crossBreedTextBox";
            this.crossBreedTextBox.ReadOnly = true;
            this.crossBreedTextBox.Size = new System.Drawing.Size(100, 20);
            this.crossBreedTextBox.TabIndex = 34;
            // 
            // ownerTextBox
            // 
            this.ownerTextBox.Location = new System.Drawing.Point(83, 239);
            this.ownerTextBox.Name = "ownerTextBox";
            this.ownerTextBox.ReadOnly = true;
            this.ownerTextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerTextBox.TabIndex = 35;
            // 
            // coatTextBox
            // 
            this.coatTextBox.Location = new System.Drawing.Point(83, 292);
            this.coatTextBox.Name = "coatTextBox";
            this.coatTextBox.ReadOnly = true;
            this.coatTextBox.Size = new System.Drawing.Size(100, 20);
            this.coatTextBox.TabIndex = 36;
            // 
            // litterTextBox
            // 
            this.litterTextBox.Location = new System.Drawing.Point(83, 318);
            this.litterTextBox.Name = "litterTextBox";
            this.litterTextBox.ReadOnly = true;
            this.litterTextBox.Size = new System.Drawing.Size(100, 20);
            this.litterTextBox.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ASRS";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalMainPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox ownerSearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox statusChecklistbox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox breedComboBox;
        private System.Windows.Forms.ComboBox speciesComboBox;
        private System.Windows.Forms.PictureBox animalMainPictureBox;
        private System.Windows.Forms.Button adoptButton;
        private System.Windows.Forms.Button addRecordButton;
        private System.Windows.Forms.Button viewRecordButton;
        private System.Windows.Forms.Button moveAnimalButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox dobTextBox;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox crossbreedCheckBox;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.CheckBox vaccCheckBox;
        private System.Windows.Forms.CheckBox sterilizedCheckBox;
        private System.Windows.Forms.CheckBox dobEstimateCheckBox;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFormToolStripMenuItem;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.TextBox sizeTextBox;
        private System.Windows.Forms.TextBox ColorTextBox;
        private System.Windows.Forms.TextBox sexTestBox;
        private System.Windows.Forms.TextBox litterTextBox;
        private System.Windows.Forms.TextBox coatTextBox;
        private System.Windows.Forms.TextBox ownerTextBox;
        private System.Windows.Forms.TextBox crossBreedTextBox;
        private System.Windows.Forms.TextBox breedTextBox;
    }
}

