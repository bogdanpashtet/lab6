using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace lab6
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.DefaultExt = ".txt";
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            textBox2.Text = "";
            
            // Диалог выбора файла
            if (file.ShowDialog() == DialogResult.OK)
            {
                // Открытие выбранного файла
                StreamReader f = new StreamReader(file.FileName);
                String pattern = @"\d{6}.+";
                String s;
                String substitution = "";
                Regex r = new Regex(pattern);
                // Чтение выбранного файла по строкам
                while ((s = f.ReadLine()) != null)
                {
                    Match m = r.Match(s);
                    
                    textBox1.Text += s + Environment.NewLine;
                    // Поиск регулярного выражения в очередной строке

                    if (m.Success)
                    {
                        textBox2.Text += Regex.Replace(s, Regex.Replace(s, pattern, substitution), substitution) + Environment.NewLine;
                        m = m.NextMatch();
                    }
                    else
                    {
                        textBox2.Text += s + Environment.NewLine;
                        m = m.NextMatch();
                    }

                }

                f.Close();
                
            }
            else textBox2.Text = "Не был выбран файл.";
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
    }
}