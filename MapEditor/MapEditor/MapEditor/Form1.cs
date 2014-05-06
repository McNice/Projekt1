using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class Form1 : Form
    {
        public int type;
        public string path;

        public int width;
        public int height;
        public bool newMap;
        public bool save;
        public bool load;

        public Form1()
        {
            InitializeComponent();
            type = Game1.TYPE1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to suck dick?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                width = (int)numericUpDown1.Value;
                height = (int)numericUpDown2.Value;
                newMap = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            if (path != "" || path != null)
                if (MessageBox.Show("Do you want to save to \"" + path + ".txt\"?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    save = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            if (path != "" || path != null)
                if (MessageBox.Show("Do you want to load \"" + path + ".txt\"?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    load = true;
        }
        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE20;
        }
        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE19;
        }
        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE18;
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE17;
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE16;
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE15;
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE14;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE13;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE12;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE11;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE10;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE9;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE8;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE7;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE6;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE4;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
  
    }
}
