using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caro
{
    class OCo
    {
        public const int CHIEU_RONG = 30;
        public const int CHIEU_CAO = 30;

        private int _Dong;
        private int _Cot;



        public int Dong         // Ctrl R, Ctrl E  : tao getter setter;
        {
            get
            {
                return _Dong;
            }

            set
            {
                _Dong = value;
            }
        }

        public int Cot
        {
            get
            {
                return _Cot;
            }

            set
            {
                _Cot = value;
            }
        }

        private Point _ViTri;       // using System.Drawing; 
        public Point ViTri
        {
            get
            {
                return _ViTri;
            }

            set
            {
                _ViTri = value;
            }
        }


        private int _SoHuu;             // 1 thì là người 1 hoặc là Máy, 2 là người 2 hoặc Người
        public int SoHuu
        {
            get
            {
                return _SoHuu;
            }

            set
            {
                _SoHuu = value;
            }
        }


        public OCo(int dong, int cot, Point viTri, int soHuu)
        {
            Dong = dong;
            Cot = cot;
            ViTri = viTri;
            SoHuu = soHuu;
        }
        public OCo() { }


        public void ganGiaTriOCo(OCo oCo1)
        {
            this.Dong = oCo1.Dong;
            this.Cot = oCo1.Cot;
            this.SoHuu = oCo1.SoHuu;
            this.ViTri = oCo1.ViTri;
        }


    }
}
