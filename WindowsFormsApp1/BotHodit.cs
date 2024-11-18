using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    internal class BotHodit
    {
        private BuffDatas buffDatas;
        private NewRand newRand = new NewRand();
        private Risovalka ris = new Risovalka();
        private bool chk;

        public BotHodit(BuffDatas buffDatas)
        {
            this.buffDatas = buffDatas;
        }
        public void MoveBotNolik(ref PictureBox pctLineXY)
        {
            var rbd = newRand.Rerandom(ref pctLineXY);
            var xHod = rbd.Item1;
            var yHod = rbd.Item2;
            int bufX;
            int bufY;
            CheckBox(xHod, yHod);
            if (chk == true)
            {
                ris.Nolik(xHod, yHod, ref pctLineXY);
                buffDatas.buffD[xHod, yHod] = "O";
            }
            else
            {
                do
                {
                    var rnd = newRand.Rerandom(ref pctLineXY);
                    bufX = rnd.Item1;
                    bufY = rnd.Item2;
                    CheckBox(bufX, bufY);
                }
                while (chk == false);
                ris.Nolik(bufX, bufY, ref pctLineXY);
                buffDatas.buffD[bufX, bufY] = "O";
            }
            
        }
        public void MoveBotKrestik(ref PictureBox pctLineXY)
        {
            var rbd = newRand.Rerandom(ref pctLineXY);
            var xHod = rbd.Item1;
            var yHod = rbd.Item2;
            int bufX;
            int bufY;
            CheckBox(xHod, yHod);
            if (chk == true)
            {
                ris.Krestik(xHod, yHod, ref pctLineXY);
                buffDatas.buffD[xHod, yHod] = "X";
            }
            else
            {
                do
                {
                    var rnd = newRand.Rerandom(ref pctLineXY);
                    bufX = rnd.Item1;
                    bufY = rnd.Item2;
                    CheckBox(bufX, bufY);
                }
                while (chk == false);
                ris.Krestik(bufX, bufY, ref pctLineXY);
                buffDatas.buffD[bufX, bufY] = "X";

            }
        }
       
        public bool CheckBox(int x, int y )
        {
         //if(buffDatas.buffD[x, y] == "X" & buffDatas.buffD[x,y] == "O")
         //       chk= false;

            if (buffDatas.buffD[x,y] == "-")
            {
                chk = true;
            }
            else
            {
                chk = false;
            }
         //if(buffDatas.buffD[x, y] == "X")
         //       chk = false;
         //if(buffDatas.buffD[x, y] == "O")
         //       chk = false;
         //if (buffDatas.buffD[x, y] == "-")
         //       chk = true;
              return chk;
        }
        
    }
}
