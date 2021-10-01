using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
namespace AppMonitor
{
    public partial class FormMain : Form
    {
        //Fields
        private Form activeForm;
        bool isStationForm = false;
        bool isAlarmForm = false;
        int nKeNgang = 0;
        //

        #region / Khoi tao Bien kiem tra ket noi
        public static bool isCheckedCuongThinh = true;
        public static bool isCheckedDuyenLinh = true;
        public static bool isCheckedMinhTuan = true;
        public static bool isCheckedPhuTan1 = true;
        public static bool isCheckedPhuTan2 = true;
        public static bool isCheckedTC1 = true;
        public static bool isCheckedGiayAH = true;
        public static bool isCheckedNhomCT = true;
        public static bool isCheckedNhomMD = true;
        public static bool isCheckedSabeco = true;

        public static bool isCheckedAriyana = true;//-----------

        public static bool isCheckedNguyetMinh2 = true;//-----------

        public static bool isCheckedMinhTien = true;
        public static bool isCheckedETC = true;

        public static bool isCheckedVicemHV1 = true;//-------
        public static bool isCheckedVicemHV2 = true;

        public static bool isCheckedSaiSon1 = true;
        public static bool isCheckedSaiSon2 = true;

        public static bool isCheckedTC31 = true;//-------
        public static bool isCheckedTC32 = true;

        public static bool isCheckedTA1 = true;
        public static bool isCheckedTA2 = true;
        public static bool isCheckedTA3 = true;
        //Acecook not check yet
        public static bool isCheckedAcecook1 = true;
        public static bool isCheckedAcecook2 = true;
        public static bool isCheckedAcecook3 = true;

        //Acecook check every 15 phút

        public static bool isCheckedVN1 = true;
        public static bool isCheckedVN2 = true;
        public static bool isCheckedVN3 = true;
        public static bool isCheckedVN4 = true;

        public static bool isCheckedHL1 = true;
        public static bool isCheckedHL2 = true;
        public static bool isCheckedHL3 = true;
        public static bool isCheckedHL4 = true;

        public static bool isCheckedTS1 = true;
        public static bool isCheckedTS2 = true;
        public static bool isCheckedTS3 = true;
        public static bool isCheckedTS4 = true;


        #endregion

        #region //TAO DIR ROOT FOR ALL STATION

        string rootCuongThinh = "/ximangcuongthinh/LO NGHIEN XI";
        string rootDuyenLinh = "/ximangduyenlinh/LO NGHIEN XI";
        string rootMinhTuan = "/ximangminhtuan/LO NGHIEN XI";
        string rootPhuTan1 = "/phutanhaiduong/LO NUNG CLINKER";
        string rootPhuTan2 = "/phutanhaiduong/LO GHI LANH";
        string rootTC1 = "/nmthanhcong1/LO NGHIEN XI";
        string rootGiayAH = "/nmgiayanhoa/KT_AnHoa1";
        string rootNhomCT = "/nhomchienthang/OngKhoiPhatThai";
        string rootNhomMD = "/nhomminhdung/OngKhoiPhatThai";
        string rootSabeco = "/sabecophulyhanam/SABECO";
        string rootAriyana = "/ariyanadanang/NUOC THAI";
        //Nguyet Minh 2 - can check tren ftp server So VP
        string rootNM2 = "/XU LY TAI CHE";

        string rootMinhTien = "/nmminhtien/MINH TIEN";
        string rootETC = "/vietmapenv/ETC";
        string rootVicemHV1 = "/ximangvicemhaivan/NghienXiDayChuyen1";
        string rootVicemHV2 = "/ximangvicemhaivan/NghienXiDayChuyen2";
        string rootSaiSon1 = "/nmnamson/lonung";
        string rootSaiSon2 = "/nmnamson/loghilanh";
        //TC3 --- Check tren server so TNMT HD

        string rootTC31 = "/ThanhCong3/LO NUNG CLINKER";
        string rootTC32 = "/ThanhCong3/GHI LANH";

        string rootTA1 = "/huyviet/HP_NMTA_KHIOK1";
        string rootTA2 = "/huyviet/HP_NMTA_KHIOK2";
        string rootTA3 = "/huyviet/HP_NMTA_KHIOK3";

        //Acecook check tren ftpserver so HY
        string rootAcecook1 = "/AcecookVN/nuocngam/G165";
        string rootAcecook2 = "/AcecookVN/nuocngam/G166";
        string rootAcecook3 = "/AcecookVN/nuocngam/G168";


        string rootVN1 = "/ximangvicemvanninh/NUNG CLINKER";
        string rootVN2 = "/ximangvicemvanninh/GHI LANH";
        string rootVN3 = "/ximangvicemvanninh/NGHIEN THAN";
        string rootVN4 = "/ximangvicemvanninh/NGHIEN XI";
        // ftpServer Ha Nam
        string rootHL1 = "/LoLungClinker";
        string rootHL2 = "/GhiLanh";
        string rootHL3 = "/NghienThan";
        string rootHL4 = "/NghienXi";

        string rootTS1 = "/ximangtrungson/LO NUNG";
        string rootTS2 = "/ximangtrungson/GHI LANH";
        string rootTS3 = "/ximangtrungson/NGHIEN THAN";
        string rootTS4 = "/ximangtrungson/NGHIEN XI";
        /// <summary>

        #endregion

        string _tailFileName;
        string _midFileName; //Fix for Da nang
        string tailDir;

