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

        public int width;
        public int height;
        public bool newMap;
        public bool save;

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
            if (MessageBox.Show("Do you want to save?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                save = true;
            }
        }
    }
}
