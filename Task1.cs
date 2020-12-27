using System;
using System.Windows.Forms;

namespace lab6
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = true; 
            string s = textBox1.Text; 
            string[] word = s.Split(new[] {'.', '!', '?', ' ', ',', '\n'});
            for (int i = 0; i < word.Length; i++)
            {
                if ( word[i] != null && word[i] != "") { 
                    for (int j = i + 1; j < word.Length; j++) {
                        if ( word[j] != null && word[j] != "")
                        {
                            if (word[i].Equals(word[j], StringComparison.OrdinalIgnoreCase))
                            {
                                word[j] = null;
                                flag = false;
                            }
                        }
                    }

                    if (!flag) word[i] = null;
                    else textBox2.Text += (word[i] + " ");
                    flag = true; 
                }
            }

            if (textBox2.Text.Length == 0) textBox2.Text = "Ничего не найдено.";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
           textBox2.Text = ""; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = null;
        }
    }
}