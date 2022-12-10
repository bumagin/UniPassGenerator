using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string pass;
        string description = "";

        private void generate_Click(object sender, EventArgs e)
        {
            pass = "";

            char[] symbols = { 'a', 'b', 'с', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u',
                'v', 'w', 'x', 'y', 'z',/*25*/ '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'С', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '!', '%', '?', '/' };

            Random rndm = new Random();

            int indx;

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                if (checkBox1.Checked == false && checkBox2.Checked == false)
                {
                    indx = rndm.Next(0, 34);
                    pass = pass + symbols[indx];
                }

                if (checkBox1.Checked == true && checkBox2.Checked == false)
                {
                    indx = rndm.Next(0, 59);
                    pass = pass + symbols[indx];
                }

                if (checkBox1.Checked == false && checkBox2.Checked == true)
                {
                    indx = rndm.Next(0, 63);

                    if (indx <= 34 || indx >= 61)
                    {
                        pass = pass + symbols[indx];
                    }
                    else
                    {
                        i--;
                    }
                }

                if (checkBox1.Checked == true && checkBox2.Checked == true)
                {
                    indx = rndm.Next(0, 63);
                    pass = pass + symbols[indx];
                }
            }
            textBox1.Text = pass;
        }

        private void info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа создана для генерации паролей разных видов.\n" +
                "Разработка - github.com/bumagin\n" +
                "Версия программы - 0.2", "Информация");
        }

        private void copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(pass);
            MessageBox.Show("Пароль скопирован в ваш буфер обмена!", "Успех!");
        }

        private void save_Click(object sender, EventArgs e)
        {
            description = textBox2.Text;

            string date = Convert.ToString(DateTime.Now);

            System.IO.File.WriteAllText("password.txt", description + "\n" + pass + "\n" + date);

            MessageBox.Show("Пароль успешно сохранен в файле password.txt", "Успех!");
        }
    }
}
