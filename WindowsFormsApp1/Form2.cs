using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public string text; // переменная для хранения текста
        public char[] arrayText; // массив для хранения символов текста
        public char[] arrayText2; // массив для хранения текста
        int numb = -1;// переменная индекса массива (значение равно -1 что окрасить самый первый символ)
        int previous = 0;// номер индекса предыдущего символа
        DateTime date1 = new DateTime(0, 0); // таймер 
        int summ; // переменая суммы символов в тексте
        double minutes; // всего минут потраченный на набор текста
        int Error; // количество ошибок при наборе текста
        System.Windows.Forms.Button[] Btn; // масси кнопок "подсказок"
        string[] shiftSimbol = new string[] { ")", "!", "\"", "№", ";", "%", ":", "?", "*", "(", "," };
        public Form2(string a)
        {
            InitializeComponent();
            Btn = new System.Windows.Forms.Button[] { Й, Ц, У, К, Е, Н, Г, Ш, Щ, З, Х, Ъ, Ф,
                                                      Ы, В, А, П, Р, О, Л, Д, Ж, Э, Я, Ч, С,
                                                      М, И, Т, Ь, Б, Ю,button10,button11,button12,
                                                      button13,button14,button15,button2,button3,button4,button5,
                                                      button6,button7,button8,button9};
            text = a; // наш текст
            label1.Text = a;
            arrayText = a.ToCharArray();// массив символов текста
            summ = Convert.ToInt32(arrayText.LongLength.ToString());// всего символов
            //arrayText2 = a.ToLower().ToCharArray();//массив символов текста в нижнем регистре
            ProverkaNaOkonchanieText(); // метод провекрни окончания текста
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
                    timer1.Start(); //старт таймера
                    label1.Text = text.Substring(numb);// обрезаем текст на numb символ
                }
                catch (System.IndexOutOfRangeException)
                {
                    timer1.Stop();
                    System.Windows.Forms.MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            double q = (date1.Second / 60.0); // высчитываем соотношение между оставшися секундами и 60
            minutes = date1.Minute + q;// прибавляем ко всем минутам таймера наше соотношение (для точного растета скороти набора текста)
        }

        public void ProverkaNaOkonchanieText()
        {
            try
            {
                bool d = AquaButton(arrayText, numb);// метод окрашивания конопки "подсказки" в бирюзовый цвет
                if (d == false) // условие которое срабатывает если вводимый символ отсутствует в массиве Btn[] (ссответствующая кнопка не окрасилась)
                {
                    char[] j = Convert.ToString(Array.IndexOf(shiftSimbol, arrayText[numb + 1].ToString())).ToCharArray(); // находим в массиве otherSimbol вводимый символ и возращаем его индекс 
                    if (j.Length > 1) // в массиве shiftSimbol под индексом 10 хранится символ ',', данное условие срабатывает когда введеный символ <,>
                    {
                        char[] tochka = new char[] { '.' };
                        AquaButton(tochka, -1);
                    }
                    else
                    {
                        AquaButton(j, -1);
                    }
                    button1.BackColor = Color.Aqua;// кнопка shift, окрашивание
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
                    f3.label3.Text = "Скорость - " + Convert.ToInt32((summ / minutes)) + " симв / мин";
                }
                catch (System.OverflowException)
                {
                    f3.label3.Text = "Скорость - Супер-мен";
                }
                f3.label4.Text = "Кол-во ошибок - " + (Error);
                f3.label5.Text = "Всего символов - " + summ;
            }
        }

        public bool AquaButton(char[] Array, int index)
        {
            for (int next = 0; next < Btn.Length; next++)// цикл сравнивающий символ[n] текста с всеми символами массива Btn (кнопок)
            {
                if (Btn[next].Text.ToLower() == Array[index + 1].ToString().ToLower())// сравнивание название кнопки и вводимого символа
                {
                    Btn[previous].BackColor = Color.White; // окрашивание предыдущей кнопки "подсказки" в белый цвет
                    Btn[next].BackColor = Color.Aqua;// окрашивание следующей кнопки "подсказки" в бирюзовый цвет
                    previous = next;

                    if (Char.IsUpper(Array[index + 1]) == true)// условие на нахождение символов в верхнем регистре
                    {
                        button1.BackColor = Color.Aqua;// перекрашивание кнопки Shift
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
    
    