        #region Pre Name file 
        string _preNameCuongThinh = "HD_XMCT_KHILNX_"; //Cuong thinh
        string _preNameMinhTuan = "HD_XMMT_KHILNX_";
        string _preNameDuyenLinh = "HD_XMDL_KHILNX_";
        string _preNamePhuTan1 = "HD_XMPT_KHIDD1_";
        string _preNamePhuTan2 = "HD_XMPT_KHIDD2_";
        string _preNameTC1 = "HD_NXTC_KHIDD1_";
        string _preNameGiayAH = "TQ_GIAH_KHILH1_";
        string _preNameNhomCT = "BN_NMCT_KHIDD1_";
        string _preNameNhomMD = "BN_NMMD_KHIDD1_";
        string _preNameSabeco = "HNa_SABE_NUOTNT_";
        string _preNameMinhTien = "BN_NMMT_KHITHA_";
        string _preNameETC = "ND_EETC_KHITHA_";
        //Nguyet Minh 2
        string _preNameNguyetMinh2 = "VP_NM02_KHIDD1_";

        //Da Nang have different format
        string _preNameAriyana = "NTCTTHIENTHAI_"; //  NTCTTHIENTHAI_20210814092500_NuocThai.txt
        string _endTailFileNameAriyana = "_NuocThai.txt";

        string _preNameVicemHV1 = "KTXMVICEMHAIVANDC1_";// KTXMVICEMHAIVANDC1_20210908221500_KhiThai.txt
        string _preNameVicemHV2 = "KTXMVICEMHAIVANDC2_";
        string _endTailFileNameHV = "_KhiThai.txt";


        //
        string _preNameSaiSon1 = "HN_XMSS_KHIDD1_";
        string _preNameSaiSon2 = "HN_XMSS_KHIDD2_";

        //TC3 --- Check tren server so TNMT HD
        string _preNameTC31 = "HD_XMTC_KHIDD1_";
        string _preNameTC32 = "HD_XMTC_KHIDD2_";

        //
        string _preNameTA1 = "HP_NMTA_KHIOK1_";
        string _preNameTA2 = "HP_NMTA_KHIOK2_";
        string _preNameTA3 = "HP_NMTA_KHIOK3_";

        //Acecook check tren ftpserver so HY
        string _preNameAce1 = "HY_ACOK_NUNTQ1_";
        string _preNameAce2 = "HY_ACOK_NUNTQ2_";
        string _preNameAce3 = "HY_ACOK_NUNTQ3_";

        string _preNameVN1 = "QB_XMVN_KHIDD1_";
        string _preNameVN2 = "QB_XMVN_KHIDD2_";
        string _preNameVN3 = "QB_XMVN_KHIDD3_";
        string _preNameVN4 = "QB_XMVN_KHIDD4_";

        //Check HL tren ftpServer HD
        string _preNameHL1 = "HNa_XMHL_KHIDD1_";
        string _preNameHL2 = "HNa_XMHL_KHIDD2_";
        string _preNameHL3 = "HNa_XMHL_KHIDD3_";
        string _preNameHL4 = "HNa_XMHL_KHIDD4_";

        string _preNameTS1 = "HB_XMTS_KHIDD1_";
        string _preNameTS2 = "HB_XMTS_KHIDD2_";
        string _preNameTS3 = "HB_XMTS_KHIDD3_";
        string _preNameTS4 = "HB_XMTS_KHIDD4_";

        #endregion






        //Tạo kết nối tới ftp server Vietmap Env
        ftp myFtp = new ftp(@"ftp://bdenv.vietmapenv.com", "ftpuser", "xxxxxxxxxxx");



        //// Acecook
        ftp ftpAce = new ftp(@"ftp://113.160.xxx.xx", "AcecookVN", "xxxxxxxx!");


        //////Tạo kết nối tới ftp server Hà Nam - XMHL
        //ftp myFtpHL = new ftp(@"ftp://113.160.199.xx", "xmhoanglong", "xxxxxxx");

        //////Tạo kết nối tới ftp server Vinh Phuc - NM2
        //ftp myFtpNM2 = new ftp(@"ftp://113.160.148.xx", "CTNM2", "xxxxxx");

        ////Tao ket noi toi ftp Server Hai Duong - TC3
        //ftp ftpTC3 = new ftp(@"ftp://113.160.129.xx", "xxxxxxxxx", "xxxxxxxxx");

        //Current number file on ftpServer

        int currentFile;
        int currentFileAcecook;


