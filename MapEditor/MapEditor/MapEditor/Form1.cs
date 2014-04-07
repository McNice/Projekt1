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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.BLANK;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE3;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to start a new Map?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                if (MessageBox.Show("Do you want to save to \"" + path + ".xml\"?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    save = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            path = textBox1.Text;
            if (path != "" || path != null)
                if (MessageBox.Show("Do you want to load \"" + path + ".xml\"?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    load = true;
        }

        private void radio4_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE4;
        }

        private void radio5_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE5;
        }

        private void radio6_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE6;
        }

        private void radio7_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE7;
        }

        private void radio8_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE8;
        }

        private void radio9_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE9;
        }

        private void radio10_CheckedChanged(object sender, EventArgs e)
        {
            type = Game1.TYPE10;
        }
    }
}
