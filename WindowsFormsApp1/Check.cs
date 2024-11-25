using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Check
    {
        Risovalka riS = new Risovalka();
        BuffDatas buffDataS;

        public Check(BuffDatas buffDataS)
        {
            this.buffDataS = buffDataS;
        }

        public bool CheckWinXvert(string symbol, int x, int y, ref PictureBox pctLineXY)//проверка вертикали по ближайшим координатам
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
                        //DrawVertikal(x, i);
                        riS.DrawGorizont1(x, i, ref pctLineXY);
                        MessageBox.Show("Победа");

                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }
        public bool CheckWinXgoriz(string symbol, int x, int y, ref PictureBox pctLineXY)//проверка горизонтали по ближайшим координатам
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
                        riS.DrawGorizont1(x, i, ref pctLineXY);
                        //DrawGorizont(i, y);
                        MessageBox.Show("Победа");
                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }
        public bool CheckWinOvert(string symbol, int x, int y, ref PictureBox pctLineXY)//проверка вертикали по ближайшим координатам
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
                        riS.DrawVertikal1(x, i, ref pctLineXY);
                        MessageBox.Show("Победа");
                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }
        public bool CheckWinOgoriz(string symbol, int x, int y, ref PictureBox pctLineXY)//проверка горизонтали по ближайшим координата
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
                        riS.DrawGorizont1(i, y, ref pctLineXY);
                        MessageBox.Show("Победа");
                    }
                    else
                        counter = 0;
                }
            }
            return win;
        }


    }
}
