
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string a = "";
       
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
       
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            a = textBox1.Text;
            string b = a.Replace("\r\n", " ");
            if (b!="")
            {
                foreach(char c in b)
                {
                    if ((c > 'a' && c < 'z') || (c > 'A' && c < 'Z'))
                    {
                        MessageBox.Show("Текст должен содержать русские символы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Windows.Forms.Application.Restart();
                    }
                }
                this.Hide();
                Form2 f2 = new Form2(b);
                f2.Show();
            }
            else
            {
                MessageBox.Show("Введите значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
