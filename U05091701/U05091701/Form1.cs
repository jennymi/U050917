using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U05091701
{
    public partial class Form1 : Form
    {
        string[] stack = new string[52];
        Random r = new Random();
        bool[] choice = new bool[52];
        int k = 0;
        bool done = false;
        bool moreCard = true;
        int points = 0;
        int pointSum = 0;

        public Form1()
        {
            InitializeComponent();

            button1.Text = "Ja";
            button2.Text = "Nej";
            label1.Text = "Vill du dra ett kort?";

            //If used
            for (int i = 0; i < 52; i++)
            {
                choice[i] = true;
            }

            //Cards value
            for (int i = 0; i < 13; i++)
            {
                stack[i] = "Hjärter " + (i + 1);
            }

            for (int i = 13; i < 26; i++)
            {
                stack[i] = "Klöver " + (i - 12);
            }

            for (int i = 26; i < 39; i++)
            {
                stack[i] = "Ruter " + (i - 25);
            }

            for (int i = 39; i < 52; i++)
            {
                stack[i] = "Spader " + (i - 38);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k = r.Next(0, 52);
            if (choice[k])
            {
                listBox1.Items.Add("Du drog kortet " + stack[k]);
                choice[k] = false;
                string[] cardsDrawn = stack[k].Split(' ');
                points = Convert.ToInt32(cardsDrawn[1]);
                pointSum += points;

                if (pointSum > 21)
                {
                    listBox1.Items.Add(", du förlorade! Du fick mer än 21");
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
                else if (pointSum == 21)
                {
                    listBox1.Items.Add(". Grattis du fick 21 och vann!");
                    button1.Enabled = false;
                    button2.Enabled = false;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            listBox1.Items.Add(" och din poängsumma är " + pointSum);
            button1.Enabled = false;
            button2.Enabled = false;
        }

        

    }
}
