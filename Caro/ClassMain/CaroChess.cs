using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public enum KET_THUC
    {
        HoaCo,
        Player1,
        Player2,
        COM
    }
    class CaroChess
    {
        public static Pen pen;

        public static SolidBrush sbScrollBar;       // màu nền của từng ô cờ



        private OCo[,] _MangOCo;
        private BanCo _BanCo;

        private Stack<OCo> listCacNuocDaDi;     // stack để lưu cờ Undo
        private Stack<OCo> stackCacNuocUndo;    // stack để lưu cờ Redo

        private KET_THUC _ketThuc;

        private bool _SanSang;
        private int _LuotDi;
        private int _CheDoChoi;                 // để lưu chế độ chơi, 1 là PvsP, 2 là PvsC


        public int LuotDi
        {
            get
            {
                return _LuotDi;
            }

            set
            {
                _LuotDi = value;
            }
        }
        public bool SanSang
        {
            get
            {
                return _SanSang;
            }

            set
            {
                _SanSang = value;
            }
        }
        public int CheDoChoi
        {
            get
            {
                return _CheDoChoi;
            }

            set
            {
                _CheDoChoi = value;
            }
        }

        public CaroChess()
        {
            pen = new Pen(Color.Green);

            sbScrollBar = new SolidBrush(Color.Silver);

            _BanCo = new BanCo(19, 19);         // tạo mới bàn cờ với số dòng , số cột = tham số truyền vào
            _MangOCo = new OCo[_BanCo.SoDong, _BanCo.SoCot];
            listCacNuocDaDi = new Stack<OCo>();
            stackCacNuocUndo = new Stack<OCo>();

            LuotDi = 1;
        }

        public void VeBanCo(Graphics g)
        {
            _BanCo.VeBanCo(g);
        }

        public void KhoiTaoMangOCo()
        {
            for (int i = 0; i < _BanCo.SoDong; i++)
            {
                for (int j = 0; j < _BanCo.SoCot; j++)
                {
                    _MangOCo[i, j] = new OCo(i, j, new Point(j * OCo.CHIEU_RONG, i * OCo.CHIEU_CAO), 0);
                }
            }
        }

        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            if (MouseX % OCo.CHIEU_RONG == 0 || MouseY % OCo.CHIEU_CAO == 0)    // nếu click vào hàng dọc hoặc ngang thì k làm j
            {
                return false;
            }

            int Cot1 = MouseX / OCo.CHIEU_RONG;
            int Dong1 = MouseY / OCo.CHIEU_CAO;

            if (_MangOCo[Dong1, Cot1].SoHuu != 0)        // khi click vào ô đã đc chọn trước đó
            {
                return false;
            }

            switch (LuotDi)
            {
                case 1:
                    _MangOCo[Dong1, Cot1].SoHuu = 1;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong1, Cot1].ViTri, 1);
                    LuotDi = 2;                            // đổi lượt đi
                    break;
                case 2:
                    _MangOCo[Dong1, Cot1].SoHuu = 2;
                    _BanCo.VeQuanCo(g, _MangOCo[Dong1, Cot1].ViTri, 2);
                    LuotDi = 1;
                    break;
                default:
                    MessageBox.Show("Error!");
                    break;
            }
            stackCacNuocUndo = new Stack<OCo>();

            OCo oCoNew = new OCo(_MangOCo[Dong1, Cot1].Dong, _MangOCo[Dong1, Cot1].Cot, _MangOCo[Dong1, Cot1].ViTri, _MangOCo[Dong1, Cot1].SoHuu);
            listCacNuocDaDi.Push(oCoNew);
            return true;

        }

        public void VeLaiQuanCo(Graphics g)     // để khi làm j đó thì k re-paint lại cả bàn cờ 
        {
            foreach (OCo oCo1 in listCacNuocDaDi)
            {
                if (oCo1.SoHuu == 1)
                {
                    _BanCo.VeQuanCo(g, oCo1.ViTri, 1);
                }
                else if (oCo1.SoHuu == 2)
                {
                    _BanCo.VeQuanCo(g, oCo1.ViTri, 2);
                }
            }
        }

        public void StartPvP(Graphics g)
        {
            SanSang = true;
            listCacNuocDaDi = new Stack<OCo>();
            stackCacNuocUndo = new Stack<OCo>();
            LuotDi = 1;
            CheDoChoi = 1;
            KhoiTaoMangOCo();
            VeBanCo(g);
        }

        public void StartPlayerVsCom(Graphics g)
        {
            SanSang = true;
            listCacNuocDaDi = new Stack<OCo>();
            stackCacNuocUndo = new Stack<OCo>();
            LuotDi = 1;
            CheDoChoi = 2;
            KhoiTaoMangOCo();
            VeBanCo(g);

            KhoiDongComputer(g);

        }


        #region Undo, Redo
        public void Undo(Graphics g)
        {
            if (listCacNuocDaDi.Count != 0)
            {
                if (CheDoChoi == 1)
                {
                    OCo oCo1 = listCacNuocDaDi.Pop();

                    stackCacNuocUndo.Push(new OCo(oCo1.Dong, oCo1.Cot, oCo1.ViTri, oCo1.SoHuu));
                    _MangOCo[oCo1.Dong, oCo1.Cot].SoHuu = 0;

                    _BanCo.XoaQuanCo(g, oCo1.ViTri, sbScrollBar);

                    if (LuotDi == 1)
                        LuotDi = 2;
                    else
                        LuotDi = 1;
                }
                else if (CheDoChoi == 2)
                {
                    OCo oCo1 = listCacNuocDaDi.Pop();
                    OCo oCo2 = listCacNuocDaDi.Pop();

                    stackCacNuocUndo.Push(new OCo(oCo1.Dong, oCo1.Cot, oCo1.ViTri, oCo1.SoHuu));
                    _MangOCo[oCo1.Dong, oCo1.Cot].SoHuu = 0;
                    stackCacNuocUndo.Push(new OCo(oCo1.Dong, oCo2.Cot, oCo2.ViTri, oCo2.SoHuu));
                    _MangOCo[oCo2.Dong, oCo2.Cot].SoHuu = 0;

                    _BanCo.XoaQuanCo(g, oCo1.ViTri, sbScrollBar);
                    _BanCo.XoaQuanCo(g, oCo2.ViTri, sbScrollBar);


                }
            }
            //VeBanCo(g);
            //VeLaiQuanCo(g);
        }

        public void Redo(Graphics g)
        {
            if (stackCacNuocUndo.Count != 0)
            {
                if (CheDoChoi == 1)
                {
                    OCo oCo1 = stackCacNuocUndo.Pop();
                    listCacNuocDaDi.Push(new OCo(oCo1.Dong, oCo1.Cot, oCo1.ViTri, oCo1.SoHuu));
                    _MangOCo[oCo1.Dong, oCo1.Cot].SoHuu = oCo1.SoHuu;

                    _BanCo.VeQuanCo(g, oCo1.ViTri, oCo1.SoHuu == 1 ? 1 : 2);

                    if (LuotDi == 1)
                        LuotDi = 2;
                    else
                        LuotDi = 1;
                }
                else if (CheDoChoi == 2)
                {
                    OCo oCo1 = stackCacNuocUndo.Pop();
                    listCacNuocDaDi.Push(new OCo(oCo1.Dong, oCo1.Cot, oCo1.ViTri, oCo1.SoHuu));
                    _MangOCo[oCo1.Dong, oCo1.Cot].SoHuu = oCo1.SoHuu;

                    _BanCo.VeQuanCo(g, oCo1.ViTri, oCo1.SoHuu == 1 ? 1 : 2);

                    OCo oCo2 = stackCacNuocUndo.Pop();
                    listCacNuocDaDi.Push(new OCo(oCo2.Dong, oCo2.Cot, oCo2.ViTri, oCo2.SoHuu));
                    _MangOCo[oCo2.Dong, oCo2.Cot].SoHuu = oCo2.SoHuu;

                    _BanCo.VeQuanCo(g, oCo2.ViTri, oCo2.SoHuu == 1 ? 1 : 2);
                }
            }
        }
        #endregion


        #region Check Winner
        public void KetThucTroChoi()        //được gọi khi end game
        {
            switch (_ketThuc)
            {
                case KET_THUC.HoaCo:
                    MessageBox.Show("Hòa cờ");
                    break;
                case KET_THUC.Player1:
                    if (CheDoChoi == 1)
                    {
                        MessageBox.Show("Người chơi 1 thắng");
                    }
                    else if (CheDoChoi == 2)
                    {
                        MessageBox.Show("Máy thắng");
                    }
                    break;
                case KET_THUC.Player2:
                    if (CheDoChoi == 1)
                    {
                        MessageBox.Show("Người chơi 2 thắng");
                    }
                    else if (CheDoChoi == 2)
                    {
                        MessageBox.Show("Bạn đã thắng");
                    }
                    break;
                case KET_THUC.COM:
                    MessageBox.Show("Máy thắng");
                    break;
            }
            SanSang = false;            // lúc này sẽ k nhấn đc j trên bàn cờ nữa

        }
        public bool KiemTraChienThang()         // kiểm tra xem ai win chưa
        {
            if (listCacNuocDaDi.Count == _BanCo.SoCot * _BanCo.SoDong)      // full ô cờ
            {
                _ketThuc = KET_THUC.HoaCo;
                return true;
            }

            foreach (OCo oco1 in listCacNuocDaDi)
            {
                if (DuyetDoc(oco1.Dong, oco1.Cot, oco1.SoHuu) || DuyetNgang(oco1.Dong, oco1.Cot, oco1.SoHuu) || DuyetCheoXuong(oco1.Dong, oco1.Cot, oco1.SoHuu) || DuyetCheoLen(oco1.Dong, oco1.Cot, oco1.SoHuu))
                {
                    _ketThuc = oco1.SoHuu == 1 ? KET_THUC.Player1 : KET_THUC.Player2;
                    return true;
                }
            }

            return false;
        }

        private bool DuyetDoc(int currentDong, int currentCot, int currentSoHuu)      // duyệt theo hàng dọc 
        {
            if (currentDong > _BanCo.SoDong - 5)      // nếu nằm ở 4 ô cuối
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)             // xét 4 ô tiếp theo + ô hiện tại
            {
                if (_MangOCo[currentDong + Dem, currentCot].SoHuu != currentSoHuu)
                {
                    return false;
                }

            }
            if (currentDong == 0 || currentDong + Dem == _BanCo.SoDong)       // Dem =5, trường hợp biên trên, biên dưới
            {
                return true;
            }
            if (_MangOCo[currentDong - 1, currentCot].SoHuu == 0 || _MangOCo[currentDong + Dem, currentCot].SoHuu == 0)// trường hợp 1 trong 2 đầu k có quân cờ nào
            {
                return true;
            }

            return false;           // trả về false cho các trường hợp còn lại
        }

        private bool DuyetNgang(int currentDong, int currentCot, int currentSoHuu)      // duyệt theo hàng dọc 
        {
            if (currentCot > _BanCo.SoCot - 5)      // nếu nằm ở 4 ô cuối
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)             // xét 4 ô tiếp theo + ô hiện tại
            {
                if (_MangOCo[currentDong, currentCot + Dem].SoHuu != currentSoHuu)
                {
                    return false;
                }

            }
            if (currentCot == 0 || currentCot + Dem == _BanCo.SoCot)       // Dem =5, trường hợp biên trái, biên phải
            {
                return true;
            }
            if (_MangOCo[currentDong, currentCot - 1].SoHuu == 0 || _MangOCo[currentDong, currentCot + Dem].SoHuu == 0)// trường hợp 1 trong 2 đầu k có quân cờ nào
            {
                return true;
            }

            return false;           // trả về false cho các trường hợp còn lại
        }

        private bool DuyetCheoXuong(int currentDong, int currentCot, int currentSoHuu)      // duyệt theo trái trên  đến phải dưới 
        {
            if (currentDong > _BanCo.SoDong - 5 || currentCot > _BanCo.SoCot - 5)      // nếu nằm ở 4 ô cuối
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)             // xét 4 ô tiếp theo + ô hiện tại
            {
                if (_MangOCo[currentDong + Dem, currentCot + Dem].SoHuu != currentSoHuu)
                {
                    return false;
                }

            }
            if (currentDong == 0 || currentDong + Dem == _BanCo.SoDong || currentCot == 0 || currentCot + Dem == _BanCo.SoCot)       // Dem =5, trường hợp biên trái, biên phải
            {
                return true;
            }
            if (_MangOCo[currentDong - 1, currentCot - 1].SoHuu == 0 || _MangOCo[currentDong + Dem, currentCot + Dem].SoHuu == 0)// trường hợp 1 trong 2 đầu k có quân cờ nào
            {
                return true;
            }

            return false;           // trả về false cho các trường hợp còn lại
        }

        private bool DuyetCheoLen(int currentDong, int currentCot, int currentSoHuu)      // duyệt theo trái dưới đến phải trên
        {
            if (currentDong < 4 || currentCot > _BanCo.SoCot - 5)      // nếu nằm ở 4 ô cuối
            {
                return false;
            }
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)             // xét 4 ô tiếp theo + ô hiện tại
            {
                if (_MangOCo[currentDong - Dem, currentCot + Dem].SoHuu != currentSoHuu)
                {
                    return false;
                }

            }
            if (currentDong == 4 || currentDong == _BanCo.SoDong - 1 || currentCot == 0 || currentCot + Dem == _BanCo.SoCot)       // Dem =5, trường hợp biên trái, biên phải
            {
                return true;
            }
            if (_MangOCo[currentDong + 1, currentCot - 1].SoHuu == 0 || _MangOCo[currentDong - Dem, currentCot + Dem].SoHuu == 0)// trường hợp 1 trong 2 đầu k có quân cờ nào
            {
                return true;
            }

            return false;           // trả về false cho các trường hợp còn lại
        }

        #endregion


        #region AI & MinimaxAlphaBeta

        public void KhoiDongComputer(Graphics g)
        {
            if (listCacNuocDaDi.Count == 0)
            {
                DanhCo(_BanCo.SoCot / 2 * OCo.CHIEU_RONG + 1, _BanCo.SoDong / 2 * OCo.CHIEU_CAO + 1, g);
            }
            else
            {

                count = 0;
                long DiemMiniMax=MiniMaxAlphaBeta(long.MinValue, long.MaxValue, 1, true);

                //MessageBox.Show(DiemMiniMax.ToString());
                //MessageBox.Show(count.ToString());
                Thread.Sleep(1300);
                //MiniMax(1, true);
                //MessageBox.Show(MiniMax(1, true).ToString());

                DanhCo(DSCacOCoMinimax[1].ViTri.X + 1, DSCacOCoMinimax[1].ViTri.Y + 1, g);
            }
        }

        long count = 0;
        OCo[] DSCacOCoMinimax = new OCo[10];

        private long MiniMax(int depth, bool isCom)       // MiniMax
        {
            count++;
            if (depth == 4)         // tương ứng với depth = 4 tức là đang ở lượt của Min
            {
                long min = long.MaxValue;           // gán min = INFINITY
                for (int i = 0; i < _BanCo.SoDong; i++)             // kiểm tra xem đã end-game chưa ?
                {
                    for (int j = 0; j < _BanCo.SoCot; j++)
                    {
                        if (_MangOCo[i, j].SoHuu == 0)              // lấy những ô chưa được đánh
                        {
                            _MangOCo[i, j].SoHuu = 2;
                            OCo oCoNew = new OCo();
                            oCoNew.ganGiaTriOCo(_MangOCo[i, j]);
                            //listCacNuocDaDi.Push(oCoNew);

                            if (DuyetDoc(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetNgang(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoXuong(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoLen(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu))       // end game
                            {
                                // nếu có lá Người win trong độ sâu này
                                _MangOCo[i, j].SoHuu = 0;
                                DSCacOCoMinimax[4] = oCoNew;
                                return long.MinValue;
                            }

                            if (min > tinhDiemOCo(_MangOCo, _MangOCo[i, j].Dong, _MangOCo[i, j].Cot))      // tìm cái nào min nhất
                            {
                                min = tinhDiemOCo(_MangOCo, _MangOCo[i, j].Dong, _MangOCo[i, j].Cot);
                                DSCacOCoMinimax[4] = oCoNew;
                            }
                            _MangOCo[i, j].SoHuu = 0;
                            //listCacNuocDaDi.Pop();
                        }
                    }
                }
                return min;
            }
            if (isCom)      // check xem có phải là máy đánh k ? , tương ứng là lượt Max trong máy
            {
                long v = long.MinValue;
                for (int i = 0; i < _BanCo.SoDong; i++)             // kiểm tra xem đã end-game chưa ?
                {
                    for (int j = 0; j < _BanCo.SoCot; j++)
                    {
                        if (_MangOCo[i, j].SoHuu == 0)              // lấy những ô chưa được đánh
                        {
                            _MangOCo[i, j].SoHuu = 1;
                            OCo oCoNew1 = new OCo();
                            oCoNew1.ganGiaTriOCo(_MangOCo[i, j]);
                            //listCacNuocDaDi.Push(oCoNew1);

                            if (DuyetDoc(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetNgang(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoXuong(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoLen(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu))
                            {
                                if (_MangOCo[i, j].SoHuu == 1)
                                {
                                    _MangOCo[i, j].SoHuu = 0;
                                    //listCacNuocDaDi.Pop();
                                    DSCacOCoMinimax[depth] = oCoNew1;
                                    return long.MaxValue;
                                }
                            }
                            if (v > MiniMax(depth + 1, false))
                            {
                            }
                            else
                            {
                                DSCacOCoMinimax[depth] = oCoNew1;
                                v = MiniMax(depth + 1, false);
                            }
                            _MangOCo[i, j].SoHuu = 0;
                            //listCacNuocDaDi.Pop();
                        }
                    }
                }
                return v;
            }
            else
            {                                       // tương ứng là lượt Min trong MiniMax
                long v = long.MaxValue;
                for (int i = 0; i < _BanCo.SoDong; i++)             // kiểm tra xem đã end-game chưa ?
                {
                    for (int j = 0; j < _BanCo.SoCot; j++)
                    {
                        if (_MangOCo[i, j].SoHuu == 0)              // lấy những ô chưa được đánh
                        {
                            _MangOCo[i, j].SoHuu = 2;
                            OCo oCoNew2 = new OCo();
                            oCoNew2.ganGiaTriOCo(_MangOCo[i, j]);
                            //listCacNuocDaDi.Push(oCoNew2);

                            if (DuyetDoc(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetNgang(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoXuong(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoLen(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu))
                            {
                                _MangOCo[i, j].SoHuu = 0;
                                //listCacNuocDaDi.Pop();
                                DSCacOCoMinimax[depth] = oCoNew2;
                                return long.MinValue;
                            }
                            if (v < MiniMax(depth + 1, false))
                            {
                            }
                            else
                            {
                                DSCacOCoMinimax[depth] = oCoNew2;
                                v = MiniMax(depth + 1, false);
                            }
                            _MangOCo[i, j].SoHuu = 0;
                            //listCacNuocDaDi.Pop();
                        }
                    }
                }
                return v;
            }
        }

        private long MiniMaxAlphaBeta(long mini, long maxi, int depth, bool isCom)       // Minimax & Alpha-Beta
        {
            
            if (depth == 2)         // tương ứng với depth = 2 tức là đang ở lượt của Min
            {
                long min = long.MaxValue;           // gán min = INFINITY
                for (int i = 0; i < _BanCo.SoDong; i++)             // kiểm tra xem đã end-game chưa ?
                {
                    for (int j = 0; j < _BanCo.SoCot; j++)
                    {
                        if (_MangOCo[i, j].SoHuu == 0)              // lấy những ô chưa được đánh
                        {
                            count++;

                            _MangOCo[i, j].SoHuu = 2;
                            OCo oCoNew = new OCo();
                            oCoNew.ganGiaTriOCo(_MangOCo[i, j]);
                            //listCacNuocDaDi.Push(oCoNew);

                            if (DuyetDoc(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetNgang(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoXuong(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoLen(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu))       // end game
                            {
                                // nếu có lá Người win trong độ sâu này
                                _MangOCo[i, j].SoHuu = 0;
                                DSCacOCoMinimax[2] = oCoNew;
                                return long.MinValue;
                            }
                            long z = tinhDiemOCo(_MangOCo, _MangOCo[i, j].Dong, _MangOCo[i, j].Cot);
                            if (min > z)      // tìm cái nào min nhất
                            {
                                min = z;
                                DSCacOCoMinimax[2] = oCoNew;
                            }
                            _MangOCo[i, j].SoHuu = 0;
                            //listCacNuocDaDi.Pop();
                        }
                    }
                }
                return min;
            }
            if (isCom)      // check xem có phải là máy đánh k ? , tương ứng là lượt Max trong máy
            {
                long v = long.MinValue;
                for (int i = 0; i < _BanCo.SoDong; i++)             // kiểm tra xem đã end-game chưa ?
                {
                    for (int j = 0; j < _BanCo.SoCot; j++)
                    {
                        if (_MangOCo[i, j].SoHuu == 0)              // lấy những ô chưa được đánh
                        {
                            _MangOCo[i, j].SoHuu = 1;
                            OCo oCoNew1 = new OCo();
                            oCoNew1.ganGiaTriOCo(_MangOCo[i, j]);
                            //listCacNuocDaDi.Push(oCoNew1);

                            if (DuyetDoc(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetNgang(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoXuong(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoLen(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu))
                            {
                                if (_MangOCo[i, j].SoHuu == 1)
                                {

                                    _MangOCo[i, j].SoHuu = 0;
                                    //listCacNuocDaDi.Pop();
                                    DSCacOCoMinimax[depth] = oCoNew1;
                                    return long.MaxValue;
                                }
                            }

                            long z = MiniMaxAlphaBeta(mini, maxi, depth + 1, false);

                            if (v > z)
                            {

                            }
                            else
                            {
                                DSCacOCoMinimax[depth] = oCoNew1;
                                v = z;
                            }
                            if (v >= maxi)
                            {
                                return v;
                            }

                            if (v > mini)
                            {
                                mini = v;
                            }

                            _MangOCo[i, j].SoHuu = 0;
                            //listCacNuocDaDi.Pop();
                        }
                    }
                }
                return v;
            }
            else
            {                                       // tương ứng là lượt Min trong MiniMax
                long v = long.MaxValue;
                for (int i = 0; i < _BanCo.SoDong; i++)             // kiểm tra xem đã end-game chưa ?
                {
                    for (int j = 0; j < _BanCo.SoCot; j++)
                    {
                        if (_MangOCo[i, j].SoHuu == 0)              // lấy những ô chưa được đánh
                        {
                            _MangOCo[i, j].SoHuu = 2;
                            OCo oCoNew2 = new OCo();
                            oCoNew2.ganGiaTriOCo(_MangOCo[i, j]);
                            //listCacNuocDaDi.Push(oCoNew2);

                            if (DuyetDoc(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetNgang(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoXuong(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu) || DuyetCheoLen(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].SoHuu))
                            {
                                _MangOCo[i, j].SoHuu = 0;
                                //listCacNuocDaDi.Pop();
                                DSCacOCoMinimax[depth] = oCoNew2;
                                return long.MinValue;
                            }
                            long z = MiniMaxAlphaBeta(mini, maxi, depth + 1, false);
                            if (v < z)
                            {

                            }
                            else
                            {
                                DSCacOCoMinimax[depth] = oCoNew2;
                                v = z;
                            }
                            if (v <= mini)
                            {
                                return v;
                            }
                            if (v < maxi)
                            {
                                maxi = v;
                            }

                            _MangOCo[i, j].SoHuu = 0;
                            //listCacNuocDaDi.Pop();
                        }



                    }
                }
                return v;
            }


        }


        int[] diem = { 0, 10, 100, 1000, 10000, 100000, 1000000, 10000000 };
        public long tinhDiemOCo(OCo[,] _MangOCo, int currentDong, int currentCot)
        {
            #region Điểm quân O

            long DiemO = 0;
            int SoQuanX = 0;
            int SoQuanO = 0;

            for (int Dem = 1; Dem < 6 && currentDong + Dem < _BanCo.SoDong; Dem++)      //xét chiều từ trên xuống           // dọc
            {
                if (_MangOCo[currentDong + Dem, currentCot].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong + Dem, currentCot].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentDong - Dem >= 0; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong - Dem, currentCot].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong - Dem, currentCot].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanX == 2 && SoQuanO <= 4)
            {
                //giữ nguyên
            }
            else
            {
                DiemO += diem[SoQuanO];
                DiemO -= diem[SoQuanX];
            }

            SoQuanX = SoQuanO = 0;
            for (int Dem = 1; Dem < 6 && currentCot + Dem < _BanCo.SoCot; Dem++)      //xét chiều từ trên xuống         // ngang
            {
                if (_MangOCo[currentDong, currentCot + Dem].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong, currentCot + Dem].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentCot - Dem >= 0; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong, currentCot - Dem].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong, currentCot - Dem].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanX == 2 && SoQuanO <= 4)
            {
                //giữ nguyên
            }
            else
            {
                DiemO += diem[SoQuanO];
                DiemO -= diem[SoQuanX];
            }


            SoQuanO = 0;
            SoQuanX = 0;
            for (int Dem = 1; Dem < 6 && currentCot + Dem < _BanCo.SoCot && currentDong - Dem >= 0; Dem++)      //xét chiều từ trên xuống  // chéo
            {
                if (_MangOCo[currentDong - Dem, currentCot + Dem].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong - Dem, currentCot + Dem].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentCot - Dem >= 0 && currentDong + Dem < _BanCo.SoDong; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong + Dem, currentCot - Dem].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong + Dem, currentCot - Dem].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanX == 2 && SoQuanO <= 4)
            {
                //giữ nguyên
            }
            else
            {
                DiemO += diem[SoQuanO];
                DiemO -= diem[SoQuanX];
            }


            SoQuanO = 0;
            SoQuanX = 0;
            for (int Dem = 1; Dem < 6 && currentCot + Dem < _BanCo.SoCot && currentDong + Dem < _BanCo.SoDong; Dem++)// chéo      //xét chiều từ trên xuống
            {
                if (_MangOCo[currentDong + Dem, currentCot + Dem].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong + Dem, currentCot + Dem].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentCot - Dem >= 0 && currentDong - Dem >= 0; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong - Dem, currentCot - Dem].SoHuu == 1)
                {
                    SoQuanO++;
                }
                else if (_MangOCo[currentDong - Dem, currentCot - Dem].SoHuu == 2)
                {
                    SoQuanX++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanX == 2 && SoQuanO <= 4)
            {
                //giữ nguyên
            }
            else
            {
                DiemO += diem[SoQuanO];
                DiemO -= diem[SoQuanX];
            }
            #endregion

            #region Điểm quân X


            long DiemX = 0;
            SoQuanO = 0;
            SoQuanX = 0;
            for (int Dem = 1; Dem < 6 && currentDong + Dem < _BanCo.SoDong; Dem++)      //xét chiều từ trên xuống
            {
                if (_MangOCo[currentDong + Dem, currentCot].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong + Dem, currentCot].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentDong - Dem >= 0; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong - Dem, currentCot].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong - Dem, currentCot].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanO == 2 && SoQuanX<=4)
            {
                //
            }
            else
            {

                DiemX += diem[SoQuanX];
                DiemX -= diem[SoQuanO];
            }



            SoQuanX = 0;
            SoQuanO = 0;
            for (int Dem = 1; Dem < 6 && currentCot + Dem < _BanCo.SoCot; Dem++)      //xét chiều từ trên xuống
            {
                if (_MangOCo[currentDong, currentCot + Dem].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong, currentCot + Dem].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentCot - Dem >= 0; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong, currentCot - Dem].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong, currentCot - Dem].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanO == 2 && SoQuanX <= 4)
            {
                //
            }
            else
            {

                DiemX += diem[SoQuanX];
                DiemX -= diem[SoQuanO];
            }



            SoQuanX = 0;
            SoQuanO = 0;
            for (int Dem = 1; Dem < 6 && currentCot + Dem < _BanCo.SoCot && currentDong - Dem >= 0; Dem++)      //xét chiều từ trên xuống
            {
                if (_MangOCo[currentDong - Dem, currentCot + Dem].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong - Dem, currentCot + Dem].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentCot - Dem >= 0 && currentDong + Dem < _BanCo.SoDong; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong + Dem, currentCot - Dem].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong + Dem, currentCot - Dem].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanO == 2 && SoQuanX <= 4)
            {
                //
            }
            else
            {

                DiemX += diem[SoQuanX];
                DiemX -= diem[SoQuanO];
            }



            SoQuanO = 0;
            SoQuanX = 0;
            for (int Dem = 1; Dem < 6 && currentCot + Dem < _BanCo.SoCot && currentDong + Dem < _BanCo.SoDong; Dem++)      //xét chiều từ trên xuống
            {
                if (_MangOCo[currentDong + Dem, currentCot + Dem].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong + Dem, currentCot + Dem].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            for (int Dem = 1; Dem < 6 && currentCot - Dem >= 0 && currentDong - Dem >= 0; Dem++)                 //xét chiều từ dưới lên
            {
                if (_MangOCo[currentDong - Dem, currentCot - Dem].SoHuu == 1)
                {
                    SoQuanO++;
                    break;
                }
                else if (_MangOCo[currentDong - Dem, currentCot - Dem].SoHuu == 2)
                {
                    SoQuanX++;
                }
                else
                {
                    break;
                }
            }

            if (SoQuanO == 2 && SoQuanX <= 4)
            {
                //
            }
            else
            {

                DiemX += diem[SoQuanX];
                DiemX -= diem[SoQuanO];
            }
            #endregion

            return DiemO - DiemX;
        }

        #endregion
    }
}
