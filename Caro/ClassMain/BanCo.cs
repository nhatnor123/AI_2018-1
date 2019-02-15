using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caro
{
    class BanCo
    {
        private int _SoDong;
        private int _SoCot;

        Image imageO = new Bitmap(Properties.Resources.o);
        Image imageX = new Bitmap(Properties.Resources.x);

        public int SoDong
        {
            get
            {
                return _SoDong;
            }

            set
            {
                _SoDong = value;
            }
        }

        public int SoCot
        {
            get
            {
                return _SoCot;
            }

            set
            {
                _SoCot = value;
            }
        }

        public BanCo()
        {
            SoDong = 0;
            SoCot = 0;
        }
        public BanCo(int dong, int cot)
        {
            SoDong = dong;
            SoCot = cot;
        }

        public void VeBanCo(Graphics g)
        {
            for (int i = 0; i <= SoCot; i++)        // vẽ chiều dọc
            {
                g.DrawLine(CaroChess.pen, i * OCo.CHIEU_RONG, 0, i * OCo.CHIEU_RONG, SoDong * OCo.CHIEU_CAO);
            }
            for (int j = 0; j <= SoDong; j++)    // vẽ chiều ngang
            {
                g.DrawLine(CaroChess.pen, 0, j * OCo.CHIEU_CAO, SoCot * OCo.CHIEU_RONG, j * OCo.CHIEU_CAO);
            }
        }

        public void VeQuanCo(Graphics g, Point point, int luotDi)
        {
            //g.FillEllipse(sb, point.X + 2, point.Y + 2, OCo.CHIEU_RONG - 4, OCo.CHIEU_CAO - 4);
            if (luotDi == 1)
            {
                g.DrawImage(imageO, new Point(point.X+2, point.Y+2) );
            }
            else if (luotDi == 2)
            {
                g.DrawImage(imageX, new Point(point.X + 2, point.Y + 2));
            }
        }

        public void XoaQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillRectangle(sb, point.X + 1, point.Y + 1, OCo.CHIEU_RONG - 2, OCo.CHIEU_CAO - 2);
        }
    }
}
