using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMonitor
{
    public partial class Stations : Form
    {

        //Khoi tao bien dem so luong ong trong tram
        int HV, HV1, HV2, SaiSon, SS1, SS2, PhuTan, PT1, PT2, TA, TA1, TA2, TA3, VN, VN1, VN2, VN3, VN4, TS, TS1, TS2, TS3, TS4;
        int HL, HL1, HL2, HL3, HL4, TC3, TC31, TC32, Ace, Ace1, Ace2, Ace3;

       

        private void Stations_Activated(object sender, EventArgs e)
        {
            
        }
        //Bien tinh tong so trạm (1 trạm có nhiều ống)
        int _HV, _SS, _PT, _TA, _VN, _TS, _TC3, _Acecook, _HL;
        int nCT, nDL, nMTuan, nTC1, nGiayAH, nNhomCT, nNhomMD, nSabeco, nAriyana, nNM2, nMTien, nETC;
        public static int TongKhi, TongNuoc, TongNuocNgam;
        public Stations()
        {
            InitializeComponent();
        }

        private void Stations_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 90000;

            //Run First Time
            runCheckAll();
            showNumberStation();
            TongKhi = nDL + nMTuan + nCT + nTC1 + nGiayAH + nNhomCT + nNhomMD + nMTien + nETC + _HV + _PT + _SS + _TA + _VN + _TS + 3 ;
            TongNuoc = nSabeco + nAriyana;
            TongNuocNgam = _Acecook;


            //Timer 2 for update first
            timer2.Enabled = true;
            timer2.Interval = 1000;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            runCheckAll();
            showNumberStation();

            TongKhi = nDL + nMTuan + nCT + nTC1 + nGiayAH + nNhomCT + nNhomMD + nMTien + nETC + _HV + _PT + _SS + _TA + _VN + _TS + 3; //TC3, HL, NM2
            TongNuoc = nSabeco + nAriyana;
            TongNuocNgam = _Acecook;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                timer2.Enabled = false;
            }

            runCheckAll();
            showNumberStation();

            TongKhi = nDL + nMTuan + nCT + nTC1 + nGiayAH + nNhomCT + nNhomMD + nMTien + nETC + _HV + _PT + _SS + _TA + _VN + _TS + 3; //TC3, HL, NM2
            TongNuoc = nSabeco + nAriyana;
            TongNuocNgam = _Acecook;
        }

        private void runCheck(bool isChecked, Panel panel)
        {
            if (isChecked)
            {
                panel.BackColor = Color.FromArgb(102, 180, 69);//Connetion - Xanh
            }
            else
            {
                panel.BackColor = Color.FromArgb(247, 0, 0);//Disconnetion - Do
            }
        }

        private void runCheckAll()
        {
            // Cuong Thinh
            runCheck(FormMain.isCheckedCuongThinh, panelCuongThinh);
            nCT = checkCount(FormMain.isCheckedCuongThinh);
            //Duyen Linh
            runCheck(FormMain.isCheckedDuyenLinh, panelDuyenLinh);
            nDL = checkCount(FormMain.isCheckedDuyenLinh);
            //Minh Tuan:
            runCheck(FormMain.isCheckedMinhTuan, panelMinhTuan);
            nMTuan = checkCount(FormMain.isCheckedMinhTuan);
            //Phu Tan
            bool isPhuTan = FormMain.isCheckedPhuTan1 && FormMain.isCheckedPhuTan2;
            runCheck(isPhuTan, panelPhuTan);
            _PT = checkCount(isPhuTan);
            //Thanh cong 1
            runCheck(FormMain.isCheckedTC1, panelTC1);
            nTC1 = checkCount(FormMain.isCheckedTC1);
            //Giay An Hoa
            runCheck(FormMain.isCheckedGiayAH, panelGiayAH);
            nGiayAH = checkCount(FormMain.isCheckedGiayAH);
            //Nhom Chien thang
            runCheck(FormMain.isCheckedNhomCT, panelNhomCT);
            nNhomCT = checkCount(FormMain.isCheckedNhomCT);
            //Nhom Minh Dung
            runCheck(FormMain.isCheckedNhomMD, panelNhomMD);
            nNhomMD = checkCount(FormMain.isCheckedNhomMD);
            //Sabeco
            runCheck(FormMain.isCheckedSabeco, panelSabeco);
            nSabeco = checkCount(FormMain.isCheckedSabeco);

            //////Nguyet Minh 2
            //runCheck(FormMain.isCheckedNguyetMinh2, panelNguyetMinh2);
            //nNM2 = checkCount(FormMain.isCheckedNguyetMinh2);
            //Minh Tien
            runCheck(FormMain.isCheckedMinhTien, panelMinhTien);
            nMTien = checkCount(FormMain.isCheckedMinhTien);
            //ETC Nam Dinh
            runCheck(FormMain.isCheckedETC, panelETC);
            nETC = checkCount(FormMain.isCheckedETC);
            //Ariyana
            runCheck(FormMain.isCheckedAriyana, panelAriyana);
            nAriyana = checkCount(FormMain.isCheckedAriyana);
            //Vicem Hai Van
            bool isHV = FormMain.isCheckedVicemHV1 && FormMain.isCheckedVicemHV2;
            runCheck(isHV, panelVicemHV);
            _HV = checkCount(isHV);
            //XM Sai Son:
            bool isSaiSon = FormMain.isCheckedSaiSon1 && FormMain.isCheckedSaiSon2;
            runCheck(isSaiSon, panelSaiSon);
            _SS = checkCount(isSaiSon);

            ////Thanh Cong 3
            //bool isTC3 = FormMain.isCheckedTC31 && FormMain.isCheckedTC32;
            //runCheck(isTC3, panelTC3);
            //_TC3 = checkCount(isTC3);

            //Thuy Anh
            bool isTA = FormMain.isCheckedTA1 && FormMain.isCheckedTA2 && FormMain.isCheckedTA3;
            runCheck(isTA, panelTA);
            _TA = checkCount(isTA);

            //Acecook
            bool isAcecook = FormMain.isCheckedAcecook1 && FormMain.isCheckedAcecook2 && FormMain.isCheckedAcecook3;
            runCheck(isAcecook, panelAcecook);
            _Acecook = checkCount(isAcecook);

            //Van Ninh
            bool isVN = FormMain.isCheckedVN1 && FormMain.isCheckedVN2 && FormMain.isCheckedVN3 && FormMain.isCheckedVN4;
            runCheck(isVN, panelVN);
            _VN = checkCount(isVN);
            ////XM HOANG LONG
            //bool isHL = FormMain.isCheckedHL1 && FormMain.isCheckedHL2 && FormMain.isCheckedHL3 && FormMain.isCheckedHL4;
            //runCheck(isHL, panelHL);
            //_HL = checkCount(isHL);
            //XM TRUNG SON
            bool isTS = FormMain.isCheckedTS1 && FormMain.isCheckedTS2 && FormMain.isCheckedTS3 && FormMain.isCheckedTS4;
            runCheck(isTS, panelTS);
            _TS = checkCount(isTS);
        }

        private int checkCount(bool isChecked)
        {
            int varInt;
            if (isChecked)
            {
                varInt = 1;
            }
            else
            {
                varInt = 0;
            }
            return varInt;
        }

        private void showNumberStation()
        {
            //Phu Tan
            PT1 = checkCount(FormMain.isCheckedPhuTan1);
            PT2 = checkCount(FormMain.isCheckedPhuTan2);
            PhuTan = PT1 + PT2;
            labelNumberPhuTan.Text = PhuTan.ToString();
            //Vicem Hai Van
            HV1 = checkCount(FormMain.isCheckedVicemHV1);
            HV2 = checkCount(FormMain.isCheckedVicemHV2);
            HV = HV1 + HV2;
            labelNumberHV.Text = HV.ToString();

            //XM Sai Son:
            SS1 = checkCount(FormMain.isCheckedSaiSon1);
            SS2 = checkCount(FormMain.isCheckedSaiSon2);
            SaiSon = SS1 + SS2;
            labelNumberSaiSon.Text = SaiSon.ToString();

            //Thanh Cong 3
            //bool isTC3 = FormMain.isCheckedTC31 && FormMain.isCheckedTC32;
            //runCheck(isTC3, panelTC3);
            //TC31 = checkCount(FormMain.isCheckedTC31);
            //TC32 = checkCount(FormMain.isCheckedTC32);
            //TC3 = TC31 + TC32;
            //labelNumberTC3.Text = TC3.ToString();
            //Thuy Anh
            TA1 = checkCount(FormMain.isCheckedTA1);
            TA2 = checkCount(FormMain.isCheckedTA2);
            TA3 = checkCount(FormMain.isCheckedTA3);
            TA = TA1 + TA2 + TA3;
            labelThuyAnh.Text = TA.ToString();

            //Acecook
            Ace1 = checkCount(FormMain.isCheckedAcecook1);
            Ace2 = checkCount(FormMain.isCheckedAcecook2);
            Ace3 = checkCount(FormMain.isCheckedAcecook3);
            Ace = Ace1 + Ace2 + Ace3;
            labelNumberAcecook.Text = Ace.ToString();


            //Van Ninh
            VN1 = checkCount(FormMain.isCheckedVN1);
            VN2 = checkCount(FormMain.isCheckedVN2);
            VN3 = checkCount(FormMain.isCheckedVN3);
            VN4 = checkCount(FormMain.isCheckedVN4);
            VN = VN1 + VN2 + VN3 + VN4;
            labelNumberVN.Text = VN.ToString();
            //Passing to Main Form


            ////XM HOANG LONG
            //HL1 = checkCount(FormMain.isCheckedHL1);
            //HL2 = checkCount(FormMain.isCheckedHL2);
            //HL3 = checkCount(FormMain.isCheckedHL3);
            //HL4 = checkCount(FormMain.isCheckedHL4);
            //HL = HL1 + HL2 + HL3 + HL4;
            //labelNumberHL.Text = HL.ToString();

            //XM TRUNG SON
            TS1 = checkCount(FormMain.isCheckedTS1);
            TS2 = checkCount(FormMain.isCheckedTS2);
            TS3 = checkCount(FormMain.isCheckedTS3);
            TS4 = checkCount(FormMain.isCheckedTS4);
            TS = TS1 + TS2 + TS3 + TS4;
            labelNumberTS.Text = TS.ToString();
        }
    }
}
