namespace MapEditor
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
            this.radio1 = new System.Windows.Forms.RadioButton();
            this.radio2 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radioDelete = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radio3 = new System.Windows.Forms.RadioButton();
            this.radio6 = new System.Windows.Forms.RadioButton();
            this.radio5 = new System.Windows.Forms.RadioButton();
            this.radio4 = new System.Windows.Forms.RadioButton();
            this.radio8 = new System.Windows.Forms.RadioButton();
            this.radio7 = new System.Windows.Forms.RadioButton();
            this.radio9 = new System.Windows.Forms.RadioButton();
            this.radio10 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // radio1
            // 
            this.radio1.AutoSize = true;
            this.radio1.Location = new System.Drawing.Point(12, 12);
            this.radio1.Name = "radio1";
            this.radio1.Size = new System.Drawing.Size(72, 17);
            this.radio1.TabIndex = 0;
            this.radio1.TabStop = true;
            this.radio1.Text = "Black Tile";
            this.radio1.UseVisualStyleBackColor = true;
            this.radio1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radio2
            // 
            this.radio2.AutoSize = true;
            this.radio2.Location = new System.Drawing.Point(12, 35);
            this.radio2.Name = "radio2";
            this.radio2.Size = new System.Drawing.Size(72, 17);
            this.radio2.TabIndex = 1;
            this.radio2.TabStop = true;
            this.radio2.Text = "Fine Brick";
            this.radio2.UseVisualStyleBackColor = true;
            this.radio2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(148, 184);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(148, 207);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown2.TabIndex = 4;
            this.numericUpDown2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "New";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioDelete
            // 
            this.radioDelete.AutoSize = true;
            this.radioDelete.Location = new System.Drawing.Point(12, 81);
            this.radioDelete.Name = "radioDelete";
            this.radioDelete.Size = new System.Drawing.Size(54, 17);
            this.radioDelete.TabIndex = 8;
            this.radioDelete.TabStop = true;
            this.radioDelete.Text = "delete";
            this.radioDelete.UseVisualStyleBackColor = true;
            this.radioDelete.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 28);
            this.button3.TabIndex = 9;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 262);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "auto";
            // 
            // radio3
            // 
            this.radio3.AutoSize = true;
            this.radio3.Location = new System.Drawing.Point(12, 58);
            this.radio3.Name = "radio3";
            this.radio3.Size = new System.Drawing.Size(58, 17);
            this.radio3.TabIndex = 11;
            this.radio3.TabStop = true;
            this.radio3.Text = "Ladder";
            this.radio3.UseVisualStyleBackColor = true;
            this.radio3.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radio6
            // 
            this.radio6.AutoSize = true;
            this.radio6.Location = new System.Drawing.Point(101, 58);
            this.radio6.Name = "radio6";
            this.radio6.Size = new System.Drawing.Size(83, 17);
            this.radio6.TabIndex = 14;
            this.radio6.TabStop = true;
            this.radio6.Text = "block type 6";
            this.radio6.UseVisualStyleBackColor = true;
            this.radio6.CheckedChanged += new System.EventHandler(this.radio6_CheckedChanged);
            // 
            // radio5
            // 
            this.radio5.AutoSize = true;
            this.radio5.Location = new System.Drawing.Point(101, 35);
            this.radio5.Name = "radio5";
            this.radio5.Size = new System.Drawing.Size(59, 17);
            this.radio5.TabIndex = 13;
            this.radio5.TabStop = true;
            this.radio5.Text = "Roof-R";
            this.radio5.UseVisualStyleBackColor = true;
            this.radio5.CheckedChanged += new System.EventHandler(this.radio5_CheckedChanged);
            // 
            // radio4
            // 
            this.radio4.AutoSize = true;
            this.radio4.Location = new System.Drawing.Point(101, 12);
            this.radio4.Name = "radio4";
            this.radio4.Size = new System.Drawing.Size(57, 17);
            this.radio4.TabIndex = 12;
            this.radio4.TabStop = true;
            this.radio4.Text = "Roof-L";
            this.radio4.UseVisualStyleBackColor = true;
            this.radio4.CheckedChanged += new System.EventHandler(this.radio4_CheckedChanged);
            // 
            // radio8
            // 
            this.radio8.AutoSize = true;
            this.radio8.Location = new System.Drawing.Point(101, 104);
            this.radio8.Name = "radio8";
            this.radio8.Size = new System.Drawing.Size(83, 17);
            this.radio8.TabIndex = 16;
            this.radio8.TabStop = true;
            this.radio8.Text = "block type 8";
            this.radio8.UseVisualStyleBackColor = true;
            this.radio8.CheckedChanged += new System.EventHandler(this.radio8_CheckedChanged);
            // 
            // radio7
            // 
            this.radio7.AutoSize = true;
            this.radio7.Location = new System.Drawing.Point(101, 81);
            this.radio7.Name = "radio7";
            this.radio7.Size = new System.Drawing.Size(83, 17);
            this.radio7.TabIndex = 15;
            this.radio7.TabStop = true;
            this.radio7.Text = "block type 7";
            this.radio7.UseVisualStyleBackColor = true;
            this.radio7.CheckedChanged += new System.EventHandler(this.radio7_CheckedChanged);
            // 
            // radio9
            // 
            this.radio9.AutoSize = true;
            this.radio9.Location = new System.Drawing.Point(101, 127);
            this.radio9.Name = "radio9";
            this.radio9.Size = new System.Drawing.Size(75, 17);
            this.radio9.TabIndex = 17;
            this.radio9.TabStop = true;
            this.radio9.Text = "Low Grass";
            this.radio9.UseVisualStyleBackColor = true;
            this.radio9.CheckedChanged += new System.EventHandler(this.radio9_CheckedChanged);
            // 
            // radio10
            // 
            this.radio10.AutoSize = true;
            this.radio10.Location = new System.Drawing.Point(101, 150);
            this.radio10.Name = "radio10";
            this.radio10.Size = new System.Drawing.Size(72, 17);
            this.radio10.TabIndex = 18;
            this.radio10.TabStop = true;
            this.radio10.Text = "Tall Grass";
            this.radio10.UseVisualStyleBackColor = true;
            this.radio10.CheckedChanged += new System.EventHandler(this.radio10_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 294);
            this.Controls.Add(this.radio10);
            this.Controls.Add(this.radio9);
            this.Controls.Add(this.radio8);
            this.Controls.Add(this.radio7);
            this.Controls.Add(this.radio6);
            this.Controls.Add(this.radio5);
            this.Controls.Add(this.radio4);
            this.Controls.Add(this.radio3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.radioDelete);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.radio2);
            this.Controls.Add(this.radio1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radio1;
        private System.Windows.Forms.RadioButton radio2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radio3;
        private System.Windows.Forms.RadioButton radio6;
        private System.Windows.Forms.RadioButton radio5;
        private System.Windows.Forms.RadioButton radio4;
        private System.Windows.Forms.RadioButton radio8;
        private System.Windows.Forms.RadioButton radio7;
        private System.Windows.Forms.RadioButton radio9;
        private System.Windows.Forms.RadioButton radio10;
    }
}