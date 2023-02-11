using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_20_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------
        string root = "";
        //-------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            //Add To ComboBox
            System.IO.DriveInfo[] myDrives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo d in myDrives)
                if (d.DriveType == System.IO.DriveType.Fixed)
                    comboBox1.Items.Add(d.Name);
        }
        //-------------------------------------------------------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string folder in System.IO.Directory.GetDirectories(comboBox1.Text))
                listBox1.Items.Add(folder);
                //listBox1.Items.Add(folder.Substring(folder.LastIndexOf("\\") + 1)); //only show names
            root = comboBox1.Text;
        }
        //-------------------------------------------------------------
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            root = listBox1.Items[listBox1.SelectedIndex].ToString();
            listBox1.Items.Clear();
            foreach (string folder in System.IO.Directory.GetDirectories(root))
                listBox1.Items.Add(folder);
        }
        //-------------------------------------------------------------
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                root = System.IO.Directory.GetParent(root).FullName;    //return back
                listBox1.Items.Clear();
                foreach (string folder in System.IO.Directory.GetDirectories(root))
                    listBox1.Items.Add(folder);
            }
            catch
            {
            }
        }
    }
}