        public FormMain()
        {
            InitializeComponent();

            //
            this.FormBorderStyle = FormBorderStyle.None;
            //Để khi Minimizer, trở lại màn hình sẽ k bị fullScreen.
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //ScrollBar of Text Notifications: initial NONE
            txbNotify.ScrollBars = ScrollBars.None;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Load Avatar
            string[] path = new string[2];
            ReadWriteTxt _getAvatar = new ReadWriteTxt();
            try
            {
                path = _getAvatar.readFile(@"txtSetting\pathAvatar.txt");
                picAvatar.Image = new Bitmap(path[1]);
            }
            catch
            {
                //Load default picture
                picAvatar.Image = new Bitmap(@"txtSetting\avatar.png");

            }



            #region Load Station Form
            // Open Form Monitor
            Stations childForm = new Stations();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChildForm.Tag = childForm;
            this.panelChildForm.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            lbTitle.Text = childForm.Text;
            isStationForm = true; //Form is active
            // End Open Form Monitor
            //Notify button
            this.panelNotify.Enabled = false;
            this.panelNotify.Visible = false;
            #endregion

            #region TIMER SETTING
            //Clock 1s
            timer1.Enabled = true;
            timer1.Interval = 1000;
            //
            timer2.Enabled = true;
            timer2.Interval = 90000; //90s, check 90s/1lan, sau khi đã check và hiển thị tại timer1.
            //timer2.Interval = 60000; //Test



            //Time check and show first
            timer3.Enabled = true;
            timer3.Interval = 10000;
            timer3.Tick += Timer3_Tick;

            //Timer 4: Alarm Email
            timer4.Enabled = true;
            timer4.Interval = 1000;

            #endregion
            //Fisrt check all connection first time
            #region FIRST CHECK
            //Calculate the number of files at present.
            currentFile = DateTime.Now.Hour * 12 + DateTime.Now.Minute / 5; //(-1) tranh truong hop delay
            currentFileAcecook = DateTime.Now.Hour * 4 + DateTime.Now.Minute / 15;
            currentNoti = 0;
            // Tạo tail Name file:
            string yyyy = DateTime.Now.ToString("yyyy");
            string MM = DateTime.Now.ToString("MM");
            string dd = DateTime.Now.ToString("dd");
            string HH = DateTime.Now.ToString("HH");
            mm = ((currentFile - DateTime.Now.Hour * 12) * 5).ToString("00");
            _tailFileName = yyyy + MM + dd + HH + mm + "00" + ".txt";
            //Fix for Da Nang
            _midFileName = yyyy + MM + dd + HH + mm + "00_";
            //Tao tail dir
            tailDir = "/" + yyyy + "/" + MM + "/" + dd;
            //Check first time:

            Thread firstCheck = new Thread(() => { checkAll(); });
            firstCheck.Start();


            #endregion

        }
        //// Get notify first time!
        private void Timer3_Tick(object sender, EventArgs e)
        {
            // Get notify first time!
            //Interval 30s
            if (DateTime.Now.Minute % 5 != 0)
            {
                getNotify();

                //Update tong so tram ket not/ mat ket noi
                labelKhi.Text = Stations.TongKhi.ToString();
                labelNuoc.Text = Stations.TongNuoc.ToString();
                labelNuocNgam.Text = Stations.TongNuocNgam.ToString();
                //Notify
                // Show
                listNotiShow = listNoti.GetRange(0, listNoti.Count);
                listNotiShow.Reverse();
                txbNotify.Text = showList(listNotiShow);
                listNotiShow.Clear();



                //lbNotiCount.Text = (listNoti.Count - currentNoti - nKeNgang).ToString();// (-1) cho elememt kẻ ngang.
                lbNotiCount.Text = (listNoti.Count - nKeNgang).ToString();// (-1) cho elememt kẻ ngang.

                if ((listNoti.Count) > 0)
                {
                    btnNotify.BackColor = Color.FromArgb(245, 71, 43);
                    lbNotiCount.Visible = true;
                }
                else
                {
                    btnNotify.BackColor = Color.FromArgb(249, 249, 249);
                    lbNotiCount.Visible = false;
                }
            }
            //Disable
            timer3.Enabled = false;
        }



        #region FORM CONTROL
        private void OpenChildFrom(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            //ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelChildForm.Tag = childForm;
            this.panelChildForm.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            lbTitle.Text = childForm.Text;
        }



        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCloseForm_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnCloseForm.BackColor = Color.FromArgb(255, 0, 0);
        }

        private void btnCloseForm_MouseLeave(object sender, EventArgs e)
        {
            this.btnCloseForm.BackColor = Color.FromArgb(249, 249, 249);

        }

