using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public string text;
        public char[] arrayText;
        public char[] arrayText2;
        int numb = -1;
        int r = 0;
        DateTime date1 = new DateTime(0, 0);
        int summ;
        double s;
        int Error;
        System.Windows.Forms.Button[] Btn;
        string[] otherSimbol = new string[] { ")", "!", "\"", "№", ";", "%", ":", "?", "*", "(", "," };
        public Form2(string a)
        {
            InitializeComponent();
            Btn = new System.Windows.Forms.Button[] { Й, Ц, У, К, Е, Н, Г, Ш, Щ, З, Х, Ъ, Ф,
                                                      Ы, В, А, П, Р, О, Л, Д, Ж, Э, Я, Ч, С,
                                                      М, И, Т, Ь, Б, Ю,button10,button11,button12,
                                                      button13,button14,button15,button2,button3,button4,button5,
                                                      button6,button7,button8,button9};
            text = a;
            label1.Text = a;
            arrayText = a.ToCharArray();
            summ = Convert.ToInt32(arrayText.LongLength.ToString());
            arrayText2 = a.ToLower().ToCharArray();
            ProverkaNaOkonchanieText();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == arrayText[numb])
            {
                try
                {
                    button1.BackColor = Color.White; // обновление кнопки Shift
                    ProverkaNaOkonchanieText();
                    timer1.Start();
                    label1.Text = text.Substring(numb);
                }
                catch (System.IndexOutOfRangeException)
                {
                    timer1.Stop();
                    System.Windows.Forms.MessageBox.Show("Не пытайся наебать программу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    System.Windows.Forms.Application.Restart();
                }
            }
            else
            {
                Error++;
            }
        }

        public void Timer1_Tick(object sender, System.EventArgs e)
        {

            date1 = date1.AddSeconds(1);
            label2.Text = date1.ToString("mm:ss");
            double q = (date1.Second / 60.0);
            s = date1.Minute + q;
        }

        public void ProverkaNaOkonchanieText()
        {
            try
            {
                bool d = AquaButton(arrayText, numb);
                if (d == false) 
                {
                    char[] j = Convert.ToString(Array.IndexOf(otherSimbol, arrayText[numb + 1].ToString())).ToCharArray();
                    if (j.Length > 1) 
                    {
                        char[] tochka = new char[] { '.' };
                        AquaButton(tochka, -1);
                    }
                    else
                    {
                        AquaButton(j, -1);
                    }
                    button1.BackColor = Color.Aqua;
                }
                numb++;
            }
            catch
            {
                timer1.Stop();
                this.Hide();
                Form3 f3 = new Form3();
                f3.Show();
                f3.label2.Text = "Время - " + this.label2.Text.ToString();
                try
                {
                    f3.label3.Text = "Скорость - " + Convert.ToInt32((summ / s)) + " симв / мин";
                }
                catch (System.OverflowException)
                {
                    f3.label3.Text = "Скорость - ДОХУЯ";
                }
                f3.label4.Text = "Кол-во ошибок - " + (Error);
                f3.label5.Text = "Всего символов - " + summ;
            }
        }

        public bool AquaButton(char[] Array, int index)
        {
            for (int i = 0; i < Btn.Length; i++)
            {
                if (Btn[i].Text.ToLower() == Array[index + 1].ToString().ToLower())
                {
                    Btn[r].BackColor = Color.White;
                    Btn[i].BackColor = Color.Aqua;
                    r = i;

                    if (Char.IsUpper(Array[index + 1]) == true)
                    {
                        button1.BackColor = Color.Aqua;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
    
    


