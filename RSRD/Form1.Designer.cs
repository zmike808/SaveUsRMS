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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.CreateAnimalButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.speciesComboBox = new System.Windows.Forms.ComboBox();
            this.CommentsPanel = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.litterTextBox = new System.Windows.Forms.TextBox();
            this.animalMainPictureBox = new System.Windows.Forms.PictureBox();
            this.coatTextBox = new System.Windows.Forms.TextBox();
            this.sterilizedCheckBox = new System.Windows.Forms.CheckBox();
            this.ownerTextBox = new System.Windows.Forms.TextBox();
            this.vaccCheckBox = new System.Windows.Forms.CheckBox();
            this.crossBreedTextBox = new System.Windows.Forms.TextBox();
            this.sexTestBox = new System.Windows.Forms.TextBox();
            this.breedTextBox = new System.Windows.Forms.TextBox();
            this.sexLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.sizeTextBox = new System.Windows.Forms.TextBox();
            this.dobEstimateCheckBox = new System.Windows.Forms.CheckBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.crossbreedCheckBox = new System.Windows.Forms.CheckBox();
            this.ColorTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.dobLabel = new System.Windows.Forms.Label();
            this.dobTextBox = new System.Windows.Forms.TextBox();
            this.moveAnimalButton = new System.Windows.Forms.Button();
            this.adoptButton = new System.Windows.Forms.Button();
            this.addRecordButton = new System.Windows.Forms.Button();
            this.viewRecordButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.CommentsPanel.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalMainPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.tabPage2);
            this.TabControl1.Controls.Add(this.tabPage1);
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Location = new System.Drawing.Point(0, 28);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1360, 674);
            this.TabControl1.TabIndex = 0;
            this.TabControl1.Enter += new System.EventHandler(this.TabControl1_Enter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1352, 648);
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
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.genderComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.statusComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.CreateAnimalButton);
            this.splitContainer1.Panel1.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.sizeComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.speciesComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.CommentsPanel);
            this.splitContainer1.Panel2.Controls.Add(this.StatusPanel);
            this.splitContainer1.Panel2.Controls.Add(this.moveAnimalButton);
            this.splitContainer1.Panel2.Controls.Add(this.adoptButton);
            this.splitContainer1.Panel2.Controls.Add(this.addRecordButton);
            this.splitContainer1.Panel2.Controls.Add(this.viewRecordButton);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.Black;
            this.splitContainer1.Size = new System.Drawing.Size(1346, 642);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 34;
            this.button2.Text = "Search (OR)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.genderComboBox.Location = new System.Drawing.Point(5, 85);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(121, 21);
            this.genderComboBox.TabIndex = 33;
            this.genderComboBox.Text = "Gender";
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Lost",
            "Found",
            "Surrendered",
            "Adopted",
            "Fostered"});
            this.statusComboBox.Location = new System.Drawing.Point(5, 58);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(121, 21);
            this.statusComboBox.TabIndex = 32;
            this.statusComboBox.Text = "Status";
            // 
            // CreateAnimalButton
            // 
            this.CreateAnimalButton.Location = new System.Drawing.Point(273, 127);
            this.CreateAnimalButton.Name = "CreateAnimalButton";
            this.CreateAnimalButton.Size = new System.Drawing.Size(75, 23);
            this.CreateAnimalButton.TabIndex = 31;
            this.CreateAnimalButton.Text = "New Animal";
            this.CreateAnimalButton.UseVisualStyleBackColor = true;
            this.CreateAnimalButton.Click += new System.EventHandler(this.CreateAnimalButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(132, 128);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(116, 23);
            this.SearchButton.TabIndex = 30;
            this.SearchButton.Text = "Search (AND)";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 153);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(368, 432);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.loadSelected);
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.sizeComboBox.Location = new System.Drawing.Point(5, 31);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(121, 21);
            this.sizeComboBox.TabIndex = 1;
            this.sizeComboBox.Text = "Size";
            // 
            // speciesComboBox
            // 
            this.speciesComboBox.FormattingEnabled = true;
            this.speciesComboBox.Items.AddRange(new object[] {
            "Canine",
            "Feline",
            "Horse"});
            this.speciesComboBox.Location = new System.Drawing.Point(5, 3);
            this.speciesComboBox.Name = "speciesComboBox";
            this.speciesComboBox.Size = new System.Drawing.Size(121, 21);
            this.speciesComboBox.TabIndex = 0;
            this.speciesComboBox.Text = "Species";
            // 
            // CommentsPanel
            // 
            this.CommentsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CommentsPanel.Controls.Add(this.tabControl2);
            this.CommentsPanel.Location = new System.Drawing.Point(3, 389);
            this.CommentsPanel.Name = "CommentsPanel";
            this.CommentsPanel.Size = new System.Drawing.Size(476, 250);
            this.CommentsPanel.TabIndex = 39;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(8, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(465, 244);
            this.tabControl2.TabIndex = 28;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.textBox5);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(457, 218);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Notes/Comments";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(6, 19);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(448, 193);
            this.textBox5.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
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
            this.tabPage6.Size = new System.Drawing.Size(457, 218);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Health";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // StatusPanel
            // 
            this.StatusPanel.Controls.Add(this.litterTextBox);
            this.StatusPanel.Controls.Add(this.animalMainPictureBox);
            this.StatusPanel.Controls.Add(this.coatTextBox);
            this.StatusPanel.Controls.Add(this.sterilizedCheckBox);
            this.StatusPanel.Controls.Add(this.ownerTextBox);
            this.StatusPanel.Controls.Add(this.vaccCheckBox);
            this.StatusPanel.Controls.Add(this.crossBreedTextBox);
            this.StatusPanel.Controls.Add(this.sexTestBox);
            this.StatusPanel.Controls.Add(this.breedTextBox);
            this.StatusPanel.Controls.Add(this.sexLabel);
            this.StatusPanel.Controls.Add(this.locationTextBox);
            this.StatusPanel.Controls.Add(this.colorLabel);
            this.StatusPanel.Controls.Add(this.sizeTextBox);
            this.StatusPanel.Controls.Add(this.dobEstimateCheckBox);
            this.StatusPanel.Controls.Add(this.sizeLabel);
            this.StatusPanel.Controls.Add(this.crossbreedCheckBox);
            this.StatusPanel.Controls.Add(this.ColorTextBox);
            this.StatusPanel.Controls.Add(this.label13);
            this.StatusPanel.Controls.Add(this.nameLabel);
            this.StatusPanel.Controls.Add(this.label9);
            this.StatusPanel.Controls.Add(this.idTextBox);
            this.StatusPanel.Controls.Add(this.label8);
            this.StatusPanel.Controls.Add(this.idLabel);
            this.StatusPanel.Controls.Add(this.label7);
            this.StatusPanel.Controls.Add(this.nameTextBox);
            this.StatusPanel.Controls.Add(this.locationLabel);
            this.StatusPanel.Controls.Add(this.dobLabel);
            this.StatusPanel.Controls.Add(this.dobTextBox);
            this.StatusPanel.Location = new System.Drawing.Point(3, 3);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(355, 340);
            this.StatusPanel.TabIndex = 38;
            // 
            // litterTextBox
            // 
            this.litterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.litterTextBox.Location = new System.Drawing.Point(82, 313);
            this.litterTextBox.Name = "litterTextBox";
            this.litterTextBox.ReadOnly = true;
            this.litterTextBox.Size = new System.Drawing.Size(100, 20);
            this.litterTextBox.TabIndex = 37;
            // 
            // animalMainPictureBox
            // 
            this.animalMainPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.animalMainPictureBox.Location = new System.Drawing.Point(3, 4);
            this.animalMainPictureBox.Name = "animalMainPictureBox";
            this.animalMainPictureBox.Size = new System.Drawing.Size(135, 123);
            this.animalMainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.animalMainPictureBox.TabIndex = 0;
            this.animalMainPictureBox.TabStop = false;
            // 
            // coatTextBox
            // 
            this.coatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.coatTextBox.Location = new System.Drawing.Point(82, 287);
            this.coatTextBox.Name = "coatTextBox";
            this.coatTextBox.ReadOnly = true;
            this.coatTextBox.Size = new System.Drawing.Size(100, 20);
            this.coatTextBox.TabIndex = 36;
            // 
            // sterilizedCheckBox
            // 
            this.sterilizedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sterilizedCheckBox.AutoSize = true;
            this.sterilizedCheckBox.Location = new System.Drawing.Point(144, 5);
            this.sterilizedCheckBox.Name = "sterilizedCheckBox";
            this.sterilizedCheckBox.Size = new System.Drawing.Size(68, 17);
            this.sterilizedCheckBox.TabIndex = 24;
            this.sterilizedCheckBox.Text = "Sterilized";
            this.sterilizedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ownerTextBox
            // 
            this.ownerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ownerTextBox.Location = new System.Drawing.Point(82, 230);
            this.ownerTextBox.Name = "ownerTextBox";
            this.ownerTextBox.ReadOnly = true;
            this.ownerTextBox.Size = new System.Drawing.Size(100, 20);
            this.ownerTextBox.TabIndex = 35;
            // 
            // vaccCheckBox
            // 
            this.vaccCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vaccCheckBox.AutoSize = true;
            this.vaccCheckBox.Location = new System.Drawing.Point(144, 28);
            this.vaccCheckBox.Name = "vaccCheckBox";
            this.vaccCheckBox.Size = new System.Drawing.Size(80, 17);
            this.vaccCheckBox.TabIndex = 25;
            this.vaccCheckBox.Text = "Vaccinated";
            this.vaccCheckBox.UseVisualStyleBackColor = true;
            // 
            // crossBreedTextBox
            // 
            this.crossBreedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crossBreedTextBox.Location = new System.Drawing.Point(246, 263);
            this.crossBreedTextBox.Name = "crossBreedTextBox";
            this.crossBreedTextBox.ReadOnly = true;
            this.crossBreedTextBox.Size = new System.Drawing.Size(100, 20);
            this.crossBreedTextBox.TabIndex = 34;
            // 
            // sexTestBox
            // 
            this.sexTestBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sexTestBox.Location = new System.Drawing.Point(230, 45);
            this.sexTestBox.Name = "sexTestBox";
            this.sexTestBox.ReadOnly = true;
            this.sexTestBox.Size = new System.Drawing.Size(100, 20);
            this.sexTestBox.TabIndex = 29;
            // 
            // breedTextBox
            // 
            this.breedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.breedTextBox.Location = new System.Drawing.Point(82, 260);
            this.breedTextBox.Name = "breedTextBox";
            this.breedTextBox.ReadOnly = true;
            this.breedTextBox.Size = new System.Drawing.Size(100, 20);
            this.breedTextBox.TabIndex = 33;
            // 
            // sexLabel
            // 
            this.sexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(144, 48);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(25, 13);
            this.sexLabel.TabIndex = 17;
            this.sexLabel.Text = "Sex";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.locationTextBox.Location = new System.Drawing.Point(82, 204);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.ReadOnly = true;
            this.locationTextBox.Size = new System.Drawing.Size(100, 20);
            this.locationTextBox.TabIndex = 32;
            // 
            // colorLabel
            // 
            this.colorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(144, 71);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 18;
            this.colorLabel.Text = "Color";
            // 
            // sizeTextBox
            // 
            this.sizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeTextBox.Location = new System.Drawing.Point(230, 94);
            this.sizeTextBox.Name = "sizeTextBox";
            this.sizeTextBox.ReadOnly = true;
            this.sizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeTextBox.TabIndex = 31;
            // 
            // dobEstimateCheckBox
            // 
            this.dobEstimateCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dobEstimateCheckBox.AutoSize = true;
            this.dobEstimateCheckBox.Enabled = false;
            this.dobEstimateCheckBox.Location = new System.Drawing.Point(187, 186);
            this.dobEstimateCheckBox.Name = "dobEstimateCheckBox";
            this.dobEstimateCheckBox.Size = new System.Drawing.Size(66, 17);
            this.dobEstimateCheckBox.TabIndex = 23;
            this.dobEstimateCheckBox.Text = "Estimate";
            this.dobEstimateCheckBox.UseVisualStyleBackColor = true;
            // 
            // sizeLabel
            // 
            this.sizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(144, 97);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 13);
            this.sizeLabel.TabIndex = 20;
            this.sizeLabel.Text = "Size";
            // 
            // crossbreedCheckBox
            // 
            this.crossbreedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crossbreedCheckBox.AutoSize = true;
            this.crossbreedCheckBox.Enabled = false;
            this.crossbreedCheckBox.Location = new System.Drawing.Point(188, 259);
            this.crossbreedCheckBox.Name = "crossbreedCheckBox";
            this.crossbreedCheckBox.Size = new System.Drawing.Size(52, 17);
            this.crossbreedCheckBox.TabIndex = 22;
            this.crossbreedCheckBox.Text = "Cross";
            this.crossbreedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ColorTextBox
            // 
            this.ColorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorTextBox.Location = new System.Drawing.Point(230, 68);
            this.ColorTextBox.Name = "ColorTextBox";
            this.ColorTextBox.ReadOnly = true;
            this.ColorTextBox.Size = new System.Drawing.Size(100, 20);
            this.ColorTextBox.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 290);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Coat Type";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(16, 135);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Name";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Owner";
            // 
            // idTextBox
            // 
            this.idTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idTextBox.Location = new System.Drawing.Point(82, 158);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(185, 20);
            this.idTextBox.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Breed";
            // 
            // idLabel
            // 
            this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(16, 161);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(18, 13);
            this.idLabel.TabIndex = 6;
            this.idLabel.Text = "ID";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Litter";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(82, 132);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(185, 20);
            this.nameTextBox.TabIndex = 8;
            // 
            // locationLabel
            // 
            this.locationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(16, 211);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 13);
            this.locationLabel.TabIndex = 11;
            this.locationLabel.Text = "Location";
            // 
            // dobLabel
            // 
            this.dobLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dobLabel.AutoSize = true;
            this.dobLabel.Location = new System.Drawing.Point(16, 186);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(30, 13);
            this.dobLabel.TabIndex = 9;
            this.dobLabel.Text = "DOB";
            // 
            // dobTextBox
            // 
            this.dobTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dobTextBox.Location = new System.Drawing.Point(82, 183);
            this.dobTextBox.Name = "dobTextBox";
            this.dobTextBox.ReadOnly = true;
            this.dobTextBox.Size = new System.Drawing.Size(100, 20);
            this.dobTextBox.TabIndex = 10;
            // 
            // moveAnimalButton
            // 
            this.moveAnimalButton.Location = new System.Drawing.Point(262, 349);
            this.moveAnimalButton.Name = "moveAnimalButton";
            this.moveAnimalButton.Size = new System.Drawing.Size(75, 23);
            this.moveAnimalButton.TabIndex = 4;
            this.moveAnimalButton.Text = "Move";
            this.moveAnimalButton.UseVisualStyleBackColor = true;
            // 
            // adoptButton
            // 
            this.adoptButton.Location = new System.Drawing.Point(181, 349);
            this.adoptButton.Name = "adoptButton";
            this.adoptButton.Size = new System.Drawing.Size(75, 23);
            this.adoptButton.TabIndex = 3;
            this.adoptButton.Text = "Adopt";
            this.adoptButton.UseVisualStyleBackColor = true;
            this.adoptButton.Click += new System.EventHandler(this.adoptButton_Click);
            // 
            // addRecordButton
            // 
            this.addRecordButton.Location = new System.Drawing.Point(100, 349);
            this.addRecordButton.Name = "addRecordButton";
            this.addRecordButton.Size = new System.Drawing.Size(75, 23);
            this.addRecordButton.TabIndex = 2;
            this.addRecordButton.Text = "Add Record";
            this.addRecordButton.UseVisualStyleBackColor = true;
            this.addRecordButton.Click += new System.EventHandler(this.addRecordButton_Click);
            // 
            // viewRecordButton
            // 
            this.viewRecordButton.Location = new System.Drawing.Point(11, 349);
            this.viewRecordButton.Name = "viewRecordButton";
            this.viewRecordButton.Size = new System.Drawing.Size(86, 23);
            this.viewRecordButton.TabIndex = 1;
            this.viewRecordButton.Text = "View Records";
            this.viewRecordButton.UseVisualStyleBackColor = true;
            this.viewRecordButton.Click += new System.EventHandler(this.viewRecordButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1432, 648);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Services";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.zg1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.listBox2);
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1432, 648);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Statistics";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data to Graph";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type of Graph";
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(475, 6);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(488, 384);
            this.zg1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create Graph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(186, 36);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(135, 160);
            this.listBox2.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(20, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(135, 160);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 705);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1362, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFormToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFormToolStripMenuItem
            // 
            this.newFormToolStripMenuItem.Name = "newFormToolStripMenuItem";
            this.newFormToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.newFormToolStripMenuItem.Text = "New Form";
            this.newFormToolStripMenuItem.Click += new System.EventHandler(this.newFormToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 727);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ASRS";
            this.TabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.CommentsPanel.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalMainPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox sizeComboBox;
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
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Panel CommentsPanel;
        private System.Windows.Forms.Button CreateAnimalButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Button button2;
    }
}

