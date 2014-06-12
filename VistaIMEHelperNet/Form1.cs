using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TSF;

namespace VistaIMEHelperNet
{
    public partial class Form1 : Form
    {
        private short[] langIDs;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            langIDs = TSFWrapper.GetLangIDs();
            if (langIDs.Length > 0)
            {
                string[] list = TSFWrapper.GetInputMethodList(1028);
                foreach (string desc in list)
                    listBox1.Items.Add(desc);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (langIDs != null)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    TSFWrapper.ActiveInputMethodWithDesc(1028, (string)listBox1.SelectedItem);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TSFWrapper.DeActiveInputMethod(1028);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TSFWrapper.GetCurrentInputMethodDesc(langIDs[0]));

        }
    }
}