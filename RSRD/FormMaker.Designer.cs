namespace RSRD
{
    partial class FormMaker
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.fieldboxListBoxLabel = new System.Windows.Forms.Label();
            this.templateListBox = new System.Windows.Forms.ListBox();
            this.fieldboxListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.createFormToolStripMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // createFormToolStripMenuItem
            // 
            this.createFormToolStripMenuItem.Name = "createFormToolStripMenuItem";
            this.createFormToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.createFormToolStripMenuItem.Text = "Create Form";
            this.createFormToolStripMenuItem.Click += new System.EventHandler(this.createFormToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.fieldboxListBoxLabel);
            this.splitContainer1.Panel1.Controls.Add(this.templateListBox);
            this.splitContainer1.Panel1.Controls.Add(this.fieldboxListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(632, 714);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Templates";
            // 
            // fieldboxListBoxLabel
            // 
            this.fieldboxListBoxLabel.AutoSize = true;
            this.fieldboxListBoxLabel.Location = new System.Drawing.Point(12, 13);
            this.fieldboxListBoxLabel.Name = "fieldboxListBoxLabel";
            this.fieldboxListBoxLabel.Size = new System.Drawing.Size(61, 13);
            this.fieldboxListBoxLabel.TabIndex = 2;
            this.fieldboxListBoxLabel.Text = "Field Boxes";
            // 
            // templateListBox
            // 
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.Location = new System.Drawing.Point(0, 312);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(82, 199);
            this.templateListBox.TabIndex = 1;
            this.templateListBox.SelectedIndexChanged += new System.EventHandler(this.templateListBox_SelectedIndexChanged);
            // 
            // fieldboxListBox
            // 
            this.fieldboxListBox.FormattingEnabled = true;
            this.fieldboxListBox.Location = new System.Drawing.Point(0, 29);
            this.fieldboxListBox.Name = "fieldboxListBox";
            this.fieldboxListBox.Size = new System.Drawing.Size(71, 160);
            this.fieldboxListBox.TabIndex = 0;
            this.fieldboxListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fieldboxListBox_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(497, 683);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 738);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMaker";
            this.Text = "FormMaker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fieldboxListBoxLabel;
        private System.Windows.Forms.ListBox templateListBox;
        private System.Windows.Forms.ListBox fieldboxListBox;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFormToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}