using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class frmCoCaro : Form
    {
        private CaroChess caroChess;        //
        private Graphics grs;               //
        public frmCoCaro()
        {
            InitializeComponent();
            caroChess = new CaroChess();    //
            caroChess.KhoiTaoMangOCo();     // init mảng ô cờ

            grs = pnlBanCo.CreateGraphics();

            ptbPvC.Visible = ptbPvP.Visible = false;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tmChuChay_Tick(object sender, EventArgs e)
        {

        }

        private void frmCoCaro_Load(object sender, EventArgs e)
        {
            // tryền text vào label lblChuoiChu
            lblChuoiChu.Text = "-Hai bên thay phiên\n nhau đi cờ\n\n-Bên nào tạo được 5\n quân liên tiếp hàng\n ngang, hoặc hàng \ndọc, hoặc hàng chéo \ntrước mà không bị \nchặn cả 2 đầu thì \ndành chiến thắng \n\n-Nếu hết chỗ thì\n 2 bên hòa nhau";

            caroChess.VeBanCo(grs);
        }

        private void lblChuoiChu_Click(object sender, EventArgs e)
        {

        }

        private void pnlBanCo_Paint(object sender, PaintEventArgs e)
        {
            caroChess.VeBanCo(grs);
            caroChess.VeLaiQuanCo(grs);
        }

        private void pnlBanCo_MouseClick(object sender, MouseEventArgs e)
        {
            if (!caroChess.SanSang)
            {
                return;        // out khỏi hàm
            }

            if (caroChess.DanhCo(e.X, e.Y, grs))
            {
                if (caroChess.KiemTraChienThang())      // kiểm tra xem ai win chưa 
                {
                    caroChess.KetThucTroChoi();
                }
                else if (caroChess.CheDoChoi == 2)           // khởi động AI của máy để chơi với người
                {
                    caroChess.KhoiDongComputer(grs);
                    if (caroChess.KiemTraChienThang())      // kiểm tra xem ai win chưa 
                    {
                        caroChess.KetThucTroChoi();
                    }

                }
            }
        }

        private void PvsP(object sender, EventArgs e)
        {
            CheDoChoi = 1;
            inMauCheDo(CheDoChoi);
            grs.Clear(pnlBanCo.BackColor);

            caroChess.StartPvP(grs);
        }

        private void btnPlayerVsPlayer_Click(object sender, EventArgs e)
        {
            CheDoChoi = 1;
            inMauCheDo(CheDoChoi);
            grs.Clear(pnlBanCo.BackColor);          //xóa bàn cờ đi

            caroChess.StartPvP(grs);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grs.Clear(pnlBanCo.BackColor);
            caroChess.Undo(grs);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caroChess.Redo(grs);
        }



        private void btnPlayerVsCom_Click(object sender, EventArgs e)
        {
            CheDoChoi = 2;
            inMauCheDo(CheDoChoi);
            grs.Clear(pnlBanCo.BackColor);          //xóa bàn cờ đi

            caroChess.StartPlayerVsCom(grs);

            
        }

        private void playerVsComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheDoChoi = 2;
            inMauCheDo(CheDoChoi);
            grs.Clear(pnlBanCo.BackColor);          //xóa bàn cờ đi

            caroChess.StartPlayerVsCom(grs);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tGame Cờ Caro\n\nPhiên bản : 1.1\n\nNhóm 4:\n\tNguyễn Lưu Nhật\n\tPhạm Duy Hiếu\n\tTạ Đức Phú");
        }

        int CheDoChoi = 1;

        private void btnChoiMoi_Click(object sender, EventArgs e)
        {
            if (CheDoChoi == 1)
            {
                grs.Clear(pnlBanCo.BackColor);          //xóa bàn cờ đi

                caroChess.StartPvP(grs);
            }
            else if (CheDoChoi == 2)
            {
                grs.Clear(pnlBanCo.BackColor);          //xóa bàn cờ đi

                caroChess.StartPlayerVsCom(grs);
            }
        }

        private void inMauCheDo(int x)
        {
            if (x == 1)
            {
                ptbPvP.Visible = true;
                ptbPvC.Visible = false;
                label1.Text = "Người chơi 1 ( đi đầu)";
                label2.Text = "Người chơi 2 ( đi sau)";
            }
            else if (x == 2)
            {
                ptbPvP.Visible = false;
                ptbPvC.Visible = true;
                label1.Text = "Máy ( đi đầu)";
                label2.Text = "Người ( đi sau)";
            }
        }

        private void ptbPvP_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmExit form = new frmExit();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExit form = new frmExit();
            form.ShowDialog();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            caroChess.Undo(grs);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            caroChess.Redo(grs);
        }
    }
}
