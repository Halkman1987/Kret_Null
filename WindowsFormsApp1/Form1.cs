using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        public static BuffDatas buffDataS = new BuffDatas();// двумерный массив для хранения информ-ии по заполнению ячеек крестиком или ноликом

        MovePeople movePeople = new MovePeople(buffDataS);
        Risovalka ris = new Risovalka();
        BotHodit botHodit = new BotHodit(buffDataS);
        
        public static int Pctwidth;
        public static int Pctheight;
        public static bool gameStarted = false;
        public static bool gameCancel = false;
        int bufX;
        int bufY;

        private void Form1_Load(object sender, EventArgs e)
        {
            Pctwidth = pctLineXY.Width;
            Pctheight = pctLineXY.Height;
            //первичное заполнения ячеек шаблонными данными для проверки подмены в случае хода 
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    buffDataS.buffD[i, j] = "-";
        }

        public void btnClickThis_Click(object sender, EventArgs e) //Разлиновка поля при нажатии кнопки
        {
            lblHelloWorld.Text = " Разметка завершенна !";
            lblHelloWorld.Text = " Выберите Крестик или Нолик:";
            lblHelloWorld.ForeColor = System.Drawing.Color.BlueViolet;
            int width = pctLineXY.Width;
            int height = pctLineXY.Height;
            int stepW = width / 10;
            int stepH = height / 10;
            int countW = width / stepW;
            int countH = height / stepH;
            int buffposX = 0;
            int buffposY = 0;
            int buffposX1 = 0;
            int buffposY1 = 0;
            int buffposNull = 0;

            var pct = pctLineXY;   //Экземпляр пикчербокса
            pct.MouseClick += pctLineXY_MouseClick; // подписка на клик или что то в этом роде

            Graphics g = pctLineXY.CreateGraphics();
            Pen pn = new Pen(Color.Black, 2);

            for (int i = 0; i <= countW; i++) //разлиновка поля
            {
                g.DrawLine(pn, buffposX, buffposY, buffposX, height);
                buffposX += stepW;
            }
            for (int i = 0; i <= countH; i++)
            {
                g.DrawLine(pn, buffposNull, buffposY1, width, buffposX1);
                buffposY1 += stepH;
                buffposX1 += stepH;
            }

        }

        private void pctLineXY_MouseClick(object sender, MouseEventArgs e) // событие клика левой клавишей по пикчербоксу
        {
            if (gameStarted == false)
            {
                gameStarted = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            bufX = e.X / (pctLineXY.Width / 10);
            bufY = e.Y / (pctLineXY.Height / 10);

            if (radioButton1.Checked == true)
            {
                movePeople.CentrovkaKrestika(e, ref pctLineXY);
                buffDataS.buffD[bufX, bufY] = "X";
                botHodit.MoveBotNolik(ref pctLineXY);
            }
            else
            {
                movePeople.CentrovkaNuLLika(e, ref pctLineXY);
                buffDataS.buffD[bufX, bufY] = "O";
                botHodit.MoveBotKrestik(ref pctLineXY);
            }
        }
        static public bool CheckWinXvert(string symbol, int x, int y)
        {
            bool win = false;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                if (buffDataS.buffD[x, i].Contains(symbol))
                {
                    counter++;
                }
                else
                {
                    if (counter == 4)
                    {
                        win = true;
                        MessageBox.Show("Победа");
                        
                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }
        static public bool CheckWinXgoriz(string symbol, int x, int y)
        {
            bool win = false;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                if (buffDataS.buffD[i, y].Contains(symbol))
                {
                    counter++;
                }
                else
                {
                    if (counter == 4)
                    {
                        win = true;
                        //ris.DrawGorizont(x, y, ref pctLineXY);
                        MessageBox.Show("Победа");
                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }

        static public bool CheckWinOvert(string symbol, int x, int y)
        {
            bool win = false;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                if (buffDataS.buffD[x, i].Contains(symbol))
                {
                    counter++;
                }
                else
                {
                    if (counter == 4)
                    {
                        win = true;
                        MessageBox.Show("Победа");

                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }
        static public bool CheckWinOgoriz(string symbol, int x, int y)
        {
            bool win = false;
            int counter = 0;
            for (int i = 0; i < 10; i++)
            {
                if (buffDataS.buffD[i, y].Contains(symbol))
                {
                    counter++;
                }
                else
                {
                    if (counter == 4)
                    {
                        win = true;
                        //ris.DrawGorizont(x, y, ref pctLineXY);
                        MessageBox.Show("Победа");
                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }

        private bool CheckWinOvert()// проверка всего массива
        {
            bool win = false;
            int tmp = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (buffDataS.buffD[i, j] == "O")
                    {
                        tmp++;
                    }
                    else
                    {
                        if (tmp == 5)
                        {
                            win = true; lblHelloWorld.Text = " Победа!";
                        }
                        else
                        {
                            tmp = 0;
                        }
                    }
                }
            return win;
        }
        private bool CheckWinOgoriz()// проверка всего массива
        {
            bool win = false;
            int tmp = 0;
            for (int j = 0; j < 10; j++)
                for (int i = 0; i < 10; i++)
                {
                    if (buffDataS.buffD[i, j] == "O")
                    {
                        tmp++;
                    }
                    else
                    {
                        if (tmp == 5)
                        {
                            win = true; lblHelloWorld.Text = " Победа!";
                        }
                        else
                        {
                            tmp = 0;
                        }
                    }
                }
            return win;
        }
        private bool PCheckWinXvert()// i - строки   j - колонки
        {
            bool win = false;
            int tmp = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    if (buffDataS.buffD[i, j] == "X")
                    {
                        tmp++;
                    }
                    else
                    {
                        if (tmp == 5)
                        {
                            win = true; lblHelloWorld.Text = " Победа!";
                        }
                        else
                        {
                            tmp = 0;
                        }
                    }
                }
           
            //for (int i = 0; i < 10; i++)
            //    for (int j = 0; j < 10; j++)
            //    {
            //        if (buffDataS.buffD[i, j] == "X")
            //        {
            //            if (buffDataS.buffD[i, j + 1] == "X")
            //            {
            //                if (buffDataS.buffD[i, j + 2] == "X")
            //                {
            //                    win = true;
            //                }
            //            }

            //        }
            //    }
            //if (win == true)
            //    lblHelloWorld.Text = " Победа!";

            return win;
        }
        private bool PCheckWinXgoriz()// i - строки   j - колонки
        {
            bool win = false;
            int tmp = 0;
            for (int j = 0; j < 10; j++)
                for (int i = 0;i < 10; i++)
                {
                    if (buffDataS.buffD[i,j] == "X")
                    {
                        tmp++;
                    }
                    else
                    {
                        if (tmp == 5)
                        {
                            win = true; lblHelloWorld.Text = " Победа!";
                        }
                        else
                        {
                            tmp = 0;
                        }
                    }
                }
            return win;
        }
        
        
        
        public void DrawGorizont(int x, int y, ref PictureBox pct)
        {
            int width = pct.Width;
            int height = pct.Height;
            int stepx = width / 10; //ширина ячейки 
            int stepy = height / 10;// высота ячейки
            int bufX = x; // stepx; //количество целых ячеек
            int bufY = y; // stepy;

            Graphics g = pct.CreateGraphics();
            Pen pn = new Pen(Color.Blue, 3);
            // g.DrawLine(pn, coordinataX1, coordinataY1, coordinataX4, coordinataY4);
        }
        public void DrawVertikal(int x, int y, ref PictureBox pct)
        {
            int width = pct.Width;
            int height = pct.Height;
            int stepx = width / 10; //ширина ячейки 
            int stepy = height / 10;// высота ячейки
            int bufX = x; // stepx; //количество целых ячеек
            int bufY = y; // stepy;

            Graphics g = pct.CreateGraphics();
            Pen pn = new Pen(Color.Blue, 3);
            // g.DrawLine(pn, coordinataX1, coordinataY1, coordinataX4, coordinataY4);
        }






        private void lblHelloWorld_Click(object sender, EventArgs e)
        {

        }

        private void pct_Click(object sender, EventArgs e)
        {

        }

        static public void pctLineXY_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e) //Крестик
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // Нолик
        {

        }
    }
}