        private void btnMinimize_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnMinimize.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.btnMinimize.BackColor = Color.FromArgb(249, 249, 249);

        }
        //Button Monitor / Alarm
        private void btnMonitor_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnMonitor.BackColor = Color.FromArgb(132, 194, 105);
        }

        private void btnMonitor_MouseLeave(object sender, EventArgs e)
        {
            this.btnMonitor.BackColor = Color.FromArgb(249, 249, 249);
        }

        private void btnAlarm_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnAlarm.BackColor = Color.FromArgb(132, 194, 105);
        }

        private void btnAlarm_MouseLeave(object sender, EventArgs e)
        {
            this.btnAlarm.BackColor = Color.FromArgb(249, 249, 249);
        }
        private void btnMonitor_Click(object sender, EventArgs e)
        {
            if (isStationForm != true)
            {
                OpenChildFrom(new Stations(), sender);
                isStationForm = true;
                isAlarmForm = false;
            }
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            if (isAlarmForm != true)
            {
                OpenChildFrom(new AlarmForm(), sender);
                isAlarmForm = true;
                isStationForm = false;
            }
        }
        // End Button Monitor /Alarm

        //Button Notify

        bool isHoldNotify = false;

        private void btnNotify_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnNotify.BackColor = Color.FromArgb(10, 184, 212);
            this.panelNotify.Enabled = true;
            this.panelNotify.Visible = true;
            //this.txbNotify.Enabled = false;
            //isHoldNotify = false;



        }
        private void btnNotify_MouseLeave(object sender, EventArgs e)
        {
            if (isHoldNotify == false)
            {
                this.btnNotify.BackColor = Color.FromArgb(249, 249, 249);
                this.panelNotify.Enabled = false;
                this.panelNotify.Visible = false;
                //this.txbNotify.Enabled = false;

            }
        }

        //Tính toán số lượng thông báo
        int currentNoti;

        private void btnNotify_Click(object sender, EventArgs e)
        {
            isHoldNotify = !isHoldNotify;

            switch (isHoldNotify)
            {
                case true:
                    //this.panelNotify.Enabled = true;
                    this.panelNotify.Visible = true;
                    this.panelNotify.Enabled = true;

                    this.txbNotify.Enabled = isHoldNotify;

                    currentNoti = listNoti.Count;
                    lbNotiCount.Visible = true;

                    //Enable ScrollBar
                    if (listNoti.Count >= 35)
                    {
                        txbNotify.ScrollBars = ScrollBars.Vertical;
                    }
                    else
                    {
                        txbNotify.ScrollBars = ScrollBars.None;
                    }
                    break;
                case false:
                    txbNotify.ScrollBars = ScrollBars.None;
                    break;
            }






        }
        private void btnClearNoti_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnClearNoti.BackColor = Color.FromArgb(245, 71, 43);
        }

        private void btnClearNoti_MouseLeave(object sender, EventArgs e)
        {
            this.btnClearNoti.BackColor = Color.FromArgb(10, 184, 212);
        }

        private void btnClearNoti_Click(object sender, EventArgs e)
        {
            listNoti.Clear();
            txbNotify.Text = "";
            nKeNgang = 0;
        }


        #endregion



        #region Check connection for whole stations

        string mm = ""; //Lấy số phút mang tới thông báo


        private bool checkConnection(string preFileName, string fullDir, ftp _ftp)
        {
            string fileName = preFileName + _tailFileName; //Format .txt

            bool isChecked;

            int nFile = _ftp.listFileName(fullDir).Count;
            if (nFile >= currentFile)
            {
                isChecked = true; //So file trong folder >= so file can co
            }
            else
            {
                isChecked = _ftp.listFileName(fullDir).Contains(fileName);
            }
            return isChecked;

        }


        private bool checkFolder(string rootDir, ftp _ftp)
        {
            bool isCheckFolder;
            //Check month in year
            string _month = DateTime.Now.ToString("MM");
            string _day = DateTime.Now.ToString("dd");

            string dir = rootDir + "/" + DateTime.Now.ToString("yyyy");

            if (_ftp.listFileName(dir).Contains(_month))
            {
                //Check day in Month
                string dirMonth = dir + "/" + _month;
                if (_ftp.listFileName(dirMonth).Contains(_day))
                {
                    isCheckFolder = true;
                }
                else
                {
                    isCheckFolder = false;
                }
            }
            else
            {
                isCheckFolder = false;
            }
            return isCheckFolder;
        }
        private bool supportCheckAll(string _rootDir, string _preFileName, ftp _ftp)
        {
            string fullDir = _rootDir + tailDir;
            bool isChecked;
            try
            {
                if (checkFolder(_rootDir, _ftp))
                {
                    isChecked = checkConnection(_preFileName, fullDir, _ftp);
                }
                else
                {
                    isChecked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at: " + _rootDir + "|" + _preFileName + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isChecked = false;
            }
            return isChecked;

        }


        //Tao thread
        //private delegate void dlgCheckAll();

        public void checkAll()
        {
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new dlgCheckAll(checkAll));
            //}
            //else
            //{
            //Cuong Thinh:
            isCheckedCuongThinh = supportCheckAll(rootCuongThinh, _preNameCuongThinh, myFtp);
            //Duyen Linh
            isCheckedDuyenLinh = supportCheckAll(rootDuyenLinh, _preNameDuyenLinh, myFtp);
            //Minh Tuan:
            isCheckedMinhTuan = supportCheckAll(rootMinhTuan, _preNameMinhTuan, myFtp);
            //Phu Tan
            isCheckedPhuTan1 = supportCheckAll(rootPhuTan1, _preNamePhuTan1, myFtp);
            isCheckedPhuTan2 = supportCheckAll(rootPhuTan2, _preNamePhuTan2, myFtp);
            //Thanh cong 1
            isCheckedTC1 = supportCheckAll(rootTC1, _preNameTC1, myFtp);
            //Giay An Hoa
            isCheckedGiayAH = supportCheckAll(rootGiayAH, _preNameGiayAH, myFtp);
            //Nhom Chien thang
            isCheckedNhomCT = supportCheckAll(rootNhomCT, _preNameNhomCT, myFtp);
            //Nhom Minh Dung
            isCheckedNhomMD = supportCheckAll(rootNhomMD, _preNameNhomMD, myFtp);
            //Sabeco
            isCheckedSabeco = supportCheckAll(rootSabeco, _preNameSabeco, myFtp);

            //Minh Tien
            isCheckedMinhTien = supportCheckAll(rootMinhTien, _preNameMinhTien, myFtp);
            //ETC Nam Dinh
            isCheckedETC = supportCheckAll(rootETC, _preNameETC, myFtp);
            //Ariyana
            isCheckedAriyana = supportCheckDaNang(rootAriyana, _preNameAriyana, _endTailFileNameAriyana, myFtp);
            //Vicem Hai Van
            isCheckedVicemHV1 = supportCheckDaNang(rootVicemHV1, _preNameVicemHV1, _endTailFileNameHV, myFtp);
            isCheckedVicemHV2 = supportCheckDaNang(rootVicemHV2, _preNameVicemHV2, _endTailFileNameHV, myFtp);

            //XM Sai Son:
            isCheckedSaiSon1 = supportCheckAll(rootSaiSon1, _preNameSaiSon1, myFtp);
            isCheckedSaiSon2 = supportCheckAll(rootSaiSon2, _preNameSaiSon2, myFtp);

            //Thuy Anh
            isCheckedTA1 = supportCheckAll(rootTA1, _preNameTA1, myFtp);
            isCheckedTA2 = supportCheckAll(rootTA2, _preNameTA2, myFtp);
            isCheckedTA3 = supportCheckAll(rootTA3, _preNameTA3, myFtp);

            //Van Ninh
            isCheckedVN1 = supportCheckAll(rootVN1, _preNameVN1, myFtp);
            isCheckedVN2 = supportCheckAll(rootVN2, _preNameVN2, myFtp);
            isCheckedVN3 = supportCheckAll(rootVN3, _preNameVN3, myFtp);
            isCheckedVN4 = supportCheckAll(rootVN4, _preNameVN4, myFtp);



            //XM TRUNG SON
            isCheckedTS1 = supportCheckAll(rootTS1, _preNameTS1, myFtp);
            isCheckedTS2 = supportCheckAll(rootTS2, _preNameTS2, myFtp);
            isCheckedTS3 = supportCheckAll(rootTS3, _preNameTS3, myFtp);
            isCheckedTS4 = supportCheckAll(rootTS4, _preNameTS4, myFtp);

            checkAcecook();
            //checkHL();

            ////Nguyet Minh 2
            //isCheckedNguyetMinh2 = supportCheckAll(rootNM2, _preNameNguyetMinh2, myFtpNM2);

            //////Thanh Cong 3
            ////isCheckedTC31 = supportCheckAll(rootTC31, _preNameTC31, ftpTC3);
            ////isCheckedTC32 = supportCheckAll(rootTC32, _preNameTC32, ftpTC3);




            ////Acecook
            //isCheckedAcecook1 = supportCheckAll(rootAcecook1, _preNameAce1, ftpAce);
            //isCheckedAcecook2 = supportCheckAll(rootAcecook2, _preNameAce2, ftpAce);
            //isCheckedAcecook3 = supportCheckAll(rootAcecook3, _preNameAce3, ftpAce);



            ////XM HOANG LONG
            //isCheckedHL1 = supportCheckAll(rootHL1, _preNameHL1, myFtpHL);
            //isCheckedHL2 = supportCheckAll(rootHL2, _preNameHL2, myFtpHL);
            //isCheckedHL3 = supportCheckAll(rootHL3, _preNameHL3, myFtpHL);
            //isCheckedHL4 = supportCheckAll(rootHL4, _preNameHL4, myFtpHL);

            //checkNM2();
            //checkTC3();
            //checkHL();

        }

        //Fix for Checking Da Nang

        private bool supportCheckDaNang(string _rootDir, string _preFileName, string _endTailFileName, ftp _ftp)
        {
            string fullDir = _rootDir + tailDir;
            bool isChecked;

            try
            {
                if (checkFolder(_rootDir, _ftp))
                {
                    isChecked = supportCheckConnectDaNang(_preFileName, _endTailFileName, fullDir, _ftp);
                }
                else
                {
                    isChecked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at: " + _rootDir + "|" + _preFileName + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isChecked = false;
            }
            return isChecked;

        }
        private bool supportCheckConnectDaNang(string _preFileName, string _endTailFileName, string fullDir, ftp _ftp)
        {
            string fileName = _preFileName + _midFileName + _endTailFileName; //Format: KTXMVICEMHAIVANDC1_20210908221500_KhiThai.txt

            bool isChecked;

            int nFile = _ftp.listFileName(fullDir).Count;
            if (nFile >= currentFile)
            {
                isChecked = true; //So file trong folder >= so file can co
            }
            else
            {
                isChecked = _ftp.listFileName(fullDir).Contains(fileName);
            }
            return isChecked;
        }

        ////Checking FTP Server Hung Yen
        private void checkAcecook()
        {
            //Acecook
            if (int.Parse(mm) % 15 == 0)
            {
                isCheckedAcecook1 = supportCheckAcecook(rootAcecook1, _preNameAce1, ftpAce);
                isCheckedAcecook1 = supportCheckAcecook(rootAcecook2, _preNameAce2, ftpAce);
                isCheckedAcecook1 = supportCheckAcecook(rootAcecook3, _preNameAce3, ftpAce);
            }

        }
        private bool checkConnectionAcecook(string preFileName, string fullDir, ftp _ftp)
        {
            string fileName = preFileName + _tailFileName; //Format .txt

            bool isChecked;

            int nFile = _ftp.listFileName(fullDir).Count;
            if (nFile >= currentFileAcecook)
            {
                isChecked = true; //So file trong folder >= so file can co
            }
            else
            {
                isChecked = _ftp.listFileName(fullDir).Contains(fileName);
            }
            return isChecked;

        }


        private bool supportCheckAcecook(string _rootDir, string _preFileName, ftp _ftp)
        {
            string fullDir = _rootDir + tailDir;
            bool isChecked;
            try
            {
                if (checkFolder(_rootDir, _ftp))
                {
                    isChecked = checkConnectionAcecook(_preFileName, fullDir, _ftp);
                }
                else
                {
                    isChecked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error at: " + _rootDir + "|" + _preFileName + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isChecked = false;
            }
            return isChecked;

        }


        ////Check FTP Ha nam Hoang Long
        private void checkHL()
        {
            ftp myFtpHL = new ftp(@"ftp://113.160.199.xx", "xmhoanglong", "xxxxxxxxx");
            //XM HOANG LONG
            isCheckedHL1 = supportCheckAll(rootHL1, _preNameHL1, myFtpHL);
            isCheckedHL2 = supportCheckAll(rootHL2, _preNameHL2, myFtpHL);
            isCheckedHL3 = supportCheckAll(rootHL3, _preNameHL3, myFtpHL);
            isCheckedHL4 = supportCheckAll(rootHL4, _preNameHL4, myFtpHL);
        }




        #endregion

        #region NOTIFY and CHECK ALL

        //Clock 1s || Check file here
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute % 5 == 0 && DateTime.Now.Second == 10)
            {
                if (timer2.Enabled)
                {
                    timer2.Enabled = false;
                }
                //Calculate the number of files at present.
                currentFile = DateTime.Now.Hour * 12 + DateTime.Now.Minute / 5; //(-1) tranh truong hop delay

                // Tạo tail Name file:
                string yyyy = DateTime.Now.ToString("yyyy");
                string MM = DateTime.Now.ToString("MM");
                string dd = DateTime.Now.ToString("dd");
                string HH = DateTime.Now.ToString("HH");
                mm = ((currentFile - DateTime.Now.Hour * 12) * 5).ToString("00");
                _tailFileName = yyyy + MM + dd + HH + mm + "00" + ".txt";
                //Fix for Da Nang
                _midFileName = yyyy + MM + dd + HH + mm + "00_";

                //Tao tail dir
                tailDir = "/" + yyyy + "/" + MM + "/" + dd;


                //CHECK ALL CONNECTION!!!!!!!!!
                Thread tCheckAll = new Thread(() => { checkAll(); });
                tCheckAll.Start();
            }


            if (DateTime.Now.Minute % 5 == 0 && DateTime.Now.Second == 45)
            {
                getNotify();
                timer2.Enabled = true;

            }
            Thread tSecond = new Thread(() => { runShow(); });
            tSecond.Start();


        }
        //Every 90s
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Calculate the number of files at present.
            currentFile = DateTime.Now.Hour * 12 + DateTime.Now.Minute / 5; //(-1) tranh truong hop delay

            // Tạo tail Name file:
            string yyyy = DateTime.Now.ToString("yyyy");
            string MM = DateTime.Now.ToString("MM");
            string dd = DateTime.Now.ToString("dd");
            string HH = DateTime.Now.ToString("HH");
            mm = ((currentFile - DateTime.Now.Hour * 12) * 5).ToString("00");
            _tailFileName = yyyy + MM + dd + HH + mm + "00" + ".txt";
            //Fix for Da Nang
            _midFileName = yyyy + MM + dd + HH + mm + "00_";

            //Tao tail dir
            tailDir = "/" + yyyy + "/" + MM + "/" + dd;


            //CHECK ALL CONNECTION!!!!!!!!!
            Thread tCheckAll = new Thread(() => { checkAll(); });
            tCheckAll.Start();

        }
        public delegate void dlgRunShow();
        public void runShow()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new dlgRunShow(runShow));
            }
            else
            {
                lbClock.Text = DateTime.Now.ToString("dd-MM-yyyy  HH:mm:ss");
                //Update tong so tram ket not/ mat ket noi
                labelKhi.Text = Stations.TongKhi.ToString();
                labelNuoc.Text = Stations.TongNuoc.ToString();
                labelNuocNgam.Text = Stations.TongNuocNgam.ToString();


                //Notify
                // Show
                listNotiShow = listNoti.GetRange(0, listNoti.Count);
                listNotiShow.Reverse();
                txbNotify.Text = showList(listNotiShow);
                listNotiShow.Clear();

                //lbNotiCount.Text = (listNoti.Count - currentNoti - nKeNgang).ToString();// (-1) cho elememt kẻ ngang.
                lbNotiCount.Text = (listNoti.Count - nKeNgang).ToString();// (-nKeNgang) cho elememt kẻ ngang.

                if ((listNoti.Count) > 0)
                {
                    btnNotify.BackColor = Color.FromArgb(245, 71, 43);
                    lbNotiCount.Visible = true;
                }
                else
                {
                    btnNotify.BackColor = Color.FromArgb(249, 249, 249);
                    lbNotiCount.Visible = false;
                }
            }

        }
        List<string> listNoti = new List<string>();

        private void txbNotyfiyShow(bool isChecked, string nameStation, List<string> _list)
        {
            if (isChecked != true)
            {
                _list.Add(DateTime.Now.ToString("dd-MM-yyyy HH:") + mm + " | " + nameStation + " mất tín hiệu!" + "\r\n");
                //_listContentsEmail.Add(DateTime.Now.ToString("dd-MM-yyyy HH:") + mm + " | " + nameStation + " mất tín hiệu!" + "\r\n");
            }
        }
        List<string> listNotiShow = new List<string>();


        //cHECK NOTIFY
        private void getNotify()
        {
            // Cuong Thinh
            txbNotyfiyShow(isCheckedCuongThinh, "XM Cường Thịnh", listNoti);

            //Duyen Linh
            txbNotyfiyShow(isCheckedDuyenLinh, "XM Duyên Linh", listNoti);

            //Minh Tuan:
            txbNotyfiyShow(isCheckedMinhTuan, "XM Minh Tuấn", listNoti);

            //Phu Tan
            txbNotyfiyShow(isCheckedPhuTan1, "XM Phú Tân - Lò Nung", listNoti);
            txbNotyfiyShow(isCheckedPhuTan2, "XM Phú Tân - Ghi Lạnh", listNoti);

            //Thanh cong 1
            txbNotyfiyShow(isCheckedTC1, "XM Thành Công 1", listNoti);
            //Giay An Hoa
            txbNotyfiyShow(isCheckedGiayAH, "Giấy An Hòa", listNoti);

            //Nhom Chien thang
            txbNotyfiyShow(isCheckedNhomCT, "Nhôm Chiến Thắng", listNoti);

            //Nhom Minh Dung
            txbNotyfiyShow(isCheckedNhomMD, "Nhôm Minh Dũng", listNoti);

            //Sabeco
            txbNotyfiyShow(isCheckedSabeco, "Sabeco", listNoti);

            ////Nguyet Minh 2
            //txbNotyfiyShow(isCheckedNguyetMinh2, "Nguyet Minh 2", listNoti);

            //Minh Tien
            txbNotyfiyShow(isCheckedMinhTien, "Minh Tiến", listNoti);

            //ETC Nam Dinh
            txbNotyfiyShow(isCheckedETC, "ETC Nam Định", listNoti);

            //Ariyana
            txbNotyfiyShow(isCheckedAriyana, "Ariyana", listNoti);

            //Vicem Hai Van
            txbNotyfiyShow(isCheckedVicemHV1, "Vicem HV - DC1", listNoti);
            txbNotyfiyShow(isCheckedVicemHV2, "Vicem HV - DC2", listNoti);



            //XM Sai Son:
            txbNotyfiyShow(isCheckedSaiSon1, "XM Sài Sơn - Lò Nung", listNoti);
            txbNotyfiyShow(isCheckedSaiSon2, "XM Sài Sơn - Ghi Lạnh", listNoti);


            ////Thanh Cong 3
            //txbNotyfiyShow(isCheckedTC31, "XM Thành Công 3 - Lò Nung", listNoti);
            //txbNotyfiyShow(isCheckedTC32, "XM Thành Công 3 - Lò Ghi Lạnh", listNoti);

            //Thuy Anh
            txbNotyfiyShow(isCheckedTA1, "Thủy Anh - OK1", listNoti);
            txbNotyfiyShow(isCheckedTA2, "Thủy Anh - OK2", listNoti);
            txbNotyfiyShow(isCheckedTA3, "Thủy Anh - OK3", listNoti);

            //Acecook
            txbNotyfiyShow(isCheckedAcecook1, "Acecook HY - G165", listNoti);
            txbNotyfiyShow(isCheckedAcecook2, "Acecook HY - G166", listNoti);
            txbNotyfiyShow(isCheckedAcecook3, "Acecook HY - G168", listNoti);


            //Van Ninh
            txbNotyfiyShow(isCheckedVN1, "Vạn Ninh - Nung", listNoti);
            txbNotyfiyShow(isCheckedVN2, "Vạn Ninh - Ghi Lạnh", listNoti);
            txbNotyfiyShow(isCheckedVN3, "Vạn Ninh - Nghiền Than", listNoti);
            txbNotyfiyShow(isCheckedVN4, "Vạn Ninh - Nghiền Xi", listNoti);

            //XM HOANG LONG
            //bool isHL = FormMain.isCheckedHL1 && FormMain.isCheckedHL2 && FormMain.isCheckedHL3 && FormMain.isCheckedHL4;
            ////runCheck(isHL, panelHL);
            //txbNotyfiyShow(isCheckedHL1, "XM Hoàng Long - Nung Clinker", listNoti);
            //txbNotyfiyShow(isCheckedHL2, "XM Hoàng Long - Ghi Lạnh", listNoti);
            //txbNotyfiyShow(isCheckedHL3, "XM Hoàng Long - Nghiền Than", listNoti);
            //txbNotyfiyShow(isCheckedHL4, "XM Hoàng Long - Nghiền Xi", listNoti);

            //XM TRUNG SON
            txbNotyfiyShow(isCheckedTS1, "XM Trung Sơn - Nung", listNoti);
            txbNotyfiyShow(isCheckedTS2, "XM Trung Sơn - Ghi Lạnh", listNoti);
            txbNotyfiyShow(isCheckedTS3, "XM Trung Sơn - Nghiền Than", listNoti);
            txbNotyfiyShow(isCheckedTS4, "XM Trung Sơn - Nghiền Xi", listNoti);
            //
            listNoti.Add("\r\n ---------------------------------------------------------------- \r\n");
            nKeNgang += 1;
            //Thêm gạch này thì phải trừ đi khi tính số lượng thông báo!
        }

        private string showList(List<string> listStr)
        {
            string text = string.Empty;
            foreach (string element in listStr)
            {
                text += element.ToString();
            }
            return text;
        }
        #endregion


        #region Email Alarm

        string userEmail1 = "";
        string userEmail2 = "";
        string userEmail3 = "";
        bool enable1;
        bool enable2;
        bool enable3;
        int iFreq;
        string Freq;
        private void timer4_Tick(object sender, EventArgs e)
        {


            string fromUser = "vietmapenv.alarm@gmail.com";
            string fromPass = "huyviet123";
            string toUser1 = userEmail1;
            string toUser2 = userEmail2;
            string toUser3 = userEmail3;

            email email1 = new email(fromUser, fromPass, toUser1);
            email email2 = new email(fromUser, fromPass, toUser2);
            email email3 = new email(fromUser, fromPass, toUser3);
            string emailContents = "";
            //Get setting
            getSetting();

            if (DateTime.Now.Minute % 2 == 0 && DateTime.Now.Second == 0)
            {
                getNotifyToEmail();
                emailContents = showList(listNotiAlarm);

                if (enable1)
                {
                    email1.sendMessage(emailContents);
                }
                if (enable2)
                {
                    email1.sendMessage(emailContents);
                }
                if (enable3)
                {
                    email1.sendMessage(emailContents);
                }

                listNotiAlarm.Clear();

            }



        }
        private void getSetting()
        {
            string[] preSetting = new string[12];
            ReadWriteTxt _getFile = new ReadWriteTxt();
            preSetting = _getFile.readFile(@"txtSetting\appSetting.txt");

            //Email
            userEmail1 = preSetting[1];
            userEmail2 = preSetting[2];
            userEmail3 = preSetting[3];

            //Enable

            enable1 = Convert.ToBoolean(preSetting[5]);
            enable2 = Convert.ToBoolean(preSetting[6]);
            enable3 = Convert.ToBoolean(preSetting[7]);

            //Freq
            Freq = preSetting[9];
            try
            {
                iFreq = int.Parse(Freq);
            }
            catch
            {
                iFreq = 60;// Dont send email
            }


        }

        public List<string> listNotiAlarm = new List<string>();

        private void getNotifyToEmail()
        {
            // Cuong Thinh
            txbNotyfiyShow(isCheckedCuongThinh, "XM Cường Thịnh", listNotiAlarm);

            //Duyen Linh
            txbNotyfiyShow(isCheckedDuyenLinh, "XM Duyên Linh", listNotiAlarm);

            //Minh Tuan:
            txbNotyfiyShow(isCheckedMinhTuan, "XM Minh Tuấn", listNotiAlarm);

            //Phu Tan
            txbNotyfiyShow(isCheckedPhuTan1, "XM Phú Tân - Lò Nung", listNotiAlarm);
            txbNotyfiyShow(isCheckedPhuTan2, "XM Phú Tân - Ghi Lạnh", listNotiAlarm);

            //Thanh cong 1
            txbNotyfiyShow(isCheckedTC1, "XM Thành Công 1", listNotiAlarm);
            //Giay An Hoa
            txbNotyfiyShow(isCheckedGiayAH, "Giấy An Hòa", listNotiAlarm);

            //Nhom Chien thang
            txbNotyfiyShow(isCheckedNhomCT, "Nhôm Chiến Thắng", listNotiAlarm);

            //Nhom Minh Dung
            txbNotyfiyShow(isCheckedNhomMD, "Nhôm Minh Dũng", listNotiAlarm);

            //Sabeco
            txbNotyfiyShow(isCheckedSabeco, "Sabeco", listNotiAlarm);

            ////Nguyet Minh 2
            //runCheck(FormMain.isCheckedNguyetMinh2, panelNguyetMinh2);
            //Minh Tien
            txbNotyfiyShow(isCheckedMinhTien, "Minh Tiến", listNotiAlarm);

            //ETC Nam Dinh
            txbNotyfiyShow(isCheckedETC, "ETC Nam Định", listNotiAlarm);

            //Ariyana
            txbNotyfiyShow(isCheckedAriyana, "Ariyana", listNotiAlarm);

            //Vicem Hai Van
            txbNotyfiyShow(isCheckedVicemHV1, "Vicem HV - DC1", listNotiAlarm);
            txbNotyfiyShow(isCheckedVicemHV2, "Vicem HV - DC2", listNotiAlarm);



            //XM Sai Son:
            txbNotyfiyShow(isCheckedSaiSon1, "XM Sài Sơn - Lò Nung", listNotiAlarm);
            txbNotyfiyShow(isCheckedSaiSon2, "XM Sài Sơn - Ghi Lạnh", listNotiAlarm);


            //Thanh Cong 3
            //bool isTC3 = FormMain.isCheckedTC31 && FormMain.isCheckedTC32;
            //runCheck(isTC3, panelTC3);
            txbNotyfiyShow(isCheckedTC31, "XM Thành Công 3 - Lò Nung", listNotiAlarm);
            txbNotyfiyShow(isCheckedTC32, "XM Thành Công 3 - Lò Ghi Lạnh", listNotiAlarm);

            //Thuy Anh
            txbNotyfiyShow(isCheckedTA1, "Thủy Anh - OK1", listNotiAlarm);
            txbNotyfiyShow(isCheckedTA2, "Thủy Anh - OK2", listNotiAlarm);
            txbNotyfiyShow(isCheckedTA3, "Thủy Anh - OK3", listNotiAlarm);

            // Acecook
            txbNotyfiyShow(isCheckedAcecook1, "Acecook - Giếng 1", listNotiAlarm);
            txbNotyfiyShow(isCheckedAcecook2, "Acecook - Giếng 2", listNotiAlarm);
            txbNotyfiyShow(isCheckedAcecook3, "Acecook - Giếng 3", listNotiAlarm);

            //Van Ninh
            txbNotyfiyShow(isCheckedVN1, "Vạn Ninh - Nung", listNotiAlarm);
            txbNotyfiyShow(isCheckedVN2, "Vạn Ninh - Ghi Lạnh", listNotiAlarm);
            txbNotyfiyShow(isCheckedVN3, "Vạn Ninh - Nghiền Than", listNotiAlarm);
            txbNotyfiyShow(isCheckedVN4, "Vạn Ninh - Nghiền Xi", listNotiAlarm);

            //XM HOANG LONG
            //bool isHL = FormMain.isCheckedHL1 && FormMain.isCheckedHL2 && FormMain.isCheckedHL3 && FormMain.isCheckedHL4;
            //runCheck(isHL, panelHL);
            txbNotyfiyShow(isCheckedHL1, "XM Hoàng Long - Nung", listNotiAlarm);
            txbNotyfiyShow(isCheckedHL2, "XM Hoàng Long - Ghi Lạnh", listNotiAlarm);
            txbNotyfiyShow(isCheckedHL3, "XM Hoàng Long - Nghiền Than", listNotiAlarm);
            txbNotyfiyShow(isCheckedHL4, "XM Hoàng Long - Nghiền Xi", listNotiAlarm);


            //XM TRUNG SON
            txbNotyfiyShow(isCheckedTS1, "XM Trung Sơn - Nung", listNotiAlarm);
            txbNotyfiyShow(isCheckedTS2, "XM Trung Sơn - Ghi Lạnh", listNotiAlarm);
            txbNotyfiyShow(isCheckedTS3, "XM Trung Sơn - Nghiền Than", listNotiAlarm);
            txbNotyfiyShow(isCheckedTS4, "XM Trung Sơn - Nghiền Xi", listNotiAlarm);
            //


            //listNoti.Add("\r\n ---------------------------------------------------------------- \r\n");
            //nKeNgang += 1;
            ////Thêm gạch này thì phải trừ đi khi tính số lượng thông báo!
        }






        #endregion

        #region Change Avatar
        // open file dialog   
        private void changeAvatar_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                picAvatar.Image = new Bitmap(open.FileName);
                string[] pathAvatar = { "path:", open.FileName };
                ReadWriteTxt _writeFile = new ReadWriteTxt();
                _writeFile.writeFile(@"txtSetting\pathAvatar.txt", pathAvatar);

            }



        }

        private void changeAvatar_MouseMove(object sender, MouseEventArgs e)
        {
            this.changeAvatar.BackColor = Color.FromArgb(229, 76, 60);
        }

        private void changeAvatar_MouseLeave(object sender, EventArgs e)
        {
            this.changeAvatar.BackColor = Color.FromArgb(139, 194, 64);

        }
        #endregion


    }
}

