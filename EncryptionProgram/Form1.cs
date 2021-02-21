using System;
using System.Windows.Forms;
using System.IO;

namespace EncryptionProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void openTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.FileName;

            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            string filename = saveFileDialog1.FileName;
            
            System.IO.File.WriteAllText(filename, textBox2.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show
            ("Author: Margulan Turganbek\n \nFree for commercial use \n",
             "SEncrypt 1.0 \n",
            MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text!=string.Empty&&textBox1.Text!=string.Empty)
            {
                int code = int.Parse(textBox3.Text);

                textBox2.Text = Encryption(textBox1.Text, code);
            }
            else 
            {
                MessageBox.Show("Write text/open file and enter the Key Code","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Encryption(string textIn, int keyCode)
        {
            string textOut = string.Empty;

            foreach(char a in textIn)
            {
                textOut += Convert.ToString((char)((int)(a) ^ keyCode));
            }

            return textOut;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
